//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;
    using SqlT.Core;
    using SqlT.Syntax;

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

}