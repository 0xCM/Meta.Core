//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

public class FacetSet : IFacetSet
{

    IReadOnlyDictionary<string, IFacet> Facets { get; }

    public FacetSet(params IFacet[] facets)
    {
        Facets = facets.ToDictionary(f => f.FacetName);
    }

    public FacetSet(IEnumerable<IFacet> facets)
    {
        Facets = facets.ToDictionary(f => f.FacetName);
    }

    public Option<IFacet> TryFind(string Name)
        => Facets.TryFind(Name);

    public Option<IFacet<V>> TryFind<V>(string Name, bool AllowConversion)
        => Facets.TryFind(Name).Map(
                z => z is IFacet<V>
                  ? z as IFacet<V>
                  : (AllowConversion ? FacetConverter.Create<V>(z) : null));

    public IFacet<V> FindOrElse<V>(string Name, V Else, bool AllowConversion)
        => TryFind<V>(Name, AllowConversion).ValueOrElse(() => FacetInfo.Create(Name, Else));

    public V FindValueOrElse<V>(string Name, V Else, bool AllowConversion)
        => FindOrElse<V>(Name, Else, AllowConversion).FacetValue;

    public IEnumerable<IFacet> Members
        => Facets.Values;

}
