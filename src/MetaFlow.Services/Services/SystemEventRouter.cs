//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;

    using static metacore;
    using static StatusMessages;

    using MetaFlow.WF;
    using SqlT.Core;

    class SystemEventRouter : PlatformService<SystemEventRouter, ISystemEventRouter>, ISystemEventRouter
    { 
        IReadOnlyDictionary<SystemEventUri, ISystemEventReactor> ReactorLookup { get; }

        public SystemEventRouter(INodeContext C)
            : base(C)
        {
            ReactorLookup = dict(from r in Reflector.SystemEventReactors from e in r.SupportedEvents select (e, r));
        }

        Option<ISystemEventReactor> LookupReceiver(ISystemEventCapture @event)
        {
            var uri = @event.ReferenceUri();
            if (ReactorLookup.TryGetValue(uri, out ISystemEventReactor reactor))
                return some(reactor);
            else
                return none<ISystemEventReactor>();
        }


        IEnumerable<SystemEventUri> ISystemEventRouter.SupportedEvents
            => ReactorLookup.Keys;

        SystemNode INodeComponent.Host
            => C.Host;

        ISystemEventReaction ISystemEventRouter.Route(ISystemEventCapture @event)
            => LookupReceiver(@event)
                        .Map(e => e.React(@event),
                            () => new SystemEventReaction(@event, false, ReactorNotFound(@event.ReferenceUri())));
    }

}