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

    using SqlT.Core;
    using SqlT.Services;

    using static metacore;

    using static WorkflowMessages;

    public abstract class TaskQueue<B, K, T, Q, I> : NodeService<B, I>, ITaskQueueService<K, T>
        where B : TaskQueue<B, K, T, Q, I>
        where I : INodeService
        where Q : class, ITaskQueue, ISqlTableProxy, new()
        where T : class, IWorkflowTask, ISqlTableTypeProxy, new()
        where K : class, ISystemCommand, ISqlTableTypeProxy, new()
    {
        protected TaskQueue(INodeContext C)
            : base(C)
        {

        }

        object locker = new object();

        protected virtual ISqlProxyBroker WorkflowBroker
            => C.WorkflowBroker(C.Host);

        protected ISqlTableRuntime WorkflowTable<X>()
            where X : class, ISqlTableProxy, new()
            => C.SqlRuntimeProvider().Table(WorkflowBroker.Table<X>());


        bool ITaskQueueService.IsEmpty
           => WorkflowTable<Q>().Count("Completed = 0").OnNone(Notify).Map(c => c == 0 ? true : false).ValueOrDefault(false);

        protected abstract IEnumerable<T> HandleEnqueueOperation(IEnumerable<K> Commands);

        protected abstract IReadOnlyList<T> HandleDequeueOperation(int batch);

        protected abstract Option<int> HandleArchiveOperation(bool ResetOutstanding, bool RetryFailures);

        public Option<int> ArchiveTasks(bool ResetOutstanding, bool RetryFailures)
        {
            lock (locker)
                return HandleArchiveOperation(ResetOutstanding, RetryFailures);
        }

        public IReadOnlyList<T> DequeueTasks(int MaxCount)
        {
            lock (locker)
                return HandleDequeueOperation(MaxCount);
        }

        Option<int> ITaskQueueService.PurgeQueue()
            => WorkflowTable<Q>().Delete();

        public IEnumerable<T> EnqueueCommands(IEnumerable<K> Commands)
        {
            lock (locker)
                return HandleEnqueueOperation(Commands);
        }

        public IWorkflowTask EnqueueCommand(ISystemCommand command, CorrelationToken? CT = null)
        {
            lock (locker)
                return HandleEnqueueOperation(stream(command as K)).Single();
        }

        public IEnumerable<IWorkflowTask> EnqueueCommands(IEnumerable<ISystemCommand> commands, CorrelationToken? CT = null)
        {
            lock (locker)
                return HandleEnqueueOperation(commands.Cast<K>());
        }
    }



}