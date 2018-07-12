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
    using MetaFlow.WF;

    using static metacore;

    
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]

    public class SystemNotificationHub : MessageHub<SystemNotificationHub,ISystemNotificationHub, SystemNotification>, ISystemNotificationHub
    {
        public SystemNotificationHub()
        {
            Receiver = OperationContext.Current.GetCallbackChannel<ISystemNotificationReceiver>();
        }

        ISystemNotificationReceiver Receiver { get; set; }

        public override CorrelationToken Connect()        
            => CorrelationToken.Create();
        
        public override void RaiseEvent(SystemNotification notification)        
            => Receiver.OnMessage(notification);        
    }
}