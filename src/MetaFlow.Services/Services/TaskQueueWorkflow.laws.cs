//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using MetaFlow.WF;
   
    public interface ITaskQueueWorkflow : INodeService, ICommandFactory, ITaskQueueService, ITaskQueueWorker
    {
        void Execute(IWorkflowOptions options, Func<bool> cancel);

        IEnumerable<ISystemCommand> DefineCommands(IWorkflowOptions options, bool enqueue);

        Option<int> ArchiveTasks();

        Option<int> ExecuteBatch(bool PLL, int MaxCount);

        void ExecuteQueue(bool PLL, int batch, Func<bool> cancel);
        
        IEnumerable<IWorkflowTask> PendingTasks { get; }

        Option<int> AbandonPending(bool RetryFailures);
    }

    public interface ITaskQueueWorkflow<in K, out T> : ITaskQueueWorkflow, ITaskQueueService<K,T>
        where K : class, ISystemCommand, ISqlTableTypeProxy, new()
        where T : class, IWorkflowTask, ISqlTableTypeProxy, new()
    {
        new IEnumerable<T> PendingTasks { get; }
    }

    public interface ITaskQueueWorkflow<K, T, R, Q, A, S, O> : 
            ITaskQueueWorkflow<K,T>,
            ICommandFactory<O, K>,
            ITaskQueueWorker<T, R>
        where K : class, ISystemCommand, ISqlTableTypeProxy, new()
        where O : IWorkflowOptions
        where T : class, IWorkflowTask, ISqlTableTypeProxy, new()
        where R : class, ITaskResult, ISqlTableTypeProxy, new()
        where Q : class, ITaskQueue, ISqlTableProxy, new()
        where A : class, ITaskArchive, ISqlTableProxy, new()
        where S : class, ITaskState, ISqlTableTypeProxy

    {
        void Execute(O options, Func<bool> cancel);

        CompletedResult<R> RunToCompletion(T task);
       
        IEnumerable<K> DefineCommands(O options, bool enqueue);
    }
}