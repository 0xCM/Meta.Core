//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

using System;


/// <summary>
/// Identifies a <see cref="SystemNode"/>
/// </summary>
public sealed class SystemNodeIdentifier : SemanticIdentifier<SystemNodeIdentifier, string>
{

    public static bool IsLocal(string id)
        => string.Equals(id, "Node00", StringComparison.InvariantCultureIgnoreCase)
        || string.Equals(id, "n00", StringComparison.InvariantCultureIgnoreCase);


    public static SystemNodeIdentifier Local
        => SystemNode.Local.NodeIdentifier;

    public static implicit operator SystemNodeIdentifier(string x)
        => new SystemNodeIdentifier(x);

    protected override SystemNodeIdentifier New(string IdentifierText)
        => new SystemNodeIdentifier(IdentifierText ?? string.Empty);


    SystemNodeIdentifier()
        : base(string.Empty)
    { }

    public SystemNodeIdentifier(string text)
        : base(text)
    {

    }

}


