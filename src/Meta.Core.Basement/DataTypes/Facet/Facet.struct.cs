//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------

public struct Facet<V> : IFacet<V>
{
    public static implicit operator V(Facet<V> f) => f.FacetValue;


    public Facet(string Name, V Value)
    {
        this.FacetName = Name;
        this.FacetValue = Value;
    }

    

    public string FacetName { get; }

    public V FacetValue { get; }

    object IFacet.FacetValue
        => FacetValue;

    public override string ToString()
        => $"{FacetName} = {FacetValue}";
}
