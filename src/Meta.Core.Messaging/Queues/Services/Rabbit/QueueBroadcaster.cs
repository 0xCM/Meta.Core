﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Queues
{
#if Rabbit
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Meta.Core.Messaging;

    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    using static metacore;


    sealed class QueueBroadcaster<M> : NodeComponent, IQueueBroadcaster<M>
            where M : new()
    {

        QueueConnection Connection { get; }

        IModel Channel
            => Connection.Channel;

        IBasicProperties ChannelProperties
        {
            get
            {
                var properties = Channel.CreateBasicProperties();
                properties.Persistent = not(Connection.Connector.Settings.Transient);
                return properties;
            }
        }

        public QueueBroadcaster(INodeContext C, QueueConnector Connector)
            : base(C)
        {
            Connection = new QueueConnection(Connector);
        }

        byte[] Encode(JsonMessage<M> Message)
            => Encoding.UTF8.GetBytes(JsonServices.ToJson(Message.MessageInfo));

        public Guid Publish(M message)
        {
            var id = Guid.NewGuid();
            Send(new JsonMessage<M>(message,id));
            return id;
        }

        public void Publish(M message, Guid messageId)
            => Send(new JsonMessage<M>(message, messageId));
      
        void Send(JsonMessage<M> Message)
            => Channel.BasicPublish
                (
                    exchange: "", 
                    routingKey: Connection.Connector.QueueName, 
                    basicProperties: ChannelProperties,
                    body: Encode(Message)
                
                );
        
        public void Dispose()
            => Connection?.Dispose();

        Guid IQueueBroadcaster.Publish(object message)
            => Publish((M)message);

        void IQueueBroadcaster.Publish(object message, Guid messageId)
            => Publish((M)message, messageId);
    }
#endif
}