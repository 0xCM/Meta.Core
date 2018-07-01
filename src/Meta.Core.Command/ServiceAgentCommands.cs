//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

using N = SystemNodeIdentifier;

public class ServiceAgentCommand : ICorrelated
{
    public ServiceAgentCommand(AgentIdentifier AgentId, CommandName CommandName, NodeLink Link, CommandArguments Args, CorrelationToken? CT = null)
    {
        this.AgentId = AgentId;
        this.CommandName = CommandName;
        this.Link = Link;
        this.Args = Args;
        this.CT = CT;
    }

    public AgentIdentifier AgentId { get; }

    public CommandName CommandName { get; }

    public NodeLink Link { get; }

    public CommandArguments Args { get; }

    public CorrelationToken? CT { get; }

}


public delegate ServiceAgentCommand AgentCommandFactory
        (AgentIdentifier AgentId, NodeLink Link, CorrelationToken? CT);

public delegate ServiceAgentCommand AgentCommandFactory<in T1>
        (AgentIdentifier AgentId, NodeLink Link, T1 Arg1, CorrelationToken? CT);

public delegate ServiceAgentCommand AgentCommandFactory<in T1, in T2>
        (AgentIdentifier AgentId, NodeLink Link, T1 Arg1, T2 Arg2, CorrelationToken? CT);

public delegate ServiceAgentCommand AgentCommandFactory<in T1, in T2, in T3>
        (AgentIdentifier AgentId, NodeLink Link, T1 Arg1, T2 Arg2, T3 Arg3, CorrelationToken? CT);

/// <summary>
/// Specifies command factories for commands common to all agents
/// </summary>
public class ServiceAgentCommands : TypedItemList<ServiceAgentCommands, AgentCommandFactory>
{
    
    public static readonly AgentCommandFactory Start = (AgentId, Link,  CT) 
        => new ServiceAgentCommand(AgentId, "Start", Link, CommandArguments.Emtpy, CT);

    public static readonly AgentCommandFactory Stop = (AgentId, Link, CT)
        => new ServiceAgentCommand(AgentId, "Stop", Link, CommandArguments.Emtpy, CT);

    public static readonly AgentCommandFactory Pause = (AgentId, Link, CT)
        => new ServiceAgentCommand(AgentId, "Pause", Link, CommandArguments.Emtpy, CT);

    public static readonly AgentCommandFactory Resume = (AgentId, Link, CT)
        => new ServiceAgentCommand(AgentId, "Resume", Link, CommandArguments.Emtpy, CT);

}