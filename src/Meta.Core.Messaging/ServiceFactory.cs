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
    using System.Text;
    using System.Threading.Tasks;

    using Meta.Core.Messaging;
    using Meta.Core.Queues;

    public static class ServiceFactory
    {
        public static IQueueBroker QueueBroker(this INodeContext C)
            => C.Agent(nameof(QueueBroker)) as IQueueBroker;
    }
}
