﻿//-------------------------------------------------------------------------------------------
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

    public class SqlColumnReader<X1, X2, X3, X4> : SqlColumnReader, ISqlColumnReader<X1, X2, X3, X4>
    {
        int[] positions { get; }

        public SqlColumnReader(SqlConnectionString cs, string sql, params int[] positions)
            : base(cs, sql)
        {
            this.positions = positions.Length != 3 ? new[] { 0, 1, 2 } : positions;
        }

        protected override object ReadColumns(SqlDataReader reader)
        {
            var i = 0;
            return Tuple.Create(
                reader.GetFieldValue<X1>(positions[i++]),
                reader.GetFieldValue<X2>(positions[i++]),
                reader.GetFieldValue<X3>(positions[i++]),
                reader.GetFieldValue<X4>(positions[i++])
                );
        }

        IEnumerator<Record<X1, X2, X3, X4>> GetEnumerator()
        {
            foreach (Record<X1, X2, X3, X4> col in GetColumnData())
                yield return col;
        }

        IEnumerator<Record<X1, X2, X3, X4>> IEnumerable<Record<X1, X2, X3, X4>>.GetEnumerator()
            => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

    }

}