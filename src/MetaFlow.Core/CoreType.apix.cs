//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Reflection;
    using System.Linq;

    using Meta.Core;    
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Workflow;
    using SqlT.Types.MC;

    using MetaFlow.Core;
    using MetaFlow.WF;
    using MetaFlow.XE;

    using static metacore;

    public static partial class CoreTypes
    {
        public static SystemMessageIdentity MessageIdentity(this MessageTypeRegistration message)
            => new SystemMessageIdentity(message.SystemId, message.SchemaName, message.TypeName);

        public static SystemMessageIdentity IdentifyBySystem(this ISystemEventCapture message)
            => new SystemMessageIdentity(SystemIdentifier.Parse(message.SourceSystemId), message.EventType);

        public static TypedDataFlowDescriptor ToTypedDataFlow(this SqlDataFlowDescriptor df)
            => new TypedDataFlowDescriptor
            (
                SourceAssembly: df.SourceAssembly.DefininingAssembly.GetSimpleName(),
                TargetAssembly: df.TargetAssembly.DefininingAssembly.GetSimpleName(),
                DataFlowName: df.ImplementingType.Name,
                WorkflowTypeUri: df.ImplementingType.Uri(),
                ArgumentTypeUri: df.ArgumentSetType.Uri()
            );

        public static PlatformDac ToPlatformDac(this SqlPackageDescription description)
        {
            var componentInfo = from path in description.AssemblyLocation
                                let a = Assembly.LoadFile(path.AbsolutePath)
                                let version = a.GetName().Version
                                let id = a.GetSimpleName()
                                let ts = path.ChangedTS
                                let product = a.Product().MapValueOrDefault(product => product.Split('/'), array<string>())
                                let system = product.Length == 3 ? SystemIdentifier.Parse(product[1]) : SystemIdentifier.Empty
                                select (system, id, version, ts);

            return componentInfo.Map(sv
                => new PlatformDac(sv.system, description, sv.id, sv.version, sv.ts.Value),
                () => new PlatformDac(SystemIdentifier.Empty, description, "", Version.Parse("1.0.0.0"), now()));
        }

        public static SystemNode ToSystemNode(this PlatformNode Src)            
             => new SystemNode
             (
                 NodeName: Src.NodeName,
                 NodeIdentifier: Src.NodeId,
                 NodeServer: Src.HostName,
                 NetworkName: Src.NetworkName,
                 ExternalIP: Src.HostIP,
                 Port: null,
                 IsLocal: Src.NodeName == PlatformVariables.SystemNode.ResolveValue().Require()
             );

        public static SqlDatabaseServer ToSqlDatabaseServer(this DatabaseServer Src, SystemNode Host)
            => new SqlDatabaseServer
            (
                Host: Host,
                  InstanceName: Src.SqlInstanceName,
                  Port: Src.SqlInstancePort,
                  Alias: new SqlServerAlias(Src.SqlAlias, Src.SqlInstanceName),
                  DefaultCredentials: new SqlUserCredentials(Src.SqlOperatorName, Src.SqlOperatorPass),
                  FileStreamRoot: new NodeUncShare(Host, new UncRoot(Src.FileStreamRoot)),
                  SqlNodeId: Src.SqlNodeId
                );

        public static SystemComponent ToSystemComponent(this ComponentDescriptor Src)
            => new SystemComponent
            (
                ComponentId: Src.ComponentId,
                SystemId: Src.SystemId,
                ComponentType: Src.Classification.ToString(),
                ComponentVersion: Src.Version.ToString(),
                ComponentTS: Src.CreatedTS
            );

        public static string Format(this PlatformProject Src)
            => $"{Src.SystemId}/{Src.ProjectId}";

        public static PlatformSystemKind ToKind(this SystemIdentifier Src)
            => parseEnum<PlatformSystemKind>(Src.Identifier);
        
        public static PlatformSystem ToPlatformSystem(this SystemIdentifier Src)
            => new PlatformSystem((byte)Src.ToKind(), Src.Identifier, Src.Identifier, null);
   
        public static ExecutableFile ToExecutable(this ToolRegistration registration)
            => new ExecutableFile(registration.ExecutableName);

        public static PlatformDacRegistration RegistrationEntry(this PlatformDac dac)
            => new PlatformDacRegistration(
                    SystemId: dac.DefiningSystem.IsEmpty ? "PF" : dac.DefiningSystem.IdentifierText,
                    PackageName: dac.PackageName,
                    ComponentId: dac.ComponentId,
                    ComponentVersion: dac.ComponentVersion.ToString(),
                    ComponentTS: dac.ComponentTS
                );

        public static Option<SystemIdentifier> Lookup(this PlatformSystems systems, string System)
            => new PlatformSystems().TryGetSingle(x => string.Compare(x.IdentifierText, System, true) == 0);

        public static Option<SystemIdentifier> Lookup(this PlatformSystems systems, PlatformSystemKind Classifier)
            => systems.Lookup(Classifier.ToString());


        static readonly IReadOnlySet<string> Fields
            = roset("error_number", "message", "severity");

        static readonly IReadOnlySet<string> Actions
            = roset("client_hostname", "client_app_name", "database_id", "session_id", "username");

        static readonly Core.PlatformDatabaseServers DatabaseServers = new Core.PlatformDatabaseServers();

        static Option<SystemNodeIdentifier> IdentifyServer(string hostname)
             => from x in DatabaseServers.TryGetFirst(x => string.Equals(x.HostName, hostname, StringComparison.InvariantCultureIgnoreCase))
                select SystemNodeIdentifier.Parse(x.HostId);

        public static PlatformNotification ToPlatformNotification(this SqlXEventDataset dataset)
           => new PlatformNotification
           (
               timestamp: dataset.EventTS,
               message: dataset.FieldValue<string>("message"),
               error_number: dataset.FieldValue<int>("error_number"),
               severity: (byte)dataset.FieldValue<int>("severity"),
               client_hostname: IdentifyServer(dataset.ActionValue<string>("client_hostname")).ValueOrDefault(dataset.ActionValue<string>("client_hostname")),
               client_app_name: dataset.ActionValue<string>("client_app_name"),
               username: dataset.ActionValue<string>("username")
           );

        public static SystemUri.PathSegment Path(this ISystemCommand Command)
            => $"{Command.GetType().DefiningSystem()}/{Command.GetType().Name}";

        public static string Format(this ISystemEventIdentity Identity)
            => Identity.EventId.ToString("N")
            + (Identity.PairId.HasValue
                    ? $"/{Identity.PairId.Value.ToString("N")}"
                    : string.Empty);

        public static ISystemEventIdentity PairedWith(this ISystemEventIdentity Identity, Guid PairId)
            => new SystemEventIdentity(Identity.EventId, PairId);

        public static SystemCommandUri TargetedUri(this ISystemCommand command)
            => SystemCommandUri.TargetedUri(command);

        public static SystemCommandUri ReferenceUri(this ISystemTask task)
            => SystemCommandUri.ReferenceUri(task);

        public static SystemCommandUri ReferenceUri(this ISystemCommand command)
            => SystemCommandUri.ReferenceUri(command);

        public static SystemEventUri ReferenceUri(this ISystemEventCapture @event)
            => SystemEventUri.ReferenceUri(@event);

    }
}
