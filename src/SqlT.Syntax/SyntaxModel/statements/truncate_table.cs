//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using static metacore;

    using sx = SqlT.Syntax.SqlSyntax;
    using sxc = contracts;
    using kwt = SqlT.Syntax.SqlKeywordTypes;

    using SqlT.Core;

    using static SqlSyntax;

    partial class SqlSyntax
    {
        

        public class truncate_table : statement<truncate_table>
        {
            public truncate_table(SqlTableName table_name)
                : base(TRUNCATE)
            {
                this.table_name = table_name;
            }

            public SqlTableName table_name { get; }
        }

    }



}