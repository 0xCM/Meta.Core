//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using SqlT.Core;
    using SqlT.Models;

    /// <summary>
    /// Constructs <see cref="SqlDropTable"/> statements
    /// </summary>
    public sealed class SqlDropTableBuilder : SqlModelBuilder<SqlDropTable>
    {

        internal SqlDropTableBuilder(SqlTableName TableName, bool CheckExistence)
        {
            this.TableName = TableName;
            this.CheckExistence = CheckExistence;
        }

        public SqlTableName TableName { get; }

        public bool CheckExistence { get; }

        public override SqlDropTable Complete()
            => new SqlDropTable(TableName, CheckExistence);
    }
}