//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using static metacore;

    using SqlT.Core;

    using sx = SqlT.Syntax.SqlSyntax;
    using sxc = SqlT.Syntax.contracts;

    /// <summary>
    /// Characterizes a (simple) insert statement
    /// </summary>
    public class SqlInsertStatement : SqlStatement<SqlInsertStatement>
    {
        public SqlInsertStatement(SqlSelectStatement Src, sxc.tabular_name Dst, bool TabLock = false,
                params SqlColumnAssociation[] ColumnAssociations) 
                    : base(sx.INSERT, Syntax.statement_kind.Insert)
        {
            this.Source = Src;
            this.Target = Dst;
            this.TabLock = TabLock;
        }

        public SqlSelectStatement Source { get; }

        public sxc.tabular_name Target { get; }

        public bool TabLock { get; }

        public IReadOnlyList<SqlColumnAssociation> ColumnAssociations { get; }
    }

}