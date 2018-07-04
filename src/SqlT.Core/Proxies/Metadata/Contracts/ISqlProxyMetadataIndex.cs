//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using sxc = SqlT.Syntax.contracts;


    public interface ISqlProxyMetadataIndex : ISqlProxyMetadataProvider
    {
        IEnumerable<TInfo> Describe<TInfo>(sxc.ISqlObjectName name)
            where TInfo : SqlObjectProxyInfo;

        IEnumerable<TInfo> Describe<TInfo>()
            where TInfo : SqlObjectProxyInfo;

        TInfo Describe<TProxy, TInfo>()
            where TProxy : ISqlObjectProxy
            where TInfo : SqlObjectProxyInfo;

        SqlObjectProxyInfo Describe(Type proxyType);

        IReadOnlyList<SqlColumnProxyInfo> DescribeColumns(Type proxyType);

        TInfo Describe<TInfo>(Type proxyType)
             where TInfo : SqlObjectProxyInfo;

        Option<Type> FindOperationProvider(Type ContractType);

        Option<Type> FindOperationProvider<T>();

        IEnumerable<SqlObjectProxyInfo> IndexedProxies { get; }
    }
}
