//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Linq;   
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;
    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    partial class TSqlFactory
    {
        [TSqlBuilder]
        public static TSql.MergeStatement TSqlStatement(this SqlMergeStatement src)
        {

            if (src.MatchColumns.Count == 0)
                throw new ArgumentException("No columns specified for match");

            var match = rolist(from c in src.MatchColumns
                               let l = c.TargetColumn.WithSourceAlias(src.TargetAlias)
                               let r = c.SourceColumn.WithSourceAlias(src.SourceAlias)
                               let ct = TSql.BooleanComparisonType.Equals
                               select l.TSqlBooleanComparison(ct, r));

            var search = match.Count == 1 
                        ? match.Single() 
                        : (TSql.BooleanExpression)match.And();


            var srcRef = src.Source.TSqlVariableTableRef(src.SourceAlias);


            var target = src.HoldLock ? src.Target.TSqlRef().WithHoldLock() : src.Target.TSqlRef();
            var spec = new TSql.MergeSpecification
            {
                TableReference = srcRef,
                Target = target,
                SearchCondition =  search,
                TableAlias = src.TargetAlias.TSqlIdentifier(false)
            };
            spec.ActionClauses.Add(src.TSqlInsertClause());
            spec.ActionClauses.Add(src.TSqlUpdateClause());
            if(src.WhenNotMatchedBySourceDelete)
            {
                var delete = new TSql.MergeActionClause
                {
                    Condition = TSql.MergeCondition.NotMatchedBySource,
                    Action = new TSql.DeleteMergeAction()
                };
                spec.ActionClauses.Add(delete);
            }

            var statement = new TSql.MergeStatement
            {
                MergeSpecification = spec
            };

            return statement;
        }

        public static TSql.MergeActionClause TSqlInsertClause(this SqlMergeStatement src)
        {
            var values = new TSql.ValuesInsertSource();
            var rowValue = new TSql.RowValue();
            rowValue.ColumnValues.AddRange(src.ColumnMappings.Map(c => c.SourceColumn.TSqlColumnRef(src.SourceAlias)));
            values.RowValues.Add(rowValue);

            var action = new TSql.InsertMergeAction
            {
                Source = values                                   
            };
            action.Columns.AddRange(src.ColumnMappings.Map(c => c.TargetColumn.TSqlColumnRef()));
            var clause = new TSql.MergeActionClause
            {
                Action = action,
                Condition = TSql.MergeCondition.NotMatched
            };
            return clause;
        }

        public static TSql.MergeActionClause TSqlUpdateClause(this SqlMergeStatement src)
        {
            var action = new TSql.UpdateMergeAction();
            var columns = from c in src.ColumnMappings where not(c.IsMatchColumn) select c;
            var assignments = columns.Map(c => new TSql.AssignmentSetClause
            {
                AssignmentKind = TSql.AssignmentKind.Equals,
                Column = c.TargetColumn.TSqlColumnRef(src.TargetAlias),
                NewValue = c.SourceColumn.TSqlColumnRef(src.SourceAlias)
            });
            action.SetClauses.AddRange(assignments);
            var clause = new TSql.MergeActionClause
            {
                Action = action,
                Condition = TSql.MergeCondition.Matched
            };


            var srcSpec = columns.Select(x => x.SourceColumn.WithSourceAlias(src.SourceAlias))
                                      .TSqlSelectScalarExpressions()
                                      .Query();
            var dstSpec = columns.Select(x => x.TargetColumn.WithSourceAlias(src.TargetAlias))
                                      .TSqlSelectScalarExpressions()
                                      .Query();

            clause.SearchCondition = srcSpec.ScalarIntersection(dstSpec).IsEmpty();

            return clause;
        }

        public static TSql.ColumnReferenceExpression TSqlColumnRef(this SqlColumnProxySelection src, string alias = null)
        {

            var _alias = alias ?? (src.HasSourceAlias ? src.SourceAlias : null);
            var components = _alias != null ? stream(_alias, src.ColumnName.UnqualifiedName) : stream(src.ColumnName.UnqualifiedName);

            return new TSql.ColumnReferenceExpression
            {
                MultiPartIdentifier = components.TSqlCompositeIdentifier(false)
            };

        }

    }
}
