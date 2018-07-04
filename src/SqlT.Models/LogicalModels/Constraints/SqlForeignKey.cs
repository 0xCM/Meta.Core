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

    using static metacore;
    using sxc = Syntax.contracts;


    public enum SqlForeignKeyAction
    {
        None = 0,
        Cascade = 1,
        SetNull = 2,
        SetDefault = 3
    }


    public abstract class SqlForeignKey<M, TClient, TSupplier> : SqlConstraint<M, SqlForeignKeyName>, sxc.foreign_key
        where M : SqlForeignKey<M,TClient,TSupplier>
        where TClient : ISqlTable
        where TSupplier : ISqlTable

    {
        protected SqlForeignKey
        (
            SqlForeignKeyName ForeignKeyName,
            IEnumerable<SqlForeignKeyColumn> KeyColumns = null,
            SqlElementDescription Documentation = null,
            SqlForeignKeyAction OnSupplierUpdate = SqlForeignKeyAction.None,
            SqlForeignKeyAction OnSupplierDelete = SqlForeignKeyAction.None,
            IEnumerable<SqlPropertyAttachment> Properties = null
        )
            : base(ForeignKeyName, Documentation, Properties)
        {
            this.KeyColumns = KeyColumns == null 
                            ? rolist<SqlForeignKeyColumn>() 
                            : KeyColumns.OrderBy(x => x.OrdinalPosition).ToReadOnlyList();
            this.OnSupplierDelete = OnSupplierDelete;
            this.OnSupplierUpdate = OnSupplierUpdate;
        }

        protected override IReadOnlyList<ISqlConstraintColumn> GetConstrainedColumns()
            => KeyColumns;

        public SqlForeignKeyAction OnSupplierUpdate { get; }

        public SqlForeignKeyAction OnSupplierDelete { get; }

        public IReadOnlyList<SqlForeignKeyColumn> KeyColumns { get; }
    }

    /// <summary>
    /// Characterizes a SQL foreign key
    /// </summary>
    [SqlElementType(SqlElementTypeNames.ForeignKey)]
    public sealed class SqlForeignKey : SqlForeignKey<SqlForeignKey, SqlTable, SqlTable>
    {

        public SqlForeignKey
        (
            SqlForeignKeyName ForeignKeyName,
            SqlTableName ClientTableName,
            SqlTableName SupplierTableName,
            IEnumerable<SqlForeignKeyColumn> KeyColumns,
            SqlForeignKeyAction OnSupplierUpdate = SqlForeignKeyAction.None,
            SqlForeignKeyAction OnSupplierDelete = SqlForeignKeyAction.None,
            SqlElementDescription Documentation = null,
            IEnumerable<SqlPropertyAttachment> Properties = null
        ) : base
            (
                ForeignKeyName,
                KeyColumns: KeyColumns,
                OnSupplierUpdate: OnSupplierUpdate,
                OnSupplierDelete: OnSupplierDelete,
                Documentation: Documentation,
                Properties: Properties
            )
        {
            this.ClientTableName = ClientTableName;
            this.SupplierTableName = SupplierTableName;
        }

        public SqlTableName ClientTableName { get; }


        public SqlTableName SupplierTableName { get; }

    }
}