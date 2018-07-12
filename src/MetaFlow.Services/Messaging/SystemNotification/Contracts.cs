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

    [ServiceContract(SessionMode = SessionMode.Required,
       CallbackContract = typeof(ISystemNotificationReceiver))]
    public interface ISystemNotificationHub : IMessageHub<SystemNotification>
    {

        [OperationContract]
        CorrelationToken Connect();

        [OperationContract(IsOneWay = true)]
        new void RaiseEvent(SystemNotification notification);

    }

    [ServiceContract]
    public interface ISystemNotificationReceiver
    {

        [OperationContract(IsOneWay = true)]
        void OnMessage(SystemNotification Notification);
    }
}