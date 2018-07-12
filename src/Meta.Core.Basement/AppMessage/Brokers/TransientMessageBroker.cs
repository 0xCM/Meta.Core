//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Concurrent;

using Meta.Core;

public class TransientMessageBroker : IMessageBroker
{
    /// <summary>
    /// Represents a subscriber
    /// </summary>
    class Subscriber : IDisposable
    {
        readonly Action<string, Subscriber> quit;
        readonly string messageTypeName;

        public Subscriber(string messageTypeName, AppMessageObserver Observer, Action<string, Subscriber> quit)
        {
            this.messageTypeName = messageTypeName;
            this.Observer = Observer;
            this.quit = quit;
        }

        public void Dispose()
        {
            quit(messageTypeName, this);
        }

        /// <summary>
        /// Gets the observer
        /// </summary>
        public AppMessageObserver Observer { get; }

    }

    AppMessageObserver Sentinel { get; }

    readonly ConcurrentDictionary<Guid, Guid> RoutedMessages = new ConcurrentDictionary<Guid, Guid>();


    public TransientMessageBroker()
    { }

    public TransientMessageBroker(AppMessageObserver sentinel)
    {
        this.Sentinel = sentinel;
    }

    public static IMessageBroker Create(Action<IAppMessage> sentinel = null)
        => new TransientMessageBroker(new AppMessageObserver(sentinel));



    private ConcurrentDictionary<string, ConcurrentBag<Subscriber>> subscribers
        = new ConcurrentDictionary<string, ConcurrentBag<Subscriber>>();

    /// <summary>
    /// Removes the identified subscriber
    /// </summary>
    /// <param name="messageTypeName">The message type to which the subscriber is presumably observing</param>
    /// <param name="subscriber">The subscriber to be removed</param>
    private void Unsubscribe(string messageTypeName, Subscriber subscriber)
    {
        subscribers[messageTypeName].TryTake(out subscriber);
    }

    public IDisposable Listen(AppMessageObserver Observer, string messageTypeName)
    {
        var mtn = messageTypeName ?? nameof(IAppMessage);
        var subscriber = new Subscriber(mtn, Observer, Unsubscribe);
        subscribers.GetOrAdd(mtn, t => new ConcurrentBag<Subscriber>())
                    .Add(subscriber);
        return subscriber;
    }

    public CorrelationToken? Route(IAppMessage message, bool immediate)
    {
        if (!RoutedMessages.TryAdd(message.MessageId, message.MessageId))
            return message.CT;

        Sentinel?.Invoke(message);

        foreach (var mtn in subscribers.Keys)
        {
            if (mtn == message.MessageType || mtn == nameof(IAppMessage))
            {
                foreach (var subscriber in subscribers[mtn])
                    subscriber.Observer(message);
            }
        }
        return message.CT;
    }

    public void Dispose() { }
}
