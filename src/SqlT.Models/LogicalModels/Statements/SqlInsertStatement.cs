//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
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