//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Linq.Expressions;

    using XPR = System.Linq.Expressions.Expression;

    public static class ExpressionFactories
    {
        /// <summary>
        /// Creates an expression that defines a function that returns true
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> True<T>()
            => f => true;

        /// <summary>
        /// Creates an expression that defines a function that returns false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> False<T>()
            => f => false;

        /// <summary>
        /// Creates an expression that defines a logical OR function
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            var invokedExpr = XPR.Invoke(right, left.Parameters.Cast<XPR>());
            return XPR.Lambda<Func<T, bool>>
                  (XPR.OrElse(left.Body, invokedExpr), left.Parameters);
        }
       
        /// <summary>
        /// Creates an expression that defines a logical AND function
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            var invokedExpr = XPR.Invoke(right, left.Parameters.Cast<XPR>());
            return XPR.Lambda<Func<T, bool>>
                  (XPR.AndAlso(left.Body, invokedExpr), left.Parameters);
        }

        /// <summary>
        /// Creates an expression tha defines an equality comparison
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Expression<Func<bool>> Equal<X>(this Expression<Func<X>> left, Expression<Func<X>> right)
        {
            var lValue = XPR.Invoke(left);
            var rValue = XPR.Invoke(right);
            return XPR.Lambda<Func<bool>>(XPR.Equal(lValue, rValue));
        }
    }
}