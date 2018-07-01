//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

public sealed class UncRoot : DomainPrimitive<UncRoot, FolderName>
{
    public static implicit operator UncRoot(FolderName Name)
        => new UncRoot(Name);

    public static UncRoot Parse(string Name)
        => new UncRoot(Name);

    public UncRoot(FolderName Name)
        : base(Name)
    {

    }

    public override string ToString()
        => Value;

}







