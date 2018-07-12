//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    using SqlT.Core;
    using MetaFlow.WF;
    
    public interface ITaskQueueService : INodeService
    {
        Option<int> ArchiveTasks(bool ResetOutstanding, bool RetryFailures);

        bool IsEmpty { get; }
        

        IWorkflowTask EnqueueCommand(ISystemCommand command, CorrelationToken? CT = null);

        IEnumerable<IWorkflowTask> EnqueueCommands(IEnumerable<ISystemCommand> commands, CorrelationToken? CT = null);

        Option<int> PurgeQueue();

    }

    public interface ITaskQueueService<in K, out T> : ITaskQueueService
        where K : class, ISqlTableTypeProxy, ISystemCommand,  new()
        where T : class, ISqlTableTypeProxy, IWorkflowTask
    {
        
        IEnumerable<T> EnqueueCommands(IEnumerable<K> commands);

        IReadOnlyList<T> DequeueTasks(int BatchSize);
    }
}