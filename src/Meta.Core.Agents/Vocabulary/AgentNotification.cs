//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Defines an agent-specific notification message
/// </summary>
public class AgentNotification : IAgentNotification
{
    public AgentNotification(SystemNodeIdentifier Host, SystemIdentifier System,
        AgentIdentifier Agent, ServiceAgentState State, IAppMessage Message)
    {
        this.Host = Host;
        this.System = System;
        this.Agent = Agent;
        this.State = State;
        this.Message = Message;
    }

    /// <summary>
    /// The node on which the agent is executing
    /// </summary>
    public SystemNodeIdentifier Host { get; }

    /// <summary>
    /// The agent's defining system
    /// </summary>
    public SystemIdentifier System { get; }

    /// <summary>
    /// The agent's identity
    /// </summary>
    public AgentIdentifier Agent { get; }

    /// <summary>
    /// The state of the agent when the notification was issues
    /// </summary>
    public ServiceAgentState State { get; }

    /// <summary>
    /// The notification content
    /// </summary>
    public IAppMessage Message { get; }

    /// <summary>
    /// The agent's system-specific URI
    /// </summary>
    public SystemUri AgentUri
        => new SystemUri("agents", System.IdentifierText, Agent.Value);
        
    /// <summary>
    /// The correlation token associated with the notification, if any
    /// </summary>
    public CorrelationToken? CT
        => Message.CT;

    public override string ToString()
        => $"{AgentUri} >> {Message.Format(false)}";
}

