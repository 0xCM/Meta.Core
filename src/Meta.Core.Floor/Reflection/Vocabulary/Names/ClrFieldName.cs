//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------


/// <summary>
/// Specifies the name of a <see cref="ClrField"/>
/// </summary>
public sealed class ClrFieldName : ClrMemberName<ClrFieldName>
{
    public static ClrFieldName Define(string Name)
        => Name;

    public static readonly ClrFieldName Anonymous 
        = new ClrFieldName(ClrItemIdentifier.Missing);

    public static implicit operator ClrFieldName(ClrItemIdentifier x)
        => new ClrFieldName(x);

    public static implicit operator ClrFieldName(string x)
        => new ClrFieldName(x);

    public ClrFieldName(ClrItemIdentifier Identifier)
        : base(Identifier)
    { }
}






