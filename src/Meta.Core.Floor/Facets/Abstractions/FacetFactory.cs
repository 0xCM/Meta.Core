//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

public abstract class FacetFactory : IFacet
{
    public static Facet<T> MinLength<T>(T value)
        => Facet.Create(CommonFacetNames.MinLength, value);

    public static Facet<T> MaxLength<T>(T value)
        => Facet.Create(CommonFacetNames.MaxLength, value);

    public static Facet<T> Min<T>(T value)
        => Facet.Create(CommonFacetNames.Min, value);

    public static Facet<T> Max<T>(T value)
        => Facet.Create(CommonFacetNames.Max, value);

    public static Facet<bool> Required(bool value)
        => Facet.Create(CommonFacetNames.Required, value);

    public static Facet<T> Precision<T>(T value)
        => Facet.Create(CommonFacetNames.Precision, value);

    public static Facet<T> Scale<T>(T value)
        => Facet.Create(CommonFacetNames.Scale, value);

    public static Facet<string> Pattern(string value)
        => Facet.Create(CommonFacetNames.Pattern, value);

    protected FacetFactory(string FacetName, object FacetValue)
    {
        this.FacetName = FacetName;
        this.FacetValue = FacetValue;
    }

    object FacetValue { get; }
    public string FacetName { get; }
        

    object IFacet.FacetValue { get; }
        
}

public abstract class FacetFactory<V> : FacetFactory, IFacet<V>
{
    public FacetFactory(string FacetName, V FacetValue)
        : base(FacetName, FacetValue)
    {


    }

    public V FacetValue
        => (V)(this as IFacet).FacetValue;
        
}