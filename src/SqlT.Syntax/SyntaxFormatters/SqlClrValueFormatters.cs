//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;

    using Meta.Core;

    using static metacore;
    using static SqlSyntax;

    /// <summary>
    /// Defines a collection of CLR primitive formatters
    /// </summary>
    public static class SqlClrValueFormatters
    {
        static IConversionSuite formatters;

        static SqlClrValueFormatters()
            => formatters = ConversionSuite.FromTypes(typeof(SqlClrValueFormatters));
        
        static string ToSqlString(this bool value)
            => value ? "1" : "0";

        static string ToSqlString(this char value)
            => value == '\'' ? @"''" : value.ToString();

        static string ToSqlString(this byte value)
            => value.ToString();

        static string ToSqlString(this sbyte value)
            => value.ToString();

        static string ToSqlString(this short value)
            => value.ToString();

        static string ToSqlString(this ushort value)
            => value.ToString();

        static string ToSqlString(this int value)
            => value.ToString();

        static string ToSqlString(this uint value)
            => value.ToString();

        static string ToSqlString(this long value)
            => value.ToString();

        static string ToSqlString(this ulong value)
            => value.ToString();

        static string ToSqlString(this float value)
            => value.ToString("e");

        static string ToSqlString(this double value)
            => value.ToString("e");

        static string ToSqlString(this decimal value)
            => value.ToString("n4");

        static string ToSqlString(this string value)
            => ifNotNull(value,
                x => squote(x.Replace("'", @"''")),
                () => NULL);

        static string ToSqlString(this DBNull dbnull)
            => NULL;

        static string ToSqlString(this Date value)
            => squote(value.ToIsoString());

        static string ToSqlString(this DateTime value)
            => squote(value.ToString("yyyy-MM-dd HH:mm:ss.fff"));

        static string ToSqlString(this TimeSpan value)
            => value.Milliseconds != 0
            ? squote(value.ToString("hh:mm:ss.fff"))
            : squote(value.ToString("hh:mm:ss"));

        static string ToSqlString(this byte[] value)
            => isNull(value)
            ? NULL
            : $"0x" + value.ToHexString();

        static string ToSqlString(this Guid value)
            => value.ToString("D");

        public static string FormatClrValue(object value)
            => formatters.Convert(value, x => x.ToString());
    }
}