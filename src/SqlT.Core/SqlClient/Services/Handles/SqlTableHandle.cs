//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    /// <summary>
    /// Represents a database table
    /// </summary>
    public class SqlTableHandle : SqlTabularHandle, ISqlTableHandle
    {
        public SqlTableHandle(ISqlClientBroker Broker, SqlTableName TableName)
            : base(Broker, TableName)
        {
            this.ElementName = TableName;
        }

        public new SqlTableName ElementName { get; }

        public ISqlIndexHandle Index(SqlIndexName IndexName)
            => new SqlIndexHandle(Broker, ElementName, IndexName);
            
    }

    public class SqlTableHandle<P> : SqlTabularHandle<P>, ISqlTableHandle<P>
        where P : class, ISqlTableProxy, new()
    {
        public SqlTableHandle(ISqlTabularBroker Broker)
            : base(Broker)
        {
            
            ElementName = Broker.Metadata.Table<P>().ObjectName;
        }

        public SqlTableHandle(ISqlProxyBroker Broker)
            : base(Broker)
        {
            ElementName = Broker.Metadata.Table<P>().ObjectName;
        }

        public new SqlTableName ElementName { get; }

        public ISqlIndexHandle Index(SqlIndexName IndexName)
            => new SqlIndexHandle(Broker, ElementName, IndexName);

    }
}
