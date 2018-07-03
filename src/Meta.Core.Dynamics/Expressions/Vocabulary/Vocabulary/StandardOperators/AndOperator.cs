//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using static minicore;
    using static express;

    /// <summary>
    /// Represents the logical and operator
    /// </summary>
    public sealed class AndOperator : BinaryOperator<AndOperator>, ILogicalOperator
    {
        /// <summary>
        /// Defines a function that will evaluate two predicates return true
        /// if both evaluations are true; otherwise, returns false
        /// </summary>
        /// <typeparam name="X1">The input type for the first predicate</typeparam>
        /// <typeparam name="X2">The input type for the second predicate</typeparam>
        /// <param name="p1">The first predicate</param>
        /// <param name="p2">The second predicate</param>
        /// <returns></returns>
        public static Option<Func<X1, X2, bool>> apply<X1, X2>(Func<X1, bool> p1, Func<X2, bool> p2)
            => from args in some((x1: paramX(typeof(X1), "x1"), x2: paramX(typeof(X2), "x2")))
               from p1Invoke in some(Expression.Invoke(funcx(p1), args.x1))
               from p2Invoke in some(Expression.Invoke(funcx(p2), args.x2))
               let body = Expression.AndAlso(p1Invoke, p2Invoke)
               select lambda<Func<X1, X2, bool>>(args, body).Compile();


        public AndOperator()
            : base("and", "&&")
        {

        }
    }
}