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

    using static metacore;

    using MetaFlow.Core;
    using MetaFlow.WF;

    using Meta.Core.Messaging;

    public class SystemNotificationHubConnection : HubConnection<ISystemNotificationHub,SystemNotification>
    {
        public static readonly string DefaultExchange = "SystemNotifications";

        static SystemNotificationHubConnection Connect(ISystemNotificationReceiver receiver, string ExchangeName)
        {
            var address = $"net.pipe://localhost/{ExchangeName}";
            var serviceContext = new InstanceContext(receiver);
            var channelFactory = new DuplexChannelFactory<ISystemNotificationHub>(serviceContext, new NetNamedPipeBinding(), new EndpointAddress(address));
            var exchange = channelFactory.CreateChannel();
            var connectionId = exchange.Connect();
            var connection = new SystemNotificationHubConnection(exchange, ExchangeName, connectionId);
            return connection;
        }

        public static IHubConnection<SystemNotification> Create(Action<SystemNotification> Handler, string ExchangeName = null)
            => Connect(new SystemNotificationReceiver(Handler), ExchangeName ?? DefaultExchange);

        SystemNotificationHubConnection(ISystemNotificationHub ConnectedHub, string ExchangeName, CorrelationToken ConnectionId)
            : base(ConnectedHub, ExchangeName, ConnectionId)
        {

        }
    }
}