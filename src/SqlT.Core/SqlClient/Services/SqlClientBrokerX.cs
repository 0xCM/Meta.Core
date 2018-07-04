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
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Defines extensions for the <see cref="ISqlClientBroker"/> contract
    /// </summary>
    public static class SqlClientBrokerX
    {
        /// <summary>
        /// Creates SQL Sequence-backed sequence generator
        /// </summary>
        /// <typeparam name="T">The sequence item type</typeparam>
        /// <param name="cs">The connection string</param>
        /// <param name="seqname">The name of the sequence</param>
        /// <returns></returns>
        /// <remarks>
        /// This operation will fail if the sequence doesn't exist
        /// </remarks>
        public static ISequenceGenerator<T> CreateSequenceGenerator<T>(this SqlConnectionString cs, SqlSequenceName seqname, int blocksize = 100)
            => SqlSequenceProvider.Get(cs, seqname).CreateCachingGenerator<T>(blocksize);

        public static ISequenceGenerator<T> CreateCachingGenerator<T>(this ISequenceProvider provider, int defaultBlockSize = 100)
            => new SequenceGenerator<T>(provider);

        public static IEnumerable<T> SelectColumn<T>(this ISqlClientBroker broker, string sql, int position = 0, bool eatnull = true)
        {
            using (var reader = SqlColumnReader.Create<T>(broker.ConnectionString, sql, position))
            {
                foreach (var value in reader)
                    if (value == null && eatnull)
                        continue;
                    else
                        yield return value.x1;
            }
        }

        const string CompatibilityLevel
            = @"select compatibility_level from [sys].[databases] where name = '@DatabaseName'";

        const string CompatibilityLevel_Qualified
            = @"select compatibility_level from [@ServerName].[master].[sys].[databases] where name = '@DatabaseName'";

        const string BULK_INSERT_TEMPLATE
            = @"bulk insert @TargetTable from '@DataFile' with(formatfile='@FormatFile');";

        static SqlScript sql(this string template, object parameters)
            => SqlScript.FromText(template, parameters);

        public static string SQL_COMPATIBILITY_LEVEL(this SqlDatabaseName database)
            => database.IsServerQualified ?
                sql(CompatibilityLevel_Qualified,
                 new
                 {
                     ServerName = database.ServerName,
                     DatabaseName = database.UnqualifiedName
                 })
                 : sql(CompatibilityLevel, new
                 {
                     DatabaseName = database.UnqualifiedName
                 });


        public static SqlScript SQL_BULK_INSERT(this SqlTableName target, string DataFile, string FormatFile)
            => sql(BULK_INSERT_TEMPLATE,
                new
                {
                    TargetTable = target.TrimCatalog(),
                    DataFile,
                    FormatFile
                });

        /// <summary>
        /// Obtains a table handle from the broker
        /// </summary>
        /// <param name="Broker">The broker that provides access to the handle</param>
        /// <param name="Table">The name of the table for which a handle will be obtained</param>
        /// <returns></returns>
        public static SqlTableHandle Table(this ISqlClientBroker Broker, SqlTableName Table)
            => new SqlTableHandle(Broker, Table);

        /// <summary>
        /// Retrieves a sequence handle
        /// </summary>
        /// <param name="Broker">The broker that provides access to the handle</param>
        /// <param name="Sequence">The name of the sequence that is represented by the returned handle</param>
        /// <returns></returns>
        public static SqlSequenceHandle Sequence(this ISqlClientBroker Broker, SqlSequenceName Sequence)
            => new SqlSequenceHandle(Broker, Sequence);

        /// <summary>
        /// Retrieves a typed sequence handle
        /// </summary>
        /// <typeparam name="T">The numeric type of the sequence</typeparam>
        /// <param name="Broker">The broker that provides access to the handle</param>
        /// <param name="Sequence">The name of the sequence that is represented by the returned handle</param>
        /// <returns></returns>
        public static SqlSequenceHandle<T> Sequence<T>(this ISqlClientBroker Broker, SqlSequenceName Sequence)
            => new SqlSequenceHandle<T>(Broker, Sequence);

        /// <summary>
        /// Retrieves a handle to a database
        /// </summary>
        /// <param name="Broker"></param>
        /// <param name="DatabaseName"></param>
        /// <returns></returns>
        public static SqlDatabaseHandle Database(this ISqlClientBroker Broker, SqlDatabaseName DatabaseName)
            => new SqlDatabaseHandle(Broker, DatabaseName);

        /// <summary>
        /// Executes a script that doesn't yield a rowset
        /// </summary>
        /// <param name="broker">The facilitating broker</param>
        /// <param name="script">The script to execute</param>
        /// <returns></returns>
        public static Option<int> ExecuteNonQuery(this ISqlClientBroker broker, SqlScript script)
            => broker.ExecuteNonQuery(script);

        static SqlConnection OpenDirectConnection(this ISqlClientBroker broker)
            => broker.ConnectionString.OpenConnection();

        /// <summary>
        /// Selects the first two columns from the result set obtained by executing the supplied SQL
        /// </summary>
        /// <typeparam name="C0">The runtime data type of the first column</typeparam>
        /// <typeparam name="C1">The runtime data type of the second column</typeparam>
        /// <param name="broker">The facilitating broker</param>
        /// <param name="sql">The script that when executing yields a conforming result set</param>
        /// <returns></returns>
        public static IEnumerable<DataFrameRow<C0, C1>> SelectColumns<C0, C1>(this ISqlClientBroker broker, string sql)
        {
            using (var connection = broker.ConnectionString.OpenConnection())
            using (var command = connection.CreateCommand(sql))
            using (var reader = command.ExecuteReader(CommandBehavior.SingleResult))
                if (reader.HasRows)
                    for (; ; )
                    {
                        if (reader.Read())
                        {
                            yield return (                                                             
                                reader.GetFieldValue<C0>(0), 
                                reader.GetFieldValue<C1>(1));
                        }
                        else
                            break;
                    }
        }

        /// <summary>
        /// Selects two index-identified columns of the result set obtained by executing the supplied SQL
        /// </summary>
        /// <typeparam name="X1">The runtime data type of the first column</typeparam>
        /// <typeparam name="X2">The runtime data type of the second column</typeparam>
        /// <param name="broker">The facilitating broker</param>
        /// <param name="sql">The script that when executing yields a conforming result set</param>
        /// <param name="positions">The zero-based column indexes</param>
        /// <returns></returns>
        public static IEnumerable<DataFrameRow<X1, X2>> SelectColumns<X1, X2>(this ISqlClientBroker broker, string sql, params int[] positions)
        {
            using (var reader = SqlColumnReader.Create<X1, X2>(broker.ConnectionString, sql, positions))
            {
                foreach (var value in reader)
                    yield return value;
            }
        }

        /// <summary>
        /// Selects the first three columns from the result set obtained by executing the supplied SQL
        /// </summary>
        /// <typeparam name="X1">The runtime data type of the first column</typeparam>
        /// <typeparam name="X2">The runtime data type of the second column</typeparam>
        /// <typeparam name="X3">The runtime data type of the third column</typeparam>
        /// <param name="broker">The facilitating broker</param>
        /// <param name="sql">The script that when executing yields a conforming result set</param>
        /// <returns></returns>
        public static IEnumerable<DataFrameRow<X1, X2, X3>> SelectColumns<X1, X2, X3>(this ISqlClientBroker broker, string sql)
        {
            using (var connection = broker.OpenDirectConnection())
            using (var command = connection.CreateCommand(sql))
            using (var reader = command.ExecuteReader(CommandBehavior.SingleResult))
                if (reader.HasRows)
                    for (;;)
                    {
                        if (reader.Read())
                        {
                            yield return (
                                reader.GetFieldValue<X1>(0),
                                reader.GetFieldValue<X2>(1),
                                reader.GetFieldValue<X3>(2)
                                );
                        }
                        else
                            break;
                    }
        }

        /// <summary>
        /// Selects three index-identified columns of the result set obtained by executing the supplied SQL
        /// </summary>
        /// <typeparam name="X1">The runtime data type of the first column</typeparam>
        /// <typeparam name="X2">The runtime data type of the second column</typeparam>
        /// <typeparam name="X3">The runtime data type of the third column</typeparam>
        /// <param name="broker">The facilitating broker</param>
        /// <param name="sql">The script that when executing yields a conforming result set</param>
        /// <param name="positions">The zero-based column indexes</param>
        /// <returns></returns>
        public static IEnumerable<DataFrameRow<X1, X2, X3>> SelectColumns<X1, X2, X3>(this ISqlClientBroker broker, string sql, params int[] positions)
        {
            using (var reader = SqlColumnReader.Create<X1, X2, X3>(broker.ConnectionString, sql, positions))
                foreach (var value in reader)
                    yield return value;
        }

        /// <summary>
        /// Selects the first four columns from the result set obtained by executing the supplied SQL
        /// </summary>
        /// <typeparam name="X1">The runtime data type of the first column</typeparam>
        /// <typeparam name="X2">The runtime data type of the second column</typeparam>
        /// <typeparam name="X3">The runtime data type of the third column</typeparam>
        /// <typeparam name="X4">The runtime data type of the fourth column</typeparam>
        /// <param name="broker">The facilitating broker</param>
        /// <param name="sql">The script that when executing yields a conforming result set</param>
        /// <returns></returns>
        public static IEnumerable<DataFrameRow<X1, X2, X3, X4>> SelectColumns<X1, X2, X3, X4>(this ISqlClientBroker broker, string sql)
        {
            using (var connection = broker.OpenDirectConnection())
            using (var command = connection.CreateCommand(sql))
            using (var reader = command.ExecuteReader(CommandBehavior.SingleResult))
                if (reader.HasRows)
                    for (;;)
                    {
                        if (reader.Read())
                        {
                            yield return (                                
                                reader.GetFieldValue<X1>(0),
                                reader.GetFieldValue<X2>(1),
                                reader.GetFieldValue<X3>(2),
                                reader.GetFieldValue<X4>(3)
                                );
                        }
                        else
                            break;
                    }
        }

        /// <summary>
        /// Selects four index-identified columns of the result set obtained by executing the supplied SQL
        /// </summary>
        /// <typeparam name="X1">The runtime data type of the first column</typeparam>
        /// <typeparam name="X2">The runtime data type of the second column</typeparam>
        /// <typeparam name="X3">The runtime data type of the third column</typeparam>
        /// <typeparam name="X4">The runtime data type of the fourth column</typeparam>
        /// <param name="broker">The facilitating broker</param>
        /// <param name="sql">The script that when executing yields a conforming result set</param>
        /// <param name="positions">The zero-based column indexes</param>
        /// <returns></returns>
        public static IEnumerable<DataFrameRow<X1, X2, X3, X4>> SelectColumns<X1, X2, X3, X4>(this ISqlClientBroker broker, 
            string sql, params int[] positions)
        {
            using (var reader = SqlColumnReader.Create<X1, X2, X3, X4>(broker.ConnectionString, sql, positions))
                foreach (var value in reader)
                    yield return value;
        }

        /// <summary>
        /// Obtains a table handle from the broker
        /// </summary>
        /// <param name="Broker">The broker that provides access to the handle</param>
        /// <param name="View">The name of the view for which a handle will be obtained</param>
        /// <returns></returns>
        public static SqlViewHandle View(this ISqlClientBroker Broker, SqlViewName View)
            => new SqlViewHandle(Broker, View);

        /// <summary>
        /// Retrieves the handle for a server that is linked to the server with which the broker is associated
        /// </summary>
        /// <param name="Broker">The mediating broker</param>
        /// <param name="LinkedServer">The name of the server that is represented by the returned handle</param>
        /// <returns></returns>
        public static SqlLinkedServerHandle LinkedServer(this ISqlClientBroker Broker, SqlServerName LinkedServer)
            => new SqlLinkedServerHandle(Broker, LinkedServer);

        /// <summary>
        /// Retrieves the handle for server with which the broker is associated
        /// </summary>
        /// <param name="Broker">The mediating broker</param>
        /// <returns></returns>
        public static ISqlServerHandle Server(this ISqlClientBroker Broker)
            => new SqlServerInstanceHandle(Broker, Broker.ConnectionString.ServerName);

        /// <summary>
        /// Retrieves the handle for a host server or linked server as applicable
        /// </summary>
        /// <param name="Broker">The mediating broker</param>
        /// <param name="ServerName">The name of the server that is represented by the returned handle</param>
        /// <returns></returns>
        public static ISqlServerHandle Server(this ISqlClientBroker Broker, SqlServerName ServerName)
            => (ServerName != null
                && ServerName.IsSpecified
                && Broker.ConnectionString.ServerName != ServerName.FullName
                ) ? Broker.LinkedServer(ServerName) : Broker.Server();
    }

}