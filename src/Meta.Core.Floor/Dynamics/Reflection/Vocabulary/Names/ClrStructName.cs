//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;




/// <summary>
/// Specifies the name of a <see cref="ClrStruct"/>
/// </summary>
public sealed class ClrStructName : ClrTypeName<ClrStructName>
{

    public static ClrStructName Define(string Name)
        => Name;

    public static readonly ClrStructName Anonymous = new ClrStructName();

    public static implicit operator ClrStructName(string x)
        => new ClrStructName(x);

    public ClrStructName(params ClrItemIdentifier[] Components)
        : base(Components)
    { }
    public ClrStructName(IEnumerable<ClrTypeParameterName> ParameterNames, params ClrItemIdentifier[] Components)
        : base(ParameterNames, Components)
    { }

}

