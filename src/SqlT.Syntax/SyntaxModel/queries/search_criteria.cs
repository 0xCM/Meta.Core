//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{

    using System;
    using System.Collections.Generic;

    using Meta.Syntax;

    using kwt = SqlKeywordTypes;
    using sxc = contracts;

    using static metacore;

    partial class SqlSyntax
    {
        public class search_criteria : SyntaxList<search_junction>
        {

            public static implicit operator search_criteria(search_junction junction)
                => new search_criteria(stream(junction));

            public static implicit operator search_criteria(search_junction[] junctions)
                => new search_criteria(junctions);

            public search_criteria(params search_junction[] junctions)
                : base(junctions)
            {


            }

            public search_criteria(IEnumerable<search_junction> junctions)
                : base(junctions)
            {


            }

        }

    }

}