//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;

using Meta.Core;

partial class etude
{
    /// <summary>
    /// Retrieves an identified <see cref="IEq"/> instance
    /// </summary>
    /// <typeparam name="X">The type over which an equality is constructed</typeparam>
    /// <returns></returns>
    public static IEq<X> equality<X>()
        => Eq.make<X>();

    /// <summary>
    /// Returns true if two values are equal, false otherwise
    /// </summary>
    /// <typeparam name="X">The value type</typeparam>
    /// <param name="x1">The first value</param>
    /// <param name="x2">The second value</param>
    /// <returns></returns>
    public static bool eq<X>(X x1, X x2)
        => Eq.make<X>().eq(x1, x2);
}
