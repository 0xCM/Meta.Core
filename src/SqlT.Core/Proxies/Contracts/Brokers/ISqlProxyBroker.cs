//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using sxc = SqlT.Syntax.contracts;

    /// <summary>
    /// Defines SQL client operations required to support typed data access
    /// </summary>
    public interface ISqlProxyBroker : ISqlClientBroker
    {
        ISqlProxyMetadataIndex Metadata { get; }

        /// <summary>
        /// Yields all available values of the specified type
        /// </summary>
        /// <typeparam name="TResult">The result type</typeparam>
        /// <returns></returns>
        IEnumerable<TResult> Stream<TResult>() 
            where TResult : class, ISqlTabularProxy, new();

        /// <summary>
        /// Yields values of the specified type subject to the constraints supplied by a filter
        /// </summary>
        /// <typeparam name="TResult">The result type</typeparam>
        /// <param name="Filter">The filter that will constrain the result set</param>
        /// <returns></returns>
        IEnumerable<TResult> Stream<TResult>(ISqlFilter<TResult> Filter)
            where TResult : class, ISqlTabularProxy, new();            

        /// <summary>
        /// Yields all available values of <typeparamref name="TDst"/> that can be
        /// derived from the underlying source of type <typeparamref name="TSrc"/>
        /// </summary>
        /// <typeparam name="TDst">The result type</typeparam>
        /// <typeparam name="TSrc">The source type</typeparam>
        /// <returns></returns>
        IEnumerable<TDst> Stream<TSrc,TDst>()
            where TSrc: class, ISqlTabularProxy, new()
            where TDst : class, ISqlTabularProxy, new();

        /// <summary>
        /// Yields all available values of <typeparamref name="TDst"/> that can be
        /// derived from the underlying source of type <typeparamref name="TSrc"/>
        /// </summary>
        /// <typeparam name="TDst">The result type</typeparam>
        /// <typeparam name="TSrc">The source type</typeparam>
        /// <returns></returns>
        IEnumerable<TDst> Stream<TSrc, TDst>(string sql)
            where TSrc : class, ISqlTabularProxy, new()
            where TDst : class, ISqlTabularProxy, new();

        /// <summary>
        /// Yields a sequence of proxy values on-demand as determined by a script
        /// </summary>
        /// <typeparam name="TResult">The result type</typeparam>
        /// <param name="sql">The script that, when executed, produces values that conform to the <typeparamref name="TResult"/></param> type
        /// <returns></returns>
        IEnumerable<TResult> Stream<TResult>(string sql)
            where TResult : class, ISqlTabularProxy, new();

        /// <summary>
        /// Delivers a sequence of proxy values to a receiver as determined by a script
        /// </summary>
        /// <typeparam name="TResult">The result type</typeparam>
        /// <param name="sql">The script that, when executed, produces values that conform to the <typeparamref name="TResult"/></param> type
        /// <param name="receiver">The proxy value recipient</param>
        /// <returns></returns>
        SqlOutcome<int> Stream<TResult>(string sql, Action<TResult> receiver)
            where TResult : class, ISqlTabularProxy, new();

        /// <summary>
        /// Yields a sequence of proxy values on-demand as determined by a TVF
        /// </summary>
        /// <typeparam name="F">The type representing the function</typeparam>
        /// <typeparam name="TResult">The result type</typeparam>
        /// <param name="func">The function specifier</param>
        /// <param name="db">The source database if applicable</param>
        /// <returns></returns>
        IEnumerable<TResult> Stream<F, TResult>(F func, SqlDatabaseName db = null)
            where F : class, ISqlTableFunctionProxy<F, TResult>, new()
            where TResult : class, ISqlTabularProxy, new();

        /// <summary>
        /// Yields the complete set of proxy values as determined by a TVF
        /// </summary>
        /// <typeparam name="F">The type representing the function</typeparam>
        /// <typeparam name="TResult">The result type</typeparam>
        /// <param name="func">The function specifier</param>
        /// <param name="db">The source database if applicable</param>
        /// <returns></returns>
        Option<IReadOnlyList<TResult>> Get<F, TResult>(SqlTableFunctionProxy<F, TResult> func, SqlDatabaseName db = null)
            where F : class, ISqlTableFunctionProxy<F, TResult>, new()
            where TResult : class, ISqlTabularProxy, new();

        /// <summary>
        /// Yields the complete set of proxy values as determined by a TVF
        /// </summary>
        /// <typeparam name="F">The type representing the function</typeparam>
        /// <typeparam name="TResult">The result type</typeparam>
        /// <param name="func">The function specifier</param>
        /// <returns></returns>
        Option<IReadOnlyList<TResult>> Select<F, TResult>(SqlTableFunctionProxy<F, TResult> func)
            where F : class, ISqlTableFunctionProxy<F, TResult>, new()
            where TResult : class, ISqlTabularProxy, new();

        /// <summary>
        /// Delivers a sequence of proxy values to a reciever as determined by a TVF
        /// </summary>
        /// <typeparam name="F">The type representing the function</typeparam>
        /// <typeparam name="TResult">The result type</typeparam>
        /// <param name="func">The function specifier</param>
        /// <returns></returns>
        SqlOutcome<int> Stream<F, TResult>(F func, Action<TResult> receiver)
            where F : class, ISqlTableFunctionProxy<F, TResult>, new()
            where TResult : class, ISqlTabularProxy, new();

        /// <summary>
        /// Execucutes the represented procedure
        /// </summary>
        /// <typeparam name="P">The proxy procedure type</typeparam>
        /// <param name="proc">The proxy instantiation</param>
        /// <returns></returns>
        Option<int> Exec<P>(P proc)
            where P : class, ISqlProcedureProxy, new();

        SqlOutcome<IReadOnlyList<TResult>> Get<TResult>(Type proxyType, SqlDatabaseName db = null);

        Option<IReadOnlyList<TResult>> Get<TResult>(SqlDatabaseName db = null)
            where TResult : class, ISqlTabularProxy, new();

        SqlOutcome<IReadOnlyList<TResult>> Get<TResult>(string sql)
            where TResult : class, ISqlTabularProxy, new();

        Option<IReadOnlyList<C>> GetColumn<T, C>(string sql, Expression<Func<T, C>> c)
            where T : class, ISqlTabularProxy, new();

        SqlOutcome<IReadOnlyList<TResult>> Get<P, TResult>(SqlProcedureProxy<P, TResult> proc, SqlDatabaseName db = null)
            where P : class, ISqlProcedureProxy<P, TResult>, new()
            where TResult : class, ISqlTabularProxy, new();

        SqlOutcome<int> Call<P>(SqlProcedureProxy<P> proc, SqlDatabaseName db = null)
            where P : class, ISqlProcedureProxy<P>, new();

        Option<int> Call(ISqlProcedureProxy proc);

        SqlOutcome<int> Call<P>(P proc, SqlDatabaseName db = null)
            where P : class, ISqlProcedureProxy, new();

        /// <summary>
        /// Executes a proxied procedure within a lock block (critical section)
        /// </summary>
        /// <typeparam name="P">The proxy procedure type</typeparam>
        /// <param name="proc">The procedure</param>
        /// <param name="lock"></param>
        /// <returns></returns>
        Option<int> Call<P>(P proc, bool @lock)
            where P : class, ISqlProcedureProxy, new();

        /// <summary>
        /// Saves a list of proxies within the context of a single batched trasaction
        /// </summary>
        /// <typeparam name="P">The proxy type</typeparam>
        /// <param name="items">The proxied values</param>
        /// <returns></returns>
        Option<int> Save<P>(IReadOnlyList<P> items)
            where P : class, ISqlTabularProxy, new();

        Option<int> Save<P>(IEnumerable<P> items, SqlSaveOptions options, Action<long> observer = null)
            where P : class, ISqlTabularProxy, new();

        Option<int> BulkCopy<T>(IEnumerable<T> items,
            SqlCopyOptions options = null, Action<int> observer = null)
                where T : class, ISqlTabularProxy, new();

        /// <summary>
        /// Executes a bulk copy operation
        /// </summary>
        /// <param name="proxyType">The proxy type</param>
        /// <param name="items">Proxies containing the data to be persisted</param>
        /// <param name="options">Bulk copy options</param>
        /// <param name="observer">An optional witness</param>
        /// <returns></returns>
        Option<int> BulkCopy(Type proxyType, IEnumerable<ISqlTabularProxy> items,
            SqlCopyOptions options = null, Action<int> observer = null);

        /// <summary>
        /// Executes a bulk copy operation
        /// </summary>
        /// <param name="proxyType">The proxy type</param>
        /// <param name="itemArrays">Proxy item arrays containing the data to be persisted</param>
        /// <param name="options">Bulk copy options</param>
        /// <param name="observer">An optional witness</param>
        /// <returns></returns>
        Option<int> BulkCopy(Type proxyType, IEnumerable<object[]> itemArrays,
            SqlCopyOptions options = null, Action<int> observer = null);

        /// <summary>
        /// Executes a bulk copy operation
        /// </summary>
        /// <param name="src">The records to load</param>
        /// <param name="exclusions">The names of the columns that should be exluded from the copy process</param>
        /// <param name="BatchSize">The number of records inserted during at once and which are persisted as a transactional unit</param>
        /// <param name="Timeout">The number of seconds to allow for a batch to be inserted</param>
        /// <returns></returns>
        Option<int> BulkCopy(Type proxyType, IEnumerable<ISqlTabularProxy> src,
            int BatchSize, IReadOnlyList<string> exclusions = null, int? Timeout = null,
            bool? LockTable = null, bool? Transactional = null

            );

        /// <summary>
        /// Loads the source records into the table represented by the proxy
        /// </summary>
        /// <typeparam name="T">The proxy type</typeparam>
        /// <param name="src">The records to load</param>
        /// <param name="exclusions">The names of the columns that should be exluded from the copy process</param>
        /// <param name="BatchSize">The number of records inserted during at once and which are persisted as a transactional unit</param>
        /// <param name="Timeout">The number of seconds to allow for a batch to be inserted</param>
        /// <returns></returns>
        Option<int> BulkCopy<T>(IEnumerable<T> src, int BatchSize, IReadOnlyList<SqlColumnName> exclusions = null, 
            int? Timeout = null, bool? LockTable = null, bool? Transactional = null) 
                where T : ISqlTabularProxy;

        /// <summary>
        /// Gets the identified operation contract that wil be bound to the context
        /// </summary>
        /// <typeparam name="T">The contract type</typeparam>
        /// <returns></returns>
        Option<T> Operations<T>();

        /// <summary>
        /// Retrieves schema table metadata for the result set specified by a query script
        /// </summary>
        /// <param name="sql">The query script</param>
        /// <returns></returns>
        Option<IReadOnlyList<SqlSchemaTableRow>> GetScriptResultSchema(string sql);

        /// <summary>
        /// Retrieves schema table metadata for the result sets specified by a stored procedure
        /// </summary>
        /// <param name="procedure">The name of the procedure</param>
        /// <returns></returns>
        Option<IReadOnlyList<SqlSchemaTableRow>> GetProcedureResultSchema(SqlProcedureName procedure, params (string, object)[] arguments);
    }

    public interface ISqlProxyBroker<A> : ISqlProxyBroker
        where A : class, ISqlProxyAssembly, new()
    {
        Assembly ProxyAssembly { get; }
    }

}
