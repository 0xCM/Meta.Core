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

    using SqlT.Core;
    using SqlT.CSharp;

    using MetaFlow.Core.Storage;
    using MetaFlow.Core;

    using static metacore;

    class ProxyServices : PlatformService<ProxyServices, IProxyServices>, IProxyServices
    {
        IReadOnlyList<SqlProxyDefinition> PlatformProxyDefinitions
            => (from b in Broker
                from spec in b.Get(new SqlProxyDefinitions())
                select spec).OnNone(Notify).Items();

        IReadOnlyList<SqlProxyDefinition> FindProxyDefinitions(SqlDatabaseName DbName)
            => (from b in Broker
                from spec in b.Get(new SqlProxyDefinitionsByDatabase(DbName.UnquotedLocalName))
                select spec).OnNone(Notify).Items();


        Option<SqlProxyDefinition> FindProxyDefinition(string ProfileName)
           => from broker in Broker
              from spec in broker.Get(new FindSqlProxyDefinition(ProfileName))
              select spec.SingleOrDefault();

        public ProxyServices(INodeContext C)
            : base(C)
        {

        }

        IJsonSerializer JsonSerializer
            => C.JsonSerializer();

        ISqlProxyGenerator ProxyGenerator
            => C.CSharpProxyGenerator();

        SqlProxyGenerationResult GenerateProxies(SqlProxyDefinition spec)
        {
            try
            {
                var profile = JsonSerializer.ObjectFromJson<SqlProxyGenerationProfile>(spec.ProfileText);
                var emissions = ProxyGenerator.GenerateProxies(profile);
                return SqlProxyGenerationResult.Success(profile, emissions);
            }
            catch (Exception e)
            {
                return SqlProxyGenerationResult.Failure(spec.TargetAssembly, error(e));
            }
        }

        IEnumerable<SqlProxyGenerationResult> GenerateProxies(IEnumerable<SqlProxyDefinition> definitions, bool PLL)
            => PLL  ? definitions.AsParallel().Select(GenerateProxies)
                : definitions.Select(GenerateProxies);
        
        Option<ISqlProxyBroker> Broker
            => PlatformBroker(SystemNode.Local);

        public IEnumerable<SqlProxyGenerationResult> GenerateDefinedProxies(SqlDatabaseName DbName, bool PLL)
            => GenerateProxies(FindProxyDefinitions(DbName), PLL);

        public IEnumerable<SqlProxyGenerationResult> GeneratePlatformProxies(bool PLL)
            => GenerateProxies(PlatformProxyDefinitions, PLL);
      
        public IEnumerable<SqlProxyGenerationResult> GenerateProxySelection(params string[] profileNames)
        {            
            foreach (var profileName in profileNames)
            {
                var definition = FindProxyDefinition(profileName);
                if(!definition)
                {
                    if (definition.Message.IsEmpty)
                        C.NotifyError($"The {profileName} profile was not found");
                    else
                        C.Notify(definition.Message);
                }
                else
                    yield return GenerateProxies(definition.ValueOrDefault());
            }
        }

        Option<SqlDatabaseServer> FindAliasedServer(string AliasName)
            => (from server in  HostConfiguration.DatabaseServers()
                where string.Compare(server.Alias.ValueOrDefault()?.AliasName, AliasName, true) == 0
                select server).FirstOrDefault();

        Option<SystemNodeIdentifier> IdentifyDbServer(SqlConnectionString connector)
            => connector.ServerName.IsLocalHost
            ? HostId : from s in FindAliasedServer(connector.ServerName)
                        select s.NodeIdentifier;

        IEnumerable<SqlProxyDefinition> Translate(IEnumerable<SystemProxyAssembly> Src)
            => from description in Src.AsParallel()
               from profile in description.GenerationProfiles
               let connector = SqlConnectionString.Parse(profile.ConnectionString)
               let nodeId = IdentifyDbServer(connector).Require()
               let json = JsonSerializer.ObjectToJson(profile)
               select new SqlProxyDefinition
               (
                   AssemblyDesignator: description.DesignatorName,
                   SystemId: description.DefiningSystem,
                   ProfileName: profile.Name,
                   SourceNode: nodeId,
                   SourceDatabase: connector.DatabaseName,
                   TargetAssembly: description.Assembly.Name,
                   ProfileText: json
               );

        public Option<int> SaveAssemblyDescriptions(IEnumerable<SystemProxyAssembly> Descriptions)
            => HostPlatformBroker.Call(new SyncSqlProxyDefinitions(list(Translate(Descriptions))));
    }
}
