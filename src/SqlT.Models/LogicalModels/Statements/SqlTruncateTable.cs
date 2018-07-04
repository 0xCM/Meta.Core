//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;
    using SqlT.Services;
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