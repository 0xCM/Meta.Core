//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

/// <summary>
/// Where good messages go to die
/// </summary>
public class AnemicMessageBroker : IMessageBroker
{

    public CorrelationToken? Route(IAppMessage message, bool immediate)
        => message.CT;

    public IDisposable Listen(AppMessageObserver Observer, string messageTypeName)
        => this;

    public void Dispose()
    { }

}
