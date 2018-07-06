//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using SqlT.Core;
    using SqlT.Models;

    using static metacore;

    public class SqlDropSequenceBuilder : SqlModelBuilder<SqlDropSequence>
    {
        internal SqlDropSequenceBuilder(SqlSequenceName SequenceName, bool CheckExistence)
        {
            this.SequenceName = SequenceName;
            this.CheckExistence = CheckExistence;
        }

        SqlSequenceName SequenceName { get; }
        bool CheckExistence { get; }

        public override SqlDropSequence Complete()
            => new SqlDropSequence(SequenceName, CheckExistence);
    }
}
