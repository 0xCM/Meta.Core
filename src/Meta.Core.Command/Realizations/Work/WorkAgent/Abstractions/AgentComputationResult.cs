//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

public abstract class AgentComputationResult : IAgentComputationResult
{
    public static IAgentComputationResult<P> Create<P>(AgentIdentifier Agent, 
        P Payload, IAppMessage Message = null)
        => new AgentComputationResult<P>(Agent, Payload, Message ?? AppMessage.Empty);

    public AgentComputationResult(AgentIdentifier AgentIdentifier, object Payload, IAppMessage Description)
    {
        this.AgentIdentifier = AgentIdentifier;
        this.Payload = Payload;
        this.Description = Description;
    }

    public AgentIdentifier AgentIdentifier { get; }

    public object Payload { get; }

    public IAppMessage Description { get; }


}


public sealed class AgentComputationResult<P> : AgentComputationResult, IAgentComputationResult<P>
{
    public AgentComputationResult(AgentIdentifier AgentIdentifier, P Payload, IAppMessage Description)
        : base(AgentIdentifier, Payload, Description)
    {
        this.Payload = Payload;
    }

    public new P Payload { get; }
}
