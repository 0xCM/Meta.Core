//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

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
}