//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

public sealed class SystemIdentifier : SemanticIdentifier<SystemIdentifier, string>
{

    public static implicit operator SystemIdentifier(string x)
        => new SystemIdentifier(x);

    protected override SystemIdentifier New(string IdentifierText)
        => new SystemIdentifier(IdentifierText ?? string.Empty);


    SystemIdentifier()
        : base(string.Empty)
    { }

    public SystemIdentifier(string text)
        : base(text)
    {

    }

}


