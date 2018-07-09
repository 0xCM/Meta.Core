//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Linq;

    using Meta.Core;

    using SqlT.Core;
    using SqlT.Models;

    using static metacore;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;


    public static partial class SqlTFactory
    {

        [SqlTBuilder]
        public static SqlPrimaryKey ModelPrimaryKey(this TSql.UniqueConstraintDefinition tsql, 
            Lst<SqlTableColumn> cols)
        {
            var keyCols = tsql.Columns.Map(tcol =>
                new SqlPrimaryKeyColumn(cols.Single(x => x.Name == tcol.FormatName()).Require()));
            return new SqlPrimaryKey(tsql.PrimaryKeyName(), keyCols);
        }

    }
}