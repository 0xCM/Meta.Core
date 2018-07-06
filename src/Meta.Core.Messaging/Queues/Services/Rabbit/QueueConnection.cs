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

    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    using static metacore;

    public class QueueConnection : IDisposable
    {
        IConnection Connection { get; }

        ConnectionFactory CF { get; }

        QueueDeclareOk QueueDeclaration { get; }


        public QueueConnection(QueueConnector Connector)
        {
            CF = new ConnectionFactory { HostName = Connector.HostName };
            Connection = CF.CreateConnection();
            Channel = Connection.CreateModel();
            QueueDeclaration = Channel.QueueDeclare
            (
               queue: Connector.QueueName,
               durable: false,
               exclusive: false,
               autoDelete: false
            );

            this.Connector = Connector;

        }

        internal IModel Channel { get; }

        public QueueConnector Connector { get; }

        public void Dispose()
        {
            Connection?.Dispose();
            Channel?.Dispose();
        }
    }
}