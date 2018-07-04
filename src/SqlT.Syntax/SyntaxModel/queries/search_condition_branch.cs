//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{

    using System;
    using System.Collections.Generic;

    using Meta.Models;

    using static metacore;

    partial class SqlSyntax
    {

        public class search_condition_branch : du<predicate_negation, predicate, search_condition>
        {

            public static implicit operator search_condition_branch(predicate_negation x)
                => new search_condition_branch(x);

            public static implicit operator search_condition_branch(predicate x)
                => new search_condition_branch(x);

            public static implicit operator search_condition_branch(search_condition x)
                => new search_condition_branch(x);

            public search_condition_branch(predicate_negation x)
                : base(x)
            { }

            public search_condition_branch(predicate x)
                : base(x)
            { }

            public search_condition_branch(search_condition x)
                : base(x)
            { }
        }
    }
}