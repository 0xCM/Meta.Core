//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections.Concurrent;
    using System.Reflection;

    using SqlT.Models;
    using SqlT.Core;

    using systems = SqlT.SqlSystem.systems;

    using static metacore;

    [Service(typeof(ISqlMetadataStore))]
    public class SqlMetadataStore : ApplicationService<SqlMetadataStore,ISqlMetadataStore>, ISqlMetadataStore
    {

        static ConcurrentDictionary<Type, IReadOnlyDictionary<string, PropertyInfo>> propcache
            = new ConcurrentDictionary<Type, IReadOnlyDictionary<string, PropertyInfo>>();

        static IReadOnlyDictionary<string, PropertyInfo> propidx<T>()
            => propcache.GetOrAdd(typeof(T),
                t => t.GetPublicInstanceProperties().ToDictionary(x => x.Name));

        static IReadOnlyList<TDst> project<TSrc, TDst>(IReadOnlyList<TSrc> src)
            where TDst : new()
        {
            var dstProps = propidx<TDst>();
            var srcProps = propidx<TSrc>().Where(x => dstProps.ContainsKey(x.Key)).ToDictionary(x => x.Key);
            var projection = map(src, item =>
            {
                var dst = new TDst();
                iter(dstProps.Values, 
                    dstProp => dstProp.SetValue(dst, srcProps[dstProp.Name].Value.GetValue(item)));
                return dst;
            });
            return projection;
        }

        public SqlMetadataStore(IApplicationContext context)
            : base(context)
        {

        }

        static IAppMessage SavedDatabaseMetadataSet(string DatabaseName, SqlMetadataStats stats)
            => AppMessage.Inform("Saved @SchemaObjectCount schema objects for @DatabaseName", new {            
                stats.SchemaObjectCount,
                DatabaseName
            });

        static IAppMessage SavedInstanceDescription(SqlServerInstanceDescription description, SqlMetadataStats stats)
        {
            var sbTemplate = new StringBuilder();
            sbTemplate.AppendLine("Received @ServerCount linked server records and @DatabaseCount database records for @ServerName");
            sbTemplate.AppendLine("Inserted or updated @TotalItemCount records");
            var template = sbTemplate.ToString();
            return AppMessage.Inform(template, new
            {
                ServerCount = description.Servers.Count,
                DatabaseCount = description.Databases.Count,
                ServerName = description.Host.systems_server_name,
                TotalItemCount = stats.TotalItemCount
            });
        }

        Option<SqlMetadataStats> Save(ISqlProxyBroker broker, SqlDatabaseMetadataSet set)
        {

            var result =
                from ops in broker.Operations<systems.IsystemsOperations>()
                from serverCount in ops.p_host_server_save(set.Server.name).ToOption()
                from databaseCount in broker.BulkCopy(stream(set.Database))
                from schemaCount in broker.BulkCopy(set.Schemas)
                from tableCount in broker.BulkCopy(set.Tables)
                from typeCount in broker.BulkCopy(set.Types)
                from viewCount in broker.BulkCopy(set.Views)
                from xpCount in broker.BulkCopy(set.ExtendedProperties)
                from tableColumnCount in broker.BulkCopy(set.TableColumns)
                from indexCount in broker.BulkCopy(set.TableIndexes)
                from indexColCount in broker.BulkCopy(set.TableIndexColumns)
                select new SqlMetadataStats
                {
                    DatabaseCount = databaseCount,
                    SchemaCount = schemaCount,
                    TableCount = tableCount,
                    TypeCount = typeCount,
                    ViewCount = viewCount,
                    TableColumnCount = tableColumnCount,
                     ExtendedPropertyCount = xpCount,                      

                };
            return result;
        }

        Option<SqlMetadataStats> Save(ISqlProxyBroker broker, systems.v_host_servers host, SqlServerMetadataSet set)
        {
            var result =
                from hostCount in broker.BulkCopy(set.HostServers)
                from serverCount in broker.BulkCopy(set.Servers)
                from databaseCount in broker.BulkCopy(set.Databases)
                from schemaCount in broker.BulkCopy(set.Schemas)
                from tableCount in broker.BulkCopy(set.Tables)
                from typeCount in broker.BulkCopy(set.Types)
                from viewCount in broker.BulkCopy(set.Views)
                from xpCount in broker.BulkCopy(set.ExtendedProperties)
                select new SqlMetadataStats
                {
                    HostCount = hostCount,
                    ServerCount = serverCount,
                    DatabaseCount = databaseCount,
                    SchemaCount = schemaCount,
                    TableCount = tableCount,
                    TypeCount = typeCount,
                    ViewCount = viewCount,
                    ExtendedPropertyCount = xpCount
                };
            return result;

        }


        public Option<SqlMetadataStats> Save(SqlConnectionString cs, SqlDatabaseMetadataSet set)
        {

            var broker = cs.CreateSystemsBroker().Require();
            var result = none<SqlMetadataStats>();
            using (var session = broker.CreateSession().PayloadOrDefault())
            {
                var outcome = broker.Operations<systems.IsystemsOperations>()
                                    .OnSome(ops => 
                                        ops.p_databases_delete(set.Server.systems_server_name, set.DatabaseName));
                if (outcome)
                    result = Save(broker, set).OnSome(stats => SavedDatabaseMetadataSet(set.DatabaseName, stats));
                else
                    result = outcome.ToNone<SqlMetadataStats>(); //result.WithMessage(ApplicationMessage.Error(outcome.Messages.Render()));

                if (!result)
                {
                    session.CompleteSession(false);
                    return result;
                }
                    
                session.CompleteSession();
            }
            return result;

        }

        public Option<SqlMetadataStats> Save(SqlConnectionString cs, SqlServerInstanceDescription description)
        {
            var broker = cs.CreateSystemsBroker().Require();
            var steps =
                from ops in broker.Operations<systems.IsystemsOperations>()
                from hostCount in ops.p_host_servers_merge(
                    project<systems.v_host_servers, systems.host_servers_record>(array(description.Host))
                    ).ToOption()
                from serverCount in ops.p_servers_merge(
                    project<systems.v_servers, systems.servers_record>(description.Servers)
                    ).ToOption()
                from databaseCount in ops.p_databases_merge(
                    project<systems.v_databases, systems.databases_record>(description.Databases)
                    ).ToOption()
                select new SqlMetadataStats
                {
                    DatabaseCount = databaseCount,
                    HostCount = hostCount,
                    ServerCount = serverCount
                };
            return  
                steps.OnSome(stats => SavedInstanceDescription(description, stats));
        }

        public Option<SqlMetadataStats> Save(SqlConnectionString cs, SqlServerMetadataSet set)
        {
            var last = default(Option<SqlMetadataStats>);
            var total = new SqlMetadataStats();
            var broker = cs.CreateSystemsBroker().Require();            
            
            foreach (var host in set.HostServers)
            {

                var outcome = broker.Operations<systems.IsystemsOperations>().OnSome(
                    ops  => ops.p_host_server_delete(host.systems_server_name));
                if (outcome.IsNone())
                {
                    last = outcome.ToNone<SqlMetadataStats>();
                    if (last.IsNone())
                        break;
                }

                last = Save(broker, host, set);
                if (last.IsNone())
                    break;

                total += last.ValueOrDefault();
            }

            return last;
        }
    }
}
