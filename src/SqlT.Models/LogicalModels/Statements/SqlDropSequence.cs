//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;

    /// <summary>
    /// Characterizes a drop sequence statement
    /// </summary>
    public class SqlDropSequence : SqlDropStatement<SqlDropSequence, SqlSequence>
    {
        public SqlDropSequence(SqlSequenceName SequenceName, bool CheckExistence = true)
            : base(CheckExistence, Syntax.statement_kind.DropSequence)
        {
            this.SequenceName = SequenceName;
        }

        /// <summary>
        /// The name of the Sequence to drop
        /// </summary>
        public SqlSequenceName SequenceName { get; }

    }

}