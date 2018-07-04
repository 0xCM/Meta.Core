//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;
    using SqlT.Syntax;
    using System.Linq.Expressions;

    using Meta.Core;    

    /// <summary>
    /// Defines a correspondence between a source and target column to indicate that
    /// the source column is projected onto the target column during in insert or update
    /// </summary>
    public class SqlMergeColumn : ValueObject<SqlMergeColumn>
    {
        public SqlMergeColumn(SqlColumnProxySelection SourceColumn, SqlColumnProxySelection TargetColumn, bool IsMatchColumn = false)
        {
            this.SourceColumn = SourceColumn;
            this.TargetColumn = TargetColumn;
            this.IsMatchColumn = IsMatchColumn;
        }

        public SqlMergeColumn(SqlColumnProxySelection CommonColumn, bool IsMatchColumn = false)
        {
            this.SourceColumn = CommonColumn;
            this.TargetColumn = CommonColumn;
            this.IsMatchColumn = IsMatchColumn;
        }

        /// <summary>
        /// Identifies the source column
        /// </summary>
        public SqlColumnProxySelection SourceColumn { get; }

        /// <summary>
        /// Identifies the target column
        /// </summary>
        public SqlColumnProxySelection TargetColumn { get; }

        /// <summary>
        /// Indicates whether the column is included in the match predicate
        /// </summary>
        public bool IsMatchColumn { get; }

        public override string ToString()
            => $"{SourceColumn} => {TargetColumn}" + (IsMatchColumn ? " (match)" : String.Empty);
    }

    public class SqlMergeColumn<TSrc, TDst>  : SqlMergeColumn
        where TSrc : class, ISqlTabularProxy, new()
        where TDst : class, ISqlTableProxy, new()
    {

        static SqlTabularProxyInfo SrcTable
            = PXM.Tabular<TSrc>();

        static SqlTableProxyInfo DstTable
            = PXM.Table<TDst>();

        public SqlMergeColumn(Expression<Func<TSrc, object>> src, Expression<Func<TDst, object>> dst, bool match = false)
            : base
            (
                  
                  SrcTable.Columns.Single(c => c.ColumnName == src.GetValueMember().Name).Selection(),
                  DstTable.Columns.Single(c => c.ColumnName == dst.GetValueMember().Name).Selection(),
                  match
            )
        {
            
        }
    }
}