namespace MetaFlow.Proxies
{
    using MetaFlow.Core;
    using MetaFlow.WF;
    using SqlT.Types;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    [SqlProxyBrokerFactory]
    class ProxyBrokerFactory : SqlProxyBrokerFactory<ProxyBrokerFactory>
    {
        /// <summary>
                /// The name of the catalog that provided the source metadata from
                /// which the proxies were constructed
                /// </summary>
        public const string SourceCatalog = @"WF";
        public static new ISqlProxyBroker CreateBroker(SqlConnectionString cs) => ((SqlProxyBrokerFactory<ProxyBrokerFactory>)(new ProxyBrokerFactory())).CreateBroker(cs);
    }
}