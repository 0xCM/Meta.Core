//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using static metacore;

/// <summary>
/// Ultimate base type for types that specify CLR element names
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class ClrElementName<T> : ValueObject<T>, IClrElementName
    where T : ClrElementName<T>
{
    public static implicit operator string(ClrElementName<T> x) 
        => x.SimpleName;

    protected ClrElementName(params ClrItemIdentifier[] Components)
    {
        this.Components = rolist(Components);
        this.ParameterNames = rolist<ClrTypeParameterName>();
    }

    protected ClrElementName(IEnumerable<ClrTypeParameterName> ParameterNames, params ClrItemIdentifier[] Components)
        : this(Components)
    {
        this.ParameterNames = rovalues(ParameterNames);
    }

    public IReadOnlyList<ClrItemIdentifier> Components { get; }

    public IReadOnlyList<ClrTypeParameterName> ParameterNames { get; }

    public IReadOnlyList<ClrItemIdentifier> ParentComponents
        => Components.Take(Components.Count - 1).ToList();

    public ClrItemIdentifier SimpleName
        => Components.FirstOrDefault(ClrItemIdentifier.Missing);

    public bool IsAnonymous
        => Components.Count == 0
        || Components.All(c => c.IsEmpty);

    public override string ToString()
        => SimpleName;
}

