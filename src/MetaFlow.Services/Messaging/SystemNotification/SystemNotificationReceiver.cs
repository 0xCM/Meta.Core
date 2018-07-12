//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;

    using MetaFlow.WF;

    using static metacore;

    public class SystemNotificationReceiver :  ISystemNotificationReceiver
    {

        Action<SystemNotification> MessageHandler { get; }


        internal SystemNotificationReceiver(Action<SystemNotification> MessageHandler)
            =>this.MessageHandler = MessageHandler;

        public void OnMessage(SystemNotification Notification)
            => MessageHandler(Notification);
    }
}