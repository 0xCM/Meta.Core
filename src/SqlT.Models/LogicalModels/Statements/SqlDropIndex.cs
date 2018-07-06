//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;


    /// <summary>
    /// Characterizes a DROP INDEX statement
    /// </summary>
    public class SqlDropIndex : SqlDropStatement<SqlDropIndex, SqlIndex>
    {
        public SqlDropIndex(SqlTableName TableName, SqlIndexName IndexName, bool CheckExistence = true)
            : base(CheckExistence, Syntax.statement_kind.DropIndex)
        {
            this.TableName = TableName;
            this.IndexName = IndexName;
        }

        /// <summary>
        /// The name of the table on which the index is defined
        /// </summary>
        public SqlTableName TableName { get; }

        /// <summary>
        /// The name of the index
        /// </summary>
        public SqlIndexName IndexName { get; }

    }
}
