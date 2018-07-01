//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    using static metacore;
    using static CommonMessages;

    using M = System.Runtime.CompilerServices.MethodImplAttribute;
    using O = System.Runtime.CompilerServices.MethodImplOptions;
    using P = Meta.Core.ParserAttribute;

    public class PrimitiveParsers
    {
        const O IL = O.AggressiveInlining;

        public static IConversionSuite Projectors()
            => VPS.Value;

        static Lazy<IConversionSuite> VPS = defer(()
            => ConversionSuite.FromType<PrimitiveParsers>());


        [M(IL), P]
        static sbyte ParseInt8(string input)
        {
            if (sbyte.TryParse(input, out sbyte output))
                return output;
            else
                throw badarg<sbyte>(input);
        }

        [M(IL), P]
        static sbyte? ParseNullableInt8(string input)
        {
            if (isBlank(input))
                return null;

            if (sbyte.TryParse(input, out sbyte output))
                return output;
            else
                return null;
        }

        [M(IL), P]
        static byte ParseUInt8(string input)
        {
            var output = default(byte);
            if (byte.TryParse(input, out output))
                return output;
            else
                throw badarg<byte>(input);
        }


        [M(IL), P]
        static byte? ParseNullableUInt8(string input)
        {
            if (isBlank(input))
                return null;

            if (byte.TryParse(input, out byte output))
                return output;
            else
                return null;
        }


        [M(IL), P]
        static short ParseInt16(string input)
        {
            if (short.TryParse(input, out short output))
                return output;
            else
                throw badarg<short>(input);
        }

        [M(IL), P]
        static short? ParseNullableInt16(string input)
        {
            if (isBlank(input))
                return null;

            if (short.TryParse(input, out short output))
                return output;
            else
                return null;
        }


        [M(IL), P]
        static ushort ParseUInt16(string input)
        {
            if (ushort.TryParse(input, out ushort output))
                return output;
            else
                throw badarg<ushort>(input);
        }


        [M(IL), P]
        static ushort? ParseNullableUInt16(string input)
        {
            if (isBlank(input))
                return null;

            if (ushort.TryParse(input, out ushort output))
                return output;
            else
                return null;
        }

        [M(IL), P]
        static int ParseInt32(string input)
        {

            var output = default(int);
            if (int.TryParse(input, out output))
                return output;
            else
                throw badarg<int>(input);
        }

        [M(IL), P]
        static int? ParseNullableInt32(string input)
        {
            if (isBlank(input))
                return null;

            if (int.TryParse(input, out int output))
                return output;
            else
                return null;
        }


        [M(IL), P]
        static uint ParseUInt32(string input)
        {

            if (uint.TryParse(input, out uint output))
                return output;
            else
                throw badarg<uint>(input);
        }

        [M(IL), P]
        static uint? ParseNullableUInt32(string input)
        {
            if (isBlank(input))
                return null;

            if (uint.TryParse(input, out uint output))
                return output;
            else
                return null;
        }

        [M(IL), P]
        static long ParseInt64(string input)
        {
            var output = default(long);
            if (long.TryParse(input, out output))
                return output;
            else
                throw badarg<long>(input);

        }

        [M(IL), P]
        static long? ParseNullableInt64(string input)
        {
            if (isBlank(input))
                return null;

            if (long.TryParse(input, out long output))
                return output;
            else
                return null;
        }

        [M(IL), P]
        static ulong ParseUInt64(string input)
        {

            if (ulong.TryParse(input, out ulong output))
                return output;
            else
                throw badarg<ulong>(input);

        }

        [M(IL), P]
        static ulong? ParseNullableUInt64(string input)
        {
            if (isBlank(input))
                return null;

            if (ulong.TryParse(input, out ulong output))
                return output;
            else
                return null;
        }

        [M(IL), P]
        static decimal ParseDecimal(string input)
        {
            if (decimal.TryParse(input, out decimal output))
                return output;
            else
                throw badarg<decimal>(input);

        }

        [M(IL), P]
        static decimal? ParseNullableDecimal(string input)
        {
            if (isBlank(input))
                return null;

            if (decimal.TryParse(input, out decimal output))
                return output;
            else
                return null;
        }

        [M(IL), P]
        static Guid ParseGuid(string input)
        {
            if (Guid.TryParse(input, out Guid output))
                return output;
            else
                throw badarg<Guid>(input);

        }

        [M(IL), P]
        static Guid? ParseNullableGuid(string input)
        {
            if (isBlank(input))
                return null;

            if (Guid.TryParse(input, out Guid output))
                return output;
            else
                return null;
        }

        [M(IL), P]
        static Date ParseDate(string input)
        {
            var cleansed = input?.Trim()?.Trim('"');
            if (Date.TryParse(cleansed, out Date output))
                return output;
            else
                throw badarg<Date>(cleansed);

        }

        [M(IL), P]
        static Date? ParseNullableDate(string input)
        {
            if (isBlank(input))
                return null;

            if (Date.TryParse(input, out Date output))
                return output;
            else
                return null;
        }

        [M(IL), P]
        static DateTime ParseDateTime(string input)
        {
            var cleansed = input?.Trim()?.Trim('"');
            if (DateTime.TryParse(cleansed, out DateTime output))
                return output;
            else
                throw badarg<DateTime>(cleansed);

        }

        [M(IL), P]
        static DateTime? ParseNullableDateTime(string input)
        {
            if (isBlank(input))
                return null;

            if (DateTime.TryParse(input, out DateTime output))
                return output;
            else
                return null;
        }

        [M(IL), P]
        static TimeSpan ParseTimespan(string input)
        {
            if (TimeSpan.TryParse(input, out TimeSpan output))
                return output;
            else
                throw badarg<TimeSpan>(input);

        }

        [M(IL), P]
        static TimeSpan? ParseNullableTimeSpan(string input)
        {
            if (isBlank(input))
                return null;

            if (TimeSpan.TryParse(input, out TimeSpan output))
                return output;
            else
                return null;
        }

        [M(IL), P]
        static string Identity(string input)
            => input;
    }


}