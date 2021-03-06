﻿//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using SqlT.Core;
    using SqlT.Syntax;
    using static metacore;
    using sx = SqlT.Syntax.SqlSyntax;
    using sxc = SqlT.Syntax.contracts;

    /// <summary>
    /// Characterizes a MERGE statement, or at least aspects thereof
    /// </summary>
    public class SqlMergeStatement : SqlStatement<SqlMergeStatement>
    {
        public SqlMergeStatement
            (
                SqlName SourceName,
                string SourceAlias,
                sxc.tabular_name TargetName,
                string TargetAlias,
                bool HoldLock = true,
                bool WhenNotMatchedBySourceDelete = false,
                params SqlMergeColumn[] ColumnMappings
            ) : base(sx.MERGE, statement_kind.Merge)
        {
            this.Source = SourceName;
            this.HoldLock = true;
            this.SourceAlias = SourceAlias;
            this.Target = TargetName;
            this.TargetAlias = TargetAlias;
            this.WhenNotMatchedBySourceDelete = WhenNotMatchedBySourceDelete;
            this.ColumnMappings = rovalues(ColumnMappings);
        }

        public SqlName Source { get; }

        public string SourceAlias { get; }

        public sxc.tabular_name Target { get; }

        public string TargetAlias { get; }

        /// <summary>
        /// Specifies whether the HOLD LOCK hint is applied to the taret table
        /// </summary>
        public bool HoldLock { get; }

        public IReadOnlyList<SqlMergeColumn> ColumnMappings { get; }

        public bool WhenNotMatchedBySourceDelete { get; }

        /// <summary>
        /// Gets the match columns defined for the merge
        /// </summary>
        public IReadOnlyList<SqlMergeColumn> MatchColumns
            => rolist(from c in ColumnMappings where c.IsMatchColumn select c);
    }


        
    
}
