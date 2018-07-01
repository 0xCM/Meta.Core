//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IQueueBroadcaster : IDisposable
    {
        Guid Publish(object message);

        void Publish(object message, Guid messageId);

    }

    public interface IQueueBroadcaster<M> : IQueueBroadcaster
        where M: new()
    {
        Guid Publish(M message);

        void Publish(M message, Guid messageId);
    }

}