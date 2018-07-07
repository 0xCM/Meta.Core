//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

/// <summary>
/// Defines agent identity
/// </summary>
public class AgentIdentifier : DomainPrimitive<AgentIdentifier, string>
{
    public static implicit operator AgentIdentifier(string Value) 
        => new AgentIdentifier(Value);

    public AgentIdentifier(string Value)
        : base(Value)
    { }
}

