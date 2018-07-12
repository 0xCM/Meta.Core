//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using N = SystemNodeIdentifier;

    using static metacore;

    using MetaFlow.WF;
    using MetaFlow.Core;

    public sealed class SystemEventUri : SystemUri<SystemEventUri>
    {
        public static readonly SystemUri.SchemeSegment EventScheme = "pdms.events";
        public static readonly SystemUri.HostSegment ReferenceHost = "anyhost";

        public static SystemEventUri Parse(string UriText)
            => new SystemEventUri(SystemUri.Parse(UriText));

        public static SystemUri.HostSegment HostSegment(N HostId = null)
            => isNull(HostId)
            ? ReferenceHost
            : SystemUri.HostSegment.Parse(HostId);

        public static SystemEventUri ReferenceUri(Type EventType)
            => new SystemEventUri
                (
                    new SystemUri
                    (
                        EventScheme,
                        ReferenceHost,
                        $"{EventType.DefiningSystem()}/{EventType.Name}"
                    )
                );

        public static SystemEventUri ReferenceUri(ISystemEventCapture @event)
            => new SystemEventUri
            (
                new SystemUri
                (
                    EventScheme, 
                    ReferenceHost, 
                    $"{@event.SourceSystemId}/{@event.EventType}"
                )
            );


        public static SystemEventUri ReferenceUri<T>()
            where T : class, ISystemEvent, new()
                => ReferenceUri(typeof(T));


        public static SystemEventUri Define(N Host, SystemIdentifier System, Type BodyType, ISystemEventIdentity Identity)
            => new SystemEventUri(SystemUri.Define
                (
                   scheme: EventScheme,
                   host: new SystemUri.HostSegment(Host),
                   path: $"{System}/{BodyType.Name}/{Identity.Format()}"
                ));

        SystemEventUri(SystemUri Uri)
            : base(Uri)
        {

        }

        public SystemIdentifier DefiningSystem
            => Path.Components().TryGetFirst()
                   .MapValueOrDefault(x => SystemIdentifier.Parse(x), SystemIdentifier.Empty);

        public override string ToString()
            => base.Subject.ToString();

    }
}
