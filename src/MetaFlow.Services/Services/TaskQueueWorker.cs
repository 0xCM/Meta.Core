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

    using static metacore;

    public abstract class TaskQueueWorker<W,T,R> : NodeComponent, ITaskQueueWorker<T,R>
        where W : TaskQueueWorker<W,T,R>
        where T : class, IWorkflowTask, ISqlTableTypeProxy, new()
        where R : class, ITaskResult, ISqlTableTypeProxy, new()

    {

        protected virtual ISqlProxyBroker WorkflowBroker
            => C.WorkflowBroker(C.Host);

        protected TaskQueueWorker(INodeContext C)
            : base(C)
        {

        }


        public virtual IEnumerable<R> ExecuteTasks(IEnumerable<T> tasks)
            => tasks.Select(ExecuteTask);

        public abstract R ExecuteTask(T task);

        IEnumerable<ITaskResult> ITaskQueueWorker.ExecuteTasks(IEnumerable<IWorkflowTask> tasks)
            => ExecuteTasks(tasks.Cast<T>());

        ITaskResult ITaskQueueWorker.ExecuteTask(IWorkflowTask task)
            => ExecuteTask(task as T);
    }

}