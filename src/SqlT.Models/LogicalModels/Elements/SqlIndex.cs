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

    using Meta.Core;
    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;
    
    /// <summary>
    /// Characterizes a Sql Index
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="I"></typeparam>
    /// <typeparam name="C1"></typeparam>
    public class SqlIndex<T, I, C1> : SqlElement<I>
        where I : SqlIndex<T, I, C1>
        where T : ISqlTable
    {
        protected SqlIndex(Expression<Func<T, C1>> Col1, SqlIndexName IndexName = null)
            : base(IndexName)
        {
            this.IndexName = IndexName ?? SqlIndexName.Parse(typeof(I).Name);
            this.Col1 = new SqlIndexColumn(Col1.GetValueMember().Name);
        }

        public SqlIndexName IndexName { get; }

        public SqlIndexColumn Col1 { get; }

        public virtual IEnumerable<SqlIndexColumn> Columns
            => stream(Col1);
    }

    /// <summary>
    /// Characterizes a SQL Index
    /// </summary>
    [SqlElementType(SqlElementTypeNames.Index)]
    public sealed class SqlIndex : SqlElement<SqlIndex>, ISqlElement
    {        
        public SqlIndex(SqlIndexName IndexName, SqlTableName TableName, params SqlIndexColumn[] PrimaryColumns) 
            : this (IndexName,  TableName,  PrimaryColumns,  null)
        {

        }

        public SqlIndex
            (
                SqlIndexName IndexName,
                SqlTableName TableName,
                IEnumerable<SqlIndexColumn> PrimaryColumns,
                IEnumerable<SqlIndexColumn> IncludedColumns = null,
                bool Clustered = false,
                bool Unique = false,
                bool ColumnStore = false,
                SqlElementDescription Documentation = null, 
                IEnumerable<SqlPropertyAttachment> Properties = null, 
                bool DropExisting = false
            )
            : base(IndexName,
                  Documentation: Documentation, 
                  Properties: Properties 
                  )
        {
            this.IndexName = IndexName;
            this.TableName = TableName;
            this.PrimaryColumns = rolist(PrimaryColumns);
            this.IncludedColumns = rolist(IncludedColumns ?? array<SqlIndexColumn>());
            this.Clustered = Clustered;
            this.Unique = Unique;
            this.ColumnStore = ColumnStore;
            this.DropExisting = DropExisting;
        }

        /// <summary>
        /// Specifies the name of the index
        /// </summary>
        public SqlIndexName IndexName { get; }

        /// <summary>
        /// Specifies the name of the table
        /// </summary>
        public SqlTableName TableName { get; }

        /// <summary>
        /// Specifies the columns on which the index is defined
        /// </summary>
        public IReadOnlyList<SqlIndexColumn> PrimaryColumns { get; }

        /// <summary>
        /// Specifies the non-primary included columns
        /// </summary>
        public IReadOnlyList<SqlIndexColumn> IncludedColumns { get; }
                                                      
        /// <summary>
        /// Specifies whether the index is clustered
        /// </summary>
        public bool Clustered { get; }

        /// <summary>
        /// Specifies whether the index is unique
        /// </summary>
        public bool Unique { get; }

        /// <summary>
        /// Specifies whether the index is a column store
        /// </summary>
        public bool ColumnStore { get; }

        public bool DropExisting { get; }

        public override string ToString() 
            => IndexName;
    }
}
