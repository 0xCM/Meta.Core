//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    /// <summary>
    /// Mediates access to a physical view or representation thereof
    /// </summary>
    public class SqlViewHandle : SqlTabularHandle, ISqlViewHandle
    {
        public SqlViewHandle(ISqlClientBroker Broker, SqlViewName ViewName)
            : base(Broker, ViewName)
        {
            this.ElementName = ViewName;
        }

        public new SqlViewName ElementName { get; }

    }

    /// <summary>
    /// Mediates access to a physical view or representation thereof
    /// </summary>
    public class SqlViewHandle<T> : SqlTabularHandle<T>, ISqlViewHandle<T>
        where T: class, ISqlViewProxy, new()
    {        

        public SqlViewHandle(ISqlProxyBroker Broker)
            : base(Broker)
        {
            ElementName = Broker.Metadata.View<T>().ObjectName;
        }

        public new SqlViewName ElementName { get; }

    }
}
