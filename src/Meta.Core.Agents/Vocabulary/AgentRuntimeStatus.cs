//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using static metacore;

    public class AgentRuntimeStatus
    {
        public AgentRuntimeStatus(AgentIdentifier AgentId, ServiceAgentState CurrentState, DateTime? AsOf = null)
        {
            this.AgentId = AgentId;
            this.CurrentState = CurrentState;
            this.AsOf = AsOf ?? now();

        }

        public AgentIdentifier AgentId { get; }

        public ServiceAgentState CurrentState { get; }

        public DateTime AsOf { get; }

        public override string ToString()
            => concat(AgentId, " | ", CurrentState.StateName);
    }

}