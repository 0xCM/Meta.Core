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
    using System.Runtime.CompilerServices;

    using static metacore;
    

    /// <summary>
    /// Implements a Spartan data reader
    /// </summary>
    public class CommonDataReader : IDataReader
    {
        readonly IEnumerator<object[]> data;
        readonly IReadOnlyDictionary<string, int> ColumnIndexLookup;
        readonly IReadOnlyDictionary<int, string> ColumnNameLookup;
        int rowidx = -1;
        bool closed = false;
        object[] current;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        object val(int idx)
        {
            if (idx >= current.Length || idx < 0)
                throw new InvalidOperationException($"The the index {idx} exceeds the number of available columns");
                            
            return current[idx];
        }

        public CommonDataReader(IEnumerable<object[]> data, IEnumerable<SqlColumnIdentifier> columns)
        {
            this.ColumnIndexLookup = dict(map(columns, 
                c => (c.ColumnName.UnqualifiedName, c.ColumnPosition.Value)));
            this.ColumnNameLookup = dict(map(columns, 
                c => (c.ColumnPosition.Value, c.ColumnName.UnqualifiedName)));
            this.Columns = columns.ToList();
            this.FieldCount = ColumnNameLookup.Count;
            this.data = data.GetEnumerator();
        }

        public CommonDataReader(IEnumerable<object[]> data, IReadOnlyDictionary<int, string> ColumnNameLookup)
        {
            this.ColumnNameLookup = ColumnNameLookup;
            this.ColumnIndexLookup = dict(map(ColumnNameLookup, col => (col.Value, col.Key)));
            this.data = data.GetEnumerator();
            this.FieldCount = ColumnNameLookup.Count;
        }

        public IReadOnlyList<SqlColumnIdentifier> Columns { get; }

        public int FieldCount { get; }

        public bool NextResult()
            => false;

        public bool Read()
        {
            var moved = data.MoveNext();
            if (moved)
            {
                current = data.Current;
                rowidx++;
            }
            return moved;
        }

        public object this[string name]
        {
            get
            {
                var idx = 0;
                if(ColumnIndexLookup.TryGetValue(name, out idx))
                    return val(idx);
                else
                    throw new InvalidExpressionException($"The '{name}' column could not be found");
            }
        }
            
        public object this[int idx]
            => val(idx);

        public bool IsClosed
            => closed;

        public void Close()
            => closed = true;        

        public void Dispose()
            => Close();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool GetBoolean(int i)
            => cast<bool>(val(i));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte GetByte(int i)
            => cast<byte>(val(i));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public char GetChar(int i)
            => cast<char>(val(i));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DateTime GetDateTime(int i)
            => cast<DateTime>(val(i));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal GetDecimal(int i)
            => cast<decimal>(val(i));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double GetDouble(int i)
            => cast<double>(val(i));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float GetFloat(int i)
            => cast<float>(val(i));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Guid GetGuid(int i)
            => cast<Guid>(val(i));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short GetInt16(int i)
            => cast<short>(val(i));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetInt32(int i)
            => cast<int>(val(i));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long GetInt64(int i)
            => cast<long>(val(i));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Type GetFieldType(int i)
            => val(i)?.GetType();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string GetString(int i)
            => cast<string>(val(i));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object GetValue(int i)
            => val(i);

        public int GetValues(object[] values)
        {
            var count = Math.Min(values.Length, current.Length);
            for (int i = 0; i < count; i++)
                values[i] = val(i);
            return count;
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            Array.Copy((object[])val(i), fieldOffset, buffer, bufferoffset, length);
            return length;
        }

        public long GetChars(int i, long fieldOffset, char[] buffer, int bufferoffset, int length)
        {
            Array.Copy((object[])val(i), fieldOffset, buffer, bufferoffset, length);
            return length;
        }

        public int Depth
            => 0;

        public int RecordsAffected
            => 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetOrdinal(string name)
        {
            var i = -1;
            if (ColumnIndexLookup.TryGetValue(name, out i))
                return i;
            else
                throw new InvalidOperationException($"The '{name}' column could not be found");            
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string GetName(int i)
        {
            if (ColumnNameLookup.ContainsKey(i))
                return ColumnNameLookup[i];
            else
                throw new InvalidOperationException($"The column with ordinal {i} could not be found");
        }
            
        public DataTable GetSchemaTable()
            => throw new NotSupportedException();

        public IDataReader GetData(int i)
            => throw new NotSupportedException();

        public string GetDataTypeName(int i)
            => throw new NotSupportedException();
        
        public bool IsDBNull(int i)
            => GetFieldType(i) == typeof(DBNull);

    }
}
