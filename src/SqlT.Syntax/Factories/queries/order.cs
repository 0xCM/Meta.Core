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
    using static metacore;
    using sxc = contracts;
    using sx = SqlSyntax;
    using kwt = SqlKeywordTypes;
    using static SqlSyntax;

    public static partial class sql
    {

        public static order_by_clause order(kwt.BY BY, column_list columns)
            => new order_by_clause(columns);

        public static order_by_clause order(kwt.BY BY, column_list columns, kwt.ASC asc)
            => new order_by_clause(columns, asc);

        public static order_by_clause order(kwt.BY BY, column_list columns, kwt.DESC desc)
            => new order_by_clause(columns, desc);
    }
}