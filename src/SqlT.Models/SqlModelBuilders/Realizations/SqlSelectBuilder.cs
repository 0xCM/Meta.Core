//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Models;
    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;
    using static SqlT.Syntax.SqlSyntax;
    using sxc = SqlT.Syntax.contracts;


    public sealed class SqlSelectBuilder : SqlSelectBuilder<SqlSelectBuilder, column_name_provider>
    {
        public SqlSelectBuilder(SqlTableName source, params SqlColumnName[] columns)
        {
            Columns(columns);
            From(source);
        }

        public SqlSelectBuilder(SqlViewName source, params SqlColumnName[] columns)
        {
            From(source);
            Columns(columns);
        }

        public SqlSelectBuilder(SqlVariableName source, params SqlColumnName[] columns)
        {
            From(source);
            Columns(columns);
        }

        public SqlSelectBuilder(SqlFunctionName source, params SqlColumnName[] columns)
        {
            From(source);
            Columns(columns);
        }

        public override SqlSelectStatement Complete()
            => new SqlSelectStatement(ColumnSelection, base.from.value);
    }
}