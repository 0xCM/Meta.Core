//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class SqlDataFrame : ISqlDataFrame
    {
        public static readonly SqlDataFrame Empty = new SqlDataFrame(null, null);

        public SqlDataFrame(IReadOnlyList<SqlColumnIdentifier> Columns, IReadOnlyList<object[]> Rows)
        {
            this.Columns = Columns ?? new List<SqlColumnIdentifier>();
            this.Rows = Rows ?? new List<object[]>();
        }

        public int? ColumnIndex(SqlColumnIdentifier colid)
        {
            switch(colid.IdentifierKind)
            {
                case SqlColumnIdentifierKind.ColumnName:
                case SqlColumnIdentifierKind.NameAndPosition:
                    return Columns.TryGetSingle(c => c.ColumnName == colid.ColumnName).MapValueOrDefault(c => c.ColumnPosition);
                default:
                    return Columns.TryGetSingle(x => x.ColumnPosition == colid.ColumnPosition).MapValueOrDefault(c => c.ColumnPosition);                
            }
        }

        public IReadOnlyList<SqlColumnIdentifier> Columns { get; }

        public IReadOnlyList<object[]> Rows { get; }

        public IDataReader GetReader()
            => new CommonDataReader(Rows, Columns);

        public SqlOutcome<IReadOnlyList<T>> Slice<T>(int ColumnIndex)
        {
            var slice = new T[Rows.Count];
            var rowidx = 0;
            foreach (var row in Rows)
            {
                try
                {
                    var val = row[ColumnIndex];
                    slice[rowidx++] = (val != null && !(val is DBNull)) ? (T)val : default(T);
                }
                catch (Exception)
                {
                    return SqlOutcome.Failure<IReadOnlyList<T>>($"Could not cast the value {row[ColumnIndex]} to a value of type {typeof(T).Name}");
                }
            }
            return slice;
        }

        public SqlOutcome<IReadOnlyList<T>> Slice<T>(string ColumnName)
        {
            var col = Columns.FirstOrDefault(c => c.ColumnName == ColumnName);
            var colidx = col != null ? col.ColumnPosition : null;
            if (colidx == null)
                return SqlOutcome.Failure<IReadOnlyList<T>>($"The {ColumnName} was not found");
            else
                return Slice<T>(colidx.Value);
        }

        public IEnumerator GetEnumerator()
            => Rows.GetEnumerator();

        public bool IsEmpy
            => Object.ReferenceEquals(this, Empty) || Rows.Count == 0;
    }

    public class SqlDataFrame<T> : ISqlDataFrame<T>
        where T : class, ISqlTabularProxy, new()
    {
        public static readonly SqlDataFrame Empty = new SqlDataFrame(null, null);

        public SqlDataFrame(IReadOnlyList<SqlColumnIdentifier> Columns, IEnumerable<T> Rows)
        {
            this.Columns = Columns ?? new List<SqlColumnIdentifier>();
            this.Rows = Rows.ToList();
        }

        public IReadOnlyList<SqlColumnIdentifier> Columns { get; }

        public IReadOnlyList<T> Rows { get; }

        IReadOnlyList<object[]> ISqlDataFrame.Rows
            => Rows.Select(r => r.GetItemArray()).ToList();
        
        public IDataReader GetReader()
            => new CommonDataReader(Rows.Select(r => r.GetItemArray()), Columns);

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
            => Rows.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => Rows.GetEnumerator();
    }
}