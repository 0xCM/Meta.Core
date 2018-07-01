//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;


using static metacore;

/// <summary>
/// Specifies the name of a <see cref="ClrEnum"/>
/// </summary>
public sealed class ClrEnumName : ClrTypeName<ClrEnumName>
{
    public static ClrEnumName Define(string Name)
        => Name;

    public static readonly ClrEnumName Anonymous 
        = new ClrEnumName();

    public static implicit operator ClrEnumName(string x) 
        => new ClrEnumName(x);

    public ClrEnumName(params ClrItemIdentifier[] Components)
        : base(Components)
    { }

    public ClrEnumName Rename(string NewName)
        => new ClrEnumName(array(ParentComponents, new ClrItemIdentifier(NewName)).ToArray());

    public ClrEnumName Edit(Func<string, string> f)
        => Rename(f(SimpleName.Value));
}
