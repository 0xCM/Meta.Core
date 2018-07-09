//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Linq;

    using SqlT.Core;
    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    using sx = Syntax.SqlSyntax;

    public static partial class SqlTFactory
    {
        [SqlTBuilder]
        public static sx.column_ref Model(this TSql.ColumnReferenceExpression tsql)
           => tsql.ColumnName();
    }
}