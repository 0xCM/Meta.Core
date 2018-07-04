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
    using sx = Syntax.SqlSyntax;
    using sxc = Syntax.contracts;

    public static partial class SqlTFactory
    {
        [TSqlBuilder]
        public static SqlTableColumn ModelTableColumn(this TSql.ColumnDefinition tsql, int position)
        {
            var dt = tsql.DataType as TSql.SqlDataTypeReference;
            if (dt == null)
                throw new NotSupportedException();

            var xdt = dt.ModelReference(tsql.IsNullable());

            var dfContraint = tsql.DefaultConstraint != null ?
                              new SqlDefaultConstraint
                              (
                                  tsql.DefaultConstraint.ConstraintName(),
                                  tsql.DefaultConstraint.Expression.GetFragmentText()
                              )
                              : null;

            return new SqlTableColumn
                (
                    Position: position,
                    LocalName: tsql.ColumnIdentifier.Value,
                    DataType: xdt,
                    DefaultConstraint: dfContraint
                );
        }



    }
}