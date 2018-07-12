//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;

    using static metacore;

    using MetaFlow.XE;

    public class PlatformNotificationReceiver :  IPlatformNotificationReceiver
    {       
        Action<PlatformNotification> MessageHandler { get; }


        internal PlatformNotificationReceiver(Action<PlatformNotification> MessageHandler)
            => this.MessageHandler = MessageHandler;


        public void OnMessage(PlatformNotification Notification)
            => MessageHandler(Notification);
    }

}