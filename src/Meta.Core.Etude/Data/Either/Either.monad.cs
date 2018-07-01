//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;

    /// <summary>
    /// Implements the right-biased <see cref="Either{L, R}"/> LINQ monad
    /// </summary>
    public static class EitherM
    {
        public static Either<L, Y> Select<L, R, Y>(this Either<L, R> value, Func<R, Either<L, Y>> selector)
                => value.IsRight ? selector(value.Right) : new Either<L, Y>(value.Left);

        public static Either<L, Z> SelectMany<L,R,Y,Z>(this Either<L,R> value, Func<R, Either<L, Y>> selector, Func<R, Y, Z> projector)
        {
            if (value.IsLeft)
                return new Either<L, Z>(value.Left);
            var selected = value.Select(selector);

            if (selected.IsLeft)
                return new Either<L, Z>(selected.Left);
            else
                return selected.Select(y => new Either<L, Z>(projector(value.Right, selected.Right)));
        }
    }
}