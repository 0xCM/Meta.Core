//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using sxc = Syntax.contracts;

    using Meta.Models;
    using Meta.Syntax;
    using SqlT.Syntax;

    public abstract class SqlElementHandle : ISqlHandle
    {

        protected SqlElementHandle(ISqlClientBroker Broker, IName ElementName)
        {
            this.ElementName = ElementName;
            this.Broker = Broker;
        }

        public IName ElementName { get; }

        public ISqlClientBroker Broker { get; }

        public SqlServerName ConnectedServer
            => Broker.ConnectionString.ServerName;

        public SqlDatabaseName DefiningCatalog
            => Broker.ConnectionString.QualifiedDatabaseName;

        public override string ToString()
            => ElementName.ToString();

    }

    public abstract class SqlElementHandle<P> : SqlElementHandle, ISqlProxyHandle<P>
        where P : ISqlProxy
    {
        protected SqlElementHandle(ISqlProxyBroker Broker, IName ElementName)
            : base(Broker,ElementName)
        {
        }

        public new ISqlProxyBroker Broker 
            => base.Broker as ISqlProxyBroker;
    }


}
