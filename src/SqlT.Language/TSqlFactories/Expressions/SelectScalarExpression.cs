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
    using SqlT.Syntax;
    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;


    public static partial class TSqlFactory
    {

        public static TSql.SelectScalarExpression TSqlSelectScalarExpression(this SqlColumnProxySelection src)
            => new TSql.SelectScalarExpression
            {
                ColumnName = src.HasColumnAlias ? new TSql.IdentifierOrValueExpression
                {
                    Identifier = src.ColumnAlias.TSqlIdentifier()
                } : null,
                Expression = new TSql.ColumnReferenceExpression
                {
                    MultiPartIdentifier = src.TSqlCompositeIdentifier()
                }
            };


        public static IReadOnlyList<TSql.SelectScalarExpression> TSqlSelectScalarExpressions(this IEnumerable<SqlColumnProxySelection> src)
            => src.Map(c => c.TSqlSelectScalarExpression());
    }
}