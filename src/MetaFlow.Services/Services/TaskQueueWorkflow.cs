//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow.WF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    using SqlT.Core;
    using SqlT.Services;

    using static WorkflowMessages;

    public abstract class TaskQueueWorkflow<W, K, T, R, Q, A, S, O, I> 
        : PlatformService<W, I>, ITaskQueueWorkflow<K,T,R,Q,A,S,O>        
        where W : TaskQueueWorkflow<W, K, T, R, Q, A, S, O,I>
        where K : class, ISystemCommand, ISqlTableTypeProxy, new()
        where T : class, IWorkflowTask, ISqlTableTypeProxy, new()
        where R : class, ITaskResult, ISqlTableTypeProxy, new()
        where Q : class, ITaskQueue, ISqlTableProxy, new()
        where A : class, ITaskArchive, ISqlTableProxy, new()
        where S : class, ITaskState, ISqlTableTypeProxy
        where O : IWorkflowOptions
        where I : ITaskQueueWorkflow

    {

        object locker = new object();
             
        protected virtual ISqlProxyBroker WorkflowBroker
            => C.WorkflowBroker(C.Host);

        protected TaskQueueWorkflow(INodeContext C)
            : base(C)
        {

        }

        protected abstract IEnumerable<T> EnqueueCommands(IEnumerable<K> Commands);

        protected abstract IReadOnlyList<T> DequeueTasks(int BatchSize);

        protected abstract Option<int> ArchiveTasks(bool ResetOutstanding, bool RetryFailures);        

        public abstract IEnumerable<K> DefineCommands(O options);

        public abstract R ExecuteTask(T task);

        public virtual Option<int> AbandonPending(bool RetryFailures)
            => ArchiveTasks(false, RetryFailures);

        protected abstract Option<int> CompleteTask(R result);

        public abstract IEnumerable<T> PendingTasks { get; }

        public virtual IEnumerable<R> ExecuteTasks(IEnumerable<T> tasks)
            => tasks.Select(ExecuteTask);

        IEnumerable<IWorkflowTask> ITaskQueueWorkflow.PendingTasks
            => PendingTasks;

        IEnumerable<K> ICommandFactory<K>.DefineCommands(IWorkflowOptions options)
            => DefineCommands((O)options);

        IEnumerable<ISystemCommand> ICommandFactory.DefineCommands(IWorkflowOptions options)
            => DefineCommands((O)options);

        protected ISqlTableRuntime WorkflowTable<X>()
            where X : class, ISqlTableProxy, new()
            => C.SqlRuntimeProvider().Table(WorkflowBroker.Table<X>());

        Option<int> ITaskQueueWorkflow.ArchiveTasks()
            => ArchiveTasks(true, true);

        bool ITaskQueueService.IsEmpty
           => WorkflowTable<Q>().Count("Completed = 0")
                            .OnNone(Notify)
                            .Map(c => c == 0 ? true : false).ValueOrDefault(false);

        IEnumerable<T> ITaskQueueService<K,T>.EnqueueCommands(IEnumerable<K> Commands)
        {
            lock (locker)
                return EnqueueCommands(Commands);
        }

        IReadOnlyList<T> ITaskQueueService<K, T>.DequeueTasks(int MaxCount)
        {
            lock (locker)
                return DequeueTasks(MaxCount);
        }

        Option<int> ITaskQueueService.ArchiveTasks(bool ResetOutstanding, bool RetryFailures)
        {
            lock (locker)
                return ArchiveTasks(ResetOutstanding, RetryFailures);
        }

        IEnumerable<ITaskResult> ITaskQueueWorker.ExecuteTasks(IEnumerable<IWorkflowTask> tasks)
            => ExecuteTasks(tasks.Cast<T>());

        public virtual ITaskResult ExecuteTask(IWorkflowTask task)
            => ExecuteTask(task as T);

        void ITaskQueueWorkflow.Execute(IWorkflowOptions options, Func<bool> cancel)
            => Execute((O)options,cancel);

        Option<int> ITaskQueueService.PurgeQueue()
            => WorkflowTable<Q>().Delete();

        public void ExecuteQueue(bool PLL, int batch, Func<bool> cancel)
        {
            task(() => Cycle(PLL, batch, cancel));
        }

        protected virtual IAppMessage PreExecuteMessage(T task)
            => ExecutingTask(task);

        protected virtual IAppMessage PostExecuteMessage(T task, R result)
            => ExecutedTask(result);

        public CompletedResult<R> RunToCompletion(T task)
        {
            Notify(PreExecuteMessage(task));
            var result = ExecuteTask(task);
            Notify(PostExecuteMessage(task,result));            
            return new CompletedResult<R>(result, CompleteTask(result));
        }

        public string CommandName
            => $"{typeof(K).Name}";
      
        public void Execute(O options, Func<bool> cancel)
        {
            var commands = rolist(DefineCommands(options));
            if (commands.Count != 0)
            {
                Notify(DefinedCommands<K>(commands.Count));
                try
                {
                    var tasks = list(EnqueueCommands(commands));
                    Notify(EnqueuedTasks<K>(tasks.Count));
                    ExecuteQueue(options.PLL, options.BatchSize ?? 5000, cancel);
                }
                catch(Exception e)
                {
                    Notify(error(e));
                }
            }
        }

        public Option<int> ExecuteBatch(bool PLL, int BatchSize)
        {
            try
            {
                Notify(ExecutingBatch<T>(BatchSize));

                var tasks = DequeueTasks(BatchSize);
                if (tasks.Count == 0)
                {
                    Notify(AllTasksDispatched<T>());
                    return 0;
                }

                Notify(Dispatched(tasks.Count));

                iter(tasks, task => RunToCompletion(task), PLL);

                Notify(ExecutedBatch<T>(tasks.Count));

                return tasks.Count;
            }
            catch (Exception e)
            {
                NotifyError($"Unhandled worker exception: {e}");
                return none<int>(e);

            }

        }

        void Cycle(bool PLL, int MaxCount, Func<bool> cancel)
        {
            Notify(ExecutingQueue<T>(C.Host));

            var cycles = 0;
            var totalCount = 0;
            while (!cancel())
            {
                cycles++;

                Notify(BeginningTaskCycle<T>(cycles));

                var execCount = ExecuteBatch(PLL, MaxCount);
                if (!execCount)
                    break;

                if (execCount.Value() == 0)
                    break;

                totalCount += execCount.Value();

                Notify(FinishedTaskCycle(cycles));
            }

            Notify(ExecutedQueue<T>(C.Host));
        }

        IEnumerable<IWorkflowTask> ITaskQueueService.EnqueueCommands(IEnumerable<ISystemCommand> commands, CorrelationToken? CT)
            => EnqueueCommands(commands.Cast<K>());

        IWorkflowTask ITaskQueueService.EnqueueCommand(ISystemCommand command, CorrelationToken? CT)
            => EnqueueCommands(stream((K)command)).Single();

        public IEnumerable<K> DefineCommands(O options, bool enqueue)
        {
            var commands = rolist(DefineCommands(options));
            if (enqueue)
                EnqueueCommands(commands);
            return commands;
        }

        IEnumerable<ISystemCommand> ITaskQueueWorkflow.DefineCommands(IWorkflowOptions options, bool enqueue)
            => DefineCommands((O)options, enqueue);        
    }
}