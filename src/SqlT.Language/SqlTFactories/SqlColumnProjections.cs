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
    using SqlT.Language;
    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    using sx = Syntax.SqlSyntax;
    using sxc = Syntax.contracts;


    public static partial class SqlTFactory
    {
        public static SqlProjector ModelProjector(this TSql.CreateFunctionStatement tsql, string QueryType,
            SqlElementDescription Documentation, string QueryPeer, IEnumerable<SqlPropertyAttachment> Properties)
        {
            var body = (TSql.FunctionStatementBody)tsql;
            var returnType = (TSql.SelectFunctionReturnType)body.ReturnType;
            var select = returnType.SelectStatement;
            var sourceName = select.SourceTableNames().Single();
            var functionName = tsql.Name.ToFunctionName();
            var parameters = tsql.ModelParameters();
            var columns = select.ModelColumnProjections();

            return new SqlProjector
                (
                    SourceTableName: sourceName,
                    FunctionName: functionName,
                    Parameters: parameters,
                    Columns: columns,
                    QueryPattern: select.GetFragmentText(),
                    Documentation: Documentation,
                    QueryType: QueryType,
                    QueryPeer: QueryPeer,
                    Properties: Properties
                );
        }

        [SqlTBuilder]
        public static IReadOnlyList<SqlColumnProjection> ModelColumnProjections(this TSql.SelectStatement tsql)
        {
            var resultColumns = new List<SqlColumnProjection>();
            var qx = tsql.QueryExpression;
            if (qx.GetType() == typeof(TSql.QuerySpecification))
            {
                var querySpec = (TSql.QuerySpecification)qx;
                var idx = 0;
                foreach (var se in querySpec.SelectElements)
                {
                    if (se.GetType() == typeof(TSql.SelectScalarExpression))
                    {
                        var ssx = (TSql.SelectScalarExpression)se;

                        var colname = string.Empty;
                        if (ssx.ColumnName != null && ssx.ColumnName.ValueExpression == null)
                        {
                            colname = ssx.ColumnName.Identifier.Value;
                        }

                        if (resultColumns.Count <= idx)
                        {
                            resultColumns.Add(new SqlColumnProjection { ProjectedColumnName = colname });
                        }

                        ssx.Expression.AddScalarExpressionRecursive(resultColumns, idx);

                    }
                    idx = idx + 1;
                }

                foreach (var tr in querySpec.FromClause.TableReferences)
                    tr.ReferenceColumns(resultColumns);
            }

            foreach (var cp in resultColumns)
            {
                if (string.IsNullOrWhiteSpace(cp.ProjectedColumnName))
                    cp.ProjectedColumnName = cp.SourceColumnName;
            }
            return resultColumns;
        }

        static void AddScalarExpressionRecursive(this TSql.ScalarExpression sx, IList<SqlColumnProjection> columns, int colidx)
        {
            if (sx.GetType() == typeof(TSql.ColumnReferenceExpression))
            {
                var colref = (TSql.ColumnReferenceExpression)sx;
                AddReferenceIdentifier(columns[colidx], colref.MultiPartIdentifier);
            }
            else if (sx.GetType() == typeof(TSql.ConvertCall))
            {
                var convert = (TSql.ConvertCall)sx;
                convert.Parameter.AddScalarExpressionRecursive(columns, colidx);
            }
            else if (sx.GetType() == typeof(TSql.FunctionCall))
            {
                var f = (TSql.FunctionCall)sx;
                if (f.FunctionName.Value.ToLower() == "isnull")
                {
                    f.Parameters[0].AddScalarExpressionRecursive(columns, colidx);
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
        }

        static void AddReferenceIdentifier(SqlColumnProjection column, TSql.MultiPartIdentifier mpi)
        {
            int identidx = 0;
            foreach (var identifier in mpi.Identifiers)
            {
                if (mpi.Identifiers.Count == 2)
                {
                    if (identidx == 0)
                        column.SourceTableAlias = identifier.Value;
                    if (identidx == 1)
                        column.SourceColumnName = identifier.Value;
                }
                if (mpi.Identifiers.Count == 3)
                {
                    if (identidx == 0)
                        column.SourceTableSchema = identifier.Value;
                    if (identidx == 1)
                        column.SourceTableName = identifier.Value;
                    if (identidx == 2)
                        column.SourceColumnName = identifier.Value;
                }

                identidx = identidx + 1;
            }
        }

        static void ReferenceColumns(this TSql.TableReference tr, IReadOnlyList<SqlColumnProjection> columns)
        {
            if (tr.GetType() == typeof(TSql.NamedTableReference))
            {
                var ntr = (TSql.NamedTableReference)tr;
                ntr.SchemaObject.ReferenceAliasedColumns(ntr.Alias, columns);

            }
            if (tr.GetType() == typeof(TSql.QualifiedJoin))
            {
                var qj = (TSql.QualifiedJoin)tr;
                qj.FirstTableReference.ReferenceColumns(columns);
                qj.SecondTableReference.ReferenceColumns(columns);
            }
            if (tr.GetType() == typeof(TSql.JoinTableReference))
            {
                var jtr = (TSql.JoinTableReference)tr;
                jtr.FirstTableReference.ReferenceColumns(columns);
                jtr.SecondTableReference.ReferenceColumns(columns);
            }
        }

        static void ReferenceAliasedColumns(this TSql.SchemaObjectName tableName, TSql.Identifier alias, IReadOnlyList<SqlColumnProjection> columns)
        {
            foreach (var column in columns)
            {
                if (alias != null &&
                    column.SourceTableAlias.ToLower() == alias.Value.ToLower())
                {
                    if (tableName.ServerIdentifier != null)
                        column.SourceTableServer = tableName.ServerIdentifier.Value;
                    if (tableName.DatabaseIdentifier != null)
                        column.SourceCatalogName = tableName.DatabaseIdentifier.Value;
                    if (tableName.SchemaIdentifier != null)
                        column.SourceTableSchema = tableName.SchemaIdentifier.Value;
                    if (tableName.BaseIdentifier != null)
                        column.SourceTableName = tableName.BaseIdentifier.Value;
                }
                else if ((alias == null) &&
                            (tableName.BaseIdentifier != null) &&
                            (tableName.BaseIdentifier.Value.ToLower() == column.SourceTableAlias.ToLower()))
                {
                    if (tableName.ServerIdentifier != null)
                        column.SourceTableServer = tableName.ServerIdentifier.Value;
                    if (tableName.DatabaseIdentifier != null)
                        column.SourceCatalogName = tableName.DatabaseIdentifier.Value;
                    if (tableName.SchemaIdentifier != null)
                        column.SourceTableSchema = tableName.SchemaIdentifier.Value;
                    if (tableName.BaseIdentifier != null)
                        column.SourceTableName = tableName.BaseIdentifier.Value;
                }
            }
        }

    }

}