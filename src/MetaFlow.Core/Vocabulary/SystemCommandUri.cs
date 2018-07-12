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


    public sealed class SystemCommandUri : SystemUri<SystemCommandUri>
    {
        public static readonly SystemUri.SchemeSegment CommandScheme = "metaflow.cmd";
        public static readonly SystemUri.HostSegment ReferenceHost = "anyhost";

        public static SystemCommandUri Parse(string UriText)
            => new SystemCommandUri(SystemUri.Parse(UriText));

        public static SystemCommandUri ReferenceUri(ISystemTask task)
            => new SystemCommandUri(SystemUri.Parse(task.CommandUri).WithNewHost(ReferenceHost));

        public static SystemUri.HostSegment HostSegment(N HostId = null)
            => isNull(HostId) 
            ? ReferenceHost 
            :  SystemUri.HostSegment.Parse(HostId);

        public static SystemCommandUri TargetedUri(N CommandNode, ISystemCommand command)
            => new SystemCommandUri(new SystemUri(
                    CommandScheme,
                    command.CommandNode,
                    PathSegment(command))
                );

        public static SystemCommandUri TargetedUri(ISystemCommand command)
            => new SystemCommandUri(new SystemUri(
                    CommandScheme, 
                    command.CommandNode, 
                    PathSegment(command)));

        public static string ParseCommandTypeName(ISystemTask task)
            => task.ReferenceUri().Path.Components().Last();

        public static SystemCommandUri ReferenceUri(Type CommandType)
            => new SystemCommandUri
                (
                    new SystemUri
                    (
                        CommandScheme,
                        ReferenceHost,
                        $"{CommandType.DefiningSystem()}/{CommandType.Name}"
                    )
                );

        public static SystemUri.PathSegment PathSegment(ISystemCommand command)
            => $"{command.GetType().DefiningSystem()}/{command.GetType().Name}";

        public static SystemCommandUri ReferenceUri(ISystemCommand command)
            => new SystemCommandUri
            (
                new SystemUri
                (
                    CommandScheme, 
                    ReferenceHost, 
                    PathSegment(command)
                )
            );


        public static SystemCommandUri ReferenceUri<T>()
            where T : class, ISystemCommand, new()
                => ReferenceUri(typeof(T));


        SystemCommandUri(SystemUri Uri)
            : base(Uri)
        {

        }

        public SystemIdentifier DefiningSystem
            => Path.Components().TryGetFirst()
                   .MapValueOrDefault(x => SystemIdentifier.Parse(x), SystemIdentifier.Empty);

        public SystemCommandUri ToReferenceUri()
            => new SystemCommandUri(new SystemUri(Scheme, ReferenceHost, Path, Query));

        public override string ToString()
            => base.Subject.ToString();

    }
}
