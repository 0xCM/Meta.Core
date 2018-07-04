//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    /// <summary>
    /// Mediates access to a physical index or representation thereof
    /// </summary>
    public class SqlIndexHandle : SqlElementHandle, ISqlIndexHandle
    {

        public SqlIndexHandle(ISqlClientBroker Broker, SqlTableName TableName, SqlIndexName IndexName)
            : base(Broker, IndexName)
        {
            this.ElementName = IndexName;
            this.TableName = TableName;
        }

        public new SqlIndexName ElementName { get; }

        public SqlTableName TableName { get; }
    }

    public class SqlIndexHandle<P> : SqlElementHandle<P>, ISqlIndexHandle<P>
        where P : ISqlIndexProxy
    {
        public SqlIndexHandle(ISqlProxyBroker Broker, SqlTableName TableName, SqlIndexName IndexName)
            : base(Broker, IndexName)
        {
            this.ElementName = ElementName;
            this.TableName = TableName;
        }

        public new SqlIndexName ElementName { get; }
        public SqlTableName TableName { get; }
    }

    public class SqlIndexHandle<P, T> : SqlIndexHandle<P>
        where P : ISqlIndexProxy
        where T : ISqlTableProxy
    {
        public SqlIndexHandle(ISqlProxyBroker Broker, SqlTableName TableName, SqlIndexName IndexName)
            : base(Broker, TableName, IndexName)
        {

        }

    }
}
