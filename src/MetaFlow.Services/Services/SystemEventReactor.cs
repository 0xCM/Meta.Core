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

    using MetaFlow.WF;
    using SqlT.Core;

    public abstract class SystemEventReactor<R> : PlatformService<R, ISystemEventReactor>, ISystemEventReactor
        where R : SystemEventReactor<R>
    {

        IReadOnlyDictionary<SystemEventUri, SystemEventMethod> EventMethods { get; }

        Option<SystemEventMethod> EventMethod(SystemEventUri uri)
            => EventMethods.TryFind(uri);


        public SystemEventReactor(INodeContext C)
            : base(C)
        {
            EventMethods = dict(from m in SystemEventMethod.Dicover(GetType())
                                  select (m.ReferenceUri, m));

        }
        Option<object> InvokeEventMethod(SystemEventMethod cm, ISystemEvent @event)
        {
            try
            {
                return cm.Method.Invoke(this, array(@event));
            }
            catch (Exception e)
            {
                return none<object>(e);
            }
        }

        Option<ISystemEvent> EventBody(SystemEventMethod method, string bodyText)
        {
            try
            {
                return some(Serializer.ObjectFromJson(method.EventType, bodyText) as ISystemEvent);
            }
            catch (Exception e)
            {
                return none<ISystemEvent>(e);
            }
        }

        IEnumerable<SystemEventUri> ISystemEventReactor.SupportedEvents
            => EventMethods.Keys;

        Option<SystemEventReaction> React(ISystemEventCapture @event)
            => from em in EventMethod(@event.ReferenceUri())
               from body in EventBody(em, @event.EventBody)
               from result in InvokeEventMethod(em, body)
               select @event.Adjudicate(result);

        ISystemEventReaction ISystemEventReactor.React(ISystemEventCapture @event)
            => React(@event).MapValueOrElse(x => x, error => new SystemEventReaction(@event, false, error));
    }
}