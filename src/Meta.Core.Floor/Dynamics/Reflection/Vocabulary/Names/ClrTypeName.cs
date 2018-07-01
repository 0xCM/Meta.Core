//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;


using static metacore;

public abstract class ClrTypeName<T> : ClrElementName<T>, IClrTypeName
    where T : ClrTypeName<T>
{
    public static implicit operator ClrTypeReference(ClrTypeName<T> x)
        => x.CreateReference();

    public static implicit operator ClrTypeName(ClrTypeName<T> x)
        => new ClrTypeName(x);

    protected ClrTypeName(params ClrItemIdentifier[] Components)
        : base(Components)
    {
    }

    protected ClrTypeName(IEnumerable<ClrTypeParameterName> ParameterNames, params ClrItemIdentifier[] Components)
        : base(ParameterNames, Components)
    {
        
    }

    public ClrTypeReference CreateReference()
        => new ClrTypeReference(this);

    public override string ToString()
        => $"{string.Join("/", Components)}";
}


public sealed class ClrTypeName : IClrTypeName
{
    public static ClrTypeName Empty = Define();

    public static implicit operator ClrTypeName(string SimpleName)
        => Define(SimpleName);

    public static ClrTypeName Define(params ClrItemIdentifier[] Components)
        => new ClrTypeName(Components);

    public static ClrTypeName Adapt(IClrTypeName Adapted)
        => new ClrTypeName(Adapted);

    Option<IClrTypeName> Adapted { get; }

    IReadOnlyList<ClrItemIdentifier> _Components { get; }
        = rolist<ClrItemIdentifier>();

    ClrTypeName(params ClrItemIdentifier[] Components)
    {
        _Components = Components.ToReadOnlyList();
    }

    public ClrTypeName(IClrTypeName TypeName)
    {
        Adapted = some(TypeName);
    }

    public IReadOnlyList<ClrItemIdentifier> Components
        => Adapted.Map(a => a.Components, 
            () => _Components);

    public ClrItemIdentifier SimpleName
        => Adapted.Map(a => a.SimpleName, 
            () => _Components.LastOrDefault());

}


