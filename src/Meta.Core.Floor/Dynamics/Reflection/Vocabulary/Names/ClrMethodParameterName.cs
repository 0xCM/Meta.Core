//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------


/// <summary>
/// Specifies the name of a <see cref="ClrMethodParameter"/>
/// </summary>
public sealed class ClrMethodParameterName : ClrElementName<ClrMethodParameterName>
{
    public static implicit operator ClrMethodParameterName(ClrItemIdentifier x)
        => new ClrMethodParameterName(x);

    public static implicit operator ClrMethodParameterName(string x)
        => new ClrMethodParameterName(x);

    public ClrMethodParameterName(ClrItemIdentifier Identifier)
        : base(Identifier)
    {

    }

    public ClrMethodParameterName(string Text)
        : base(Text)
    { }
}
