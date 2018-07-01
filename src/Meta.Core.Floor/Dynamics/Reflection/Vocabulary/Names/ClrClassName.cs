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
/// Specifies the name of a <see cref="ClrClass"/>
/// </summary>
public sealed class ClrClassName : ClrTypeName<ClrClassName>
{
    public static ClrClassName Define(string Name)
        => Name;

    public static readonly ClrClassName Anonymous 
        = new ClrClassName();

    public static implicit operator ClrClassName(string x) 
        => new ClrClassName(x);

    public ClrClassName(params ClrItemIdentifier[] Components)
        : base(Components)
    { }

    public ClrClassName(IEnumerable<ClrTypeParameterName> ParameterNames, params ClrItemIdentifier[] Components)
        : base(ParameterNames, Components)
    { }

    public ClrClassName Rename(string NewName)
        => new ClrClassName(stream(ParentComponents, stream(new ClrItemIdentifier(NewName))).ToArray());

    public ClrClassName Edit(Func<string, string> f)
        => Rename(f(SimpleName.Value));

}
