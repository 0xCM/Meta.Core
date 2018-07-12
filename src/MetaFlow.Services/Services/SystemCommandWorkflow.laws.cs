//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// 
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Meta.Core;

    using SqlT.Core;
    using MetaFlow.WF;

    using static metacore;

    public interface ISystemCommandWorkflow : ITaskQueueWorkflow
    {

        Option<SystemTaskDefinition> DefineTask(ISystemCommand command, CorrelationToken? CT);
       
        ISystemWorkflowServices WorkflowServices { get; }        

        Option<SystemTask> Submit(ISystemCommand command, CorrelationToken? CT);

        Option<SystemTask> Submit<K>(K command, CorrelationToken? CT)
            where K : class, ISystemCommand, ISqlTableTypeProxy, new();

        Option<IReadOnlyList<SystemTask>> Submit(IEnumerable<ISystemCommand> commands, CorrelationToken? CT);
    }
}