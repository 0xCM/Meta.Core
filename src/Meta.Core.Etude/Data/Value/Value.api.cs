//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using Meta.Core;


partial class etude
{
    /// <summary>
    /// Lifts content into the <see cref="Value{X}"/> monad
    /// </summary>
    /// <typeparam name="X">The content type</typeparam>
    /// <param name="x">The content</param>
    /// <returns></returns>
    public static Value<X> value<X>(X x)
        => x;

    /// <summary>
    /// Lifts content into a Value monad over (X1,X2)
    /// </summary>
    /// <returns></returns>
    public static Value<(X1 x1, X2 x2)> value<X1, X2>(X1 x1, X2 x2)
        => (x1, x2);

    /// <summary>
    /// Lifts content into a Value monad over (X1,X2,X3)
    /// </summary>
    /// <returns></returns>
    public static Value<(X1 x1, X2 x2, X3 x3)> value<X1, X2, X3>(X1 x1, X2 x2, X3 x3)
        => (x1, x2, x3);

    /// <summary>
    /// Transforms a collection of (X1,X2) values into a Sequence of (X1,X2) values
    /// </summary>
    /// <returns></returns>
    public static Seq<Value<(X1 x1, X2 x2)>> values<X1, X2>(params (X1 x1, X2 x2)[] items)
        => Seq.make(items.Select(Value.make));

    /// <summary>
    /// Transforms an enumerable over X into a Value sequence
    /// </summary>
    /// <returns></returns>
    public static Seq<Value<X>> values<X>(IEnumerable<X> items)
        => Seq.make(items.Select(Value.make));

    /// <summary>
    /// Applies f under the Value consturctor as usual
    /// </summary>
    /// <typeparam name="X">The value input type</typeparam>
    /// <typeparam name="Y">The value output type</typeparam>
    /// <param name="x"></param>
    /// <param name="f"></param>
    /// <returns></returns>
    public static Value<Y> map<X, Y>(Value<X> x, Func<X, Y> f)
        => f(x);
}
