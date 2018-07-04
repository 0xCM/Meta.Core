//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    public class SqlTableRowCount
    {

        public SqlTableRowCount((string svr, string db, string schema, string table) TableName, int RowCount)
        {
            this.TableName = new SqlTableName(TableName.svr, TableName.db, TableName.schema, TableName.table);
            this.RowCount = RowCount;
        }

        public SqlTableName TableName { get; }

        public int RowCount { get; }

        public override string ToString()
            => $"{TableName} ({RowCount} rows)";

    }
}
