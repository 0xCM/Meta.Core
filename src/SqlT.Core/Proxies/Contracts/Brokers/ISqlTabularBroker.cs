//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using sxc = SqlT.Syntax.contracts;


    public interface ISqlTabularBroker
    {

        SqlTabularProxyInfo TabularInfo { get; }

        SqlConnectionString ConnectionString { get; }

        ISqlProxyMetadataIndex Metadata { get; }

        ISqlProxyBroker InnerBroker { get; }

        sxc.tabular_name BrokeredObjectName { get; }

    }

    public interface ISqlTabularBroker<T> : ISqlTabularBroker
        where T : class, ISqlTabularProxy, new()
    {

        IEnumerable<T> Stream(string sql);

        Option<int> Stream(string sql, Action<T> receiver);

        Option<IReadOnlyList<T>> Get(SqlDatabaseName db = null);

        Option<IReadOnlyList<T>> Get(string sql);

        Option<IReadOnlyList<C>> GetColumn<C>(string sql, Expression<Func<T, C>> selector);

        Option<int> Save(IEnumerable<T> items, int? BatchSize = null);

    }


}