namespace SqlT.Models
{
    using System;
    using SqlT.Core;
    using static metacore;
    

    public static class ProxyBroker
    {
        [SqlProxyBrokerFactory]
        public class BrokerFactory : SqlProxyBrokerFactory<BrokerFactory>
        {
            public static new ISqlProxyBroker CreateBroker(SqlConnectionString cs)
                    => ((SqlProxyBrokerFactory<BrokerFactory>)(new BrokerFactory())).CreateBroker(cs);

            protected override void RegisterConverters(ISqlProxyBroker broker)
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
        }

        public static Option<ISqlProxyBroker> CreateSystemsBroker(this SqlConnectionString cs)
            => some(BrokerFactory.CreateBroker(cs));

               

    }
}