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
    using SqlT.Templates;
    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    public static partial class TSqlFactory
    {
        [TSqlBuilder]
        public static TSql.SelectStatement TSqlStatement(this SqlSelectStatement select)
        {
            var spec = new TSql.QuerySpecification();
            foreach (var column in select.Columns)
            {
                spec.SelectElements.Add
                    (
                        new TSql.SelectScalarExpression
                        {
                            Expression = new TSql.ColumnReferenceExpression
                            {
                                MultiPartIdentifier = column.ColumnName.TSqlCompositeIdentifier()
                            }
                        }
                    );
            }
            return new TSql.SelectStatement{QueryExpression = spec};            
        }

        public static TSql.SelectStatement TSqlSelectStatement(this SqlColumnProxyList src)
        {
            var spec = new TSql.QuerySpecification();

            foreach (var column in src.Columns)
            {
                spec.SelectElements.Add(new TSql.SelectScalarExpression
                {
                    ColumnName = column.HasColumnAlias ? new TSql.IdentifierOrValueExpression
                    {
                        Identifier = column.ColumnAlias.TSqlIdentifier()
                    } : null,
                    Expression = new TSql.ColumnReferenceExpression
                    {
                        MultiPartIdentifier = column.TSqlCompositeIdentifier()
                    }
                });
            }
            var statement = new TSql.SelectStatement
            {
                QueryExpression = spec
            };
            return statement;
        }
    }
}