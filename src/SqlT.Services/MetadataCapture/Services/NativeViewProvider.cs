//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections.Concurrent;
    using System.Reflection;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Services;
    using SqlT.Models.Proxies;

    using MC = Meta.Core;

    using static metacore;

    class NativeViewProvider : INativeViewProvider
    {
        static readonly IReadOnlyDictionary<string, string> SqlVersionNamespaces 
            = new Dictionary<string, string>
        {
            [SqlVersionNames.Sql2012] = nameof(SQL11),
            [SqlVersionNames.Sql2014] = nameof(SQL12),
            [SqlVersionNames.Sql2016] = nameof(SQL13),
            [SqlVersionNames.Sql2017] = nameof(SQL14)
        };

        static readonly IReadOnlyDictionary<Type, string> DefaultViewTypeMap 
            = new Dictionary<Type, string>
        {
            [typeof(IDatabase)] = SystemViewNames.databases,
            [typeof(IServer)] = SystemViewNames.servers,
            [typeof(ITable)] = SystemViewNames.tables,
            [typeof(ITableType)] = SystemViewNames.table_types,
            [typeof(IType)] = SystemViewNames.types,
            [typeof(ISchema)] = SystemViewNames.schemas,
            [typeof(IType)] = SystemViewNames.types,
            [typeof(IView)] = SystemViewNames.views,
            [typeof(IProcedure)] = SystemViewNames.procedures,
            [typeof(ISystemObject)] = SystemViewNames.objects,
            [typeof(ISchema)] = SystemViewNames.schemas,
            [typeof(IColumn)] = SystemViewNames.columns,
            [typeof(IIndexColumn)] = SystemViewNames.index_columns,
            [typeof(IIndex)] = SystemViewNames.indexes,
            [typeof(IParameter)] = SystemViewNames.parameters,
            [typeof(IExtendedProperty)] = SystemViewNames.extended_properties,
            [typeof(ISequence)] = SystemViewNames.sequences,
            [typeof(IMasterFile)] = SystemViewNames.master_files,
            [typeof(IServiceMessageType)] = SystemViewNames.service_message_types,
            [typeof(IFileTable)] = SystemViewNames.filetables,
            [typeof(ISystemMessage)] = SystemViewNames.messages
        };

        static IReadOnlyDictionary<string, Type> IndexSystemViewTypes(SqlVersion version) 
            => (from t in SqlTModels.ModelProxyAssembly.GetTypes()
                 where Attribute.IsDefined(t, typeof(SqlViewAttribute)) &&
                        t.Namespace.Contains(SqlVersionNamespaces[version.Name])
                 let attrib = t.GetCustomAttribute<SqlViewAttribute>()
                 select (new SqlViewName(attrib.SchemaName, attrib.ObjectName).FullName, t)).ToReadOnlyDictionary();

        readonly ConcurrentDictionary<Type, object> cache;
        readonly IReadOnlyDictionary<string, Type> viewtypes;
        readonly SqlVersion CompatibilityVerion;
        readonly ISqlProxyBroker Broker;
        readonly SqlDatabaseHandle MetadataSource;

        string viewName<T>()
            => DefaultViewTypeMap[typeof(T)];

        Type viewType<T>(string viewName)
            => isBlank(viewName) 
            ? viewtypes[DefaultViewTypeMap[typeof(T)]] 
            : viewtypes[viewName];

        public NativeViewProvider(SqlConnectionString Connector,  SqlDatabaseName SourceDatabase)
        {
            this.Broker = Connector.CreateSystemsBroker().Require();
            this.MetadataSource = Broker.Database(SourceDatabase.TrimServer());
            this.CompatibilityVerion = ~ MetadataSource.GetCompatibilityVersion();
            this.cache = new ConcurrentDictionary<Type, object>();
            this.viewtypes = IndexSystemViewTypes(
                CompatibilityVerion.Name == SqlVersionNames.Sql2017 
                ? SqlVersionNames.Sql2016 
                : CompatibilityVerion);
        }

        public MC.Lst<T> GetNativeView<T>(string viewName) 
            where T : ISystemElement
                => (MC.Lst<T>)cache.GetOrAdd(viewType<T>(viewName), 
                        t => list(Broker.Get<T>(t, MetadataSource.DatabaseName).Payload.Cast<T>()));

        public IReadOnlyList<T> GetNativeView<T>() 
            where T : ISystemElement
                => GetNativeView<T>(viewName<T>()).AsReadOnlyList();
    }
}
