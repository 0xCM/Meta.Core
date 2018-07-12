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
    using System.Collections.Concurrent;

    using Meta.Core.Messaging;
    using MetaFlow.XE;

    using static metacore;
    
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class PlatformNotificationHub : MessageHub<PlatformNotificationHub,IPlatformNotificationHub,PlatformNotification>, IPlatformNotificationHub
    {
        static ConcurrentDictionary<CorrelationToken, IPlatformNotificationReceiver> Receivers { get; }
            = new ConcurrentDictionary<CorrelationToken, IPlatformNotificationReceiver>();

        static void Broadcast(PlatformNotification notification, CorrelationToken receiverId)
        {
            try
            {
                if (Receivers.TryGetValue(receiverId, out IPlatformNotificationReceiver receiver))
                {
                    receiver.OnMessage(notification);
                }
            }
            catch(CommunicationObjectAbortedException)
            {
                SystemConsole.Get().Write(inform($"Receiver {receiverId} no longer exists."));
                Receivers.TryRemove(receiverId);
            }
            catch(Exception e)
            {
                SystemConsole.Get().Write(error(e));
            }
        }

        public static void Broadcast(PlatformNotification notification)
        {
            var receivers = Receivers.Keys.ToReadOnlyList();

            iter(receivers, receiver => task(() => Broadcast(notification, receiver)));
        }

        public PlatformNotificationHub()
        {
            Receiver = OperationContext.Current.GetCallbackChannel<IPlatformNotificationReceiver>();
            ReceiverId = CorrelationToken.Create();
            Receivers.TryAdd(ReceiverId, Receiver);
        }

        CorrelationToken ReceiverId { get; }

        IPlatformNotificationReceiver Receiver { get; set; }

        public override CorrelationToken Connect()
        {
            SystemConsole.Get().Write(inform($" Created connection {ReceiverId}"));
            return ReceiverId;
        }

        public override void RaiseEvent(PlatformNotification notification)
        {
            Receiver.OnMessage(notification);
        }
    }

}