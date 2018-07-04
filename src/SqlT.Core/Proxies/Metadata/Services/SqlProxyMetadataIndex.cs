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

    using sxc = SqlT.Syntax.contracts;

    /// <summary>
    /// Defines metadata index for the proxies defined in a single assembly
    /// </summary>
    public class SqlProxyMetadataIndex : ISqlProxyMetadataIndex
    {
        readonly ISqlProxyMetadataIndex MetadataIndex;

        public SqlProxyMetadataIndex(Assembly IndexedAssembly, ISqlProxyMetadataIndex ProxyMetadata)
        {
            this.IndexedAssembly = IndexedAssembly;
            this.MetadataIndex = ProxyMetadata;
        }

        public Assembly IndexedAssembly { get; }

        public IEnumerable<SqlObjectProxyInfo> IndexedProxies 
            => MetadataIndex.IndexedProxies;

        public IEnumerable<SqlProcedureProxyInfo> Procedures 
            => MetadataIndex.Procedures;

        public IEnumerable<SqlTableFunctionProxyInfo> TableFunctions
            => MetadataIndex.TableFunctions;

        public SqlColumnProxyInfo Column<P>(string MemberName) 
            where P : ISqlTabularProxy
                => MetadataIndex.Column<P>(MemberName);

        public SqlColumnProxyInfo Column<T, C>(Expression<Func<T, C>> ex0) 
            where T : ISqlTabularProxy
                => MetadataIndex.Column(ex0);

        public IReadOnlyList<SqlColumnProxyInfo> Columns<TProxy>() 
            where TProxy : ISqlTabularProxy
                => MetadataIndex.Columns<TProxy>();

        public IEnumerable<TInfo> Describe<TInfo>(sxc.ISqlObjectName name) 
            where TInfo : SqlObjectProxyInfo
                => MetadataIndex.Describe<TInfo>(name);

        public IEnumerable<TInfo> Describe<TInfo>() 
            where TInfo : SqlObjectProxyInfo
            => MetadataIndex.Describe<TInfo>();

        public TInfo Describe<TProxy, TInfo>()
            where TProxy : ISqlObjectProxy
            where TInfo : SqlObjectProxyInfo
                => MetadataIndex.Describe<TProxy, TInfo>();
                  
        public SqlObjectProxyInfo Describe(Type proxyType)
            => MetadataIndex.Describe(proxyType);

        public TInfo Describe<TInfo>(Type proxyType) 
            where TInfo : SqlObjectProxyInfo
                => MetadataIndex.Describe<TInfo>(proxyType);

        public IReadOnlyList<SqlColumnProxyInfo> DescribeColumns(Type proxyType)
            => MetadataIndex.DescribeColumns(proxyType);

        public Option<Type> FindOperationProvider(Type ContractType)
            => MetadataIndex.FindOperationProvider(ContractType);

        public Option<Type> FindOperationProvider<T>()
            => MetadataIndex.FindOperationProvider<T>();

        public IEnumerable<SqlPrimaryKeyProxyInfo> PrimaryKeys
            => MetadataIndex.PrimaryKeys;

        public SqlPrimaryKeyProxyInfo PrimaryKey(Type ProxyType)
            => MetadataIndex.PrimaryKey(ProxyType);

        public SqlPrimaryKeyProxyInfo PrimaryKey<P>() 
            where P : ISqlPrimaryKeyProxy
                => MetadataIndex.PrimaryKey<P>();
        
        public SqlProcedureProxyInfo Procedure(SqlProcedureName Name)
            => MetadataIndex.Procedure(Name);

        public SqlProcedureProxyInfo Procedure<P>() 
            where P : ISqlProcedureProxy
            => MetadataIndex.Procedure<P>();

        public IEnumerable<SqlTableTypeProxyInfo> TableTypes
            => MetadataIndex.TableTypes;

        public SqlTableTypeProxyInfo TableType(Type ProxyType)
            => MetadataIndex.TableType(ProxyType);

        public SqlTableTypeProxyInfo TableType(SqlTableTypeName Name)
            => MetadataIndex.TableType(Name);

        public SqlTableTypeProxyInfo TableType<P>() 
            where P : ISqlTableTypeProxy        
            => MetadataIndex.TableType<P>();
        
        public SqlSequenceProxyInfo Sequence<P>() 
            where P : ISqlSequenceProxy
            => MetadataIndex.Sequence<P>();

        public IEnumerable<SqlTableProxyInfo> Tables
            => MetadataIndex.Tables;

        public SqlTableProxyInfo Table<P>() 
            where P : ISqlTableProxy, new()        
                => MetadataIndex.Table<P>();
        
        public SqlTableProxyInfo Table(Type ProxyType)
            => MetadataIndex.Table(ProxyType);

        public SqlProcedureProxyInfo Procedure(Type ProxyType)
            => MetadataIndex.Procedure(ProxyType);

        public SqlTableProxyInfo Table(SqlTableName Name)
            => MetadataIndex.Table(Name);

        public SqlTableFunctionProxyInfo TableFunction<P>() 
            where P : ISqlTableFunctionProxy
                => MetadataIndex.TableFunction<P>();

        public IEnumerable<SqlIndexProxyInfo> Indexes
            => MetadataIndex.Indexes;

        public SqlIndexProxyInfo Index<P>() 
            where P : ISqlIndexProxy
            => MetadataIndex.Index<P>();

        public SqlIndexProxyInfo Index(Type ProxyType)
            => MetadataIndex.Index(ProxyType);

        public SqlTabularProxyInfo Tabular<P>() 
            where P : ISqlTabularProxy, new()
                => MetadataIndex.Tabular<P>();

        public SqlTabularProxyInfo Tabular(Type proxyType)
            => MetadataIndex.Tabular(proxyType);

        public SqlViewProxyInfo View<P>() 
            where P : ISqlViewProxy
                => MetadataIndex.View<P>();

    }

}
