//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using SqlT.Core;
    using SqlT.Syntax;

    using sxc = Syntax.contracts;


    [SqlElementType(SqlElementTypeNames.DefaultConstraint)]
    public sealed class SqlDefaultConstraint :  SqlConstraint<SqlDefaultConstraint, SqlDefaultConstraintName>
    {
        public string DefaultExpression { get; }

        List<ISqlConstraintColumn> _ConstrainedColumns { get; }
            = new List<ISqlConstraintColumn>();

        public SqlDefaultConstraint(SqlDefaultConstraintName ObjectName, string DefaultExpression, SqlColumnName ConstrainedColumnName = null)
            : base(ObjectName)
        {
            this.DefaultExpression = DefaultExpression;
            this.ConstrainedColumnName = ConstrainedColumnName ?? SqlColumnName.Empty;
        
        }

        public SqlDefaultConstraint Rename(SqlDefaultConstraintName NewName)
            => new SqlDefaultConstraint(NewName, DefaultExpression);

        public override string ToString() 
            => $"{ObjectName}: {DefaultExpression}";

        public SqlColumnName ConstrainedColumnName { get; }


        protected override IReadOnlyList<ISqlConstraintColumn> GetConstrainedColumns()
            => _ConstrainedColumns;

        public static SqlDefaultConstraintName ConventionalName(sxc.ISqlObjectName TableName, SqlColumnName ColummName)
            => new SqlDefaultConstraintName($"DF_{TableName.UnqualifiedName}_{ColummName}");

    }

    public abstract class SqlDefaultConstraint<T, K, C> : SqlConstraint<K, SqlDefaultConstraintName>, sxc.default_constraint
        where T : ISqlTable
        where K : SqlDefaultConstraint<T, K, C>
    {

        protected SqlDefaultConstraint(Expression<Func<T, C>> Column, SqlDefaultConstraintName ConstraintName = null)
            : base(ConstraintName ?? new SqlDefaultConstraintName(typeof(K).Name))
        {

        }

        public C Column1 { get; }

    }

}
