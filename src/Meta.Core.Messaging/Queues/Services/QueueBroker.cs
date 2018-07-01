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

    using Meta.Core.Messaging;




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


    [ServiceAgent(nameof(QueueBroker)), ApplicationService(nameof(QueueBroker))]
    class QueueBroker : NodeAgent<QueueBroker>, IQueueBroker
    {

        ConcurrentDictionary<QueueConnector, IQueueBroadcaster> Broadcasters { get; }
            = new ConcurrentDictionary<QueueConnector, IQueueBroadcaster>();

        ConcurrentDictionary<QueueConnector, IQueueReceiver> Receivers { get; }
            = new ConcurrentDictionary<QueueConnector, IQueueReceiver>();

        ConcurrentDictionary<CorrelationToken, IQueueReceiver> Subscriptions { get; }
            = new ConcurrentDictionary<CorrelationToken, IQueueReceiver>();

        CorrelationToken RecordSubscription(CorrelationToken SubscriptionId, IQueueReceiver Receiver)
        {
            Subscriptions.TryAdd(SubscriptionId, Receiver);
            return SubscriptionId;
                
        }

        IQueueBroadcaster Broadcaster(Type MessageType)            
            => Broadcasters.GetOrAdd(
                QueueConnector.Define(C.Host,MessageType),
                    connector => QueueBroadcaster.Define(C, MessageType, connector));

        IQueueBroadcaster Broadcaster<M>()
            where M : new()
            => Broadcasters.GetOrAdd(
                QueueConnector.Define<M>(C.Host),
                    connector => QueueBroadcaster.Define<M>(C, connector));

        IQueueReceiver Receiver<M>()
            where M : new()
            => Receivers.GetOrAdd(
                QueueConnector.Define<M>(C.Host),
                    connector => QueueReceiver.Define<M>(C, connector));

        IQueueReceiver Receiver(Type MessageType)            
            => Receivers.GetOrAdd(
                QueueConnector.Define(C.Host, MessageType),
                    connector => QueueReceiver.Define(C, MessageType, connector));


        public QueueBroker(INodeContext C)
            : base(C)
        {

        }

        protected override Option<int> DoWork()
        {
            return 0;
        }

        public void Cancel(CorrelationToken Subscription)
        {
            if (Subscriptions.TryRemove(Subscription, out IQueueReceiver receiver))
            {
                receiver?.Cancel(Subscription);
                receiver?.Dispose();
            }
        }

        public Guid Publish<M>(M message) where M : new()
            => Broadcaster<M>().Publish(message);

        Guid IQueueBroker.Publish(object message)
            => Broadcaster(message.GetType()).Publish(message);

        void IQueueBroker.Publish(object message, Guid messageId)
            => Broadcaster(message.GetType()).Publish(message,messageId);

        public void Publish<M>(M message, Guid messageId) where M : new()
            => Broadcaster<M>().Publish(message, messageId);

        public CorrelationToken Subscribe<M>(IQueueSubscriber<M> Subscriber)
            where M : new()
        {
            var receiver = Receiver<M>();
            return RecordSubscription(receiver.Subscribe(Subscriber), receiver);
        }

        public CorrelationToken Subscribe(Type MessageType, IQueueSubscriber Subscriber)            
        {
            var receiver = Receiver(MessageType);
            return RecordSubscription(receiver.Subscribe(Subscriber), receiver);
        }

        public IMessageEmitter<M> ConnectEmitter<M>()
            where M : new()
            => new QueueEmitter<M>(Receiver<M>());
            


        CorrelationToken IQueueBroker.Subscribe(Type MessageType, Action<object> OnMessage)
            => Subscribe(MessageType, QueueSubscriber.Define(OnMessage, MessageType));
      
        public CorrelationToken Subscribe<M>(Action<M> OnMessage)
            where M : new()
                => Subscribe(QueueSubscriber.Define(OnMessage));


    }

}