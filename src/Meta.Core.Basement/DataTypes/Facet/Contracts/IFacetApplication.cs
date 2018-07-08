//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------

public interface IFacetApplication
{
    IFacet Facet { get; }

    object Target { get; }
}

public interface IFacetApplication<out T> : IFacetApplication
{
    new T Target { get; }
}

public interface IFacetApplication<out F, out T> : IFacetApplication<T>
    where F : IFacet
{
    new F Facet { get; }
}
