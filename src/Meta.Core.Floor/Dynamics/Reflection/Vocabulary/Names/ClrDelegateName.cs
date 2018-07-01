//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;



/// <summary>
/// Specifies the name of a <see cref="ClrDelegate"/>
/// </summary>
public sealed class ClrDelegateName : ClrTypeName<ClrDelegateName>
{
    public static ClrDelegateName Define(string Name)
        => Name;

    public static readonly ClrDelegateName Empty
        = new ClrDelegateName();

    public static implicit operator ClrDelegateName(string x)
        => new ClrDelegateName(x);
    public ClrDelegateName(params ClrItemIdentifier[] Components)
        : base(Components)
    { }

    public ClrDelegateName(IEnumerable<ClrTypeParameterName> ParameterNames, params ClrItemIdentifier[] Components)
        : base(ParameterNames, Components)
    { }
}

