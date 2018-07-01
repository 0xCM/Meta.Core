//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    /// <summary>
    /// Imlementation of the Value monad
    /// </summary>
    public static class ValueM
    {

        /// <summary>
        /// Canonical select
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static Value<Y> Select<X, Y>(this Value<X> value, Func<X, Y> selector)
                => selector(value.Data);

        /// <summary>
        /// Canonical select many for LINQ integration
        /// </summary>
        /// <param name="f"></param>
        /// <param name="g"></param>
        /// <returns></returns>
        public static Value<Z> SelectMany<X, Y, Z>(this Value<X> value, Func<X, Value<Y>> f, Func<X, Y, Z> g)
            => f(value.Data).Select(y => g(value.Data, y));

    }


}