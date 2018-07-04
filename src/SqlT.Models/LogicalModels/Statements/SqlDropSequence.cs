//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
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