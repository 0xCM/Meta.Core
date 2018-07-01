//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Runtime.CompilerServices;

using static metacore;
using static AgentNotifications;

/// <summary>
/// Defines agent-related extensions
/// </summary>
public static class AgentX
{
    public static A Agent<A>(this INodeContext C, string AgentIdentifier)
        where A : IServiceAgent
        => (A)C.Service<IServiceAgent>(AgentIdentifier);

    public static IServiceAgent Agent(this INodeContext C, string AgentIdentifier)
        => C.Service<IServiceAgent>(AgentIdentifier);

    public static Option<A> StartIfNotRunning<A>(this A Agent)
        where A : IServiceAgent
    {
        try
        {
            if (!Agent.AgentState.IsRunning)
            {
                Agent.Start();
            }

        }
        catch (Exception e)
        {
            return none<A>(e);
        }

        Agent.Context.Notify(AgentHasState(Agent.AgentName, Agent.AgentState));

        return Agent;
    }

    public static Option<A> StopIfRunning<A>(this A Agent)
        where A : IServiceAgent
    {
        try
        {
            if (Agent.AgentState.IsRunning)
                Agent.Stop();
        }
        catch (Exception e)
        {
            return none<A>(e);
        }

        Agent.Context.Notify(AgentHasState(Agent.AgentName, Agent.AgentState));
        return Agent;
    }

    public static Option<A> PauseIfRunning<A>(this A Agent)
        where A : IServiceAgent
    {
        try
        {
            if (Agent.AgentState.IsRunning)
                Agent.Pause();
        }
        catch (Exception e)
        {
            return none<A>(e);
        }

        Agent.Context.Notify(AgentHasState(Agent.AgentName, Agent.AgentState));
        return Agent;
    }
    public static Option<A> ResumeIfPaused<A>(this A Agent)
        where A : IServiceAgent
    {
        try
        {
            if (Agent.AgentState.IsPaused)
                Agent.Resume();
        }
        catch (Exception e)
        {
            return none<A>(e);
        }

        Agent.Context.Notify(AgentHasState(Agent.AgentName, Agent.AgentState));
        return Agent;
    }

}