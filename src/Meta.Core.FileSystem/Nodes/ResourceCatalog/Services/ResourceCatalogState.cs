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

    class ResourceCatalogState
    {
        readonly Dictionary<SystemResourceUrn, CatalogSubject> SubjectsByUrn;

        readonly Dictionary<Type, CatalogSubject> SubjectsByType;

        readonly Dictionary<Type, CatalogSubject> LeadingSubjects;

        

        public ResourceCatalogState()
        {
            this.SubjectsByType = new Dictionary<Type, CatalogSubject>();
            this.LeadingSubjects = new Dictionary<Type, CatalogSubject>();
            this.SubjectsByUrn = new Dictionary<SystemResourceUrn, CatalogSubject>();
        
        }


        static IEnumerable<CatalogSubject> Descendents(CatalogSubject parent, SystemUri.SchemeSegment scheme)
        {
            foreach (var childType in parent.GetType().GetNestedTypes())
            {
                var child = (CatalogSubject)Activator.CreateInstance(childType, parent);
                yield return child;

                foreach (var grandchild in Descendents(child,scheme))
                    yield return grandchild;
            }

        }

        static IEnumerable<CatalogSubject> Descendents<S>(SystemUri.SchemeSegment scheme)
                    where S : CatalogSubject, new() => Descendents(new S(),scheme);

        public void Add<S>(SystemUri.SchemeSegment scheme)
            where S : CatalogSubject<S>, new()
        {

            LeadingSubjects[typeof(S)] = new S();
            var descendents = Descendents<S>(scheme).ToDictionary(d => d.GetType());
            SubjectsByType.AddRange(descendents);
            foreach(var d in descendents)
            {
                SubjectsByUrn.Add(d.Value.Urn, d.Value);
            }
         
        }


        public IEnumerable<CatalogSubject> FindDescendents(CatalogSubject parent)
            => SubjectsByType.Values.Where(subect => object.ReferenceEquals(subect.Parent, parent));

        public IReadOnlyDictionary<Type, CatalogSubject> TopSubjects
            => this.LeadingSubjects;

        public IReadOnlyDictionary<Type, CatalogSubject> SubjectTypeIndex
            => SubjectsByType;

        public IReadOnlyDictionary<SystemResourceUrn, CatalogSubject> SubjectUrnIndex
            => this.SubjectsByUrn;
    }



}