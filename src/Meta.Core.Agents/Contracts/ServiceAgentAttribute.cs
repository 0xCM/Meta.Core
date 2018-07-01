//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

/// <summary>
/// Identifies a service agent
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class ServiceAgentAttribute : Attribute
{
    private readonly string agentidentifier;
    public ServiceAgentAttribute(string agentidentifier)
    {
        this.agentidentifier = agentidentifier;
    }

    public string AgentIdentifier
        => agentidentifier;
}



