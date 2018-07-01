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
    /// <typeparam name="X">The function argument type</typeparam>
    /// <typeparam name="Y">The function return type</typeparam>
    public readonly struct FuncExpression<X, Y>
    {
        /// <summary>
        /// Implicitly converts a func expression to linq expression
        /// </summary>
        /// <param name="fx">The source func expression</param>
        public static implicit operator Expression<Func<X, Y>>(FuncExpression<X, Y> fx)
            => fx.Fx;

        /// <summary>
        /// Implicitly constructs a func expression from a func
        /// </summary>
        /// <param name="f">The source function</param>
        public static implicit operator FuncExpression<X, Y>(Func<X, Y> f)
            => new FuncExpression<X, Y>(f);

        public FuncExpression(Func<X, Y> f)
            => this.Fx = x => f(x);

        /// <summary>
        /// The expression derived from the source function
        /// </summary>
        public Expression<Func<X, Y>> Fx { get; }

    }


}