//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System.Collections.Generic;

    using Meta.Models;
    using Meta.Syntax;

    using sxc = contracts;
    using static metacore;

    using SqlT.Core;

    partial class SqlSyntax
    {

        public sealed class common_table_expression : Model<common_table_expression>, sxc.named_expression
        {
            public common_table_expression(SqlExpressionName name, IEnumerable<SqlColumnName> columns = null)
            {
                this.name = name;
                this.columns = new column_list(array(columns ?? stream<SqlColumnName>()));
            }

            public SqlExpressionName name { get; }

            public select_list columns { get; }

            IName sxc.named_expression.name
                => name;
        }


    }
}