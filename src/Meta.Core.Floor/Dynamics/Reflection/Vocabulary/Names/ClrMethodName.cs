//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------


/// <summary>
/// Specifies the name of a <see cref="ClrMethod"/>
/// </summary>
public sealed class ClrMethodName : ClrMemberName<ClrMethodName>
{
    public static implicit operator ClrMethodName(ClrItemIdentifier x)
        => new ClrMethodName(x);
    public static implicit operator ClrMethodName(string x)
        => new ClrMethodName(x);

    public ClrMethodName(ClrItemIdentifier Identifier)
        : base(Identifier)
    { }
}

