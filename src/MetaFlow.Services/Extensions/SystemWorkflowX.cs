//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;

    using Meta.Core;
    using SqlT;

    using MetaFlow.WF;    

    public static class SystemWorkflowX
    {
        public static ISystemEventHub SystemEventHub(this INodeContext C)
            => C.Service<ISystemEventHub>();

        public static ISystemCommandWorkflow CommandWorkflow(this INodeContext C)
            => C.Service<ISystemCommandWorkflow>(nameof(SystemCommand));

        public static IJobScheduler Scheduler(this IApplicationContext C)
            => C.HostContext().Agent<IJobScheduler>(JobScheduler.AgentIdentifier);

    }
}