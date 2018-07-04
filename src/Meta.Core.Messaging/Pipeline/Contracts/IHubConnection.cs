//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Messaging
{
    using System.Collections.Generic;
    using System.Linq;
    

    using static metacore;


    public interface IHubConnection
    {
        CorrelationToken ConnectionId { get; }

        string ExchangeName { get; }

        IMessageHub ConnectedHub { get; }

    }

    public interface IHubConnection<M> : IHubConnection
    {
        new IMessageHub<M> ConnectedHub { get; }
    }

    public interface IHubConnection<H, M> : IHubConnection<M>
        where H : IMessageHub<M>
    {
        new H ConnectedHub { get; }
    }



}