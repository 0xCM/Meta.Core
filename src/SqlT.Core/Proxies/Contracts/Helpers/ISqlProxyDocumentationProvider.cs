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


    public interface ISqlProxyDocumentationProvider
    {
        SqlTableProxyInfo Table<T>()
            where T : ISqlTableProxy, new();

        SqlTableProxyInfo Table(Type ProxyType);

        IEnumerable<SqlTableProxyInfo> Tables();

        SqlTableProxyInfo Table(SqlTableName TableName);

        IEnumerable<SqlTableName> TableNames { get; }


    }

}