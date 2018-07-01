//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
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
