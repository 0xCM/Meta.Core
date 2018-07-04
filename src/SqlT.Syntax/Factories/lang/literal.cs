//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Syntax;
    using SqlT.Core;
    using SqlT.Models;

    using static metacore;
    using kwt = SqlKeywordTypes;
    using sxc = contracts;
    using sx = SqlSyntax;
    using static SqlSyntax;

    public static partial class sql
    {

        public static sxc.literal_value L(object value)
        {
            switch (value)
            {
                case byte[] x: return L(x);
                case bool x: return L(x);
                case char x: return L(x);
                case string x: return L(x);
                case decimal x: return L(x);
                case float x: return L(x);
                case double x: return L(x);
                case byte x: return L(x);
                case short x: return L(x);
                case ushort x: return L(x);
                case int x: return L(x);
                case uint x: return L(x);
                case long x: return L(x);
                case ulong x: return L(x);
                case Date x: return L(x);
                case DateTime x: return L(x);
                case TimeSpan x: return L(x);
                case Guid x: return L(x);
                case SqlVariant x: return L(x);
                case object_id x: return L(x.Value);
            }


            return null;

        }

        public static binary_literal L(byte[] value)
            => value;

        public static bit_literal L(bool value)
            => value;

        public static character_literal L(char value)
            => value;

        public static date_literal L(Date value)
            => value;

        public static datetime_literal L(DateTime value)
            => value;

        public static decimal_literal L(decimal value)
            => value;

        public static float_literal L(float value)
            => value;

        public static float_literal L(double value)
            => value;

        public static integer_literal L(int value)
            => value;

        public static integer_literal L(byte value)
            => value;

        public static integer_literal L(short value)
            => value;

        public static integer_literal L(ushort value)
            => value;

        public static integer_literal L(long value)
            => value;

        public static integer_literal L(uint value)
            => value;

        public static integer_literal L(ulong value)
            => value;

        public static string_literal string_literal(string value)
            => value;

        public static string_literal L(string value)
            => value;

        public static time_literal L(TimeSpan value)
            => value;

        public static uniqueidentifier_literal L(Guid value)
            => value;

        public static scalar_value L(CoreDataValue value)
            => new scalar_value(value);

        public static scalar_value literal(DBNull dbNull)
            => new scalar_value(dbNull);

        public static scalar_value L(SqlVariant value)
            => new scalar_value(value);

        public static integer_literal L(object_id value)
            => L(value.Value);

        public static binary_literal binary_literal(string value)
            => Convert.FromBase64String(value);

        public static bit_literal bit_literal(string value)
            => parse<bool>(value);

        public static character_literal character_literal(string value)
            => string.IsNullOrWhiteSpace(value) ? '\0' : value[0];

        public static date_literal date_literal(string value)
            => Date.Parse(value);

        public static datetime_literal date_time_literal(string value)
            => parse<DateTime>(value);

        public static decimal_literal decimal_literal(string value)
            => parse<decimal>(value);

        public static money_literal money_literal(string value)
            => parse<decimal>(value);

        public static integer_literal integer_literal(string value)
            => parse<int>(value);

        public static float_literal float_literal(string value)
            => parse<double>(value);

        public static symbolic_literal symbolic_literal(IKeyword keyword)
            => new symbolic_literal(keyword.KeywordName);

        public static time_literal time_literal(string value)
            => parse<TimeSpan>(value);

        public static uniqueidentifier_literal unique_identifier_literal(string value)
            => parse<Guid>(value);

        public static SqlIdentifier sql_identifier(string value)
            => new SqlIdentifier(value,false);

    }


}