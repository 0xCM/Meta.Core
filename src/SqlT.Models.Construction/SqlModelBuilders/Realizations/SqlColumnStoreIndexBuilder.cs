//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;

    using Meta.Core;
    using SqlT.Core;

    /// <summary>
    /// Constructs <see cref="SqlColumnStoreIndex"/> definitions
    /// </summary>
    public sealed class SqlColumnStoreIndexBuilder : SqlModelBuilder<SqlColumnStoreIndex>
    {

        internal SqlColumnStoreIndexBuilder(SqlIndexName IndexName, SqlTableName TableName, bool Clustered = true, params SqlColumnName[] columns)
        {
            this.IndexName = IndexName;
            this.TableName = TableName;
            this.Clustered = Clustered;
            this.Columns.AddRange(columns.Select(c => new SqlIndexColumn(c, true)));
        }

        SqlIndexName IndexName;
        SqlTableName TableName;
        bool Clustered = false;
        MutableList<SqlIndexColumn> Columns = MutableList.Create<SqlIndexColumn>();

        public override SqlColumnStoreIndex Complete()
            => new SqlColumnStoreIndex(IndexName, TableName, Clustered, Columns.ToArray());
    }
}