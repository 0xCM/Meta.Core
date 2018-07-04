//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    using sxc = SqlT.Syntax.contracts;

    public abstract class SqlTabularHandle : SqlObjectHandle, ISqlTabularHandle
    {
        protected SqlTabularHandle(ISqlClientBroker Broker, sxc.tabular_name TabularName)
            : base(Broker, TabularName)
        {
            this.ElementName = TabularName;
        }

        protected SqlTabularHandle(ISqlTabularBroker Broker)
            : base(Broker.InnerBroker, Broker.TabularInfo.ObjectName)
        {
            this.ElementName = Broker.TabularInfo.ObjectName;
        }

        public new sxc.tabular_name ElementName { get; }
     
    }

    public abstract class SqlTabularHandle<T> : SqlTabularHandle, ISqlTabularHandle<T>
        where T : class, ISqlTabularProxy, new()

    {
        public SqlTabularHandle(ISqlTabularBroker Broker)
            : base(Broker)
        {

        }

        public SqlTabularHandle(ISqlProxyBroker Broker)
            : base(Broker, PXM.TabularName<T>())
        {

        }

        public new ISqlProxyBroker Broker
            => base.Broker as ISqlProxyBroker;
    }
}
