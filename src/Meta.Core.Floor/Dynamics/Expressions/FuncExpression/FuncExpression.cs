//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public static class FuncExpression
    {
        /// <summary>
        /// Produces a 0-argument func expression
        /// </summary>
        /// <typeparam name="X">The function return type</typeparam>
        /// <param name="f">The source function</param>
        /// <returns></returns>
        public static FuncExpression<X> make<X>(Func<X> f)
            => f;

        /// <summary>
        /// Produces a 1-argument func expression
        /// </summary>
        /// <typeparam name="X">The function argument type</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f">The source function</param>
        /// <returns></returns>
        public static FuncExpression<X,Y> make<X,Y>(Func<X,Y> f)
            => f;

        /// <summary>
        /// Produces a 2-argument func expression
        /// </summary>
        /// <typeparam name="X1">The type of the first argument</typeparam>
        /// <typeparam name="X2">The type of the second argument</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f">The source function</param>
        /// <returns></returns>
        public static FuncExpression<X1, X2, Y> make<X1, X2, Y>(Func<X1, X2, Y> f)
            => f;

        public static FuncExpression<X, X, X> make<X>(Func<X, X, X> f)
            => f;

        /// <summary>
        /// Produces a 2-argument func expression
        /// </summary>
        /// <typeparam name="X1">The type of the first argument</typeparam>
        /// <typeparam name="X2">The type of the second argument</typeparam>
        /// <typeparam name="X3">The type of the third argument</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f">The source function</param>
        /// <returns></returns>
        public static FuncExpression<X1, X2, X3, Y> make<X1, X2, X3, Y>(Func<X1, X2, X3, Y> f)
            => f;

    }


}