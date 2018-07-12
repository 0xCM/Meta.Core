//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
public interface IAgentComputationResult
{
    AgentIdentifier AgentIdentifier { get; }

    IAppMessage Description { get; }

    object Payload { get; }
}

public interface IAgentComputationResult<out P> : IAgentComputationResult
{
    new P Payload { get; }
}


