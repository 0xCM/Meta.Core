//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Resources
{
    using System.Collections.Generic;

    public interface IResourceCatalog
    {
        IEnumerable<CatalogSubject> Children(CatalogSubject parent);
        Option<CatalogSubject> TryFindSubject(SystemResourceUrn urn);

        IEnumerable<CatalogSubject> Children<S>()
                    where S : CatalogSubject, new();
        S Subject<S>()
            where S : CatalogSubject;

        void RegisterSubject<S>(SystemUri.SchemeSegment scheme = null)
            where S : CatalogSubject<S>, new();
        
        IEnumerable<CatalogSubject> KnownSubjects { get; }

    }

}