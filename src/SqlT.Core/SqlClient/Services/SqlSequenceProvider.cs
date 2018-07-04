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

    public class SqlSequenceProvider : ISequenceProvider
    {
        public static ISequenceProvider Get(SqlConnectionString cs, SqlSequenceName seqname)
            => new SqlSequenceProvider(cs, seqname);
        
        static IEnumerable<T> Allocate<T>(SqlConnectionString cs, SqlSequenceName seqname, int count)
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

            for (var i = 0m; i < count; i++)
                yield return (T)Convert.ChangeType(i + firstValue, typeof(T));
        }


        readonly SqlConnectionString cs;
        readonly SqlSequenceName seqname;

        SqlSequenceProvider(SqlConnectionString cs, SqlSequenceName seqname)
        {
            this.cs = cs;
            this.seqname = seqname;
        }

        public IEnumerable<T> NextRange<T>(int count)
            => Allocate<T>(cs, seqname, count);

        public T NextValue<T>()
            => Allocate<T>(cs, seqname, 1).Single();

    }
}