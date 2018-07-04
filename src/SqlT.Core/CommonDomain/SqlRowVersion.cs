//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Reasonable way of dealing with the SQL Server rowversion data type that is transported
    /// via an 8-byte binary array
    /// </summary>
    /// <remarks>
    /// Taken from https://gist.github.com/jnm2/929d194c87df8ad0438f6cab0139a0a6
    ///</remarks>
    [DebuggerDisplay("{ToString(),nq}")]
    public struct SqlRowVersion : IComparable, IEquatable<SqlRowVersion>, IComparable<SqlRowVersion>
    {
        public static readonly SqlRowVersion Zero = default(SqlRowVersion);

        public readonly ulong Value;

        public static SqlRowVersion Parse(string s)
            => new SqlRowVersion(Convert.ToUInt64(s, 16));


        SqlRowVersion(ulong Value)
        {
            this.Value = Value;
        }

        public static implicit operator SqlRowVersion(ulong Value)        
            => new SqlRowVersion(Value);
        
        public static implicit operator SqlRowVersion(long Value)
            => new SqlRowVersion(unchecked((ulong)Value));

        public static explicit operator SqlRowVersion(byte[] Value)
            => Value == null 
            ? Zero 
            : new SqlRowVersion(
                ((ulong)Value[0] << 56) | 
                ((ulong)Value[1] << 48) | 
                ((ulong)Value[2] << 40) | 
                ((ulong)Value[3] << 32) | 
                ((ulong)Value[4] << 24) | 
                ((ulong)Value[5] << 16) | 
                ((ulong)Value[6] << 8) | Value[7]);
        

        public static explicit operator SqlRowVersion? (byte[] Value)
        {
            if (Value == null) return null;
            return new SqlRowVersion(
                ((ulong)Value[0] << 56) | 
                ((ulong)Value[1] << 48) | 
                ((ulong)Value[2] << 40) | 
                ((ulong)Value[3] << 32) | 
                ((ulong)Value[4] << 24) | 
                ((ulong)Value[5] << 16) | 
                ((ulong)Value[6] << 8) | Value[7]);
        }


        public static implicit operator byte[] (SqlRowVersion version)
            => version.GetBytes();


        byte[] GetBytes()
        {
            var r = new byte[8];
            r[0] = (byte)(Value >> 56);
            r[1] = (byte)(Value >> 48);
            r[2] = (byte)(Value >> 40);
            r[3] = (byte)(Value >> 32);
            r[4] = (byte)(Value >> 24);
            r[5] = (byte)(Value >> 16);
            r[6] = (byte)(Value >> 8);
            r[7] = (byte)Value;
            return r;

        }

        public override bool Equals(object obj)
            => obj is SqlRowVersion && Equals((SqlRowVersion)obj);

        public override int GetHashCode()
            => Value.GetHashCode();

        public bool Equals(SqlRowVersion other)
            => other.Value == Value;

        int IComparable.CompareTo(object obj)        
            => obj == null ? 1 : CompareTo((SqlRowVersion)obj);
        

        public int CompareTo(SqlRowVersion other)
            => Value == other.Value ? 0 : Value < other.Value ? -1 : 1;

        public static bool operator ==(SqlRowVersion comparand1, SqlRowVersion comparand2)        
            => comparand1.Equals(comparand2);
        
        public static bool operator !=(SqlRowVersion comparand1, SqlRowVersion comparand2)        
            => !comparand1.Equals(comparand2);
        
        public static bool operator >(SqlRowVersion comparand1, SqlRowVersion comparand2)
        {
            return comparand1.CompareTo(comparand2) > 0;
        }
        public static bool operator >=(SqlRowVersion comparand1, SqlRowVersion comparand2)
        {
            return comparand1.CompareTo(comparand2) >= 0;
        }
        public static bool operator <(SqlRowVersion comparand1, SqlRowVersion comparand2)
        {
            return comparand1.CompareTo(comparand2) < 0;
        }
        public static bool operator <=(SqlRowVersion comparand1, SqlRowVersion comparand2)
        {
            return comparand1.CompareTo(comparand2) <= 0;
        }

        public object ConvertTo(Type t)
        {
            if (t == typeof(string))
                return ToString();
            else if (t == typeof(byte[]))
                return GetBytes();
            else
                throw new NotSupportedException($"Cannot convert the rowversion value {this} to a value of type {t.Name}");
        }

        public override string ToString()
        {
            return Value.ToString("x16");
        }

        public static SqlRowVersion Max(SqlRowVersion comparand1, SqlRowVersion comparand2)
        {
            return comparand1.Value < comparand2.Value ? comparand2 : comparand1;
        }
    }
}
