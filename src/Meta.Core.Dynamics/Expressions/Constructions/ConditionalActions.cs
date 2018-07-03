//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using static minicore;


    /// <summary>
    /// Defines helper methods for working with LINQ expressions
    /// </summary>
    public static class ConditionalActions
    {
        /// <summary>
        /// Tests whether an expression is a nullity operator
        /// </summary>
        /// <param name="x">The expression to examine</param>
        /// <returns></returns>
        public static bool IsNullityOperator(this Expression x)
            => x.TryGetNullityOperator().Exists;

        /// <summary>
        /// Extracts a nullity operator if detected
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static Option<INullityOperator> TryGetNullityOperator(this Expression X)
        {
            var no = none<INullityOperator>();
            var C = (X as BinaryExpression)?.Right as ConstantExpression;
            if (C != null && C.Value == null)
            {
                switch (X.NodeType)
                {
                    case ExpressionType.NotEqual:
                        return StandardOperators.IsNotNull;
                    case ExpressionType.Equal:
                        return StandardOperators.IsNull;
                }
            }
            return no;
        }

        /// <summary>
        /// Extracts a comparison operator if detected
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Option<IComparisonOperator> TryGetComparisonOperator(this Expression x)
        {
            var no = none<IComparisonOperator>();

            if (x.IsNullityOperator())
                return no;

            switch (x.NodeType)
            {
                case ExpressionType.NotEqual:
                    return StandardOperators.NotEqual;
                case ExpressionType.Equal:
                    return StandardOperators.Equal;
                case ExpressionType.GreaterThan:
                    return StandardOperators.GreaterThan;
                case ExpressionType.GreaterThanOrEqual:
                    return StandardOperators.GreaterThanOrEqual;
                case ExpressionType.LessThan:
                    return StandardOperators.LessThan;
                case ExpressionType.LessThanOrEqual:
                    return StandardOperators.LessThanOrEqual;
            }
            return no;
        }



        /// <summary>
        /// Invokes the supplied action if the expression is a conjunction and returns true in this case and otherwise false
        /// </summary>
        /// <param name="x">The expression to test</param>
        /// <param name="action">The action to conditionally invoke</param>
        /// <returns></returns>
        public static bool OnConjunction<X>(this X x, Action<X> action)
            where X : Expression
        {
            var conjunction = x.TryGetConjunction();
            if (conjunction)
            {
                conjunction.OnSome(action);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Invokes the supplied action if the expression is a comparision operator
        /// </summary>
        /// <param name="X">The expression to test</param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static bool OnComparisonOperator(this Expression X, Action<IComparisonOperator> action)
        {
            var C = X.TryGetComparisonOperator();
            if (C)
            {
                C.OnSome(action);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Invokes the supplied action if the expression is a nullity operator and returns true in this case and otherwise false
        /// </summary>
        /// <param name="x">The expression to examine</param>
        /// <param name="op">The operation to conditionally invoke</param>
        /// <returns></returns>
        public static bool OnNullityOperator(this Expression x, Action<INullityOperator> op)
        {
            var C = x.TryGetNullityOperator();
            if (C)
            {
                C.OnSome(op);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Invokes the supplied action if the expression is a disjunction and returns true in this case and otherwise false
        /// </summary>
        /// <param name="x">The expression to examine</param>
        /// <param name="action">The action to conditionally invoke</param>
        /// <returns></returns>
        public static bool OnDisjunction<X>(this X x, Action<X> action)
            where X : Expression
        {
            var D = x.TryGetDisjunction();
            if (D)
            {
                D.OnSome(action);
                return true;
            }
            else
                return false;
        }

    }


}