//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

public static class NullableExtensions
{
    public static S MapValueOrDefault<T, S>(this T? x, Func<T, S> f, S @default = default(S))
        where T : struct
    {
        if (x != null)
            return f(x.Value);
        else
            return @default;
    }

    public static S? TryMapValue<T, S>(this T? x, Func<T, S> f)
        where T : struct
        where S : struct
    {
        if (x != null)
            return f(x.Value);
        else
            return null;
    }

    public static S Map<T, S>(this T? x, Func<T, S> ifSome, Func<S> ifNone)
        where T : struct
    {
        if (x != null)
            return ifSome(x.Value);
        else
            return ifNone();
    }


    public static S MapValueOrElse<T, S>(this T? x, Func<T, S> f, Func<S> @else)
        where T : struct
    {
        if (x != null)
            return f(x.Value);
        else
            return @else();
    }

    public static T ValueOrElse<T>(this T? x,  Func<T> @else)
        where T : struct
    {
        if (x != null)
            return x.Value;
        else
            return @else();
    }

    public static T ValueOrElse<T>(this T? x, T @else)
        where T : struct
    {
        if (x != null)
            return x.Value;
        else
            return @else;
    }

    public static T ValueOrDefault<T>(this T? x, T @default = default)
        where T : struct
    {
        if (x != null)
            return x.Value;
        else
            return @default;
    }

    /// <summary>
    /// Transforms a nulluble value into an optional value
    /// </summary>
    /// <typeparam name="T">The underlying value type</typeparam>
    /// <param name="x">The potential value</param>
    /// <returns></returns>
    public static Option<T> ValueOrNone<T>(this T? x)
        where T : struct
    {
        if (x != null)
            return x.Value;
        else
            return Option.None<T>();
    }


    public static void OnValue<T>(this T? x, Action<T> action)
        where T : struct
    {
        if (x.HasValue)
            action(x.Value);
    }

    public static long ToLong(this Decimal? src)
        => (long)(src.ValueOrDefault(0));

    public static long? ToNullableLong(this Decimal? src)
        => src.HasValue ? (long)src.Value : (long?)null;

    public static int ToInt(this Decimal? src)
        => (int)(src.ValueOrDefault(0));

    public static int? ToNullableInt(this Decimal? src)
        => src.HasValue ? (int)src.Value : (int?)null;

}
