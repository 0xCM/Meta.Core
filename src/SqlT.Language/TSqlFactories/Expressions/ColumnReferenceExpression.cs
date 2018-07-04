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


    public static partial class TSqlFactory
    {
        public static TSql.ColumnReferenceExpression TSqlColumnRef(this ISqlColumn src)
            => src.Name.TSqlColumnRef();

        public static TSql.ColumnReferenceExpression TSqlColumnRef(this SqlIndexColumn src)
            => new TSql.ColumnReferenceExpression
            {
                MultiPartIdentifier = src.ColumnName.UnqualifiedName.TSqlMultiPartIdentifier()
            };

        public static TSql.ColumnReferenceExpression TSqlColumnRef(this SqlColumnName src)
            => new TSql.ColumnReferenceExpression
            {
                MultiPartIdentifier = src.UnqualifiedName.TSqlMultiPartIdentifier()
            };

        public static TSql.ColumnReferenceExpression TSqlColumnRef(this ISqlConstraintColumn src)
            => src.ConstrainedColumn.TSqlColumnRef();
    }
}