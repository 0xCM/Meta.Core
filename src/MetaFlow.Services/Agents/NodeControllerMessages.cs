//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow.WF
{
    using static metacore;
    using System;

    static class NodeControllerMessages
    {
        public static IAppMessage StartedAgent(AgentIdentifier AgentId)
            => inform($"Started the {AgentId} agent");

        public static IAppMessage AgentNotFound(AgentIdentifier AgentId)
            => error($"{AgentId} Agent not found");

        public static IAppMessage AgentStartError(AgentIdentifier AgentId)
            => error($"{AgentId} agent could not start");

        public static IAppMessage UnanticipatedError(AgentIdentifier AgentId, Exception e)
            => error($"{AgentId} agent could not start due to an unanticipated error: {e}");

        public static IAppMessage StoppingAgent(AgentIdentifier AgentId)
            => inform($"Stoping the {AgentId} agent");

    }
}
