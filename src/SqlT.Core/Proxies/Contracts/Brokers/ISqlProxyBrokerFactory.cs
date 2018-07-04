//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

    public interface ISqlProxyBrokerFactory
    {        

        ISqlProxyBroker CreateBroker(SqlConnectionString cs);

        ISqlProxyBroker CreateBroker(SqlConnectionString cs, SqlNotificationObserver observer);


        ISqlProxyMetadataIndex Metadata { get; }
    }


    public interface ISqlProxyBrokerFactory<A> : ISqlProxyBrokerFactory
            where A : class, ISqlProxyAssembly, new()
    {
        ISqlProxyBroker<A> CreateAssemblyBroker(SqlConnectionString cs, Action<SqlNotification> observer);

    }
}
