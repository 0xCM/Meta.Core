//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

public delegate void AgentNoficationChannel(IAgentNotification Notification);

/// <summary>
/// Defines basic agent contract 
/// </summary>
public interface IServiceAgent : IDisposable, IApplicationService
{
    /// <summary>
    /// Initiates agent exececution
    /// </summary>
    void Start();

    /// <summary>
    /// Halts agent execution
    /// </summary>
    void Stop();

    /// <summary>
    /// Halts agent work but retains any accumulated state necessary to resume function and
    /// transitions agent to the Paused state
    /// </summary>
    void Pause();

    /// <summary>
    /// Places the agent in the 
    /// </summary>
    void Resume();

    /// <summary>
    /// Initializes the agent and precondition for the body of the Start operation.
    /// </summary>
    /// <remarks>
    /// If not initialized, the operation should be invoked by the Start operation
    /// </remarks>
    void Initialize(params object[] initparams);
   
    /// <summary>
    /// Gets the name of the current state
    /// </summary>
    string AgentStateName { get; }

    /// <summary>
    /// The agent's current state
    /// </summary>
    ServiceAgentState AgentState { get; }

    /// <summary>
    /// The name of the agent
    /// </summary>
    string AgentName { get; }
    
    /// <summary>                  
    /// Prevents the agent from babbling
    /// </summary>
    void NoBabble();

    /// <summary>
    /// Encourages the agent to babble
    /// </summary>
    void Babble();

    /// <summary>
    /// Assigns the agent a notification channel
    /// </summary>
    /// <param name="channel">The notification channel the agent should use</param>
    void UseChannel(AgentNoficationChannel channel);    


}


