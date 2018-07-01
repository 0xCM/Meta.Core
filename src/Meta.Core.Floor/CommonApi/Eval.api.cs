//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Linq;

partial class metacore
{

    /// <summary>
    /// Maps a function over a set and returns a dictionary-based result
    /// </summary>
    /// <typeparam name="X">The function input type</typeparam>
    /// <typeparam name="Y">The function output type</typeparam>
    /// <param name="values">The values to be evaluated</param>
    /// <param name="f">The evaulator</param>
    /// <param name="PLL">Whether to evaulate concurrently</param>
    /// <returns></returns>
    public static IReadOnlyDictionary<X, Y> eval<X, Y>(IReadOnlySet<X> values, Func<X, Y> f, bool PLL = true)
    {
        if (PLL)
        {
            var data = new ConcurrentDictionary<X, Y>();
            values.AsParallel().ForAll(p => data[p] = f(p));
            return data;
        }
        else
            return dict(map(values, p => (p, f(p))));
    }



    /// <summary>
    /// Binds a function, the evaluator, to a value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="S"></typeparam>
    /// <param name="input"></param>
    /// <param name="evaluator"></param>
    /// <returns></returns>
    public static S eval<T, S>(T input, Func<T, S> evaluator)
        => evaluator(input);

    /// <summary>
    /// Non-order-preserving parallel evaluation
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="Y"></typeparam>
    /// <param name="items"></param>
    /// <param name="eval"></param>
    /// <param name="cancel"></param>
    /// <returns></returns>
    public static IReadOnlyList<Y> peval<X, Y>(IEnumerable<X> items, Func<X, Y> eval, Func<bool> cancel = null)
    {
        var results = new ConcurrentBag<Y>();
        cancel = cancel ?? (() => false);
        items.AsParallel().ForAll(item =>
        {
            if (!cancel())
                results.Add(eval(item));
        });
        return results.ToList();
    }


}