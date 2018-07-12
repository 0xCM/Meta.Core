//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow.WF
{
    using System;
    using System.Linq;

    using SqlT.Core;
    
    using MetaFlow.Proxies.WF;

    using static metacore;

    class AgentControl : PlatformService<AgentControl, IAgentControl>, IAgentControl
    {
        public AgentControl(INodeContext C)
            : base(C)
        {
            WorkflowBroker = C.WorkflowBroker();
        }

        ISqlProxyBroker WorkflowBroker { get; }

        SystemNodeIdentifier SourceNode
            => C.ExecutingNode().NodeIdentifier;

        SystemNodeIdentifier TargetNode
            => C.Host.NodeIdentifier;

        Option<int> SubmitControlCommand<C>(AgentIdentifier AgentId)
            where C : IAgentControlCommand
            => WorkflowBroker.Call(new SubmitAgentCommand(SourceNode, TargetNode, AgentId, typeof(C).Name, CorrelationToken.Create())).ToOption()
                    .OnNone(Notify).OnSome(_ => inform($"Submitted {typeof(C).Name} command to {AgentId}"));

        public void PauseAgent(AgentIdentifier AgentId)
            => SubmitControlCommand<C0.PauseAgent>(AgentId);

        public void ResumeAgent(AgentIdentifier AgentId)
            => SubmitControlCommand<C0.ResumeAgent>(AgentId);

        public void StartAgent(AgentIdentifier AgentId)
            => SubmitControlCommand<C0.StartAgent>(AgentId);

        public void StopAgent(AgentIdentifier AgentId)
            => SubmitControlCommand<C0.StopAgent>(AgentId);
    }
}