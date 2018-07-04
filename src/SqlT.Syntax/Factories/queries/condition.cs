//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using static SqlSyntax;

    using static metacore;
    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    partial class sql
    {
        public static search_condition condition(between_expression between)
            => new search_condition(new search_condition_branch(new between_predicate(between)));

        public static search_condition condition(predicate predicate)
            => new search_condition(predicate);

        public static search_condition condition(search_condition left, kwt.AND AND, predicate right)
            => new search_condition(left, new search_junction(AND, right));

        public static search_condition condition(predicate left, kwt.AND AND, predicate right)
            => new search_condition(condition(left), new search_junction(AND, right));

        public static search_condition condition(search_condition left, kwt.OR OR, predicate right)
            => new search_condition(left, new search_junction(OR, right));

        public static search_condition condition(kwt.NOT NOT, predicate predicate)
            => new search_condition(new predicate_negation(predicate));

        public static search_condition condition(predicate left, kwt.OR OR, predicate right)
            => new search_condition(condition(left), new search_junction(OR, right));

        public static search_condition condition(predicate left, kwt.OR OR, kwt.NOT NOT, predicate right)
            => new search_condition(condition(left), new search_junction(OR, new predicate_negation(right)));

        public static search_condition condition(predicate left, kwt.AND AND, kwt.NOT NOT, predicate right)
            => new search_condition(condition(left), new search_junction(AND, new predicate_negation(right)));

    }

}