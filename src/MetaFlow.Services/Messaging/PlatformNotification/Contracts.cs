//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using System.ServiceModel;

    using Meta.Core.Messaging;

    using MetaFlow.XE;

    using static metacore;

    public interface IXEventObserver<out X>
        where X : IXEventDataType
    {
        CorrelationToken Listen(Action<X> Observer, Func<bool> Cancel);
    }


    public interface IPlatformNotificationObserver : IXEventObserver<PlatformNotification>
    {
        
    }

    [ServiceContract(SessionMode = SessionMode.Required,
       CallbackContract = typeof(IPlatformNotificationReceiver))]
    public interface IPlatformNotificationHub : IMessageHub<PlatformNotification>
    {
        [OperationContract]
        CorrelationToken Connect();

        [OperationContract(IsOneWay = true)]
        new void RaiseEvent(PlatformNotification notification);
    }


    [ServiceContract]
    public interface IPlatformNotificationReceiver : IHubMessageReceiver<PlatformNotification>
    {
        [OperationContract(IsOneWay = true)]
        void OnMessage(PlatformNotification Notification);
    }
}