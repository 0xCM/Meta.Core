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

    using Meta.Models;
    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;

    public abstract class SqlTable<T> : SqlTabularObject<T, SqlTableName>, ISqlTable
        where T : SqlTable<T>
    {
        protected SqlTable(SqlTableName Name)
            : base(Name)

        {

        }

        protected SqlTable
        (
            SqlTableName TableName,
            IEnumerable<SqlTableColumn> Columns,
            SqlPrimaryKey PrimaryKey = null,
            IEnumerable<SqlIndex> Indexes = null,
            IEnumerable<SqlPropertyAttachment> Properties = null,
            SqlElementDescription Documentation = null,
            SqlName FileGroupName = null,
            IEnumerable<SqlColumnStoreIndex> ColumnStoreIndexes = null,
            IEnumerable<SqlForeignKey> ForeignKeys = null
         )
            : base
            (
                  Name: TableName,
                  Properties: Properties,
                  Documentation: Documentation
            )
        {
            this.PrimaryKey = PrimaryKey;
            this.Columns = rolist(Columns.Select(c => c.Reparent(this)));
            this.FileGroupName = FileGroupName ?? SqlFileGroup.DefaultFileGroupName;
            this.Indexes = rolist(Indexes ?? stream<SqlIndex>());
            this.ColumnStoreIndexes = rolist(ColumnStoreIndexes ?? stream<SqlColumnStoreIndex>());
            this.ForeignKeys = rolist(ForeignKeys ?? stream<SqlForeignKey>());
        }


        protected override IReadOnlyList<ISqlColumn> GetColumns()
            => Columns;

        public IReadOnlyList<SqlTableColumn> Columns { get; }

        public IReadOnlyList<SqlIndex> Indexes { get; }

        public IReadOnlyList<SqlColumnStoreIndex> ColumnStoreIndexes { get; }

        public IReadOnlyList<SqlForeignKey> ForeignKeys { get; }

        public Option<SqlPrimaryKey> PrimaryKey { get; }

        public SqlName FileGroupName { get; }

        SqlTableName IModel<SqlTableName>.Name
            => base.Name;

        public ISqlColumn this[string colname]
            => Columns.Single(x => x.Name == colname);

        public ISqlColumn this[int colidx]
            => Columns.Single(x => x.Position == colidx);

        public virtual bool IsFileTable
            => false;
    }

    [SqlElementType(SqlElementTypeNames.Table)]
    public sealed class SqlTable : SqlTable<SqlTable>
    {

        public SqlTable
        (
            SqlTableName TableName,
            IEnumerable<SqlTableColumn> Columns,
            SqlPrimaryKey PrimaryKey = null,
            IEnumerable<SqlIndex> Indexes = null,
            IEnumerable<SqlPropertyAttachment> Properties = null,
            SqlElementDescription Documentation = null,
            SqlName FileGroupName = null,
            IEnumerable<SqlColumnStoreIndex> ColumnStoreIndexes = null,
            IEnumerable<SqlForeignKey> ForeignKeys = null
         ) : base(
             TableName: TableName,
             Columns: Columns,
             PrimaryKey: PrimaryKey,
             Indexes: Indexes,
             Properties: Properties,
             Documentation: Documentation,
             FileGroupName: FileGroupName,
             ColumnStoreIndexes: ColumnStoreIndexes,
             ForeignKeys: ForeignKeys

             )
        {
        }

    }
}
