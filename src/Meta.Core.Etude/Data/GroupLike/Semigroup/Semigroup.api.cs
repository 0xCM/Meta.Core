//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;

partial class etude
{
    /// <summary>
    /// Combines the values in a list using a semigroup combinator
    /// </summary>
    /// <typeparam name="X">The value type</typeparam>
    /// <param name="g"></param>
    /// <param name="list"></param>
    /// <returns></returns>
    public static X combine<X>(ISemigroup<X> g, Lst<X> list)
        => Lst.combine(g.combine, list);
}