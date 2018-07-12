//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

public interface IAgentNotification : ICorrelated
{
    SystemNodeIdentifier Host { get; }

    SystemIdentifier System { get; }

    AgentIdentifier Agent { get; }

    ServiceAgentState State { get; }

    SystemUri AgentUri { get; }


    IAppMessage Message { get; }

}
