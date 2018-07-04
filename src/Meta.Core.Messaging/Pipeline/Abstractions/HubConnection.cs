//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Messaging
{ 
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using static metacore;



    public abstract class HubConnection<H,M> : IHubConnection<H,M>
        where H : IMessageHub<M>
    {
        public H ConnectedHub { get; }

        protected HubConnection(H ConnectedHub, string ExchangeName, CorrelationToken ConnectionId)
        {
            this.ConnectedHub = ConnectedHub;
            this.ConnectionId = ConnectionId;
            this.ExchangeName = ExchangeName;
        }

        public CorrelationToken ConnectionId { get; }

        public string ExchangeName { get; }

        IMessageHub IHubConnection.ConnectedHub
            => ConnectedHub;

        IMessageHub<M> IHubConnection<M>.ConnectedHub
            => ConnectedHub;
    }



 

}