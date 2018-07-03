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
    /// Constructs a <see cref="SemigroupOp{X}"/> value
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <param name="x"></param>
    /// <returns></returns>
    public static SemigroupOp<X> sum<X>(X x)
        => new SemigroupOp<X>(x);

}
