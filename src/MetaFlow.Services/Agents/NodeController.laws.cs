//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public interface INodeController : IServiceAgent, IAgentControl
    {
        IEnumerable<AgentRuntimeStatus> AgentStatusReport();

        void StartAgents();

        void StopAgents();
    }
}