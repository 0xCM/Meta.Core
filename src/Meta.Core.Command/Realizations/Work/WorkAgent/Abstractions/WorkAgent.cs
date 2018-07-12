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

    public abstract class WorkAgent : IWorkAgent
    {
        protected WorkAgent(IWorkAgentConfiguration AgentConfiguration)
        {
            this.AgentConfiguration = AgentConfiguration;
        }

        protected IWorkAgentConfiguration AgentConfiguration;

        protected readonly ConcurrentDictionary<string, ConcurrentQueue<WorkPartition>> PartitionQueues
            = new ConcurrentDictionary<string, ConcurrentQueue<WorkPartition>>();

        protected readonly ConcurrentSet<string> ExecutingGroups
            = new ConcurrentSet<string>();

        protected readonly CancellationTokenSource AgentControl
            = new CancellationTokenSource();

        protected readonly CancellationTokenSource ChildCancellation
            = new CancellationTokenSource();

        /// <summary>
        /// Tracks partition group task counts
        /// </summary>
        protected readonly IDictionary<string, int> PartitionCounts
            = new ConcurrentDictionary<string, int>();

        protected readonly ConcurrentDictionary<int, WorkPartition> ExecutingTasks
            = new ConcurrentDictionary<int, WorkPartition>();

        protected readonly ConcurrentDictionary<string, IWorkSupplier> WorkSuppliers
            = new ConcurrentDictionary<string, IWorkSupplier>();

        /// <summary>
        /// Tracks the total number of tasks that have been executed since the queue was instantiated
        /// </summary>
        int executed;

        /// <summary>
        /// Tracks the total number of spinner loops that have been executed
        /// </summary>
        int revolutions;

        int lastSubmissionCount;

        protected Option<Task> AgentControlTask;

        protected ConcurrentSet<Task> Spinners = new ConcurrentSet<Task>();

        /// <summary>
        /// Specifies whether there are any pending tasks
        /// </summary>
        protected bool HasPendingTasks
            => PendingTaskCount != 0;

        protected bool DiagnosticMode
            => AgentSettings.DiagnosticMode;

        protected void CancelAgentControl()
            => AgentControl.Cancel();

        protected void CancelChildren()
            => ChildCancellation.Cancel();

        protected Action<IAppMessage> MessageReceiver
            => AgentConfiguration.MessageReceiver;

        protected void Notify(IAppMessage message)
            => MessageReceiver(message);

        protected bool IsAgentCancelling
            => AgentControl.IsCancellationRequested;

        protected WorkAgentSettings AgentSettings
            => AgentConfiguration.Settings;


        /// <summary>
        /// Retrieves the queue for the identified partition
        /// </summary>
        /// <param name="partition">The partition</param>
        /// <returns></returns>
        protected ConcurrentQueue<WorkPartition> GetPartitionQueue(string partition)
            => PartitionQueues.GetOrAdd(partition, name
                    => new ConcurrentQueue<WorkPartition>());

        /// <summary>
        /// The names of the partitions for which tasks are enqueued
        /// </summary>
        protected IEnumerable<string> NonemptyPartititions
            => PartitionQueues.Where(x => x.Value.Count != 0).Select(x => x.Key).ToList();

        /// <summary>
        /// Gets the number of tasks that are currently executing for the partition
        /// </summary>
        /// <param name="partition">The partition to check</param>
        /// <returns></returns>
        protected int GetExecutionCount(string partition)
            => PartitionCounts.TryFind(partition).ValueOrDefault();

        /// <summary>
        /// Determines whether the identified position has an opening available for a new work item
        /// </summary>
        /// <param name="partition">The partition to check</param>
        /// <returns></returns>
        protected bool CanAcceptWork(string partition)
            => GetExecutionCount(partition) < AgentSettings.PartitionTaskLimit;


        /// <summary>
        /// Specifies whether an identified task group is currently 
        /// </summary>
        /// <param name="groupName">The name of the group</param>
        /// <returns></returns>
        public bool IsGroupExecuting(string groupName)
            => ExecutingGroups.Contains(groupName);

        /// <summary>
        /// Computes the number of open work slots for the partition
        /// </summary>
        /// <param name="partition">The partition to check</param>
        /// <returns></returns>
        protected int CountOpenSlots(string partition)
            => AgentSettings.PartitionTaskLimit - GetExecutionCount(partition);

        public void Dispose(int timeout)
            => Stop(timeout);

        public void Dispose()
            => Dispose(AgentSettings.CancellationTimeout);

        /// <summary>
        /// The total number of tasks that are enqueued and awaiting dispatch
        /// </summary>
        public int PendingTaskCount
            => PartitionQueues.Values.Select(x => x.Count).Sum();

        /// <summary>
        /// Pause execution loop for a configured time slice
        /// </summary>
        protected void CompleteRevolution(int lastSubmissionCount)
        {
            Notify(Pausing(Task.CurrentId ?? 0, AgentSettings.SpinDelay));
            Task.Delay(AgentSettings.SpinDelay).Wait();
            Interlocked.Increment(ref revolutions);
            this.lastSubmissionCount = lastSubmissionCount;

        }

        protected Task SpinUpSpinner()
        {
            var task = new Task(() => ExecuteQueue(), ChildCancellation.Token);
            Notify(SpinnerCreated(task));
            Spinners.Add(task);

            task.ContinueWith(t =>
            {
                Spinners.Remove(t);
                Notify(SpinnerCompleted(t));
            });
            task.Start();
            return task;
        }

        /// <summary>
        /// Executes until the agent is cancelled
        /// </summary>
        protected virtual void Spin()
        {
            var MaxSpinnerCount = 5;
            try
            {
                while (!IsAgentCancelling)
                {
                    var submissions = MutableList.Create<WorkPartition>();
                    if (Spinners.Count < MaxSpinnerCount)
                    {
                        submissions.AddRange(SubmitNext());
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

        bool WaitForExecutionCompletion(int timeout)
            => Task.WaitAll(ExecutingTasks.Values.Select(x => x.ClrTask).ToArray(), timeout);

        protected void AgentCancellationGuard(Action a)
        {
            if (!IsAgentCancelling)
            {
                a();
            }
        }

        public void Stop(int? timeout = null)
        {
            Notify(Stopping());
            var wait = timeout ?? AgentSettings.CancellationTimeout;

            CancelAgentControl();
            Notify(WaitingForTasks(ExecutingTasks.Count, wait));
            if (!WaitForExecutionCompletion(wait))
                Notify(TasksUnfinished(ExecutingTasks.Count, wait));

            CancelChildren();

            AgentControlTask.OnSome(t =>
            {
                t.Wait(wait);
                AgentControlTask = none<Task>();
            });
            Notify(Stopped());
        }

        public void Start()
        {
            try
            {
                if (AgentControlTask.IsNone())
                    AgentControlTask = Task.Factory.StartNew(Spin, TaskCreationOptions.LongRunning);
                else
                    Notify(AlreadyRunning());
            }
            catch (Exception e)
            {
                Notify(AppMessage.Error(e));
            }
        }

        /// <summary>
        /// Executes an action until no tasks are pending
        /// </summary>
        /// <param name="a">The action to invoke</param>
        protected void WhileTasksArePending(Action a)
        {
            while (HasPendingTasks)
                a();

        }

        /// <summary>
        /// If possible, takes an item from a partition in the queue
        /// </summary>
        /// <param name="partition">The name of the partition</param>
        /// <returns></returns>
        protected Option<WorkPartition> TryDequeue(string partition)
        {
            var x = default(WorkPartition);
            AgentCancellationGuard(()
                =>
            {
                lock (PartitionCounts)
                {
                    if (CanAcceptWork(partition) && GetPartitionQueue(partition).TryDequeue(out x))
                        PartitionCounts[partition] = GetExecutionCount(partition) + 1;
                }
            });
            return x;
        }

        /// <summary>
        /// Calculates a set of statistics that reflect the current state of the queue
        /// </summary>
        /// <returns></returns>
        public WorkAgentStatistics ComputeStats()
            => new WorkAgentStatistics
            (
                TotalPartitionCount: PartitionQueues.Count,
                PendingTaskCount: PartitionQueues.Values.Select(x => x.Count).Sum(),
                NonemptyPartitionCount: PartitionQueues.Where(x => x.Value.Count != 0).Count(),
                ExecutingTaskCount: ExecutingTasks.Count,
                ExecutedTaskCount: executed,
                SpinnerCount: Spinners.Count,
                RevolutionCount: revolutions,
                LastSubmissionCount: lastSubmissionCount
            );

        /// <summary>
        /// Updates the internal state to reflect that a partitioned task has completed
        /// and broadcasts the resulting partition state to the observer
        /// </summary>
        protected Option<WorkPartition> HandleTaskCompletion(int taskid)
        {
            var completed = default(WorkPartition);
            if (ExecutingTasks.TryRemove(taskid, out completed))
            {
                Interlocked.Increment(ref executed);
                var partition = completed.Partition;

                int count = 0;
                lock (PartitionCounts)
                {
                    if (PartitionCounts.ContainsKey(partition))
                    {
                        count = PartitionCounts[partition] - 1;
                        PartitionCounts[partition] = count;
                    }
                }
            }
            return completed;
        }

        protected WorkPartition EnqueueWork(WorkPartition workTask)
        {
            GetPartitionQueue(workTask.Partition).Enqueue(workTask);
            return workTask;
        }

        protected void StartTask(WorkPartition task, bool wait)
        {
            task.Start();
            if (!ExecutingTasks.TryAdd(task.ClrTaskId, task))
                Notify(ExecutionIndexUpdateFailed(task.ClrTaskId));

            if (wait)
                task.Wait();
        }

        /// <summary>
        /// Enqueues a collection of work items wherein each work item will be executed 
        /// independently and returns a <see cref="Task"/> that will complete when all
        /// work submitted in the group has been completed.
        /// </summary>
        /// <param name="work">The work to be performed</param>
        /// <param name="worker">Invoked to perform each unit of work</param>    
        /// <param name="observers">A listener for which appropriate actions will be invoked during execution</param>
        /// <returns></returns>
        protected Task<ReadOnlyList<WorkPartition>> SubmitGroup(IReadOnlyList<IPartitionedWork> work,
            Action<IPartitionedWork> worker, string groupName, IReadOnlyList<IWorkAgentObserver> observers)
        {
            return Task.Factory.StartNew(() =>
            {
                var tasks = work.Map(w => Submit(w, worker, observers));
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

        /// <summary>
        /// Enqueues a unit of work
        /// </summary>
        /// <param name="work">The work to be performed</param>
        /// <param name="worker">The handler that will be invoked to perform the work</param>
        /// <param name="observers">A listener for which appropriate actions will be invoked during
        /// execution</param>
        /// <returns></returns>
        public WorkPartition Submit(IPartitionedWork work, Action<IPartitionedWork> worker, IReadOnlyList<IWorkAgentObserver> observers)
        {
            var clrTaskId = WorkPartition.AssignIdentity();

            Action<IPartitionedWork> adapter = w =>
            {
                iter(observers, observer => observer.RaiseWorkDispatched(work));

                try
                {
                    worker(work);
                }
                finally
                {
                    HandleTaskCompletion(clrTaskId).OnNone(()
                        => Notify(AppMessage.Warn("There was no task to complete")));
                }

                iter(observers, observer => observer.RaiseWorkCompleted(work));
            };

            var workTask = EnqueueWork(WorkPartition.Create(clrTaskId, work, adapter));
            iter(observers, observer => observer.RaiseWorkSubmitted(work));
            return workTask;
        }


        public ReadOnlyList<Task<ReadOnlyList<WorkPartition>>> Submit(IReadOnlyList<IPartitionedWork> work,
            Action<IPartitionedWork> worker, IReadOnlyList<IWorkAgentObserver> observers)
        {
            var groupTasks = map(work.GroupBy(w => w.GroupName), workGroup
                => (workGroup.Key,
                            SubmitGroup(workGroup.ToList(), worker, workGroup.Key, observers)));
            return map(groupTasks, x => x.Item2);
        }


        protected abstract IEnumerable<WorkPartition> SubmitNext();

        /// <summary>
        /// Executes until there are no more pending tasks
        /// </summary>
        public IEnumerable<WorkPartition> ExecuteQueue()
        {
            while (HasPendingTasks)
            {
                foreach (var p in NonemptyPartititions)
                {
                    if (!IsAgentCancelling)
                    {
                        var w = TryDequeue(p);
                        if (w)
                        {
                            var wt = ~w;
                            StartTask(wt, DiagnosticMode);
                            yield return wt;
                        }
                    }

                }
            }


        }


        /// <summary>
        /// Pulls work from any sources that are specified
        /// </summary>
        /// <param name="worker">The work item recipient</param>
        /// <param name="observers">The observers to notify</param>
        protected IEnumerable<WorkPartition> SubmitNext(Action<IPartitionedWork> worker, IReadOnlyList<IWorkAgentObserver> observers)
        {
            foreach (var partition in WorkSuppliers.Keys)
            {
                var count = CountOpenSlots(partition);
                if (count != 0)
                {
                    var supplier = WorkSuppliers[partition];
                    foreach (var work in supplier.Next(count))
                    {
                        yield return Submit(work, worker, observers);
                    }
                }
            }
        }

    }
}