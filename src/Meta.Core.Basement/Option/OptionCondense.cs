//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

public static class OptionCondense
{
    public static Option<int> Condense<T>(this Option<IReadOnlyList<Option<T>>> option)
    {
        if (option.IsSome())
            return Condense(option.ValueOrDefault());
        else
            return option.ToNone<int>();
    }

    public static Option<int> Condense<T>(this Option<ReadOnlyList<Option<T>>> option)
    {
        if (option.IsSome())
            return Condense(option.ValueOrDefault());
        else
            return option.ToNone<int>();
    }

    public static Option<int> Condense<T>(this IEnumerable<Option<T>> options)
    {
        var failure = options.Any(o => o.IsNone());
        if (failure)
            return options.First(x => x.IsNone()).ToNone<int>();
        return options.Count();
    }

    public static Option<int> Condense<T>(this Option<IEnumerable<Option<T>>> option)
    {
        if (option.IsSome())
            return Condense(option.ValueOrDefault());
        else
            return option.ToNone<int>();
    }

    public static Option<int> Condense<T>(this IReadOnlyList<Option<T>> options)
    {
        var failure = options.Any(o => o.IsNone());
        if (failure)
            return options.First(x => x.IsNone()).ToNone<int>();
        return options.Count;
    }

    public static Option<int> Condense<T>(this ReadOnlyList<Option<T>> options)
    {
        var failure = options.Any(o => o.IsNone());
        if (failure)
            return options.First(x => x.IsNone()).ToNone<int>();
        return options.Count;
    }


}
