//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Meta.Core;

    /// <summary>
    /// Defines options for bulk copy operations
    /// </summary>
    public class SqlCopyOptions
    {
        const bool AtomicDefault = true;
        const int TimeoutDefault = 60;        

        public static SqlCopyOptions Create
        (
            SqlConnectionString TargetConnection,
            SqlTableAssociation TableAssociation,
            bool? Atomic = null, 
            int? BatchSize = null, 
            int? Timeout = null
        ) => new SqlCopyOptions
            (
                TargetConnection,
                TableAssociation, 
                Atomic ?? AtomicDefault,
                BatchSize,
                Timeout ?? TimeoutDefault
            );

        public static SqlCopyOptions Create
        (
            SqlConnectionString TargetConnection,
            SqlTableName TargetTableName = null,
            bool? Atomic = null,
            int? BatchSize = null,
            int? Timeout = null,
            params string[] ExcludedColumns
        ) => new SqlCopyOptions(
                   TargetConnection,
                   TargetTableName: TargetTableName,
                   Atomic: Atomic ?? AtomicDefault,
                   BatchSize: BatchSize,
                   Timeout: Timeout ?? TimeoutDefault,
                   ExcludedColumns: ExcludedColumns
                );

        public static SqlCopyOptions<T> Create<T>
        (
            SqlConnectionString TargetConnection,
            SqlTableName TargetTableName = null,
            bool? Atomic = null,
            int? BatchSize = null,
            int? Timeout = null,
            params string[] ExcludedColumns
        ) => new SqlCopyOptions<T>
            (
                TargetConnection,
                TargetTableName,
                Atomic ?? AtomicDefault, 
                BatchSize: BatchSize,
                Timeout: Timeout ?? TimeoutDefault,
                ExcludedColumns: ExcludedColumns
            );

        public SqlCopyOptions Clone
        (
            SqlConnectionString TargetConnector = null,
            SqlTableName TargetTableName = null,
            bool? Atomic = null,
            int? BatchSize = null,
            int? Timeout = null,
            params string[] ExcludedColumns
        ) => new SqlCopyOptions
            (
                TargetConnection: TargetConnector,
                TargetTableName: TargetTableName,
                Atomic: Atomic ?? this.Atomic,
                BatchSize: BatchSize ?? this.BatchSize,
                Timeout: Timeout ?? this.Timeout,
                ExcludedColumns: this.ExcludedColumns.Union(ExcludedColumns).ToArray()
            );

        public Option<SqlConnectionString> TargetConnector { get; }

        public bool Atomic { get; }

        public Option<SqlTableName> TargetTableName { get; }

        public int? BatchSize { get; }

        public int Timeout { get; }

        public IReadOnlyList<string> ExcludedColumns { get; }

        public Option<SqlTableAssociation> TableAssociation { get; }

        protected SqlCopyOptions(SqlCopyOptions src)
        {
            this.TargetConnector = src.TargetConnector;
            this.Atomic = src.Atomic;
            this.TargetTableName = src.TargetTableName;
            this.BatchSize = src.BatchSize;
            this.Timeout = src.Timeout;
            this.ExcludedColumns = src.ExcludedColumns;
            this.TableAssociation = src.TableAssociation;
        }

        protected SqlCopyOptions
            (
                SqlConnectionString TargetConnection, 
                SqlTableAssociation TableAssociation, 
                bool Atomic, 
                int? BatchSize,
                int Timeout
            )
        {
            this.TargetConnector = TargetConnection;
            this.TableAssociation = TableAssociation;
            this.Atomic = Atomic;
            this.BatchSize = BatchSize;
            this.Timeout = Timeout;
        }

        protected SqlCopyOptions
            (
                SqlConnectionString TargetConnection,
                SqlTableName TargetTableName,
                bool? Atomic,
                int? BatchSize, 
                int? Timeout, 
                params string[] ExcludedColumns
            )
        {
            this.TargetConnector = TargetConnection;
            this.Atomic = Atomic ?? AtomicDefault;
            this.TargetTableName = TargetTableName;
            this.BatchSize = BatchSize;
            this.Timeout = Timeout ?? TimeoutDefault;
            this.ExcludedColumns = ExcludedColumns.ToList();
        }

    }

    /// <summary>
    /// Defines options for typed bulk copy operations
    /// </summary>
    public sealed class SqlCopyOptions<T> : SqlCopyOptions
    {
        internal SqlCopyOptions(
            SqlConnectionString TargetConnection,
            SqlTableName TargetTableName = null,
            bool? Atomic = null, 
            int? BatchSize = null, 
            int? Timeout = null, 
            params string[] ExcludedColumns
            ) : base(TargetConnection, TargetTableName, Atomic, BatchSize, Timeout, ExcludedColumns)
        {

        }

        public SqlCopyOptions(SqlCopyOptions src)
            : base(src)
        {

        }

        public SqlCopyOptions<T> Exclude<TColumn>(Expression<Func<T, TColumn>> col)
            => new SqlCopyOptions<T>(this.Clone(ExcludedColumns: col.SelectedPropertyName()));

        public SqlCopyOptions<T> Exclude<TCol1, TCol2>(Expression<Func<T, TCol1>> col1, Expression<Func<T, TCol2>> col2)
            => new SqlCopyOptions<T>(this.Clone(
                ExcludedColumns: new string[]
                {
                    col1.SelectedPropertyName(),
                    col2.SelectedPropertyName()
                }));

    }
}
