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

    sealed class QueueBroadcaster<M> : NodeComponent, IQueueBroadcaster<M>
       where M : new()
    {

        public QueueBroadcaster(INodeContext C, QueueConnector Connector)
            : base(C)
        { }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Guid Publish(M message)
        {
            throw new NotImplementedException();
        }

        public void Publish(M message, Guid messageId)
        {
            throw new NotImplementedException();
        }

        public Guid Publish(object message)
        {
            throw new NotImplementedException();
        }

        public void Publish(object message, Guid messageId)
        {
            throw new NotImplementedException();
        }
    }



}