//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using Meta.Core;

    /// <summary>
    /// Base type for readers that transform data for a specific number and type of columns
    /// </summary>
    public abstract class SqlColumnReader : ISqlColumnReader
    {
        public static SqlColumnReader<C> Create<C>(SqlConnectionString cs, string sql, int position = 0)
            => new SqlColumnReader<C>(cs, sql, position);

        public static SqlColumnReader<C0, C1> Create<C0, C1>(SqlConnectionString cs, string sql, params int[] positions)
            => new SqlColumnReader<C0, C1>(cs, sql, positions);

        public static SqlColumnReader<C0, C1, C2> Create<C0, C1, C2>(SqlConnectionString cs, string sql, params int[] positions)
            => new SqlColumnReader<C0, C1, C2>(cs, sql, positions);

        public static SqlColumnReader<C0, C1, C2, C3> Create<C0, C1, C2, C3>(SqlConnectionString cs, string sql, params int[] positions)
            => new SqlColumnReader<C0, C1, C2, C3>(cs, sql, positions);

        SqlConnection connection { get; }

        SqlCommand command { get; }

        SqlDataReader reader { get; }


        protected SqlColumnReader(SqlConnectionString cs, string sql)
        {
            this.connection = cs.OpenConnection();
            this.command = connection.CreateCommand(sql);
            this.reader = command.ExecuteReader(CommandBehavior.SingleResult);
        }

        public void Dispose()
        {
            (reader as IDisposable).Dispose();
            command.Dispose();
            connection.Dispose();
        }

        protected abstract object ReadColumns(SqlDataReader reader);

        protected IEnumerable GetColumnData()
        {
            if (reader.HasRows)
                while (reader.Read())
                    yield return ReadColumns(reader);
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetColumnData().GetEnumerator();
    }







}
