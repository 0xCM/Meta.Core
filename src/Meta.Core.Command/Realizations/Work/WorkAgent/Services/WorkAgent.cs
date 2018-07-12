//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Concurrent;

    using static metacore;
    using static WorkAgentMessages;


    public class WorkAgent<W> : WorkAgent, IWorkAgent<W> where W : IPartitionedWork
    {


        public WorkAgent(IWorkAgentConfiguration<W> AgentConfiguration)
            : base(AgentConfiguration)
        {
            this.AgentConfiguration = AgentConfiguration;
            iter(AgentConfiguration.DefaultSuppliers, source
                => WorkSuppliers.TryAdd(source.PartitionName, source));
        }

        readonly new IWorkAgentConfiguration<W> AgentConfiguration;

        Action<W> ConfiguredWorker
            => AgentConfiguration.DefaultWorker;

        IReadOnlyList<IWorkAgentObserver<W>> ConfiguredObservers
            => AgentConfiguration.DefaultObservers;

        protected override IEnumerable<WorkPartition> SubmitNext()
            => SubmitNext(w => ConfiguredWorker((W)w), ConfiguredObservers);


        /// <summary>
        /// Enqueues a unit of work
        /// </summary>
        /// <param name="work">The work to be performed</param>
        /// <param name="worker">The handler that will be invoked to perform the work</param>
        /// <param name="observers">A listener for which appropriate actions will be invoked during
        /// execution</param>
        /// <returns></returns>
        public WorkPartition<W> Submit(W work, Action<W> worker, IReadOnlyList<IWorkAgentObserver<W>> observers)
            => (WorkPartition<W>)base.Submit(work, w => worker((W)w), observers);

        public new IEnumerable<WorkPartition<W>> ExecuteQueue()
            => base.ExecuteQueue().Cast<WorkPartition<W>>();

        public void Submit(IReadOnlyList<W> work, Action<W> worker = null, IReadOnlyList<IWorkAgentObserver<W>> observers = null)
            => map(work, w => Submit(w, worker, observers));
    }


    public class WorkAgent<W, R> : WorkAgent<W>, IWorkAgent<W, R>
        where W : IPartitionedWork
    {

        readonly new ConcurrentDictionary<string, IWorkSupplier<W>> WorkSuppliers
            = new ConcurrentDictionary<string, IWorkSupplier<W>>();

        readonly new WorkAgentConfiguration<W, R> AgentConfiguration;

        Func<W, R> ConfiguredWorker
            => AgentConfiguration.DefaultWorker;

        IReadOnlyList<IWorkAgentObserver<W, R>> ConfiguredObservers
            => AgentConfiguration.DefaultObservers;

        IReadOnlyList<IWorkSupplier<W>> ConfiguredSuppliers
            => AgentConfiguration.DefaultSuppliers;

        public WorkAgent(WorkAgentConfiguration<W, R> AgentConfiguration)
            : base(AgentConfiguration)
        {
            this.AgentConfiguration = AgentConfiguration;
            iter(AgentConfiguration.DefaultSuppliers, source
                => WorkSuppliers.TryAdd(source.PartitionName, source));
        }


        IEnumerable<WorkPartition<W, R>> DoSubmitNext()
            => DoSubmitNext(ConfiguredWorker, ConfiguredObservers);


        protected override void Spin()
        {
            var MaxSpinnerCount = 5;
            try
            {
                while (!IsAgentCancelling)
                {
                    var submissions =  MutableList.Create<WorkPartition<W, R>>();
                    if (Spinners.Count < MaxSpinnerCount)
                    {
                        submissions.AddRange(DoSubmitNext());
                        if (HasPendingTasks)
                        {
                            iter(ExecuteQueue(), task => { });
                            if (!DiagnosticMode)
                                SpinUpSpinner();
                        }
                    }
                    CompleteRevolution(submissions.Count);
                }

            }
            catch (Exception e)
            {
                Notify(AppMessage.Error(e));
            }

        }

        Task<ReadOnlyList<WorkPartition<W, R>>> DoSubmitGroup(IReadOnlyList<W> work,
            Func<W, R> worker, string groupName, IReadOnlyList<IWorkAgentObserver<W, R>> observers)
        {
            return Task.Factory.StartNew(() =>
            {
                var tasks = work.Map(w => DoSubmit(w, worker, observers));
                try
                {
                    ExecutingGroups.Add(groupName);

                    iter(observers, observer
                        => observer.RaiseGroupSubmitted(groupName));
                    tasks.WaitOn(ChildCancellation.Token);

                    if (ExecutingGroups.Remove(groupName))
                        iter(observers, observer
                            => observer.RaiseGroupCompleted(groupName));

                }
                catch (OperationCanceledException)
                {
                    Notify(TaskGroupExecutionCancelled(groupName));
                }
                catch (Exception e)
                {
                    Notify(AppMessage.Error(e));
                }
                return tasks;
            });
        }

        protected IEnumerable<WorkPartition<W, R>> DoSubmitNext(Func<W, R> worker, IReadOnlyList<IWorkAgentObserver<W, R>> observers)
        {
            foreach (var partition in WorkSuppliers.Keys)
            {
                var count = CountOpenSlots(partition);
                if (count != 0)
                {
                    var supplier = WorkSuppliers[partition];
                    foreach (var work in supplier.Next(count))
                    {
                        yield return DoSubmit(work, worker, observers);
                    }
                }
            }
        }


        IEnumerable<Task<ReadOnlyList<WorkPartition<W, R>>>> DoSubmit(IReadOnlyList<W> work, Func<W, R> worker, IReadOnlyList<IWorkAgentObserver<W, R>> observers)
        {
            var groupTasks = map(work.GroupBy(w => w.GroupName), workGroup
                => (workGroup.Key, DoSubmitGroup(workGroup.ToList(), worker, workGroup.Key, observers)));
            return groupTasks.Select(x => x.Item2);
        }

        WorkPartition<W, R> DoSubmit(W work, Func<W, R> worker, IEnumerable<IWorkAgentObserver<W, R>> observers)
        {
            var clrTaskId = WorkPartition.AssignIdentity();
            Func<W, R> adapter = w =>
             {
                 iter(observers, observer => observer.RaiseWorkDispatched(work));
                 var result = default(R);
                 try
                 {
                     result = worker(work);
                 }
                 finally
                 {
                     HandleTaskCompletion(clrTaskId).OnNone(()
                         => Notify(AppMessage.Warn("There was no task to complete")));
                 }

                 iter(observers, observer => observer.RaiseWorkCompleted(work, result));
                 return result;
             };

            var wt = WorkPartition.Create(clrTaskId, work, adapter);
            EnqueueWork(wt);
            iter(observers, observer => observer.RaiseWorkSubmitted(work));
            return wt;
        }


        public void Submit(IReadOnlyList<W> work, Func<W, R> worker = null, IReadOnlyList<IWorkAgentObserver<W, R>> observers = null)
        {
            var groupTasks = map(work.GroupBy(w => w.GroupName), workGroup
                => (workGroup.Key, DoSubmitGroup(workGroup.ToList(), worker, workGroup.Key, observers)));
        }

        public WorkPartition<W, R> Submit(W work, Func<W, R> worker = null, IReadOnlyList<IWorkAgentObserver<W, R>> observers = null)
            => (WorkPartition<W, R>)base.Submit(work, w => worker(w), observers);

        public new IEnumerable<WorkPartition<W, R>> ExecuteQueue()
            => base.ExecuteQueue().Cast<WorkPartition<W, R>>();
    }
}