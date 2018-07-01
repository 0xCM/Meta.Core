//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

/// <summary>
/// Specifies the name of a <see cref="ClrConstructor"/>
/// </summary>
public sealed class ClrConstructorName : ClrMemberName<ClrConstructorName>
{
    public static ClrConstructorName Define(string Name)
        => Name;

    public static implicit operator ClrConstructorName(ClrItemIdentifier x)
        => new ClrConstructorName(x);

    public static implicit operator ClrConstructorName(string x)
        => new ClrConstructorName(x);

    public ClrConstructorName(ClrItemIdentifier Identifier)
        : base(Identifier)
    { }
}
