//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using static metacore;

/// <summary>
/// Defines common agent notifcation messages
/// </summary>
public static class AgentNotifications
{

    /// <summary>
    /// Issued when an agent has been created
    /// </summary>
    /// <param name="AgentName">Identifies the created agent</param>
    /// <returns></returns>
    public static IAppMessage AgentCreated(string AgentName)
        => inform("@AgentName agent created", new
        {
            AgentName,
        });

    /// <summary>
    /// Issued to reveal agent state
    /// </summary>
    /// <param name="AgentName">The name of the agent</param>
    /// <param name="AgentState"></param>
    /// <returns></returns>
    public static IAppMessage AgentHasState(string AgentName, ServiceAgentState AgentState)
        => inform("The @AgentName agent is in the @AgentState state", new
        {
            AgentName,
            AgentState
        });


    /// <summary>
    /// Issued to indicate an agent state transition
    /// </summary>
    /// <param name="AgentName">The name of the agent</param>
    /// <param name="Transition"></param>
    /// <returns></returns>
    public static IAppMessage StateTransitioned(string AgentName, AgentStateTransition Transition)
        => inform("@AgentName agent transitioned from @SourceState to @TargetState", new
        {
            AgentName,
            Transition.SourceState,
            Transition.TargetState

        });

    public static IAppMessage InvalidStartState(string AgentName, ServiceAgentState AgentState)
        => warn($"The {AgentName} cannot start while in the {AgentState} state");

    /// <summary>
    /// Issued when an agent control task is unexpectedly has a value
    /// </summary>
    /// <param name="AgentName">The name of the agent</param>
    /// <returns></returns>
    public static IAppMessage ControlTaskNotNull(string AgentName)
        => error($"Agent {AgentName} control task should be null but yet it is not");

}
