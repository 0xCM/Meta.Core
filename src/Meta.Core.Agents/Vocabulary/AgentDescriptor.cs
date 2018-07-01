//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Identifies an agent and host type
/// </summary>
public sealed class AgentDescriptor
{
    public AgentDescriptor(AgentIdentifier AgentId, Type HostType)
    {
        this.AgentId = AgentId;
        this.HostType = HostType;
    }

    /// <summary>
    /// The identity of the agent
    /// </summary>
    public AgentIdentifier AgentId { get; }

    /// <summary>
    /// The agent's host type
    /// </summary>
    public Type HostType { get; }

    public override string ToString()
        => AgentId;
}
