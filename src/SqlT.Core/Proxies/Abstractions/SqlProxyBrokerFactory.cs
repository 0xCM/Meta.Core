//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

    /// <summary>
    /// Base type for broker factories that are intended to be implemented in assemblies 
    /// where proxies are defined; moreover, there should be exactly one broker factory
    /// in each assembly that defines proxies
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SqlProxyBrokerFactory<T> : ISqlProxyBrokerFactory 
        where T : SqlProxyBrokerFactory<T>, new()
    {

        static ISqlProxyMetadataIndex ProxyMetadata;
        
        static SqlProxyBrokerFactory()
        {
            ProxyMetadata = typeof(T).Assembly.SqlProxyMetadataIndex();
        }    

        
        void RegisterDefaultConverters(ISqlProxyBroker broker)
        {
            broker.RegisterConverter<DateTime, Date>(SqlConversionDirection.ToProxy,
                src => new Date(src.Year, src.Month, src.Day));

            broker.RegisterConverter<Date, DateTime>(SqlConversionDirection.ToTransport,
                src => src.ToDateTimeAtMidnight());

            broker.RegisterConverter<byte[], SqlRowVersion>(SqlConversionDirection.ToProxy,
                src => (SqlRowVersion)src);

            broker.RegisterConverter<SqlRowVersion, byte[]>(SqlConversionDirection.ToTransport,
                src => src);

            broker.RegisterConverter<TimeSpan, TimeOfDay>
                (SqlConversionDirection.ToProxy,
                    src => new TimeOfDay(src.Hours, src.Minutes, src.Seconds, src.Milliseconds));

            broker.RegisterConverter<TimeOfDay, TimeSpan>
                (SqlConversionDirection.ToTransport,
                    src => new TimeSpan(src.Hour, src.Minute, src.Second, src.Millisecond));

        }


        protected virtual void RegisterConverters(ISqlProxyBroker broker)
            => RegisterDefaultConverters(broker);
    

        public ISqlProxyBroker CreateBroker(SqlConnectionString cs, SqlNotificationObserver observer)
        {
            var broker = (ISqlProxyBroker)new SqlProxyBroker(ProxyMetadata, cs, observer);
            RegisterConverters(broker);
            return broker;
        }

        public ISqlProxyBroker<A> CreateBroker<A>(SqlConnectionString cs, Action<SqlNotification> observer)
            where A : class, ISqlProxyAssembly, new()
        {
            var broker = new SqlProxyBroker<A>(ProxyMetadata, cs, observer);
            RegisterConverters(broker);
            return broker;
        }

        public ISqlProxyBroker CreateBroker(SqlConnectionString cs)
            => CreateBroker(cs, m => Console.WriteLine(m));

        protected SqlProxyBrokerFactory()
        {

        }

        public ISqlProxyMetadataIndex Metadata
            => ProxyMetadata;

        public override string ToString()
            => $"{typeof(T).Assembly.GetName().Name} Broker Factory";

    }

}
