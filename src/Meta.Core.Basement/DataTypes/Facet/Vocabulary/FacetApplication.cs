//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------

public readonly struct FacetApplication<F,T> : IFacetApplication<F,T>
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


public readonly struct FacetApplication<T> : IFacetApplication 
{
    public FacetApplication(FacetInfo Facet, T Target)
    {
        this.Facet = Facet;
        this.Target = Target;

    }

    public FacetInfo Facet { get; }
    public T Target { get; }


    IFacet IFacetApplication.Facet
        => Facet;

    object IFacetApplication.Target
        => Target;
}