//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------


/// <summary>
/// Specifies the name of <see cref="ClrProperty"/>
/// </summary>
public sealed class ClrPropertyName : ClrMemberName<ClrPropertyName>
{
    public static ClrPropertyName Define(string Name)
        => Name;

    public static implicit operator ClrPropertyName(ClrItemIdentifier x)
        => new ClrPropertyName(x);

    public static implicit operator ClrPropertyName(string x)
        => new ClrPropertyName(x);

    public ClrPropertyName(ClrItemIdentifier Identifier)
        : base(Identifier)
    { }
}
