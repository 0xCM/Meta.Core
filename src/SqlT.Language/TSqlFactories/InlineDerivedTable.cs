//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Language;
    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    using SqlT.Syntax;
    using static SqlT.Syntax.SqlSyntax;

    public static partial class TSqlFactory
    {
        [TSqlBuilder]
        public static TSql.RowValue TSqlRowValue(this row_value_expression src)
        {
            var dst = new TSql.RowValue();
            dst.ColumnValues.AddRange(src.CellValues.Select(c => c.TSqlLiteral()));
            return dst;
        }

        [TSqlBuilder]
        public static TSql.InlineDerivedTable TSqlCreate(this table_value_constructor src)
        {
            var table = new TSql.InlineDerivedTable();
            src.Alias.OnSome(
                a => table.Alias = a.TSqlIdentifier());
            table.RowValues.AddRange(src.Rows.Select(r => r.TSqlRowValue()));
            return table;
        }

    }
}