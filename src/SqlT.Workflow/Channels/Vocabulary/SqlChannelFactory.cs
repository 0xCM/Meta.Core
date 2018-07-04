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


    public class SqlChannelFactory : ISqlChannelFactory
    {
        public static ISqlChannelFactory CreateFactory(SqlNotificationObserver Observer, ISqlContext SourceContext, ISqlContext TargetContext = null)
            => new SqlChannelFactory(Observer, SourceContext, TargetContext);

        public static ISqlProxyChannelFactory CreateFactory(SqlNotificationObserver Observer, ISqlProxyBrokerFactory SourceBrokerFactory, ISqlContext SourceContext, ISqlProxyBrokerFactory TargetBrokerFactory = null, ISqlContext TargetContext = null)
            => new SqlProxyChannelFactory(Observer, SourceBrokerFactory, SourceContext, TargetBrokerFactory, TargetContext);


        public static ISqlProxyChannelFactory CreateFactory<A>(SqlNotificationObserver Observer, ISqlContext SourceContext, ISqlContext TargetContext = null)
            where A : class, ISqlProxyAssembly, new()
                => new SqlProxyChannelFactory<A>(Observer, SourceContext, TargetContext);

        public static ISqlProxyChannelFactory CreateFactory<A,B>(SqlNotificationObserver Observer, ISqlContext SourceContext, ISqlContext TargetContext = null)
            where A : class, ISqlProxyAssembly, new()
            where B : class, ISqlProxyAssembly, new()
                => new SqlProxyChannelFactory<A,B>(Observer, SourceContext, TargetContext);

        protected SqlChannelFactory(SqlNotificationObserver Observer, ISqlContext SourceContext, ISqlContext TargetContext = null)
        {
            this.Observer = Observer;
            this.SourceContext = SourceContext;
            this.TargetContext = TargetContext ?? TargetContext;
        }

        public ISqlContext SourceContext { get; }

        public ISqlContext TargetContext { get; }

        protected SqlNotificationObserver Observer { get; }

        protected ILinkedContext LinkedContext
            => new LinkedContext(SourceContext, TargetContext);

        public ISqlClientChannel ClientChannl()
            => new SqlClientClannel(LinkedContext,
                        new SqlClientBroker(SourceContext.SqlConnector, Observer),
                        new SqlClientBroker(TargetContext.SqlConnector, Observer));


    }



}
