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
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    using static metacore;

    public static class SqlClientExtensions
    {
        public static IReadOnlyList<SqlColumnIdentifier> IdentifyColumns(this SqlDataReader reader)
        {
            var identifiers = new List<SqlColumnIdentifier>();
            for (int i = 0; i < reader.FieldCount; i++)
                identifiers.Add(new SqlColumnIdentifier(reader.GetName(i), i));
            return identifiers;            
        }

        public static SqlConnectionCommand WithArguments(this SqlConnectionCommand command, IEnumerable<(string name,object value)> parameters)
        {
            iter(parameters, p=>
                command.Parameters.AddWithValue(p.name, p.value));
            return command;
        }

        public static DataTable GetSchemaTable(this SqlCommand command)
        {
            var reader = command.ExecuteReader(CommandBehavior.SchemaOnly);
            try
            {
                return reader.GetSchemaTable();
            }
            finally
            {
                reader.Close();
            }
        }

        public static DataTable GetDataTable(this SqlConnectionString cs, ISqlScript sql, SqlObjectName SourceObjectName = null)
        {
            var dataTable = SourceObjectName == null 
                ? new DataTable() 
                : new DataTable(SourceObjectName);
            using (var connection = cs.OpenConnection())
                using (var command = connection.CreateCommand(sql.ScriptText))
                    using (var adapter = new SqlDataAdapter(command))
                        adapter.Fill(dataTable);

            return dataTable;
        }

        /// <summary>
        /// Populates a <see cref="DataTable"/> as specified by a <see cref="SqlTableQuery"/>
        /// </summary>                                                 
        public static DataTable GetDataTable(this SqlConnectionString cs, SqlTableQuery query)
            => cs.GetDataTable(query.Script, query.SourceName);
           
        public static IEnumerable<T> Select<T>(this SqlConnectionString cs, string sql, Func<object[], T> converter)
        {
            using (var connection = cs.OpenConnection())
            using (var command = new SqlCommand(sql, connection))
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return converter(reader.GetValueArray());
                    }
                }
            }
        }

        /// <summary>
        /// Reads an array of values from the reader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object[] GetValueArray(this SqlDataReader reader)
        {
            var values = new object[reader.FieldCount];
            reader.GetValues(values);
            return values;
        }

        /// <summary>
        /// Exhausts the reader's data supply
        /// </summary>
        /// <param name="reader">The reader to exhaust</param>
        /// <returns></returns>
        public static IEnumerable<object[]> ReadToEnd(this SqlDataReader reader)
        {
            while (reader.Read())
                yield return reader.GetValueArray();
        }

        /// <summary>
        /// Opens a connection to an identified data source
        /// </summary>
        /// <param name="cs">Provides access to the data source</param>
        /// <returns></returns>
        public static SqlConnection OpenConnection(this SqlConnectionString cs, Action<SqlNotification> observer = null)
        {
            var connection = new SqlConnection(cs);
            observer?.Observe(connection);
            connection.Open();            
            return connection;
        }

        /// <summary>
        /// Creates a <see cref="SqlCommand"/> from supplied SQL on a <see cref="SqlConnection"/>
        /// </summary>
        /// <param name="connection">The connection</param>
        /// <param name="sql">The SQL that specifies the command</param>
        /// <returns></returns>
        public static SqlCommand CreateCommand(this SqlConnection connection, string sql, int timeout = 60) 
            => new SqlCommand(sql, connection)
            {
                CommandTimeout = timeout
            };

        /// <summary>
        /// Executes a (pure) SQL command on a specified connection
        /// </summary>
        /// <param name="cs">Identifies the connection on which to execute the command</param>
        /// <param name="sql">The SQL to execute</param>
        public static void ExecuteCommand(this SqlConnectionString cs, string sql, Action<SqlNotification> observer = null)
        {
            using (var connection = cs.OpenConnection(observer))
                using (var command = connection.CreateCommand(sql))
                    command.ExecuteNonQuery();
        }

        /// <summary>
        /// Creates a client broker as specified by a connector
        /// </summary>
        /// <param name="connector">The connection string</param>
        /// <param name="observer">An optional witness to connection operations</param>
        /// <returns></returns>
        public static ISqlClientBroker GetClientBroker(this SqlConnectionString connector, SqlNotificationObserver observer = null)
            => new SqlClientBroker(connector, observer);

    }
}
