//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Queues
{
    using System;
    using System.Linq;

    public static class QueueBroadcaster
    {

        public static IQueueBroadcaster Define<M>(INodeContext C, QueueConnector Connector)
            where M : new() => new QueueBroadcaster<M>(C, Connector);

        public static IQueueBroadcaster Define(INodeContext C, Type MessageType, QueueConnector Connector)
        {
            var typedef = typeof(QueueBroadcaster<>).GetGenericTypeDefinition();
            var type = typedef.MakeGenericType(MessageType);
            var broadcaster = Activator.CreateInstance(type, new object[] { C, Connector });
            return broadcaster as IQueueBroadcaster;
        }
    }


}