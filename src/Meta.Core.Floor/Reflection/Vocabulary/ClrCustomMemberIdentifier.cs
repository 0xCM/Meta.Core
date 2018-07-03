//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

public sealed class ClrCustomMemberIdentifier : SemanticIdentifier<ClrCustomMemberIdentifier, string>
{
    protected override ClrCustomMemberIdentifier New(string IdentifierText)
        => new ClrCustomMemberIdentifier(IdentifierText);

    ClrCustomMemberIdentifier()
        : base(string.Empty)
    {


    }

    public ClrCustomMemberIdentifier(string Name)
        : base(Name)
    {

    }


}

