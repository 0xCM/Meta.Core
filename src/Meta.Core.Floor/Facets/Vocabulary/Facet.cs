//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

public struct Facet : IFacet
{
    public Facet(string Name, object Value)
    {
        this.FacetName = Name;
        this.FacetValue = Value;
    }
    public string FacetName { get; }

    public object FacetValue { get; }


    public static Facet<T> Create<T>(string Name, T Value)
        => new Facet<T>(Name, Value);
}

public struct Facet<V> : IFacet<V>
{
    public static implicit operator V(Facet<V> f) => f.FacetValue;

    private readonly string _Name;
    private readonly V _Value;

    public Facet(string Name, V Value)
    {
        this._Name = Name;
        this._Value = Value;
    }

    public string FacetName
        => _Name;

    public V FacetValue
        => _Value;

    object IFacet.FacetValue
        => _Value;

    public override string ToString()
        => $"{FacetName} = {FacetValue}";
}
