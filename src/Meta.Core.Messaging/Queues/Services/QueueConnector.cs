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

    public class QueueConnector : IEquatable<QueueConnector>
    {

        public static QueueConnector Define(SystemNode Host, Type MessageType)
            => new QueueConnector(Host.NetworkName, MessageType.Uri());

        public static QueueConnector Define<M>(SystemNode Host)
            where M : new() => Define(Host, typeof(M));


        public QueueConnector(string HostName, string QueueName, QueueConfiguration Configuration = null)
        {
            this.HostName = HostName;
            this.QueueName = QueueName;
            this.Settings = Configuration ?? new QueueConfiguration();            
          
        }

        public string HostName { get; }

        public string QueueName { get; }
        
        public QueueConfiguration Settings { get; }

        public SystemUri ConnectionUri
            => new SystemUri("mq", HostName, QueueName);

        public bool Equals(QueueConnector other)
            => other is null 
            ? false 
            : other.ConnectionUri.Equals(ConnectionUri);

        public override bool Equals(object obj)
            => Equals(obj as QueueConnector);

        public override string ToString()
            => ConnectionUri.ToString();

        public override int GetHashCode()
            => ConnectionUri.GetHashCode();
        

    }


}
