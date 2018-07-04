//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;
    using SqlT.Core;

    using P = Meta.Models.cdu<contracts.predicate,
        SqlSyntax.between_predicate,
        SqlSyntax.comparison_predicate,
        SqlSyntax.exists_predicate,
        SqlSyntax.like_predicate,
        SqlSyntax.nullity_predicate
        >;

    partial class SqlSyntax
    {
        /// <summary>
        /// See https://docs.microsoft.com/en-us/sql/t-sql/queries/search-condition-transact-sql
        /// </summary>
        public sealed class search_predicate : P
        {
            public static implicit operator search_predicate(between_predicate selection)
                => new search_predicate(selection);

            public static implicit operator search_predicate(comparison_predicate selection)
                => new search_predicate(selection);

            public static implicit operator search_predicate(exists_predicate selection)
                => new search_predicate(selection);

            public static implicit operator search_predicate(like_predicate selection)
                => new search_predicate(selection);

            public static implicit operator search_predicate(nullity_predicate selection)
                => new search_predicate(selection);

            public search_predicate(between_predicate selection)
                : base(selection)
            {

            }

            public search_predicate(comparison_predicate selection)
                : base(selection)
            {

            }

            public search_predicate(exists_predicate selection)
                : base(selection)
            {

            }

            public search_predicate(like_predicate selection)
                : base(selection)
            {

            }

            public search_predicate(nullity_predicate selection)
                : base(selection)
            {

            }
        }
    }
}