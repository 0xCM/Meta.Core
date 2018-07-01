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

    using Meta.Core.Messaging;


    public interface IQueueBroker: IServiceAgent
    {
        Guid Publish<M>(M message)
            where M : new();

        Guid Publish(object message);

        void Publish<M>(M message, Guid messageId)
            where M : new();
        void Publish(object message, Guid messageId);

        CorrelationToken Subscribe<M>(IQueueSubscriber<M> Subscriber)
            where M : new();

        CorrelationToken Subscribe(Type MessageType, IQueueSubscriber Subscriber);

        CorrelationToken Subscribe(Type MessageType, Action<object> OnMessage);

        void Cancel(CorrelationToken Subscription);

        CorrelationToken Subscribe<M>(Action<M> OnMessage)
            where M : new();

        IMessageEmitter<M> ConnectEmitter<M>()
            where M: new();




    }

}