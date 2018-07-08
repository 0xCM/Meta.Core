//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------

public readonly struct FacetInfo : IFacet
{
    public FacetInfo(string Name, object Value)
    {
        this.FacetName = Name;
        this.FacetValue = Value;
    }

    public string FacetName { get; }

    public object FacetValue { get; }


    public static Facet<T> Create<T>(string Name, T Value)
        => new Facet<T>(Name, Value);
}
