//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Reflection;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;

    using SqlT.SqlSystem;    
    

    using systems = SqlT.SqlSystem.systems;


    using static metacore;
    using static SqlSystem.SqlStatusMessages;

    [Service(typeof(ISqlMetadataProvider))]
    public class SqlMetadataCollector : ApplicationService<SqlMetadataCollector, ISqlMetadataProvider>, ISqlMetadataProvider
    {
        public SqlMetadataCollector(IApplicationContext context)
            : base(context)
        { }

        class MetadataCollectionContext
        {
            public IServer server { get; }

            public IDatabase database { get; }

            public ISystemViewProvider svp { get; }

            public IReadOnlyDictionary<int, ISchema> schemas { get; }

            public MetadataCollectionContext(SqlMetadataSelectionOptions options, IServer server, IDatabase database, ISystemViewProvider svp)
            {
                this.server = server;
                this.database = database;
                this.svp = svp;
                this.schemas = (options.IncludedSchemas.IsEmpty
                            ? svp.GetNativeView<ISchema>().Where(x => x.is_user_defined || x.name == "dbo")
                            : svp.GetNativeView<ISchema>().Where(x => options.IncludedSchemas.Contains(x.name))).ToDictionary(x => x.schema_id);

            }
        }

        static IEnumerable<systems.v_types> SelectTypes(MetadataCollectionContext mcc)
            => from x in mcc.svp.GetNativeView<IType>()
               where x.is_user_defined && mcc.schemas.ContainsKey(x.schema_id)
               let s = mcc.schemas[x.schema_id]
               select new systems.v_types()
               {
                   systems_server_name = mcc.server.name,
                   systems_database_name = mcc.database.name,
                   systems_schema_name = s.name,
                   collation_name = x.collation_name,
                   default_object_id = 0,
                   is_assembly_type = x.is_assembly_type,
                   is_nullable = x.is_nullable,
                   is_table_type = x.is_table_type,
                   is_user_defined = x.is_user_defined,
                   max_length = x.max_length,
                   name = x.name,
                   precision = x.precision,
                   principal_id = s.principal_id,
                   rule_object_id = 0,
                   scale = x.scale,
                   schema_id = x.schema_id,
                   system_type_id = x.system_type_id,
                   user_type_id = x.user_type_id
               };


        public Option<SqlDatabaseMetadataSet> DescribeDatabase(SqlConnectionString Connector, SqlDatabaseName Source, 
            SqlMetadataSelectionOptions options = null)
        {
            try
            {
                options = options ?? new SqlMetadataSelectionOptions();
                var svp = SqlSystemViews.Create(new SystemViewsSettings(Connector, Source: Source));
                Notify(CollectingDatabaseMetadata(Source));

                var server = svp.GetNativeView<IServer>().OrderBy(x => x.server_id).First();
                var database = svp.GetNativeView<IDatabase>().Single(x => equals(x.name, Source.UnqualifiedName));
                var schemas = (options.IncludedSchemas.IsEmpty
                            ? svp.GetNativeView<ISchema>().Where(x => x.is_user_defined || equals(x.name, "dbo"))
                            : svp.GetNativeView<ISchema>().Where(x =>
                                    options.IncludedSchemas.Contains(x.name))).ToDictionary(x => x.schema_id);

                var mcc = new MetadataCollectionContext(options, server, database, svp);

                Func<string, string, SqlName> object_name = (schema_name, element_name)
                    => new SqlName(server.name, database.name, schema_name, element_name);

                var set = new SqlDatabaseMetadataSet(server, database);
                set.Absorb(Source, schemas.Values);

                if(options.CollectExtendedProperties)
                    set.Absorb(Source, svp.GetNativeView<IExtendedProperty>());

                if (options.CollectTypes)
                    set.Absorb(SelectTypes(mcc));

                var tableidx = svp.GetNativeView<ITable>().ToDictionary(x => x.object_id);
                if (options.CollectTables)
                {
                    var schemaGroups
                        = from item in tableidx.Values
                          where schemas.ContainsKey(item.schema_id)
                          group item by item.schema_id into g
                          select g;

                    foreach (var schemaGroup in schemaGroups)
                    {
                        var schema = schemas.Values.Single(x => x.schema_id == schemaGroup.Key);
                        var tables = schemaGroup;
                        set.Absorb(Source, schema.name, tables);
                    }
                }

                if (options.CollectViews)
                {
                    var schemaGroups
                        = from item in svp.GetNativeView<IView>()
                          where schemas.ContainsKey(item.schema_id)
                          group item by item.schema_id into g
                          select g;

                    foreach (var schemaGroup in schemaGroups)
                    {
                        var schema = schemas.Values.Single(x => x.schema_id == schemaGroup.Key);
                        set.Absorb(Source, schema.name, schemaGroup);
                    }
                }

                if (options.CollectTableColumns)
                {
                    var cols = from c in svp.GetNativeView<IColumn>()
                               where tableidx.ContainsKey(c.object_id)
                               let parent_table = tableidx[c.object_id]
                               let parent_schema_name = schemas.Values.FirstOrDefault(x => x.schema_id == parent_table.schema_id)?.name
                               where isNotBlank(parent_schema_name)
                               select new
                               {
                                   Column = c,
                                   schema_name = parent_schema_name,
                                   parent_name = parent_table.name,
                                   parent_type = parent_table.type
                               };

                    foreach (var col in cols)
                        set.Absorb(Source, col.schema_name, col.parent_name, col.parent_type, col.Column);


                    if (options.CollectTableIndexes)
                    {
                        var indexes = from i in svp.GetNativeView<IIndex>()
                                      where (SqlIndexType)i.type != SqlIndexType.Heap
                                      where tableidx.ContainsKey(i.object_id)
                                      let parent_table = tableidx[i.object_id]
                                      let parent_schema_name = schemas.Values.FirstOrDefault(x => x.schema_id == parent_table.schema_id)?.name
                                      where isNotBlank(parent_schema_name)
                                      select new
                                      {
                                          Index = i,
                                          schema_name = parent_schema_name,
                                          parent_name = parent_table.name,
                                          object_id = parent_table.object_id,
                                          parent_type = parent_table.type
                                      };

                        var indexcols = (from g in svp.GetVirtualView<vIndexColumn>().GroupBy(x => x.index)
                                             select (g.Key, g.ToReadOnlyList())).ToReadOnlyDictionary();

                        foreach (var objectIndexes in indexes.GroupBy(x => new
                        {
                            x.schema_name,
                            x.parent_name,
                            x.parent_type
                        }))
                        {
                            var sqlobjname = new SqlObjectName(objectIndexes.Key.schema_name, objectIndexes.Key.parent_name);
                            var idxlist = objectIndexes.Select(x => x.Index).ToList();
                            set.Absorb(Source,
                                objectIndexes.Key.schema_name,
                                objectIndexes.Key.parent_name,
                                objectIndexes.Key.parent_type,
                                idxlist
                                );

                            foreach (var idx in idxlist)
                            {
                                var idxcols = indexcols.TryFind(idx);
                                foreach (var idxcol in idxcols.Items())
                                {
                                    set.Absorb(
                                        Source,
                                        objectIndexes.Key.schema_name,
                                        objectIndexes.Key.parent_name,
                                        objectIndexes.Key.parent_type,
                                        idx.name,
                                        idxcol
                                        );
                                }
                            }
                        }
                    }
                }

                return set;
            }
            catch (Exception e)
            {
                Notify(MetadataCollectionError(e, Source));
                return none<SqlDatabaseMetadataSet>(e);
            }
        }

        static ConcurrentDictionary<Type, IReadOnlyDictionary<string, PropertyInfo>> propcache
            = new ConcurrentDictionary<Type, IReadOnlyDictionary<string, PropertyInfo>>();

        static IReadOnlyDictionary<string, PropertyInfo> propidx<T>()
            => propcache.GetOrAdd(typeof(T),
                t => t.GetPublicInstanceProperties().ToDictionary(x => x.Name));

        static TDst project<TSrc, TDst>(TSrc item, Action<TSrc, TDst> specialize = null)
            where TDst : new()
        {
            var srcProps = propidx<TSrc>();
            var dstProps = propidx<TDst>();
            var dst = new TDst();

            foreach (var srcPropName in srcProps.Keys)
            {
                var _dstPropName =
                    srcPropName.Contains('.')
                    ? srcPropName.Substring(srcPropName.LastIndexOf('.') + 1)
                    : srcPropName;
                dstProps.TryFind(_dstPropName).OnSome(dstProp =>
                {
                    var srcprop = srcProps[srcPropName];
                    var srcpropval = srcprop.GetValue(item);
                    dstProp.SetValue(dst, srcpropval);
                });
            }
            specialize?.Invoke(item, dst);
            return dst;
        }

        static IEnumerable<TDst> Map<TSrc, TDst>(IEnumerable<TSrc> src, Action<TSrc, TDst> specialize = null)
            where TDst : new()
                => map(src, item => project(item, specialize));

        static IEnumerable<systems.v_servers> MapToViewProxies(IEnumerable<IServer> src, string host)
            => Map<IServer, systems.v_servers>(src, (srcItem, dstItem) =>
            {
                dstItem.systems_server_name = host;
            });

        static IEnumerable<systems.v_databases> MapToViewProxies(IEnumerable<IDatabase> src, string host)
            => Map<IDatabase, systems.v_databases>(src, (srcItem, dstItem) =>
            {
                dstItem.systems_server_name = host;
            });

        public Option<SqlServerInstanceDescription> DescribeServer(SqlConnectionString Connector, SqlServerName ServerName)
        {
            Notify(SelectingInstanceInformation(ServerName));
            return DescribeServer(Connector.GetClientBroker(), ServerName);
        }

        public static Option<SqlServerInstanceDescription> DescribeServer(ISqlClientBroker Broker, SqlServerName ServerName)
        {            
            var svp = SqlSystemViews.Create(new SystemViewsSettings(Broker.ConnectionString, Source: new SqlDatabaseName(ServerName, "master")));
            var servers = MapToViewProxies(svp.GetNativeView<IServer>(), ServerName);
            var databases = MapToViewProxies(svp.GetNativeView<IDatabase>().Where(x => x.is_user_defined), ServerName);
            return new SqlServerInstanceDescription(ServerName, servers, databases);
        }
    }

}
