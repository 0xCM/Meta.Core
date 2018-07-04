//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    using static metacore;


    public class SqlConnectionCommand : IDisposable
    {

        public SqlConnectionCommand(SqlConnection Connection, SqlCommand Command, bool OwnsConnection, SqlNotificationObserver observer)
        {
            this.Connection = Connection;
            this.Command = Command;
            this.OwnsConnection = OwnsConnection;
            this.Observer = msg => Observer?.Invoke(msg);

        }

        public SqlConnectionCommand(SqlConnection Connection, SqlCommand Command, bool OwnsConnection, Action<SqlNotification> observer)
        {
            this.Connection = Connection;
            this.Command = Command;
            this.OwnsConnection = OwnsConnection;
            this.Observer = observer;

        }

        SqlConnection Connection { get; }

        SqlCommand Command { get; }

        bool OwnsConnection { get; }

        Action<SqlNotification> Observer { get; }

        public void Dispose()
        {
            if (this.Command != null)
                this.Command.Dispose();

            if (this.Connection != null && OwnsConnection)
                this.Connection.Dispose();
        }

        public int ExecuteNonQuery()
            => Command.ExecuteNonQuery();

        public SqlParameterCollection Parameters
            => Command.Parameters;

        public SqlDataReader ExecuteReader()
            => Command.ExecuteReader(CommandBehavior.SingleResult);

        public DataTable GetSchemaTable()
            => Command.GetSchemaTable();

        public Task<int> ExecuteNonQueryAsync()
            => Command.ExecuteNonQueryAsync();


        public object ExecuteScalar()
        {            
            var result = Command.ExecuteScalar();
            return result;
        }

        public ScalarResult<T> GetScalar<T>(Func<object,T> converter)
        {
            try
            {
                var result = Command.ExecuteScalar();
                if (result == null || result.Equals(DBNull.Value))
                    return new ScalarResult<T>(true, none<T>());
                else
                    return new ScalarResult<T>(true, converter(result));
            }
            catch(Exception e)
            {
                return new ScalarResult<T>(false, none<T>(e));
            }

        }

        public T? ExecuteScalar<T>(Func<object,T> converter)
            where T : struct
        {
            var result = Command.ExecuteScalar();
            if (result == null || result.Equals(DBNull.Value))
                return null;
            else
                return converter(result);
        }

    }
}
