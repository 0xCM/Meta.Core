//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;

    /// <summary>
    /// Characterizes an ALTER INDEX statement
    /// </summary>
    public sealed class SqlAlterIndex : SqlAlterStatement<SqlAlterIndex, SqlIndex>
    {
        public SqlAlterIndex(SqlTableName TableName, SqlIndexName IndexName, SqlAlterIndexAction AlterAction)
            : base(Syntax.statement_kind.AlterIndex)
        {
            this.TableName = TableName;
            this.IndexName = IndexName;
            this.AlterAction = AlterAction;
        }

        /// <summary>
        /// The name of the table on which the index is defined
        /// </summary>
        public SqlTableName TableName { get; }

        /// <summary>
        /// The name of the index
        /// </summary>
        public SqlIndexName IndexName { get; }

        public SqlAlterIndexAction AlterAction { get; }

    }

    public enum SqlAlterIndexAction : byte
    {
        None = 0,
        Rebuild = 1,
        Disable = 2,
        Reorganize =3 
    }
}
