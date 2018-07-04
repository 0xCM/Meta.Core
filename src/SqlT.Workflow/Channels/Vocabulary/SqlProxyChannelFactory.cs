//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using N = SystemNode;

    class SqlProxyChannelFactory : SqlChannelFactory, ISqlProxyChannelFactory
    {
        public SqlProxyChannelFactory(SqlNotificationObserver Observer, ISqlProxyBrokerFactory SourceBrokerFactory, ISqlContext SourceContext, ISqlProxyBrokerFactory TargetBrokerFactory = null, ISqlContext TargetContext = null)
            : base(Observer, SourceContext, TargetContext)
        {
            this.SourceBrokerFactory = SourceBrokerFactory;
            this.TargetBrokerFactory = TargetBrokerFactory ?? SourceBrokerFactory;
        }

        ISqlProxyBrokerFactory SourceBrokerFactory { get; }

        ISqlProxyBrokerFactory TargetBrokerFactory { get; }


        public ISqlProxyChannel ProxyChannel()
            => new SqlProxyChannel(
                    LinkedContext,
                    SourceBrokerFactory.CreateBroker(SourceContext.SqlConnector),
                    TargetBrokerFactory.CreateBroker(TargetContext.SqlConnector)
                );
    }

    class SqlProxyChannelFactory<A> : SqlChannelFactory, ISqlProxyChannelFactory
        where A : class, ISqlProxyAssembly, new()
    {
        public SqlProxyChannelFactory(SqlNotificationObserver Observer, ISqlContext SourceContext, ISqlContext TargetContext = null)
            : base(Observer, SourceContext, TargetContext)
        {


        }

        public ISqlProxyChannel ProxyChannel()
            => new SqlProxyChannel(
                    LinkedContext,
                    new A().CreateBroker(SourceContext.SqlConnector),
                    new A().CreateBroker(TargetContext.SqlConnector)
                );
    }

    class SqlProxyChannelFactory<A, B> : SqlChannelFactory, ISqlProxyChannelFactory
        where A : class, ISqlProxyAssembly, new()
        where B : class, ISqlProxyAssembly, new()
    {
        public SqlProxyChannelFactory(SqlNotificationObserver Observer, ISqlContext SourceContext, ISqlContext TargetContext = null)
            : base(Observer, SourceContext, TargetContext)
        {


        }


        public ISqlProxyChannel ProxyChannel()
            => new SqlProxyChannel(
                    LinkedContext,
                    new A().CreateBroker(SourceContext.SqlConnector),
                    new B().CreateBroker(TargetContext.SqlConnector)
                );
    }
}
