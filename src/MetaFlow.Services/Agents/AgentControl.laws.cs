//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;    

    public interface IAgentControl : INodeService
    {

        void PauseAgent(AgentIdentifier AgentId);

        void ResumeAgent(AgentIdentifier AgentId);

        void StartAgent(AgentIdentifier AgentId);

        void StopAgent(AgentIdentifier AgentId);

    }
}