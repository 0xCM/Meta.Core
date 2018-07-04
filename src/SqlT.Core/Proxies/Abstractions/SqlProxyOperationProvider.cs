//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

    /// <summary>
    /// Ultimate superclass for types realize proxy-specific oprational contracts
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SqlProxyOperationProvider<T> : ISqlProxyOperationProvider
    {
        protected ISqlProxyBroker Broker { get; }

        protected SqlProxyOperationProvider(ISqlProxyBroker Broker)
        {
            this.Broker = Broker;
        }

        Type ISqlProxyOperationProvider.ContractType
            => typeof(T);

        ISqlProxyBroker ISqlProxyOperationProvider.ProxyBroker
            => Broker;
    }
}
