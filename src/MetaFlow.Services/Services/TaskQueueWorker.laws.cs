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

    using static metacore;

    using SqlT.Core;
    using MetaFlow.WF;
    
    public interface ITaskQueueWorker 
    {
        IEnumerable<ITaskResult> ExecuteTasks(IEnumerable<IWorkflowTask> tasks);

        ITaskResult ExecuteTask(IWorkflowTask task);
    }

    public interface ITaskQueueWorker<in T, out R> : ITaskQueueWorker
        where T : class, IWorkflowTask, ISqlTableTypeProxy, new()
        where R : class, ITaskResult, ISqlTableTypeProxy, new()
    {
        IEnumerable<R> ExecuteTasks(IEnumerable<T> tasks);

        R ExecuteTask(T task);
    }


}