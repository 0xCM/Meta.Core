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
    using SqlT.Services;
    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;


    public static partial class SqlTFactory
    {

        [SqlTBuilder]
        public static SqlPrimaryKey ModelPrimaryKey(this TSql.UniqueConstraintDefinition tsql, 
            IReadOnlyList<SqlTableColumn> cols)
        {
            var keyCols = tsql.Columns.Map(tcol =>
                new SqlPrimaryKeyColumn(cols.Single(x => x.Name == tcol.FormatName())));
            return new SqlPrimaryKey(tsql.PrimaryKeyName(), keyCols);
        }

    }
}