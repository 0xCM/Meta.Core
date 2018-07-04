//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System.Collections.Generic;

    using sxc = SqlT.Syntax.contracts;
   
    public class SqlElementDocumetation : ISqlElementDocumentation
    {
        public static readonly SqlElementDocumetation Empty = new SqlElementDocumetation();

        Dictionary<string, IFacet> facets = new Dictionary<string, IFacet>();

        protected SqlElementDocumetation()
        {
            Name = SqlName.Empty;
            Label = string.Empty;
            Description = string.Empty;
            Identifier = string.Empty;
        }

        protected SqlElementDocumetation(SqlName Name, string Label, string Description, string Identifier)
        {
            this.Name = Name;
            this.Label = Label;
            this.Description = Description;
            this.Identifier = Identifier;
        }

        SqlName Name { get; }

        public bool IsEmpty
            => Equals(this, Empty);


        SqlName ISqlElementDocumentation.Name
            => Name;

        public string Label { get; set; }

        /// <summary>
        /// The purpose of the element
        /// </summary>
        public string Description { get; set; }

        public string Identifier { get; set; }

        public IEnumerable<IFacet> Facets
            => facets.Values;

        public void SetFacet(IFacet facet)
        {
            facets[facet.FacetName] = facet;
        }

        public bool HasFacet(IFacet facet)
            => facets.ContainsKey(facet.FacetName);

        public IFacet GetFacet(string FacetName)
            => facets.ContainsKey(FacetName) ? facets[FacetName] : null;

        public IFacet<V> GetFacet<V>(string FacetName)
            => facets.ContainsKey(FacetName) ? (IFacet<V>)facets[FacetName] : null;

        public override string ToString()
            => Name;
    }

    public class SqlElementDocumetation<N>  : SqlElementDocumetation, ISqlElementDocumentation<N>
        where N : SqlName<N>, new()
    {

        protected SqlElementDocumetation()
        {
            this.Name = SqlName<N>.Empty;
        }

        protected SqlElementDocumetation(N Name, string Label, string Description, string Identifier)
            : base(Name, Label, Description, Identifier)
        {
            this.Name = Name;
        }

        public N Name { get; set; }
    }
}