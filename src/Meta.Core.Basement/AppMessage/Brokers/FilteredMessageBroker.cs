//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

public class FilteredMessageBroker : IMessageBroker
{
    readonly Func<IApplicationMessage,bool> allow;
    readonly Func<IMessageBroker> Broker;

    public FilteredMessageBroker(Func<IMessageBroker> broker, Func<IApplicationMessage, bool> allow)
    {
        this.Broker = broker;
        this.allow = allow;

    }

    bool CanHear(IApplicationMessage Message)
        => allow(Message);

    void ConditionalRelay(IApplicationMessage Message)
    {
        if (allow(Message))
            Broker().Route(Message);            
    }

    public IDisposable Listen(Action<IApplicationMessage> observer)
        => Broker().Listen(ConditionalRelay);

    public CorrelationToken? Route(IApplicationMessage message, bool immediate)
        => CanHear(message) 
        ? Broker().Route(message, immediate) 
        : null;

    public IDisposable Listen(AppMessageObserver Observer, string messageTypeName)
        => Broker().Listen(ConditionalRelay, messageTypeName);

    public void Dispose()
        => Broker().Dispose();
}