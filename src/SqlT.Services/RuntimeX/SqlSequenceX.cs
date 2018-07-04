//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using SqlT.Core;

    public static partial class SqlBrokerExtensions
    {
        internal static Tuple<T, T> AllocateRange<T>(SqlConnectionString cs, SqlSequenceName seqname, int count)
        {
            var firstValue = 0m;
            using (var connection = new SqlConnection(cs))
            {
                connection.Open();
                using (var command = new SqlCommand("sys.sp_sequence_get_range", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@sequence_name", seqname.SchemaQualifiedName);
                    command.Parameters.AddWithValue("@range_size", count);
                    var firstValParam = new SqlParameter(@"range_first_value", SqlDbType.Variant);
                    firstValParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(firstValParam);
                    command.ExecuteNonQuery();

                    firstValue = (decimal)Convert.ChangeType(firstValParam.Value, typeof(decimal));
                }
            }

            var lastValue = firstValue + count;
            return (Tuple.Create((T)Convert.ChangeType(firstValue, typeof(T)), (T)Convert.ChangeType(lastValue, typeof(T))));
        }

        public static Tuple<T, T> AllocateRange<T>(this SqlSequenceHandle<T> h, int count)
            => AllocateRange<T>(h.Broker.ConnectionString, h.ElementName, count);

        /// <summary>
        /// Drops the represented sequence
        /// </summary>
        /// <param name="h">The handle that identifies the sequence object on which to operate</param>
        /// <returns></returns>
        public static SqlOutcome<int> Drop(this ISqlSequenceHandle h)
            => h.Broker.ExecuteNonQuery($"drop sequence {h}")
                    .OnFailure(message => new SqlErrorMessage($"Could not drop {h}", message));

        public static Option<int> DropIfExists(this ISqlSequenceHandle h)
        {
            var exists = h.Exists();
            if (!exists)
                return exists.ToNone<int>();

            if (exists.Value() == SqlBooleanValue.True)
                return h.Drop().ToOption();
            else
                return 0;            
        }

        public static Option<int> Restart<T>(this ISqlSequenceHandle h, T newValue)        
            => h.Broker.ExecuteNonQuery($"alter sequence {h} restart with {newValue}").ToOption();
        

    }
}
