//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;
       
    using static metacore;

    /// <summary>
    /// Constructs <see cref="SqlDropIndex"/> statements
    /// </summary>
    public sealed class SqlDropIndexBuilder : SqlModelBuilder<SqlDropIndex>
    {

        internal SqlDropIndexBuilder(SqlTableName TableName, SqlIndexName IndexName, bool CheckExistence)
        {
            this.TableName = TableName;
            this.IndexName = IndexName;
            this.CheckExistence = CheckExistence;
        }

        public SqlTableName TableName { get; }

        public SqlIndexName IndexName { get; }

        public bool CheckExistence { get; }

        public override SqlDropIndex Complete()
            => new SqlDropIndex(TableName, IndexName, CheckExistence);

    }
}
