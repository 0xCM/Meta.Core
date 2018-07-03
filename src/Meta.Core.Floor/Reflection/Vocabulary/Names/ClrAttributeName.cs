//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;

using static metacore;


/// <summary>
/// Specifies the name of a <see cref="ClrAttribute"/>
/// </summary>
public sealed class ClrAttributeName : ClrTypeName<ClrAttributeName>
{
    public static ClrAttributeName Define(string Name)
        => Name;

    public static readonly ClrAttributeName Anonymous 
        = new ClrAttributeName();

    public static implicit operator ClrAttributeName(string x) 
        => new ClrAttributeName(x);

    public ClrAttributeName(params ClrItemIdentifier[] Components)
        : base(Components)
    { }

    public ClrAttributeName(IEnumerable<ClrTypeParameterName> ParameterNames, params ClrItemIdentifier[] Components)
        : base(ParameterNames, Components)
    { }

    public ClrAttributeName Rename(string NewName)
        => new ClrAttributeName(list(ParentComponents, new ClrItemIdentifier(NewName)));

    public ClrAttributeName Edit(Func<string, string> f)
        => Rename(f(SimpleName.Value));
}
