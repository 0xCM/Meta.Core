//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

    using static metacore;
       
    /// <summary>
    /// Defines a structural isomorphism to represent a Sql variant value
    /// </summary>
    public readonly struct SqlVariant : ISqlVariant
    {
        /// <summary>
        /// Maps a CLR runtime value to a <see cref="SqlVariant"/> value if possible
        /// </summary>
        /// <param name="value">The input value</param>
        /// <returns>Returns a non-null <see cref="SqlVariant"/> value if successfull, otherwise returns null</returns>
        public static SqlVariant? FromObject(object value)
        {
            if (value is null)
                return null;

            switch (value)
            {
                case long x: return x;
                case int x: return x;
                case short x: return x;
                case bool x: return x;
                case string x: return x;
                case char[] x: return x;
                case byte[] x: return x;
                case byte x: return x;
                case float x: return x;
                case double x: return x;
                case decimal x: return x;
                case Guid x: return x;
                case DateTime x: return x;
                case Date x: return x;
                case DateTimeOffset x: return x;
                case TimeSpan x: return x;

            }
            return null;
        }

        /// <summary>
        /// Parses a variant from a string, if possible; otherwise, returns None
        /// </summary>
        /// <param name="kind">The target type</param>
        /// <param name="s">The variant value represented as a string</param>
        /// <returns></returns>
        public static Option<SqlVariant> Parse(SqlVariantKind kind, string s)
            => TryParse(kind, s).ValueOrDefault();

        static SqlVariant? TryParse(SqlVariantKind kind, string s)
        {
            switch(kind)
            {
                case SqlVariantKind.Bigint:
                    return try_parse<long>(s).ValueOrDefault();

                case SqlVariantKind.Bit:
                    return try_parse<bool>(s).ValueOrDefault();

                case SqlVariantKind.Tinyint:
                    return try_parse<byte>(s).ValueOrDefault();

                case SqlVariantKind.Smallint:
                    return try_parse<short>(s).ValueOrDefault();

                case SqlVariantKind.Char:
                case SqlVariantKind.NChar:
                    return s.ToCharArray();

                case SqlVariantKind.VarChar:
                case SqlVariantKind.NVarChar:
                    return s;

                case SqlVariantKind.Date:
                    return try_parse<Date>(s).ValueOrDefault();

                case SqlVariantKind.DateTime:
                case SqlVariantKind.DateTime2:
                case SqlVariantKind.SmallDateTime:
                    return try_parse<DateTime>(s).ValueOrDefault();

                case SqlVariantKind.DateTimeOffset:
                    return try_parse<DateTimeOffset>(s).ValueOrDefault();

                case SqlVariantKind.Time:
                    return try_parse<TimeSpan>(s).ValueOrDefault();

                case SqlVariantKind.Money:
                case SqlVariantKind.Decimal:
                case SqlVariantKind.SmallMoney:
                    return try_parse<Decimal>(s).ValueOrDefault();

                case SqlVariantKind.Binary:
                case SqlVariantKind.Varbinary:
                    throw new NotSupportedException();
                default:
                    return s?.ToString();
            }
        }

        public static readonly SqlVariant Unspecified 
            = new SqlVariant(DBNull.Value, SqlVariantKind.Unspecified);

        public static implicit operator int?(SqlVariant x)
            => x.value == null ? (int?)null : cast<int>(x.value);

        public static implicit operator SqlVariant(int x)
            => new SqlVariant(x);

        public static implicit operator long? (SqlVariant x)
            => x.value == null ? (long?)null : cast<long>(x.value);

        public static implicit operator SqlVariant(long x)
            => new SqlVariant(x);

        public static implicit operator string (SqlVariant x)
            => x.value?.ToString() ?? String.Empty;

        public static implicit operator SqlVariant(string x)
            => new SqlVariant(x);

        public static implicit operator byte[] (SqlVariant x)
            => tryCast<byte[]>(x.value).ValueOrElse( () => new byte[] { });

        public static implicit operator SqlVariant(byte[] x)
            => new SqlVariant(x);

        public static implicit operator Guid? (SqlVariant x)
            => x.value == null ? (Guid?) null : cast<Guid>(x.value);

        public static implicit operator SqlVariant(Guid x)
            => new SqlVariant(x);

        public static implicit operator Date? (SqlVariant x)
            => x.value == null ? (Date?)null : cast<Date>(x.value);

        public static implicit operator SqlVariant(Date x)
            => new SqlVariant(x);

        public static implicit operator DateTime? (SqlVariant x)
            => x.value == null ? (DateTime?)null : cast<DateTime>(x.value);

        public static implicit operator SqlVariant(DateTime x)
            => new SqlVariant(x);

        public static implicit operator byte? (SqlVariant x)
            => x.value == null ? (byte?)null : convert<byte>(x.value);

        public static implicit operator SqlVariant(byte x)
            => new SqlVariant(x);

        public static implicit operator bool? (SqlVariant x)
            => x.value == null ? (bool?)null : convert<bool>(x.value);

        public static implicit operator SqlVariant(bool x)
            => new SqlVariant(x);

        public static implicit operator SqlVariant(char[] x)
            => new SqlVariant(x);

        public static implicit operator SqlVariant(DateTimeOffset x)
            => new SqlVariant(x);

        public static implicit operator DateTimeOffset?(SqlVariant x)
            => x.value == null ? (DateTimeOffset?) null : cast<DateTimeOffset>(x.value);

        public static implicit operator SqlVariant(Decimal x)
            => new SqlVariant(x);

        public static implicit operator decimal? (SqlVariant x)
            => x.value == null ? (Decimal?)null : cast<Decimal>(x.value);

        public static implicit operator SqlVariant(TimeSpan x)
            => new SqlVariant(x);

        public static implicit operator TimeSpan? (SqlVariant x)
            => x.value == null ? (TimeSpan?)null : cast<TimeSpan>(x.value);

        public static implicit operator SqlVariant(Single x)
            => new SqlVariant(x);

        public static implicit operator float? (SqlVariant x)
            => x.value == null ? (float?)null : (float)x.value;

        public static implicit operator SqlVariant(double x)
            => new SqlVariant(x);

        public static implicit operator double? (SqlVariant x)
            => x.value == null ? (double?)null : cast<double>(x.value);

        public static implicit operator CoreDataValue(SqlVariant x)
            => CoreDataValue.FromObject(x.value).ValueOrDefault();
       

        public SqlVariant(object value, SqlVariantKind kind = SqlVariantKind.Unspecified)
        {
            this.kind = kind;
            this.value = value;
        }

        public SqlVariant(string value, SqlVariantKind kind = SqlVariantKind.NVarChar)
        {
            this.kind = kind;
            this.value = value;
        }

        public SqlVariant(Date value)
        {
            this.kind = SqlVariantKind.Date;
            this.value = value;
        }

        public SqlVariant(DateTime value, SqlVariantKind kind = SqlVariantKind.DateTime2)
        {
            this.kind = kind;
            this.value = value;
        }

        public SqlVariant(byte value)
        {
            this.kind = SqlVariantKind.Tinyint;
            this.value = value;
        }

        public SqlVariant(decimal value, SqlVariantKind kind = SqlVariantKind.Money)
        {
            this.kind = kind;
            this.value = value;
        }

        public SqlVariant(byte[] value, SqlVariantKind kind = SqlVariantKind.Varbinary)
        {
            this.kind = kind;
            this.value = value;
        }

        public SqlVariant(bool value)
        {
            this.kind = SqlVariantKind.Bit;
            this.value = value;
        }

        public SqlVariant(short value)
        {
            this.kind = SqlVariantKind.Smallint;
            this.value = value;
        }

        public SqlVariant(int value)
        {
            this.kind = SqlVariantKind.Int;
            this.value = value;
        }

        public SqlVariant(long value)
        {
            this.kind = SqlVariantKind.Bigint;
            this.value = value;
        }

        public SqlVariant(Guid value)
        {
            this.kind = SqlVariantKind.UniqueIdentifier;
            this.value = value;
        }

        public SqlVariant(TimeSpan value)
        {
            this.kind = SqlVariantKind.Time;
            this.value = value;
        }

        public SqlVariant(char[] value, SqlVariantKind kind = SqlVariantKind.NChar)
        {
            this.kind = kind;
            this.value = value;            
        }

        public SqlVariant(DateTimeOffset value)
        {
            this.kind = SqlVariantKind.DateTimeOffset;
            this.value = value;
        }

        public SqlVariant(Single value)
        {
            this.kind = SqlVariantKind.Real;
            this.value = value;
        }

        public SqlVariant(double value)
        {
            this.kind = SqlVariantKind.Float;
            this.value = value;
        }

        object value { get; }

        SqlVariantKind kind { get; }

        public object Value 
            => value;

        public SqlVariantKind VariantKind 
            => kind;        

        public override string ToString()
        {
            if (value == null)
                return "null";

            return value.ToString();

        }
    }
}
