//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

/// <summary>
/// Defines states common to all agents
/// </summary>
public class ServiceAgentStates : TypedItemList<ServiceAgentStates, ServiceAgentState>
{
    /// <summary>
    /// Specifies that the agent is embued with no state
    /// </summary>
    public static readonly ServiceAgentState None = ServiceAgentStateNames.None;

    /// <summary>
    /// Specifies that the agent is preparing to transition to the <see cref="Started"/> state
    /// </summary>
    public static readonly ServiceAgentState Starting = ServiceAgentStateNames.Starting;

    /// <summary>
    /// Specifies that the agent has been started but is not yet running
    /// </summary>
    public static readonly ServiceAgentState Started = ServiceAgentStateNames.Started;

    /// <summary>
    /// Specifies that the agent has been created but initialization operations have not been executed
    /// </summary>
    public static readonly ServiceAgentState Uninitialized = ServiceAgentStateNames.Uninitialized;

    /// <summary>
    /// Specifies that the agent is in the process of initialzing
    /// </summary>
    public static readonly ServiceAgentState Initializing = ServiceAgentStateNames.Initializing;

    /// <summary>
    /// Specifies that initialization has been completed
    /// </summary>
    public static readonly ServiceAgentState Initialized = ServiceAgentStateNames.Initialized;

    /// <summary>
    /// Speciies that the agent is preparing to transition to the <see cref="Paused"/> state
    /// </summary>
    public static readonly ServiceAgentState Pausing = ServiceAgentStateNames.Pausing;

    /// <summary>
    /// Specifies the agent has suspended all activity
    /// </summary>
    public static readonly ServiceAgentState Paused = ServiceAgentStateNames.Paused;

    /// <summary>
    /// Specifies that the agent is fulfilling its primary function
    /// </summary>
    public static readonly ServiceAgentState Running = ServiceAgentStateNames.Running;

    /// <summary>
    /// Specifies that the agent is preparing to enter the <see cref="Stopped"/> state
    /// </summary>
    public static readonly ServiceAgentState Stopping = ServiceAgentStateNames.Stopping;

    /// <summary>
    /// Denotes the end of the agent lifecycle
    /// </summary>
    public static readonly ServiceAgentState Stopped = ServiceAgentStateNames.Stopped;
    public static readonly ServiceAgentState Error = ServiceAgentStateNames.Error;
    public static readonly ServiceAgentState Resuming = ServiceAgentStateNames.Resuming;
}
