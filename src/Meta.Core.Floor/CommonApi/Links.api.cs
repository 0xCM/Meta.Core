//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using Meta.Core;

partial class metacore
{
    /// <summary>
    /// Creates a directed link from a source to a target
    /// </summary>
    /// <typeparam name="X">The source item type</typeparam>
    /// <typeparam name="Y">The target item type</typeparam>
    /// <param name="x">The source item</param>
    /// <param name="y">The target item</param>
    /// <returns></returns>
    public static Link<X, Y> link<X, Y>(X x, Y y)
        => new Link<X, Y>(x, y);

    /// <summary>
    /// Creates a chain from the first link to the second
    /// </summary>
    /// <typeparam name="X">The head source type</typeparam>
    /// <typeparam name="Y">The head's target type anad the tail's source type</typeparam>
    /// <typeparam name="Z">The tail's target type</typeparam>
    /// <param name="head">The first link</param>
    /// <param name="tail">The second link</param>
    /// <returns></returns>
    public static Chain<X, Y, Z> chain<X, Y, Z>(Link<X, Y> head, Link<Y, Z> tail)
        => (Chain<X, Y, Z>)(head, tail);
}