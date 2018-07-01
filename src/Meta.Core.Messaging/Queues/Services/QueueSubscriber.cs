﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Queues
{
    using System;
    using System.Collections.Generic;


    public static class QueueSubscriber
    {
        public static IQueueSubscriber<M> Define<M>(Action<M> OnMessage, Action OnConectionClosed = null)
            where M : new()
                => new QueueSubscriber<M>(OnMessage, OnConectionClosed);

        public static IQueueSubscriber Define(Action<object> OnMessage, Type MessageType, Action OnConnectionClosed = null)
        {
            var typedef = typeof(QueueSubscriber<>).GetGenericTypeDefinition();
            var type = typedef.MakeGenericType(MessageType);
            var Receiver = Activator.CreateInstance(type, new object[] { OnMessage, OnConnectionClosed});
            return Receiver as IQueueSubscriber;

        }

    }

    sealed class QueueSubscriber<M> : IQueueSubscriber<M>
        where M :new()
    {

        public QueueSubscriber(Action<object> OnMessage, Action OnConnectionClosed = null)
        {            
            MessageHandler = (M message) => OnMessage(message);
            this.OnConnectionClosed = OnConnectionClosed;
        }
        public QueueSubscriber(Action<M> OnMessage, Action OnConnectionClosed = null)
        {
            this.MessageHandler = OnMessage;
            this.OnConnectionClosed = OnConnectionClosed;
        }

       
        Action<M> MessageHandler { get; }

        Action OnConnectionClosed { get; }

        public void OnMessage(M Message)
            => MessageHandler(Message);

        void IQueueSubscriber.OnMessage(object Message)
            => OnMessage((M)Message);

        public void Dispose()
        {
            OnConnectionClosed?.Invoke();
        }

    }
}