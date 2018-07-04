//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;

    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;

    /// <summary>
    /// Characterizes a SQL Columnstore Index
    /// </summary>
    [SqlElementType(SqlElementTypeNames.ColumnStoreIndex)]
    public sealed class SqlColumnStoreIndex : SqlElement<SqlColumnStoreIndex>
    {
        public SqlColumnStoreIndex
            (
                SqlIndexName IndexName,
                SqlTableName TableName,
                bool Clustered = false,
                params SqlIndexColumn[] Columns
            ) : this
                (
                IndexName,
                TableName,
                Columns
                )
        {

        }


        public SqlColumnStoreIndex
            (
                SqlIndexName IndexName,
                SqlTableName TableName,
                IEnumerable<SqlIndexColumn> Columns,
                bool Clustered = false,
                bool DropExisting = false,
                SqlElementDescription Documentation = null,
                IEnumerable<SqlPropertyAttachment> Properties = null
            )
            : base(
                  IndexName,
                  Documentation: Documentation,
                  Properties: Properties                  
                  )
        {
            this.IndexName = IndexName;
            this.TableName = TableName;
            this.Columns = rolist(Columns);
            this.Clustered = Clustered;
            this.DropExisting = DropExisting;
        }

        public SqlIndexName IndexName { get; }

        public SqlTableName TableName { get; }

        public IReadOnlyList<SqlIndexColumn> Columns { get; }

        public bool Clustered { get; }

        public bool DropExisting { get; }

        public override string ToString()
            => IndexName;

    }
}
