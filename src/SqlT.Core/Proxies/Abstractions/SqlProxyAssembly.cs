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
    using System.Reflection;
    using System.Linq.Expressions;

    using Meta.Core;

    using static metacore;

    using sxc = SqlT.Syntax.contracts;

    /// <summary>
    /// Describes and represents an assembly containing SqlT proxies
    /// </summary>
    /// <typeparam name="T">The derived subtype</typeparam>
    public abstract class SqlProxyAssembly<T> : ISqlProxyAssembly<T>
        where T : SqlProxyAssembly<T>, new()
    {

        public static ComponentIdentifier Identifier
            => typeof(T).Assembly.GetSimpleName();

        public static Assembly Assembly 
            = typeof(T).Assembly;

        public static implicit operator Assembly(SqlProxyAssembly<T> a)
            => Assembly;

        static T _Instance;

        static SqlProxyAssembly()
        {
            _Instance = new T();
        }

        public static T Instance 
            => _Instance;

        public static ISqlProxyMetadataIndex Metadata() 
            => _Instance;

        public static ISqlProxyBrokerFactory<T> BrokerFactory() 
            => _Instance;

        public static ISqlProxyBroker Broker(SqlConnectionString cs)
            => _Instance.Factory.CreateBroker(cs);

        public static ISqlProxyBroker Broker(SqlConnectionString cs, SqlNotificationObserver observer)
            => observer == null ? Broker(cs) : _Instance.Factory.CreateBroker(cs, observer);

        public static ISqlProxyBroker Broker(SqlConnectionString cs, AppMessageObserver observer)
            => observer == null ? Broker(cs) :  _Instance.Factory.CreateBroker(cs, n => Relay(n,observer));

        static void Relay(SqlNotification notification, AppMessageObserver observer)
            => observer?.Invoke(notification.ToApplicationMessage());
            
        protected readonly ISqlProxyMetadataIndex MetadataIndex;
        protected readonly ISqlProxyBrokerFactory Factory;

        protected SqlProxyAssembly()
        {
            MetadataIndex = typeof(T).Assembly.SqlProxyMetadataIndex();
            Factory = SqlProxyBroker.GetBrokerFactory(typeof(T).Assembly).Require();
        }

        public ISqlProxyBroker<T> CreateAssemblyBroker(SqlConnectionString cs, Action<SqlNotification> observer)
            => new SqlProxyBroker<T>(Metadata(), cs, observer);
            
        IEnumerable<SqlObjectProxyInfo> ISqlProxyMetadataIndex.IndexedProxies
            => MetadataIndex.IndexedProxies;

        IEnumerable<SqlTableProxyInfo> ISqlProxyMetadataProvider.Tables
            => MetadataIndex.Tables;

        IEnumerable<SqlTableTypeProxyInfo> ISqlProxyMetadataProvider.TableTypes
            => MetadataIndex.TableTypes;

        IEnumerable<SqlPrimaryKeyProxyInfo> ISqlProxyMetadataProvider.PrimaryKeys
                => MetadataIndex.PrimaryKeys;

        IEnumerable<SqlIndexProxyInfo> ISqlProxyMetadataProvider.Indexes
                => MetadataIndex.Indexes;

        IEnumerable<SqlProcedureProxyInfo> ISqlProxyMetadataProvider.Procedures
                => MetadataIndex.Procedures;

        IEnumerable<SqlTableFunctionProxyInfo> ISqlProxyMetadataProvider.TableFunctions
                => MetadataIndex.TableFunctions;

        ISqlProxyMetadataIndex ISqlProxyBrokerFactory.Metadata
            => this;

        Assembly ISqlProxyAssembly.DefininingAssembly
            => this;

        string ISqlProxyAssembly.ComponentName
            => GetComponentName();

        IEnumerable<TInfo> ISqlProxyMetadataIndex.Describe<TInfo>(sxc.ISqlObjectName name)
            => MetadataIndex.Describe<TInfo>(name);

        IEnumerable<TInfo> ISqlProxyMetadataIndex.Describe<TInfo>()
            => MetadataIndex.Describe<TInfo>();

        TInfo ISqlProxyMetadataIndex.Describe<TProxy, TInfo>()
            => MetadataIndex.Describe<TProxy, TInfo>();

        IReadOnlyList<SqlColumnProxyInfo> ISqlProxyMetadataProvider.Columns<TProxy>()
             => MetadataIndex.Columns<TProxy>();

        SqlTableTypeProxyInfo ISqlProxyMetadataProvider.TableType<P>()
            => MetadataIndex.TableType<P>();

        SqlTableFunctionProxyInfo ISqlProxyMetadataProvider.TableFunction<P>()
            => this.MetadataIndex.TableFunction<P>();

        SqlProcedureProxyInfo ISqlProxyMetadataProvider.Procedure(SqlProcedureName Name)
            => MetadataIndex.Procedure(Name);

        SqlProcedureProxyInfo ISqlProxyMetadataProvider.Procedure(Type ProxyType)
            => MetadataIndex.Procedure(ProxyType);

        SqlProcedureProxyInfo ISqlProxyMetadataProvider.Procedure<P>()
            => MetadataIndex.Procedure<P>();

        SqlIndexProxyInfo ISqlProxyMetadataProvider.Index<P>()
            => MetadataIndex.Index<P>();

        SqlIndexProxyInfo ISqlProxyMetadataProvider.Index(Type ProxyType)
            => MetadataIndex.Index(ProxyType);

        SqlSequenceProxyInfo ISqlProxyMetadataProvider.Sequence<P>()
            => MetadataIndex.Sequence<P>();

        SqlViewProxyInfo ISqlProxyMetadataProvider.View<P>()
            => MetadataIndex.View<P>();

        SqlColumnProxyInfo ISqlProxyMetadataProvider.Column<P, C>(Expression<Func<P, C>> ex0)
            => MetadataIndex.Column<P, C>(ex0);

        SqlObjectProxyInfo ISqlProxyMetadataIndex.Describe(Type proxyType)
            => MetadataIndex.Describe(proxyType);

        IReadOnlyList<SqlColumnProxyInfo> ISqlProxyMetadataIndex.DescribeColumns(Type proxyType)
            => MetadataIndex.DescribeColumns(proxyType);

        TInfo ISqlProxyMetadataIndex.Describe<TInfo>(Type proxyType)
            => MetadataIndex.Describe<TInfo>(proxyType);

        Option<Type> ISqlProxyMetadataIndex.FindOperationProvider(Type ContractType)        
            => MetadataIndex.FindOperationProvider(ContractType);
        
        Option<Type> ISqlProxyMetadataIndex.FindOperationProvider<I>()
            => MetadataIndex.FindOperationProvider<I>();

        SqlTableProxyInfo ISqlProxyMetadataProvider.Table<P>()
            => MetadataIndex.Table<P>();

        SqlTableProxyInfo ISqlProxyMetadataProvider.Table(Type ProxyType)
            => MetadataIndex.Table(ProxyType);

        SqlTableProxyInfo ISqlProxyMetadataProvider.Table(SqlTableName Name)
            => MetadataIndex.Table(Name);

        public SqlTableTypeProxyInfo TableType(Type ProxyType)
            => MetadataIndex.TableType(ProxyType);

        public SqlTableTypeProxyInfo TableType(SqlTableTypeName Name)
            => MetadataIndex.TableType(Name);

        SqlPrimaryKeyProxyInfo ISqlProxyMetadataProvider.PrimaryKey(Type ProxyType)
            => MetadataIndex.PrimaryKey(ProxyType);

        SqlPrimaryKeyProxyInfo ISqlProxyMetadataProvider.PrimaryKey<P>()        
            => MetadataIndex.PrimaryKey<P>();
        
        SqlTabularProxyInfo ISqlProxyMetadataProvider.Tabular<P>()
            => MetadataIndex.Tabular<P>();

        SqlTabularProxyInfo ISqlProxyMetadataProvider.Tabular(Type proxyType)
            => MetadataIndex.Tabular(proxyType);

        SqlColumnProxyInfo ISqlProxyMetadataProvider.Column<P>(string MemberName)
            => MetadataIndex.Column<P>(MemberName);

        protected virtual string GetComponentName()
            => typeof(T).Assembly.GetName().Name;

        ISqlProxyBroker ISqlProxyBrokerFactory.CreateBroker(SqlConnectionString cs)
            => Broker(cs);

        ISqlProxyBroker ISqlProxyBrokerFactory.CreateBroker(SqlConnectionString cs, SqlNotificationObserver observer)
            => Broker(cs, observer);

        IMutableContext IAssemblyDesignator.CreateContext()
            => ApplicationContext.Create(stream(Assembly.GetExecutingAssembly()));

        string IAssemblyDesignator.ProductName 
            => typeof(T).Assembly.TryGetAttribute<AssemblyProductAttribute>()
                                 .MapValueOrDefault(a => a.Product, String.Empty);

        Version IAssemblyDesignator.NetFrameworkVersion
            => Assembly.GetNetFrameworkVersion();

        AssemblyResourceProvider IAssemblyDesignator.Resources
            => AssemblyResourceProvider.Get(typeof(T).Assembly);

        Assembly IModuleDesignator<Assembly>.DesignatedModule
            => Assembly;

        IReadOnlyList<Assembly> IModuleDesignator<Assembly>.ModuleDependencies
            => rolist<Assembly>();

        string IModuleDesignator.ModuleName 
            => typeof(T).Assembly.TryGetAttribute<AssemblyTitleAttribute>()
                                 .MapValueOrDefault(a => a.Title, typeof(T).Assembly.GetSimpleName());

        string IModuleDesignator.ModuleVersion
            => typeof(T).Assembly.GetName().Version.ToString();

        ModuleArea IModuleDesignator.Area
            => nameof(SqlT);

        public ComponentIdentifier Identity
            => Assembly.Identifier();

        public IReadOnlySet<ComponentIdentifier> IdentifiedDependencies
            //=> roset(MetaCore.Identifier);
            => roset<ComponentIdentifier>();
    }
}
