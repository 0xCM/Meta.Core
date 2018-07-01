//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using static Option;

public static class OptionMap
{
    public static Y MapValue<X, Y>(this Option<X> x, Func<X, Y> F)
        => F(x.Require());

    public static IEnumerable<Y> MapValues<X, Y>(this Option<IEnumerable<X>> values, Func<X, Y> F)
        => values.Items().Select(F);

    public static Option<ReadOnlyList<Y>> TryMapList<X, Y>(this Option<IReadOnlyList<X>> x, Func<X, Y> f)
        => from l in x
           let y = l.Select(item => f(item))
           select y.ToReadOnlyList();

    public static IEnumerable<Option<Y>> TryMapItems<X, Y>(this IEnumerable<X> src, Func<X, Option<Y>> f)
        => from item in src
           select f(item);

    public static IEnumerable<Option<Y>> TryMapItems<X, Y>(this IEnumerable<Option<X>> src, Func<Option<X>, Option<Y>> f)
        => from item in src
           select f(item);

    public static Option<IEnumerable<Y>> TryMapValues<X, Y>(this Option<IEnumerable<X>> values, Func<X, Y> F)
        => values.IsSome() ? Some(values.Items().Select(F)) : values.ToNone<IEnumerable<Y>>();

    public static Option<ReadOnlyList<Y>> TryMapValues<X, Y>(this Option<IReadOnlyList<X>> x, Func<X, Y> f)
        => x.IsSome() ? Some((~x).Map(f)) : None<ReadOnlyList<Y>>(x.Message);

    public static Option<ReadOnlyList<Y>> TryMapValues<X, Y>(this Option<ReadOnlyList<X>> x, Func<X, Y> f)
        => x.IsSome() ? Some((~x).Map(f)) : None<ReadOnlyList<Y>>(x.Message);

    public static Option<ReadOnlyList<TDst>> TryMapItems<TSrc, TDst>(this Option<IEnumerable<TSrc>> src, Func<TSrc, TDst> f)
        => src.Map(seq => seq.Map(f));

    public static ReadOnlyList<TDst> MapItems<TSrc, TDst>(this Option<IEnumerable<TSrc>> src, Func<TSrc, TDst> f)
        => ~src.Map(seq => seq.Map(f));

    public static Option<Y> TryMapValue<X, Y>(this Option<X> x, Func<X, Y> f,
        Func<X, IApplicationMessage> success,
        Func<IApplicationMessage> failure = null)
    {
        if (x.IsSome())
        {
            var v = x.ValueOrDefault();
            var y = f(v);
            return Some(y, success(v));
        }
        else
            return None<Y>(failure?.Invoke() ?? x.Message);
    }
}
