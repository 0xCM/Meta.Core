//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using Meta.Core;

    using static metacore;

    using sxc = SqlT.Syntax.contracts;

    /// <summary>
    /// Defines metadata index for all proxies loaded in an application domain
    /// </summary>
    class SqlProxyMetadataCache : ISqlProxyMetadataIndex
    {
        public SqlProxyMetadataCache()
            => Me = Assembly.GetEntryAssembly();

        public SqlProxyMetadataCache(Assembly ProxyAssembly,
            IReadOnlyDictionary<SqlProxyKind, IReadOnlyList<SqlProxyInfo>> MetadataDictionary,
            IReadOnlyDictionary<Type, Type> OperationProviders)
        {
            Me = ProxyAssembly;
            Cache(ProxyAssembly, MetadataDictionary, OperationProviders);
        }

        Assembly Me { get; }

        Dictionary<Type, Type> OperationProviders { get; }
            = new Dictionary<Type, Type>();

        Dictionary<Type, SqlObjectProxyInfo> ObjectsByType { get; }
            = new Dictionary<Type, SqlObjectProxyInfo>();

        Dictionary<sxc.ISqlObjectName, MutableList<SqlObjectProxyInfo>> ObjectsByName { get; }
            = new Dictionary<sxc.ISqlObjectName, MutableList<SqlObjectProxyInfo>>();

        Dictionary<Type, SqlProxyInfo> ElementsByType { get; }
            = new Dictionary<Type, SqlProxyInfo>();

        HashSet<Assembly> Assemblies { get; }
            = new HashSet<Assembly>();

        public void Merge(SqlProxyMetadataCache Source)
        {
            foreach (var x in Source.OperationProviders)
                OperationProviders[x.Key] = x.Value;

            foreach (var x in Source.ObjectsByType)
                ObjectsByType[x.Key] = x.Value;

            foreach(var x in Source.ObjectsByName)
            {
                if (!ObjectsByName.ContainsKey(x.Key))
                    ObjectsByName[x.Key] = MutableList.Create<SqlObjectProxyInfo>();
                ObjectsByName[x.Key].AddRange(x.Value);
            }

            foreach (var x in Source.ElementsByType)
                ElementsByType[x.Key] = x.Value;

            foreach (var x in Source.Assemblies)
                Assemblies.Add(x);
        }

        void CacheOperationProviders(IReadOnlyDictionary<Type, Type> providers)
            => iter(providers.Keys, k => OperationProviders[k] = providers[k]);

        void CacheObjectsByType(IReadOnlyList<SqlObjectProxyInfo> objects)
        {
            foreach (var o in objects.ToDictionary(x => (Type)x.ClrElement))
                ObjectsByType[o.Key] = o.Value;
        }

        void CacheObjectsByName(IReadOnlyList<SqlObjectProxyInfo> objects)
        {
            foreach (var o in objects.GroupBy(x => x.ObjectName)
                                        .Select(g => (g.Key, g.Select(y => y).ToList()))
                                        .ToDictionary(z => z.Item1, z => z.Item2))
            {
                if (!ObjectsByName.ContainsKey(o.Key))
                    ObjectsByName[o.Key] = MutableList.Create<SqlObjectProxyInfo>();

                ObjectsByName[o.Key].AddRange(o.Value);
            }
        }

        void CacheClrElementsByType(IReadOnlyList<SqlObjectProxyInfo> objects)
            => iter(objects, o => ElementsByType[(Type)o.ClrElement] = o);
        
        void CacheObjects(IReadOnlyList<SqlObjectProxyInfo> objects)
        {            
            CacheObjectsByType(objects);
            CacheObjectsByName(objects);
            CacheClrElementsByType(objects);
        }

        public void Cache(Assembly ProxyAssembly,
            IReadOnlyDictionary<SqlProxyKind, IReadOnlyList<SqlProxyInfo>> MetadataDictionary,
            IReadOnlyDictionary<Type, Type> OperationProviders)
        {
            CacheOperationProviders(OperationProviders);
            CacheObjects(MetadataDictionary.Values.SelectMany(x => x).OfType<SqlObjectProxyInfo>().ToList());
            Assemblies.Add(ProxyAssembly);
        }

        public TInfo DescribeElement<TProxy, TInfo>()
            where TProxy : ISqlProxy
            where TInfo : SqlProxyInfo
        {
            if (ElementsByType.TryGetValue(typeof(TProxy), out SqlProxyInfo x))
                return x as TInfo;
            else
                return null;
        }

        public TInfo DescribeElement<TInfo>(Type ProxyType)
            where TInfo : SqlProxyInfo
                => ElementsByType.TryGetValue(ProxyType, out SqlProxyInfo x)
                    ? x as TInfo : default;

        public SqlProxyInfo DescribeElement(Type proxyType)
        {

            if (ElementsByType.TryGetValue(proxyType, out SqlProxyInfo x))
                return x;
            else
                return null;
        }

        public IEnumerable<TInfo> DescribeElements<TInfo>()
            where TInfo : SqlProxyInfo => ElementsByType.Values.OfType<TInfo>();

        public IEnumerable<TInfo> Describe<TInfo>(sxc.ISqlObjectName name)
            where TInfo : SqlObjectProxyInfo
                => ObjectsByName.ContainsKey(name)
                    ? ObjectsByName[name].Cast<TInfo>()
                    : rolist<TInfo>();

        public IEnumerable<TInfo> Describe<TInfo>()
            where TInfo : SqlObjectProxyInfo => ObjectsByType.Values.OfType<TInfo>();

        public TInfo Describe<TProxy, TInfo>()
            where TProxy : ISqlObjectProxy where TInfo : SqlObjectProxyInfo        
                => (ObjectsByType.TryGetValue(typeof(TProxy), out SqlObjectProxyInfo x)) ?
                    x as TInfo : default;        

        public SqlObjectProxyInfo Describe(Type proxyType)
            => ObjectsByType.TryGetValue(proxyType, out SqlObjectProxyInfo x) ? x : default;

        public TInfo Describe<TInfo>(Type proxyType)
             where TInfo : SqlObjectProxyInfo
                => ObjectsByType.TryGetValue(proxyType, out SqlObjectProxyInfo x) 
                    ? x as TInfo : default;
        
        public Option<Type> FindOperationProvider(Type ContractType)
            => OperationProviders.ContainsKey(ContractType)
            ? OperationProviders[ContractType]
            : default;

        public Option<Type> FindOperationProvider<T>()
            => FindOperationProvider(typeof(T));

        public IEnumerable<SqlObjectProxyInfo> IndexedProxies
            => ObjectsByType.Values;

        public SqlProcedureProxyInfo Procedure(SqlProcedureName Name)
            => Describe<SqlProcedureProxyInfo>(Name).SingleOrDefault();

        SqlTableProxyInfo ISqlProxyMetadataProvider.Table(SqlTableName Name)
            => Describe<SqlTableProxyInfo>(Name).SingleOrDefault();

        IReadOnlyList<SqlColumnProxyInfo> ISqlProxyMetadataIndex.DescribeColumns(Type proxyType)
            => Describe<SqlTabularProxyInfo>(proxyType).Columns;

        IReadOnlyList<SqlColumnProxyInfo> ISqlProxyMetadataProvider.Columns<TProxy>()
            => Describe<TProxy, SqlTabularProxyInfo>().Columns;

        SqlTableProxyInfo ISqlProxyMetadataProvider.Table<P>()
            => Describe<P, SqlTableProxyInfo>();

        SqlTableProxyInfo ISqlProxyMetadataProvider.Table(Type ProxyType)
            => Describe<SqlTableProxyInfo>(ProxyType);

        SqlTabularProxyInfo ISqlProxyMetadataProvider.Tabular<P>()
            => Describe<P, SqlTabularProxyInfo>();

        SqlTabularProxyInfo ISqlProxyMetadataProvider.Tabular(Type ProxyType)
            => Describe<SqlTabularProxyInfo>(ProxyType);

        SqlColumnProxyInfo ISqlProxyMetadataProvider.Column<P>(string MemberName)
            => Describe<P, SqlTabularProxyInfo>().Columns.Single(x => x.RuntimeName == MemberName);

        SqlTableTypeProxyInfo ISqlProxyMetadataProvider.TableType<P>()
            => Describe<P, SqlTableTypeProxyInfo>();

        SqlTableFunctionProxyInfo ISqlProxyMetadataProvider.TableFunction<P>()
            => Describe<P, SqlTableFunctionProxyInfo>();

        SqlProcedureProxyInfo ISqlProxyMetadataProvider.Procedure<P>()
            => Describe<P, SqlProcedureProxyInfo>();

        SqlProcedureProxyInfo ISqlProxyMetadataProvider.Procedure(Type ProxyType)
            => Describe<SqlProcedureProxyInfo>(ProxyType);

        SqlIndexProxyInfo ISqlProxyMetadataProvider.Index<P>()
            => DescribeElement<P, SqlIndexProxyInfo>();

        SqlIndexProxyInfo ISqlProxyMetadataProvider.Index(Type ProxyType)
            => DescribeElement<SqlIndexProxyInfo>(ProxyType);

        SqlPrimaryKeyProxyInfo ISqlProxyMetadataProvider.PrimaryKey<P>()
            => Describe<P, SqlPrimaryKeyProxyInfo>();

        SqlPrimaryKeyProxyInfo ISqlProxyMetadataProvider.PrimaryKey(Type ProxyType)
            => Describe<SqlPrimaryKeyProxyInfo>(ProxyType);

        SqlSequenceProxyInfo ISqlProxyMetadataProvider.Sequence<P>()
            => Describe<P, SqlSequenceProxyInfo>();

        SqlViewProxyInfo ISqlProxyMetadataProvider.View<P>()
            => Describe<P, SqlViewProxyInfo>();

        SqlColumnProxyInfo ISqlProxyMetadataProvider.Column<T, C>(Expression<Func<T, C>> ex0)
            => Describe<T, SqlTabularProxyInfo>().FindColumnByRuntimeName(ex0.GetMember().Name);

        public SqlTableTypeProxyInfo TableType(Type ProxyType)
            => DescribeElement<SqlTableTypeProxyInfo>(ProxyType);

        public SqlTableTypeProxyInfo TableType(SqlTableTypeName Name)
            => Describe<SqlTableTypeProxyInfo>(Name).SingleOrDefault();

        IEnumerable<SqlTableProxyInfo> ISqlProxyMetadataProvider.Tables
            => Describe<SqlTableProxyInfo>();

        IEnumerable<SqlTableTypeProxyInfo> ISqlProxyMetadataProvider.TableTypes
            => Describe<SqlTableTypeProxyInfo>();

        IEnumerable<SqlPrimaryKeyProxyInfo> ISqlProxyMetadataProvider.PrimaryKeys
            => Describe<SqlPrimaryKeyProxyInfo>();

        IEnumerable<SqlIndexProxyInfo> ISqlProxyMetadataProvider.Indexes
            => DescribeElements<SqlIndexProxyInfo>();

        IEnumerable<SqlProcedureProxyInfo> ISqlProxyMetadataProvider.Procedures
            => Describe<SqlProcedureProxyInfo>();

        IEnumerable<SqlTableFunctionProxyInfo> ISqlProxyMetadataProvider.TableFunctions
            => Describe<SqlTableFunctionProxyInfo>();

        public override string ToString()
            => $"{Me.GetSimpleName()}";
    }
}