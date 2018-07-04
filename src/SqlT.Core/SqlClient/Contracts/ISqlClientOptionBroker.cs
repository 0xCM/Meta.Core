//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines SQL client operations required to support both typed and untyped data access
    /// </summary>
    public interface ISqlClientOptionBroker
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
            where T : new()
            ;

        /// <summary>
        /// Executes a script that does not yield a result set
        /// </summary>
        /// <param name="sql">The script to execute</param>
        /// <returns></returns>
        Option<int> ExecuteNonQuery(string sql);

        /// <summary>
        /// Blindly executes whatever is passed as a scalar and, without discrimination, returns whatever
        /// came over the wire
        /// </summary>
        /// <param name="sql">The script to execute</param>
        /// <returns></returns>
        Option<object> ExecuteScalarScript(string sql);


        /// <summary>
        /// Executes a scalar function and returns weakly-typed result 
        /// </summary>
        /// <param name="function">The function to execute</param>
        /// <param name="arguments">The set of (ordered) arguments that will passed to the function</param>
        /// <returns></returns>
        Option<object> ExecuteScalarFunction(SqlFunctionName function, params object[] arguments);


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
        /// <param name="sql">The script to execute</param>
        /// <param name="arguments">The arguments to pass to the procedure</param>
        /// <returns></returns>
        ScalarResult<T> ExecuteScalarScript<T>(string sql, params (string, object)[] arguments);

        /// <summary>
        /// Retrieves the next value from a named sequence
        /// </summary>
        /// <typeparam name="T">The CLR type mapped to the sequence data type</typeparam>
        /// <param name="sequence">The name of the sequence to hit</param>
        /// <returns></returns>
        Option<T> NextSequenceValue<T>(SqlSequenceName sequence);

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
        Option<ISqlBrokerSession> CreateSession();

        /// <summary>
        /// Provides the broker with a function to apply when a conversion from the source type to the target type is required
        /// </summary>
        /// <typeparam name="TSrc">The source type</typeparam>
        /// <typeparam name="TDst">The target type</typeparam>
        /// <param name="direction">Whether the data is flowing across or from the wire</param>
        /// <param name="f"></param>
        void RegisterConverter<TSrc, TDst>(SqlConversionDirection direction, Func<TSrc, TDst> f);
    }
}
