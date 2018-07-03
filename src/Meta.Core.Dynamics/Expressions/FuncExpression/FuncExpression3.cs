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

    /// <summary>
    /// Encapsulates a delegate that is transformed into a linq expression when extracted
    /// </summary>
    /// <typeparam name="X1">The type of the first argument</typeparam>
    /// <typeparam name="X2">The type of the second argument</typeparam>
    /// <typeparam name="X3">The type of the third argument</typeparam>
    /// <typeparam name="Y">The function return type</typeparam>
    public readonly struct FuncExpression<X1, X2, X3, Y>
    {
        /// <summary>
        /// Implicitly converts a func expression to linq expression
        /// </summary>
        /// <param name="fx">The source func expression</param>
        public static implicit operator Expression<Func<X1, X2, X3, Y>>(FuncExpression<X1, X2, X3, Y> fx)
            => fx.Fx;

        /// <summary>
        /// Implicitly constructs a func expression from a func
        /// </summary>
        /// <param name="f">The source function</param>
        public static implicit operator FuncExpression<X1, X2, X3, Y>(Func<X1, X2, X3, Y> f)
            => new FuncExpression<X1, X2, X3, Y>(f);

        public FuncExpression(Func<X1, X2, X3, Y> f)
            => this.Fx = (x1, x2, x3) => f(x1, x2, x3);

        /// <summary>
        /// The expression derived from the source function
        /// </summary>
        public Expression<Func<X1, X2, X3, Y>> Fx { get; }

    }


}