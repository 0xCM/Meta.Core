//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

/// <summary>
/// Where good messages go to die
/// </summary>
public class AnemicMessageBroker : IMessageBroker
{

    public CorrelationToken? Route(IApplicationMessage message, bool immediate)
        => message.CT;

    public IDisposable Listen(AppMessageObserver Observer, string messageTypeName)
        => this;

    public void Dispose()
    { }

}
