//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;

    using Meta.Core;

    class SystemWorkflowServices : PlatformService<SystemWorkflowServices, ISystemWorkflowServices>, ISystemWorkflowServices
    {
        public SystemWorkflowServices(INodeContext C)
            : base(C)
        {
            this.TaskHandler = C.Service<ISystemTaskHandler>();
            this.MessageSerializer = C.Service<ICommandSpecSerializer>();
        }

        public ISystemTaskHandler TaskHandler { get; }

        public ICommandSpecSerializer MessageSerializer { get; }
    }
}