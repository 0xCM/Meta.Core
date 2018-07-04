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
    using kwt = SqlKeywordTypes;

    partial class SqlSyntax
    {
        public sealed class order_by_column : order_by_expression<order_by_column>
        {           

            public order_by_column(sort_column column, string collation_name = null)
                : base(column.column, column.direction, collation_name)
            {

            }

            public override string ToString()
                => $"order by {column}";
        }
    }
}