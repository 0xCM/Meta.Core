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
    using System.Linq.Expressions;

    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;

    using sxc = Syntax.contracts;

    /// <summary>
    /// Characterizes a primary key
    /// </summary>
    [SqlElementType(SqlElementTypeNames.PrimaryKeyConstraint)]
    public sealed class SqlPrimaryKey : SqlConstraint<SqlPrimaryKey, SqlPrimaryKeyName>, sxc.primary_key
    {
        public SqlPrimaryKey
        (
            SqlPrimaryKeyName PrimaryKeyName,
            IEnumerable<SqlPrimaryKeyColumn> KeyColumns,
            bool IgnoreDuplicateKeys = false,
            SqlElementDescription Documentation = null,
            IEnumerable<SqlPropertyAttachment> Properties = null

        ) : base(PrimaryKeyName, Documentation, Properties)
        {
            this.IgnoreDuplicateKeys = IgnoreDuplicateKeys;
            this.KeyColumns = rolist(KeyColumns);

        }

        protected override IReadOnlyList<ISqlConstraintColumn> GetConstrainedColumns()
            => KeyColumns;

        public IReadOnlyList<SqlPrimaryKeyColumn> KeyColumns { get; }

        public bool IgnoreDuplicateKeys { get; }


        public override bool IsIdentifying
           => true;


    }

    public abstract class SqlPrimaryKey<T, K, C1> : SqlConstraint<K, SqlPrimaryKeyName>, sxc.primary_key
        where T : ISqlTable
        where K : SqlPrimaryKey<T, K, C1>
    {

        protected SqlPrimaryKey(Expression<Func<T, C1>> Column1, SqlPrimaryKeyName PrimaryKeyName = null)
            : base( PrimaryKeyName ?? SqlPrimaryKeyName.Parse(typeof(K).Name))
        {

        }

        public C1 Column1 { get; }

    }

    public abstract class SqlPrimaryKey<T, K, C1, C2> : SqlPrimaryKey<T, K, C1>
        where T : ISqlTable
        where K : SqlPrimaryKey<T, K, C1, C2>
    {

        protected SqlPrimaryKey(
            Expression<Func<T, C1>> Column1,
            Expression<Func<T, C2>> Column2,
            SqlPrimaryKeyName PrimaryKeyName = null
            )
            : base(Column1, PrimaryKeyName)
        {

        }

        public C2 Column2 { get; }

    }

    public abstract class SqlPrimaryKey<T, K, C1, C2, C3> : SqlPrimaryKey<T, K, C1, C2>
        where T : ISqlTable
        where K : SqlPrimaryKey<T, K, C1, C2, C3>
    {

        protected SqlPrimaryKey(
            Expression<Func<T, C1>> Column1,
            Expression<Func<T, C2>> Column2,
            Expression<Func<T, C3>> Column3,
            SqlPrimaryKeyName PrimaryKeyName = null
            )
            : base(Column1, Column2, PrimaryKeyName)
        {
            
        }

        public C3 Column3 { get; }

    }


}
