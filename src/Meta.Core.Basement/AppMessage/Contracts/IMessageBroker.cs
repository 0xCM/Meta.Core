//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

public interface IMessageBroker : IDisposable
{
    /// <summary>
    /// Posts a message to the broker
    /// </summary>
    /// <param name="message">The notification</param>
    CorrelationToken? Route(IAppMessage message, bool immediate = false);

    /// <summary>
    /// Subscribes to a notification
    /// </summary>
    /// <param name="listener">The action that will be invoked upon receiving a message compatible with the message type</param>
    /// <returns></returns>
    IDisposable Listen(AppMessageObserver listener, string messageTypeName = null);
}

