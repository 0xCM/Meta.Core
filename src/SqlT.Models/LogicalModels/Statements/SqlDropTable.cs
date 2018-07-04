//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;


    /// <summary>
    /// Characterizes a drop table statement
    /// </summary>
    public class SqlDropTable : SqlDropStatement<SqlDropTable, SqlTable>
    {
        public static SqlDropTable Specify(SqlTableName name, bool check_exists = true)
            => new SqlDropTable(name, check_exists);

        public SqlDropTable(SqlTableName TableName, bool CheckExistence = true)
            : base(CheckExistence, Syntax.statement_kind.DropTable)
        {
            this.TableName = TableName;
        }

        /// <summary>
        /// The name of the table to drop
        /// </summary>
        public SqlTableName TableName { get; }

    }



}