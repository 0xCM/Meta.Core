//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Reflection;

using static metacore;

using Meta.Core;
using Meta.Core.Modules;

using static tuple;
public static partial class TupleExtensions
{
    /// <summary>
    /// Converts an homogeneous tuple of one type to another
    /// </summary>
    /// <typeparam name="X">The source item type</typeparam>
    /// <typeparam name="Y">The target item type</typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static (Y y1, Y y2) Convert<X,Y>(this (X x1, X x2) source)
        => (convert<Y>(source.x1), convert<Y>(source.x2));

    /// <summary>
    /// Converts an homogeneous tuple of one type to another
    /// </summary>
    /// <typeparam name="X">The source item type</typeparam>
    /// <typeparam name="Y">The target item type</typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static (Y y1, Y y2, Y y3) Convert<X, Y>(this (X x1, X x2, X x3) source)
        => (convert<Y>(source.x1), convert<Y>(source.x2), convert<Y>(source.x3));

}