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
    using System.ComponentModel;
    using System.Reflection;
    using Meta.Core;

    using SqlT;
    using SqlT.Core;
    using SqlT.Services;
    using SqlT.Models;
    using SqlT.Workflow;
    using SqlT.Types;


    using MetaFlow.Core;
    using MetaFlow.WF;
    using MetaFlow.Core.Storage;

    using static StatusMessages;

    using static metacore;


     class PlatformSync : SqlDataFlow<SqlDataFlowArgs, MetaFlowCoreStorage>
    {
        public PlatformSync(ILinkedContext C)
            : base(C.ChannelFactory<MetaFlowCoreStorage>(PlatformDatabaseKind.MetaFlow))
        {
            Reflector = C.SystemReflector();

        }


        ISystemReflector Reflector { get; }

        IProxyServices ProxyServices
            => C.PlatformProxyServices();

        ISqlPackageManager PacMan
            => C.SqlPackageManager();

        protected Option<int> TargetExec<P>(P proc = null)
              where P : class, ISqlProcedureProxy, new()
            => TargetBroker.Call(proc ?? new P(), Notify);


        void SyncVariables()
        {
            var names = new PlatformVariables().Select(v => v.VariableName.IdentifierText).ToReadOnlySet();
            var vars = Lst.make(from v in C.TargetContext.SqlHostServices().NodeVariables
                            where names.Contains(v.VariableName)
                            select new PlatformVariable(v.VariableName, v.VariableValue));

            if (vars.Count != 0)
                SavePlatformVariables(vars).OnNone(Notify);


        }

        Option<int> SavePlatformVariables(Lst<PlatformVariable> Variables)
            => TargetExec(new StorePlatformVariables(Variables.AsReadOnlyList()));

        void SyncMessageTypeRegistry()
        {
            var wf = from x in TargetExec(new SyncMessageTypeRegistry(Pull(new MessageTypes()), Pull(new MessageAttributes())))
                     from y in TargetExec(new SyncMessageFormats((list(Pull(new MessageFormats())))))
                     select x;
            wf.OnSome(_ => SynchronizedMessageTypeRegistry())
                .OnNone(Notify);
        }

        void SyncHostMessageTypeRegistry()
        {
            var descriptions = list(SystemMessageTypeInfo.Construct(Reflector.SystemEventTypes, Reflector.SystemCommandTypes));
            var registrations = descriptions.Select(x => x.Registration).AsReadOnlyList();
            var attributes = rolist(from d in descriptions.Stream()
                             from a in d.Attributes
                             select a);
            Witness(TargetExec(new SyncMessageTypeRegistry(
                registrations,
                attributes)), _ => Notify(SynchronizedMessageTypeRegistry()), Notify);


        }

        void SyncHostSystemComponents()
        {
            var descriptions = list(Reflector.ComponentDescriptions);
            
            var components = map(descriptions.Where(x => not(x.SystemId.IsEmpty)), d => d.ToSystemComponent());

            Witness(TargetExec(new SyncSystemComponents(components)),
               _ => Notify(SynchronizedPlatformComponents()), Notify);
        }

        void SyncHostPlatformProjects()
            => Witness(TargetExec(new SyncPlatformProjects(list(Reflector.PlatformProjects))),
                _ => Notify(SynchronizedPlatformSolutions()), Notify);

        void SyncHostPlatformSolutions()
            => Witness(TargetExec(new SyncPlatformSolutions(Reflector.PlatformSolutions)),
                _ => Notify(SynchronizedPlatformProjects()), Notify);

        void SyncHostSystemEvents()
            => Witness(TargetExec(new SyncEventRegistry(list(Reflector.SystemEvents))),
                _ => Notify(SynchronizedEventRegistry()), Notify);

        void SyncHostSystemCommands()
                    => Witness(TargetExec(new SyncSystemCommandRegistry(list(Reflector.SystemCommands))),
                        _ => Notify(SynchronizedCommandRegistry()), Notify);

        void SyncHostPlatformAgents()
            => Witness(TargetExec(new SyncPlatformAgents(list(Reflector.PlatformAgents))),
                _ => Notify(SynchronizedPlatformAgents()), Notify);


        void SyncHostPlatformSystems()
            => Witness(TargetExec(new SyncPlatformSystems(
                map(Reflector.Systems, c => c.ToPlatformSystem()))),
                _ => Notify(SynchronizedPlatformSystems()), Notify);

        void SyncHostDistributionRegistry()
            => Witness(TargetExec(new SyncDistributionRegistry(
                list(Reflector.Distributions))),
                _ => Notify(SynchronizedDistributionRegistry()),
                error => Notify(error));

        void SyncHostPlatformDacRegistry()
        {
            var dacs = list(Reflector.PlatformDacs);

            var registryEntries = dacs.Select(x => x.RegistrationEntry());
            Witness(TargetExec(new SyncPlatformDacRegistry(registryEntries)),
               _ => Notify(SynchronizedPlatformDacRegistry()),
               error => Notify(error));

            var profileQuery = from profilePath in Reflector.DacProfileFiles
                               let profileLoad = PacMan.LoadProfile(profilePath)
                               where profileLoad.IsSome()
                               let profile = profileLoad.Require()
                               let targetNode = profile.TargetConnectionString.TargetNodeId()
                               where targetNode.IsSome()
                               select profileLoad.MapRequired(p =>
                               new DacProfileDefinition
                               (
                                    ProfileFileName: profilePath.FileName,
                                    SourcePackage: "",
                                    TargetNodeId: targetNode.Require(),
                                     ProfileSourcePath: p.SourcePath.Map(path => path.AbsolutePath, () => profilePath.AbsolutePath),
                                     ProfileXml: p.SourceXml,
                                     TargetDatabase: p.TargetDatabaseName.UnquotedLocalName
                               ));

            var profiles = list(profileQuery);
            Witness(TargetExec(new SyncDacProfiles(profiles)),
               _ => Notify(SynchronizedDacProfiles()),
               error => Notify(error));

        }

        void SyncHostDataFlowRegistry()
            => Witness(TargetExec(new SyncTypedDataFlowRegistry
                (list(Reflector.DataFlows.Select(x => x.ToTypedDataFlow())))),
                _ => Notify(SynchronizedDataFlowRegistry()),
                error => Notify(error));

        void SyncHostProxySpecs()
            => (from profiles in some(Reflector.ProxyAssemblyDescriptions.ToReadOnlyList())
                from saved in ProxyServices.SaveAssemblyDescriptions(profiles)
                select profiles).OnNone(Notify).OnSome(profiles => Notify(SynchronizedProxyProfiles(profiles.Count)));


        void SyncHost()
        {
            var commonActions = new Action[] {
                    SyncVariables,
                    SyncHostPlatformSystems,
                    SyncHostPlatformAgents,
                    SyncHostSystemComponents,
                    SyncHostDistributionRegistry,
                    SyncHostPlatformDacRegistry,
                    SyncHostDataFlowRegistry,
                    SyncHostSystemCommands,
                    SyncHostSystemEvents
                    };            

            var buildActions = new Action[] {
                    SyncHostPlatformSolutions,
                    SyncHostPlatformProjects,
                    SyncHostProxySpecs
                };

            var selected = unionize(commonActions, buildActions);
            iter(selected, a => a(), true);

            SyncHostMessageTypeRegistry();            
        }
       
        void SyncTableTypes()
        {
            TargetExec(new SyncMessageClasses(
                map(Pull(new MessageClasses()), row => new TinyTypeTableRow(row.TypeCode, row.Identifier, row.Label, row.Description)))
                ).OnNone(Notify);
        }

        void SyncTarget()
        {
            SyncTableTypes();
            SyncMessageTypeRegistry();
        }

        public override WorkFlowed<int> Execute(SqlDataFlowArgs args)
        {
            if (SourceNode.NodeIdentifier == TargetNode.NodeIdentifier)
                SyncHost();
            else
                SyncTarget();

            return 0;
        }
    }
}