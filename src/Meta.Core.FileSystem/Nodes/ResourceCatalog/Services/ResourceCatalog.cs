//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Resources
{

    using System;
    using System.Collections.Generic;
    using System.Linq;    

    using static metacore;


    class ResourceCatalog : ApplicationService<ResourceCatalog, IResourceCatalog>, IResourceCatalog
    {

        readonly ResourceCatalogState CatalogState;

        public ResourceCatalog(IApplicationContext C)
            : base(C)
        {

            this.CatalogState = new ResourceCatalogState();
        }

        public void RegisterSubject<S>(SystemUri.SchemeSegment scheme)
            where S : CatalogSubject<S>, new()        
                => CatalogState.Add<S>(scheme);


        public IEnumerable<CatalogSubject> KnownSubjects
            => CatalogState.SubjectUrnIndex.Values;

        public IEnumerable<CatalogSubject> Children(CatalogSubject parent)
            => CatalogState.FindDescendents(parent);        

        IEnumerable<CatalogSubject> IResourceCatalog.Children<S>()
            => CatalogState.FindDescendents(CatalogState.SubjectTypeIndex[typeof(S)]);

        public S Subject<S>() where S : CatalogSubject
            => (S)CatalogState.SubjectTypeIndex[typeof(S)];

        public Option<CatalogSubject> TryFindSubject(SystemResourceUrn urn)
            => CatalogState.SubjectUrnIndex.TryFind(urn);

    }

    

}
