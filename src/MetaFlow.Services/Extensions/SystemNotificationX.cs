//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// 
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;

    using Meta.Core;
    using SqlT.Core;


    using MetaFlow.Core;
    using MetaFlow.WF;
    using MetaFlow.Commands;

    using N = SystemNodeIdentifier;
    using static metacore;


    public static class SystemNotificationX
    {

        static readonly N Host = SystemNode.Local.NodeIdentifier;


        static SystemNotificationX()
        {
            
        }


        static Guid newid()
            => Guid.NewGuid();

        static SystemIdentifier system<E>()
            where E : class, ISystemEvent, new()
                => typeof(E).DefiningSystem();

        static SystemEventUri uri<E>(ISystemEventIdentity identity)
            where E : class, ISystemEvent, new()
            => SystemEventUri.Define(Host, system<E>(), typeof(E), identity);

        static ISystemEventIdentity id()
              => new SystemEventIdentity(newid(), null);

        static ISystemEventIdentity id(Guid antecedent)
            => new SystemEventIdentity(antecedent, newid());


        public static SystemNotification ToSytemNotification<E>(this E @event,
                ISystemEventIdentity identity = null,
                CorrelationToken? CT = null,
                int SeverityLevel = 0
            )
            where E : class, ISystemEvent, new()
            => new SystemNotification

            (
                   EventId: identity?.EventId ?? id().EventId,
                   PairId: identity?.PairId,
                   SourceNodeId: @event.HostId,
                   SourceSystemId: system<E>(),
                   EventType: typeof(E).Name,
                   EventUri: uri<E>(identity),
                   CorrelationToken: CT,
                   SeverityLevel: SeverityLevel,
                   EventTS: now(),
                   EventBody: JsonServices.ToJson(@event),
                   FormattedMessage: @event.ToString()
              );

        public static SystemNotification CommandExecuting<T>(this T task)
            where T : class, ISystemTask, new()
            => ToSytemNotification(new E0.CommandExecuting(task.TargetNodeId, task.TaskId, task.CommandUri));

        //public static SystemNotification ExchangeConnected(string ExchangeName)
        //    => ToSytemNotification(new E0.ExchangeConnected(Host, ExchangeName), id());

    }


}