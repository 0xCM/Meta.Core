//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------


public class FacetApplication<F,T> : IFacetApplication<F,T>
    where F : IFacet
{

    public FacetApplication(F Facet, T Target)
    {
        this.Facet = Facet;
        this.Target = Target;

    }

    public F Facet { get; }

    public T Target { get; }

    F IFacetApplication<F,T>.Facet
        => Facet;

    IFacet IFacetApplication.Facet
        => Facet;

    T IFacetApplication<T>.Target
        => Target;

    object IFacetApplication.Target
        => Target;
}


public class FacetApplication<T> : IFacetApplication 
{
    public FacetApplication(Facet Facet, T Target)
    {
        this.Facet = Facet;
        this.Target = Target;

    }

    public Facet Facet { get; }
    public T Target { get; }


    IFacet IFacetApplication.Facet
        => Facet;

    object IFacetApplication.Target
        => Target;
}