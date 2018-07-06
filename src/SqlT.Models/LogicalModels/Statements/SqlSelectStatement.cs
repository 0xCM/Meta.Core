//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    using SqlT.Core;
    using SqlT.Syntax;

    using Meta.Models;

    using sxc = Syntax.contracts;
    using sx = SqlT.Syntax.SqlSyntax;

    /// <summary>
    /// Characterizes a simple select statement
    /// </summary>
    /// <typeparam name="M">A derived subtype</typeparam>
    public class SqlSelectStatement<M> : SqlStatement<M>
        where M : SqlSelectStatement<M>
    {
        public SqlSelectStatement(IEnumerable<sxc.clause> Clauses = null)
            : base(sx.SELECT, statement_kind.Select)
        {
            this.Clauses = ReadOnlyList.Create(Clauses);
        }

        public SqlSelectStatement(sxc.from_clause From, sxc.where_clause Where)
            : base(sx.SELECT, statement_kind.Select)
        {
            this.From = ModelOption.decide(From);
            this.Where = ModelOption.decide(Where);
            this.Clauses = ReadOnlyList.Create(array<sxc.clause>(From, Where));
        }

        public SqlSelectStatement(IEnumerable<SqlColumnIdentifier> Columns, SqlTableName Table)
            : base(sx.SELECT, statement_kind.Select)
        {
            this.From = new sx.from_clause(new sx.table_source(new sx.from_table_or_view(new sx.table_source_name(Table))));
            this.Clauses = rolist<sxc.clause>();
            this.Columns = Columns.ToReadOnlyList();;
        }

        public SqlSelectStatement(IEnumerable<SqlColumnName> Columns, sx.table_source source)
            : base(sx.SELECT, statement_kind.Select)
        {
            this.From = new sx.from_clause(source);
            this.Clauses = rolist<sxc.clause>();
            this.Columns = map(Columns, c => new SqlColumnIdentifier(c));
        }

        public SqlSelectStatement(IEnumerable<SqlColumnName> Columns, sxc.from_clause From = null)
            : base(sx.SELECT, statement_kind.Select)
        {
            this.From = ModelOption.decide(From);
            this.Clauses = rolist<sxc.clause>();
            this.Columns = map(Columns, c => new SqlColumnIdentifier(c));
        }

        public ReadOnlyList<sxc.clause> Clauses { get; }

        public ReadOnlyList<SqlColumnIdentifier> Columns { get; }

        public ModelOption<sxc.from_clause> From { get; }

        public ModelOption<sxc.where_clause> Where { get; }
    }

    public sealed class SqlSelectStatement : SqlSelectStatement<SqlSelectStatement>
    {
        public SqlSelectStatement(sxc.from_clause From, sxc.where_clause Where)
            : base(From, Where)
        {
        }

        public SqlSelectStatement(IEnumerable<sxc.clause> Clauses)
            : base(Clauses)
        { }

        public SqlSelectStatement(IEnumerable<SqlColumnName> Columns, sxc.from_clause From)
            : base(Columns, From)
        {
        }

        public SqlSelectStatement(IEnumerable<SqlColumnName> Columns, sx.table_source Source)
            : base(Columns, Source)
        {
        }
    }
}
