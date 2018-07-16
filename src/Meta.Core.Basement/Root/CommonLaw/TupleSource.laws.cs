//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;


    /// <summary>
    /// Elemental 2-tuple producer
    /// </summary>
    /// <typeparam name="X1">The type of value produced for the first coordinate</typeparam>
    /// <typeparam name="X2">The type of value produced for the second coordinate</typeparam>
    /// <returns></returns>
    public delegate IEnumerable<(X1 x1, X2 x2)> TupleSource<X1, X2>();

    /// <summary>
    /// Elemental 3-tuple producer
    /// </summary>
    /// <typeparam name="X1">The type of value produced for the first coordinate</typeparam>
    /// <typeparam name="X2">The type of value produced for the second coordinate</typeparam>
    /// <typeparam name="X3">The type of value produced for the third coordinate</typeparam>
    /// <returns></returns>
    public delegate IEnumerable<(X1 x2, X2 X2, X3 x3)> TupleSource<X1, X2, X3>();

    /// <summary>
    /// Elemental 4-tuple producer
    /// </summary>
    /// <typeparam name="X1">The type of value produced for the first coordinate</typeparam>
    /// <typeparam name="X2">The type of value produced for the second coordinate</typeparam>
    /// <typeparam name="X3">The type of value produced for the third coordinate</typeparam>
    /// <typeparam name="X4">The type of value produced for the fourth coordinate</typeparam>
    /// <returns></returns>
    public delegate IEnumerable<(X1 x2, X2 X2, X3 x3, X4 x4)> TupleSource<X1, X2, X3, X4>();

    /// <summary>
    /// Elemental 5-tuple producer
    /// </summary>
    /// <typeparam name="X1">The type of value produced for the first coordinate</typeparam>
    /// <typeparam name="X2">The type of value produced for the second coordinate</typeparam>
    /// <typeparam name="X3">The type of value produced for the third coordinate</typeparam>
    /// <typeparam name="X4">The type of value produced for the fourth coordinate</typeparam>
    /// <typeparam name="X5">The type of value produced for the fifth coordinate</typeparam>
    /// <returns></returns>
    public delegate IEnumerable<(X1 x2, X2 X2, X3 x3, X4 x4, X5 x5)> TupleSource<X1, X2, X3, X4, X5>();

    /// <summary>
    /// Elemental 6-tuple producer
    /// </summary>
    /// <typeparam name="X1">The type of value produced for the first coordinate</typeparam>
    /// <typeparam name="X2">The type of value produced for the second coordinate</typeparam>
    /// <typeparam name="X3">The type of value produced for the third coordinate</typeparam>
    /// <typeparam name="X4">The type of value produced for the fourth coordinate</typeparam>
    /// <typeparam name="X5">The type of value produced for the fifth coordinate</typeparam>
    /// <typeparam name="X6">The type of value produced for the sixth coordinate</typeparam>
    /// <returns></returns>
    public delegate IEnumerable<(X1 x2, X2 X2, X3 x3, X4 x4, X5 x5, X6 x6)> TupleSource<X1, X2, X3, X4, X5, X6>();


}