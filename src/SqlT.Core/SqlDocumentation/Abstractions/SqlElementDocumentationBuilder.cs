//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Meta.Core;

    public abstract class SqlElementDocumentationBuilder<B,T,D,N>
        where B : SqlElementDocumentationBuilder<B, T, D, N>
        where T : ISqlProxy
        where D : SqlElementDocumetation<N>, new()
        where N : SqlName<N>, new()
   {
        protected readonly D ElementDocumentation;

        protected SqlElementDocumentationBuilder()
            : this(new D())
        {

        }

        protected SqlElementDocumentationBuilder(D ElementDocumentation)
        {
            this.ElementDocumentation = ElementDocumentation;
        }

        public B WithFacet<V>(string name, V value)
        {
            ElementDocumentation.SetFacet(new Facet<V>(name, value));
            return (B)this;
        }

        public B WithFacet<V>(IFacet<V> facet)
        {
            ElementDocumentation.SetFacet(facet);
            return (B)this;

        }

        public B WithFacets(params IFacet[] facets)
        {
            foreach (var facet in facets)
                ElementDocumentation.SetFacet(facet);
            return (B)this;
        }




    }

}