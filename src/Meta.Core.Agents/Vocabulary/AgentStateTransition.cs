//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

/// <summary>
/// Describes an agent state transition
/// </summary>
public class AgentStateTransition 
{
    public AgentStateTransition(ServiceAgentState SourceState, ServiceAgentState TargetState, object Data = null)
    {
        this.SourceState = SourceState;
        this.TargetState = TargetState;
        this.Data = Data;

    }

    /// <summary>
    /// The state prior to transition
    /// </summary>
    public ServiceAgentState SourceState { get; }

    /// <summary>
    /// The state after transition
    /// </summary>
    public ServiceAgentState TargetState { get; }

    /// <summary>
    /// Agent-specific data associated with the transition
    /// </summary>
    public object Data { get; }

}

public class AgentStateTransition<D> : AgentStateTransition
{
    public AgentStateTransition(ServiceAgentState SourceState, ServiceAgentState TargetState, D Data = default(D))
        : base(SourceState, TargetState, Data)
    {

    }

    public new D Data
        => (D)base.Data;
}


