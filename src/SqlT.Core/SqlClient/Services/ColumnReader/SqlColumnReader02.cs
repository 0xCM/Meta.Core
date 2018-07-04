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
    using System.Data.SqlClient;

    using Meta.Core;
    /// <summary>
    /// Translates two columns of data from the input reader
    /// </summary>
    /// <typeparam name="X1">The runtime data type of the first column</typeparam>
    /// <typeparam name="X2">The runtime data type of the second column</typeparam>
    public class SqlColumnReader<X1, X2> : SqlColumnReader, ISqlColumnReader<X1, X2>
    {
        private readonly int[] positions;

        public SqlColumnReader(SqlConnectionString cs, string sql, params int[] positions)
            : base(cs, sql)
        {
            this.positions = positions.Length != 2 ? new[] { 0, 1 } : positions;
        }

        protected override object ReadColumns(SqlDataReader reader)
        {
            var i = 0;
            return Tuple.Create(
                reader.GetFieldValue<X1>(positions[i++]),
                reader.GetFieldValue<X2>(positions[i++]));
        }

        IEnumerator<DataFrameRow<X1, X2>> GetEnumerator()
        {
            foreach (DataFrameRow<X1, X2> col in GetColumnData())
                yield return col;
        }

        IEnumerator<DataFrameRow<X1, X2>> IEnumerable<DataFrameRow<X1, X2>>.GetEnumerator()
            => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }

}