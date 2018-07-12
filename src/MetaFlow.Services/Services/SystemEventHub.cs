//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow.WF
{
    using System;
    using System.Linq;
    using Meta.Core;

    using SqlT.Core;
    using MetaFlow.Core;

    using static metacore;
    using N = SystemNodeIdentifier;
    using MetaFlow.Proxies.WF;

    sealed class SystemEventHub : PlatformService<SystemEventHub, ISystemEventHub>, ISystemEventHub
    {
        ISystemMessageConverter MessageConverter { get; }

        public SystemEventHub(INodeContext C)
             : base(C)
        {
            this.MessageConverter = C.Service<ISystemMessageConverter>();    
            this.EventBroker = (from connector in C.SqlConnector(Host, PlatformDatabaseKind.WF)
                               select MetaFlowWorkflowProxies.Broker(connector)).Require();
        }

        ISqlProxyBroker EventBroker { get; }

        RaiseSystemEvent Raise(ISystemEventCapture @event)
            => new RaiseSystemEvent
            (
               EventId: @event.EventId,
               PairId: @event.PairId,
               SourceNodeId: @event.SourceNodeId,
               SourceSystemId: @event.SourceSystemId,
               EventUri: @event.EventUri,
               EventType: @event.EventType,
               CorrelationToken: @event.CorrelationToken,
               SeverityLevel: @event.SeverityLevel,
               EventBody: @event.EventBody,
               EventTS: null
            );
    
        public Option<int> Persist(ISystemEventCapture @event)
            => EventBroker.Call(Raise(@event));
       
        public void RaiseEvent<TBody>(ISystemEventCapture<TBody> @event)
            where TBody : class, ISystemEvent, new()
        {
            task(() =>
            {
                try
                {
                    Notify(MessageConverter.ToApplicationMessage(@event));
                    Persist(@event).OnNone(Notify);
                }
                catch(Exception e)
                {
                    Notify(error(e));                        
                }
            });            
        }        
    }
}
