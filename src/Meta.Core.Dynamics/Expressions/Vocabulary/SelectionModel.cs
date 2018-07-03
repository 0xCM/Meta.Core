//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Defines a set of members together with the criteria used to determine a selected collection
    /// </summary>
    public class SelectionModel 
    {
        readonly Expression X;

        public SelectionModel
        (
            Expression X, 
            MemberSelection SelectedMembers, 
            Option<MemberOrdering> Order, 
            IEnumerable<Junction> Junctions, 
            params SelectionFacet[] Facets
        )
        {
            this.X = X;
            this.MemberOrder = Order;
            this.SelectedMembers = SelectedMembers;
            this.Facets = Facets;
            this.Junctions = Junctions.ToList();
        }

        /// <summary>
        /// The members that represent the columns to be selected
        /// </summary>
        public MemberSelection SelectedMembers { get; }

        /// <summary>
        /// Optional order-by specification
        /// </summary>
        public Option<MemberOrdering> MemberOrder { get; }

        /// <summary>
        /// A sequence of con/dis-junctions that will fitler the results set
        /// and effectively represents a WHERE clausee
        /// </summary>
        public IReadOnlyList<Junction> Junctions { get; }

        /// <summary>
        /// Facets such as TOP and DISTINCT
        /// </summary>
        public IReadOnlyList<SelectionFacet> Facets { get; }
    }

    public static class LinqXtend
    {
        public static SelectionModel BuildSelectionModel<T>(this IQueryable<T> queryable, params SelectionFacet[] facets)
            => SelectionModelBuilder.CreateModel(queryable);
    }    
}
