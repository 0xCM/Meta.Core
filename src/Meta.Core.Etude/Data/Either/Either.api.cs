//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using Meta.Core;
using static metacore;

partial class etude
{
    /// <summary>
    /// Determines whether the either is left-valued
    /// </summary>
    /// <typeparam name="L">The left type</typeparam>
    /// <typeparam name="R">The right type</typeparam>
    /// <param name="e">The value to examine</param>
    /// <returns></returns>
    public static bool isLeft<L, R>(Either<L, R> e)
        => e.IsLeft;

    /// <summary>
    /// Determines whether the either is right-valued
    /// </summary>
    /// <typeparam name="L">The left type</typeparam>
    /// <typeparam name="R">The right type</typeparam>
    /// <param name="e">The value to examine</param>
    /// <returns></returns>
    public static bool isRight<L, R>(Either<L, R> e)
        => e.IsRight;

    /// <summary>
    /// If either is Left, returns the left value; oterwise, raises an error
    /// </summary>
    /// <typeparam name="L">The left type</typeparam>
    /// <typeparam name="R">The right type</typeparam>
    /// <param name="e"></param>
    /// <returns></returns>
    public static L left<L, R>(Either<L, R> e)
        => e.IsLeft ? e.Left : fail<L>(NotLeft(e));

    /// <summary>
    /// If either is Left, returns the left value; oterwise, raises an error
    /// </summary>
    /// <typeparam name="L">The left type</typeparam>
    /// <typeparam name="R">The right type</typeparam>
    /// <param name="e"></param>
    /// <returns></returns>
    public static R right<L, R>(Either<L, R> e)
        => e.IsRight ? e.Right : fail<R>(NotRight(e));


}
