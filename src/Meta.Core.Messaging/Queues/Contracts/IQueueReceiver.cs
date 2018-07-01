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

    public interface IQueueReceiver : IDisposable
    {
        CorrelationToken Subscribe(IQueueSubscriber Subscriber);

        void Cancel(CorrelationToken SubscriptionId);
    }

    public interface IQueueReceiver<out M> : IQueueReceiver
       where M : new()
    {
        CorrelationToken Subscribe(IQueueSubscriber<M> Subscriber);
    }



}