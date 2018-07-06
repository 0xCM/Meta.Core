//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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