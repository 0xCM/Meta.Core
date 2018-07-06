//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Queues
{
    using System;
    using System.Linq;

    public static class QueueReceiver
    {
        public static IQueueReceiver Define<M>(INodeContext C, QueueConnector Connector)
            where M : new() => new QueueReceiver<M>(C, Connector);

        public static IQueueReceiver Define(INodeContext C, Type MessageType, QueueConnector Connector)
        {
            var typedef = typeof(QueueReceiver<>).GetGenericTypeDefinition();
            var type = typedef.MakeGenericType(MessageType);
            var Receiver = Activator.CreateInstance(type, new object[] { C, Connector });
            return Receiver as IQueueReceiver;
        }
    }
}