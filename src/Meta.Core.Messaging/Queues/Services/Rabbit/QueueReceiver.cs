//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
#if Rabbit
namespace Meta.Core.Queues
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections.Concurrent;
    using System.Threading;

    using Meta.Core.Messaging;

    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    using static metacore;


    sealed class QueueReceiver<M> : NodeComponent, IQueueReceiver<M>
        where M : new()
    {

        ConcurrentDictionary<CorrelationToken, IQueueSubscriber> Subscribers { get; }
            = new ConcurrentDictionary<CorrelationToken, IQueueSubscriber>();

        int Failures = 0;
        int Successes = 0;

        QueueConnection Connection { get; }

        EventingBasicConsumer Consumer { get; }

        IModel Channel
            => Connection.Channel;


        void OnDelieveryFailure(BasicDeliverEventArgs @event, IApplicationMessage Reason)
        {
            Interlocked.Increment(ref Failures);
            Notify(Reason);
        }


        void OnMessage(BasicDeliverEventArgs @event)
        {
            try
            {
                var message = DecodeMessage(@event.Body);
                map(Subscribers.Values, 
                    s => task(() 
                        => Try(() => s?.OnMessage(message.Body))
                                .OnNone(error => OnDelieveryFailure(@event, error))
                                .OnSome(_ => Interlocked.Increment(ref Successes))
                        ));
                if (not(Connection.Connector.Settings.AutoAck))
                    Channel.BasicAck(@event.DeliveryTag, false);
            }
            catch(Exception e)
            {
                Notify(error(e));
            }
        }


        JsonMessage<M> DecodeMessage(byte[] body)
        {
            var info = JsonServices.ToObject<MessageInfo>(Encoding.UTF8.GetString(body));
            var message = JsonMessage<M>.FromInfo(info);
            return message;

        }

        public QueueReceiver(INodeContext C, QueueConnector Connector)

            : base(C)
        {
            Connection = new QueueConnection(Connector);
            Consumer = new EventingBasicConsumer(Channel);
            Consumer.Received += (channel, e) => OnMessage(e);            
            Channel.BasicConsume
                (   queue: Connector.QueueName, 
                    autoAck: Connector.Settings.AutoAck, 
                    consumer: Consumer
                 );
        }

        public CorrelationToken Subscribe(IQueueSubscriber<M> Subscriber)
        {
            var ct = CorrelationToken.Create();
            Subscribers.TryAdd(ct, Subscriber);
            return ct;
        }

        public void Dispose()
        {
            Connection?.Dispose();

            iter(Subscribers.Keys, k =>
            {
                if (Subscribers.TryRemove(k, out IQueueSubscriber subscriber))
                    subscriber?.Dispose();

            });
        }

        public void Cancel(CorrelationToken SubscriptionId)
            => Subscribers.TryRemove(SubscriptionId, out IQueueSubscriber subcriber);
                

        CorrelationToken IQueueReceiver.Subscribe(IQueueSubscriber Subscriber)
        {
            var ct = CorrelationToken.Create();
            Subscribers.TryAdd(ct, Subscriber);
            return ct;

        }
    }
}



#endif