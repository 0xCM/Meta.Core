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


    public class SqlColumnReader<X1> : SqlColumnReader, ISqlColumnReader<X1>
    {
        private readonly int colpos;

        public SqlColumnReader(SqlConnectionString cs, string sql, int colpos = 0)
            : base(cs, sql)
        {
            this.colpos = colpos;
        }


        protected override object ReadColumns(SqlDataReader reader)
            => reader.IsDBNull(colpos) ? default : reader.GetFieldValue<X1>(colpos);

        IEnumerator<DataFrameRow<X1>> GetEnumerator()
        {
            foreach (X1 col in GetColumnData())
                yield return new DataFrameRow<X1>(col);
        }

        IEnumerator<DataFrameRow<X1>> IEnumerable<DataFrameRow<X1>>.GetEnumerator()
            => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}