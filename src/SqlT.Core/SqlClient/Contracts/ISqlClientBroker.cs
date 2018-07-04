//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines SQL client operations required to support both typed and untyped data access
    /// </summary>
    public interface ISqlClientBroker
    {
        /// <summary>
        /// Executes a script that yields a result set
        /// </summary>
        /// <param name="sql">The script to execute</param>
        /// <returns></returns>
        Option<SqlDataFrame> Select(string sql);

        /// <summary>
        /// Executes a script that yields a typed result set
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        Option<IReadOnlyList<T>> Select<T>(string sql)
            where T : new() ;
        
        /// <summary>
        /// Executes a script that does not yield a result set
        /// </summary>
        /// <param name="sql">The script to execute</param>
        /// <returns></returns>
        SqlOutcome<int> ExecuteNonQuery(string sql);

        /// <summary>
        /// Asynchronously executes a script that does not yield a result set
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="Observer"></param>
        /// <returns></returns>
        Task<Option<int>> ExecuteNonQueryAsync(string sql, SqlNotificationObserver Observer);

        /// <summary>
        /// Executes a supplied script while providing notifications to a supplied observer
        /// </summary>
        /// <param name="Script">The script to execute</param>
        /// <param name="Observer">The message receiver</param>
        /// <returns></returns>
        Option<int> ExecuteNonQuery(SqlScript Script, SqlNotificationObserver Observer, int? Timeout = null);
        
        /// <summary>
        /// Executes a script that returns a scalar value
        /// </summary>
        /// <typeparam name="T">The (mapped) scalar type</typeparam>
        /// <param name="sql">The script to execute</param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        ScalarResult<T> ExecuteScalarScript<T>(string sql, params(string, object)[] arguments);

        /// <summary>
        /// Blindly executes whatever is passed as a scalar and, without discrimination, returns whatever
        /// came over the wire
        /// </summary>
        /// <param name="sql">The script to execute</param>
        /// <returns></returns>
        SqlOutcome<object> ExecuteScalarScript(string sql);

        /// <summary>
        /// Executes a scalar function and returns weakly-typed result 
        /// </summary>
        /// <param name="function">The function to execute</param>
        /// <param name="arguments">The set of (ordered) arguments that will passed to the function</param>
        /// <returns></returns>
        ScalarResult<object> ExecuteScalarFunction(SqlFunctionName function, params object[] arguments);

        /// <summary>
        /// Executes a scalar function and returns strongly-typed result 
        /// </summary>
        /// <param name="function">The function to execute</param>
        /// <param name="arguments">The set of (ordered) arguments that will passed to the function</param>
        /// <returns></returns>
        ScalarResult<T> ExecuteScalarFunction<T>(SqlFunctionName function, params (string, object)[] arguments);


        /// <summary>
        /// Executes a scalar function and returns strongly-typed result 
        /// </summary>
        /// <param name="function">The function to execute</param>
        /// <param name="arguments">The set of (ordered) arguments that will passed to the function</param>
        /// <returns></returns>
        ScalarResult<T> ExecuteScalarFunction<T>(SqlFunctionName function, params object[] arguments);

        /// <summary>
        /// Executes a procedure that does not return a result set
        /// </summary>
        /// <param name="procedure">The name of the procedure to execute</param>
        /// <param name="arguments">The arguments to pass to the procedure</param>
        /// <returns></returns>
        Option<int> ExecuteProcedure(SqlProcedureName procedure, params (string, object)[] arguments);

        /// <summary>
        /// Retrieves the next value from a named sequence
        /// </summary>
        /// <typeparam name="T">The CLR type mapped to the sequence data type</typeparam>
        /// <param name="sequence">The name of the sequence to hit</param>
        /// <returns></returns>
        SqlOutcome<T> NextSequenceValue<T>(SqlSequenceName sequence);

        /// <summary>
        /// Retrieves a list of values from a named seqeuence
        /// </summary>
        /// <typeparam name="T">The CLR type mapped to the sequence data type</typeparam>
        /// <param name="sequence">The name of the sequence to hit</param>
        /// <returns></returns>
        /// <remarks>
        /// Note that depending on how sequence is defined, the returned list may not
        /// be a sequence of numbers that simply increments by 1. So, to preclude the
        /// client from engaging in explicit sequence gymnastics, this function will 
        /// return values computed by the database.
        /// </remarks>
        Option<IReadOnlyList<T>> NextSequenceValues<T>(SqlSequenceName sequence, int cout);

        /// <summary>
        /// The data used by the broker to locate and authenticate with a data source
        /// </summary>
        SqlConnectionString ConnectionString { get; }

        /// <summary>
        /// Opens a transaction within which subsequent operations will execute
        /// </summary>
        /// <returns></returns>
        SqlOutcome<ISqlBrokerSession> CreateSession();        

        /// <summary>
        /// Provides the broker with a function to apply when a conversion from the source type to the target type is required
        /// </summary>
        /// <typeparam name="TSrc">The source type</typeparam>
        /// <typeparam name="TDst">The target type</typeparam>
        /// <param name="direction">Whether the data is flowing across or from the wire</param>
        /// <param name="f"></param>
        void RegisterConverter<TSrc, TDst>(SqlConversionDirection direction, Func<TSrc, TDst> f);

        /// <summary>
        /// Adds an observer to the broker's notification delivery stream
        /// </summary>
        /// <param name="observer">Invoked when something of interest occurs</param>
        void Observe(Action<SqlNotification> observer);

    }
}
