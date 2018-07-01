//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Queues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections.Concurrent;
    using System.Threading;

    using Meta.Core.Messaging;

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

    sealed class QueueReceiver<M> : NodeComponent, IQueueReceiver<M>
        where M : new()
    {
        public QueueReceiver(INodeContext C, QueueConnector Connector)
            : base(C)
        { }

        public void Cancel(CorrelationToken SubscriptionId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public CorrelationToken Subscribe(IQueueSubscriber<M> Subscriber)
        {
            throw new NotImplementedException();
        }

        public CorrelationToken Subscribe(IQueueSubscriber Subscriber)
        {
            throw new NotImplementedException();
        }
    }

}