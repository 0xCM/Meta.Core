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

        public static where_clause where(search_condition left, kwt.AND AND, predicate right)
            => new where_clause(condition(left, AND, right));

        public static where_clause where(between_expression between)
            => new where_clause(condition(between));

        public static where_clause where(predicate predicate)
            => new where_clause(condition(predicate));

        public static where_clause where(search_condition left, kwt.OR OR, predicate right)
            => new where_clause(condition(left, OR, right));

        public static where_clause where(kwt.NOT NOT, predicate predicate)
            => new where_clause(condition(NOT, predicate));

        public static where_clause where(predicate left, kwt.AND AND, predicate right)
            => new where_clause(condition(left, AND, right));

        public static where_clause where(predicate left, kwt.OR OR, predicate right)
            => new where_clause(condition(left, OR, right));

        public static where_clause where(predicate left, kwt.OR OR, kwt.NOT NOT, predicate right)
            => new where_clause(condition(left, OR, NOT, right));

        public static where_clause where(predicate left, kwt.AND AND, kwt.NOT NOT, predicate right)
            => new where_clause(condition(left, AND, NOT, right));

    }

}