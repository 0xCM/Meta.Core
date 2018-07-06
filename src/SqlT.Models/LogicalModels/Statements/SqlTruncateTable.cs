//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;
    using SqlT.Syntax;

    using static SqlT.Syntax.SqlSyntax;

    using sxc = SqlT.Syntax.contracts;
    using sx = SqlT.Syntax.SqlSyntax;

    /// <summary>
    /// Characterizes a SQL truncate table statement
    /// </summary>
    public class SqlTruncateTable : SqlStatement<SqlTruncateTable>
    {
        public SqlTruncateTable(SqlTableName TableName)
            : base(sx.TRUNCATE, statement_kind.TruncateTable)
        {
            this.TableName = TableName;
        }

        /// <summary>
        /// The name of the table to drop
        /// </summary>
        public SqlTableName TableName { get; }


        public SqlName Name
            => new SqlName("[Truncate]", ".[Table]", TableName.Format(true));

        public override string ToString()
            => $"{TRUNCATE} {TABLE} {TableName}";
    }



}