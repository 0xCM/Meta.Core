//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using System.ServiceModel;

    using Meta.Core.Messaging;

    using static metacore;

    using MetaFlow.XE;

    public class PlatformNotificationHubConnection : HubConnection<IPlatformNotificationHub, PlatformNotification>
    {
        public static readonly string DefaultExchange = "PlatformNotifications";

        static PlatformNotificationHubConnection Connect(IPlatformNotificationReceiver receiver, string ExchangeName)
        {
            var address = $"net.pipe://localhost/{ExchangeName}";
            var serviceContext = new InstanceContext(receiver);
            var channelFactory = new DuplexChannelFactory<IPlatformNotificationHub>(serviceContext, new NetNamedPipeBinding(), new EndpointAddress(address));
            var exchange = channelFactory.CreateChannel();
            var connectionId = exchange.Connect();
            var connection = new PlatformNotificationHubConnection(exchange, ExchangeName, connectionId);
            return connection;
        }

        public static IHubConnection<PlatformNotification> Create(Action<PlatformNotification> Handler, string ExchangeName = null)
            => Connect(new PlatformNotificationReceiver(Handler), ExchangeName ?? DefaultExchange);

        PlatformNotificationHubConnection(IPlatformNotificationHub ConnectedHub, string ExchangeName, CorrelationToken ConnectionId)
            : base(ConnectedHub, ExchangeName, ConnectionId)
        {

        }
    }
}