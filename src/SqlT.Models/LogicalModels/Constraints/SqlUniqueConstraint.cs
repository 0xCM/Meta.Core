//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq.Expressions;

    using System.Collections.Generic;
    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;
    using sxc = Syntax.contracts;

    [SqlElementType(SqlElementTypeNames.UniqueConstraint)]
    public sealed class SqlUniqueConstraint : SqlConstraint<SqlUniqueConstraint, SqlUniqueConstraintName>, sxc.unique_constraint
    {

        public SqlUniqueConstraint
        (
            SqlUniqueConstraintName ConstraintName, 
            IEnumerable<SqlUniqueConstraintColumn> Columns,
            bool IgnoreDuplicateKeys = false,
            SqlElementDescription Documentation = null,
            IEnumerable<SqlPropertyAttachment> Properties = null

        ) : base(ConstraintName, Documentation:Documentation)
        {
            this.Columns = rolist(Columns);
        }

        protected override IReadOnlyList<ISqlConstraintColumn> GetConstrainedColumns()
            => Columns;

        public IReadOnlyList<SqlUniqueConstraintColumn> Columns { get; }

        public bool IgnoreDuplicateKeys { get; }

        public override bool IsIdentifying 
           => true;
    }

    public abstract class SqlUniqueConstraint<T, K, C1> : SqlConstraint<K, SqlUniqueConstraintName>, sxc.unique_constraint
        where T : ISqlTable
        where K : SqlUniqueConstraint<T, K, C1>
    {

        protected SqlUniqueConstraint(Expression<Func<T, C1>> Column1, SqlUniqueConstraintName PrimaryKeyName = null)
            : base(PrimaryKeyName ?? SqlUniqueConstraintName.Parse(typeof(K).Name))
        {

        }

        public C1 Column1 { get; }

    }

    public abstract class SqlUniqueConstraint<T, K, C1, C2> : SqlUniqueConstraint<T, K, C1>
        where T : ISqlTable
        where K : SqlUniqueConstraint<T, K, C1, C2>
    {

        protected SqlUniqueConstraint(
            Expression<Func<T, C1>> Column1,
            Expression<Func<T, C2>> Column2,
            SqlUniqueConstraintName PrimaryKeyName = null
            )
            : base(Column1, PrimaryKeyName)
        {

        }

        public C2 Column2 { get; }

    }


}
