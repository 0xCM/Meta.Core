//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;

    

    using static metacore;

    public class Function : TypeModule<Function>
    {
        /// <summary>
        /// Constructs a function from a from a delegate of type X->Y
        /// </summary>
        /// <typeparam name="X">The input type</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f">The delegate to lift</param>
        /// <returns></returns>
        public static Function<X, Y> make<X, Y>(Func<X, Y> f)
            => new Function<X, Y>(f);

        /// <summary>
        /// Constructs a function from a from a delegate of type X1->X2->Y
        /// </summary>
        /// <typeparam name="X1">The type of the first input parameter</typeparam>
        /// <typeparam name="X2">The type of the second input parameter</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f">The delegate to lift</param>
        /// <returns></returns>
        public static Function<X1, X2, Y> make<X1, X2, Y>(Func<X1, X2, Y> f)
            => new Function<X1, X2, Y>(f);

        /// <summary>
        /// Constructs a function from a from a delegate of type X1->X2->X3->Y
        /// </summary>
        /// <typeparam name="X1">The type of the first parameter</typeparam>
        /// <typeparam name="X2">The type of the second parameter</typeparam>
        /// <typeparam name="X3">The type of the third parameter</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f">The delegate to lift</param>
        /// <returns></returns>
        public static Function<X1, X2, X3, Y> make<X1, X2, X3, Y>(Func<X1, X2, X3, Y> f)
            => new Function<X1, X2, X3, Y>(f);

        /// <summary>
        /// Lifts a delegate to a Function value
        /// </summary>
        /// <typeparam name="X1">The type of the first parameter</typeparam>
        /// <typeparam name="X2">The type of the second parameter</typeparam>
        /// <typeparam name="X3">The type of the third parameter</typeparam>
        /// <typeparam name="X4">The type of the fourth parameter</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f">The delegate to lift</param>
        /// <returns></returns>
        public static Function<X1, X2, X3, X4, Y> make<X1, X2, X3, X4, Y>(Func<X1, X2, X3, X4, Y> f)
            => new Function<X1, X2, X3, X4, Y>(f);

        /// <summary>
        /// Extracts the encapsulated delegate
        /// </summary>
        /// <typeparam name="X">The input type</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f">The function encapsulating the delegate</param>
        /// <returns></returns>
        public static Func<X, Y> value<X, Y>(Function<X, Y> f)
            => x => f.Eval(x);

        /// <summary>
        /// Extracts the encapsulated delegate
        /// </summary>
        /// <typeparam name="X1">The first input type</typeparam>
        /// <typeparam name="X2">The second input type</typeparam>
        /// <typeparam name="Y">The output type</typeparam>
        /// <param name="f">The function encapsulating the delegate</param>
        /// <returns></returns>
        public static Func<X1, X2, Y> value<X1, X2, Y>(Function<X1, X2, Y> f)
            => (x1, x2) => (x1, x2) > f;

        /// <summary>
        /// Extracts the encapsulated delegate
        /// </summary>
        /// <typeparam name="X1">The type of the first parameter</typeparam>
        /// <typeparam name="X2">The type of the second parameter</typeparam>
        /// <typeparam name="X3">The type of the third parameter</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f">The function</param>
        /// <returns></returns>
        public static Func<X1, X2, X3, Y> value<X1, X2, X3, Y>(Function<X1, X2, X3, Y> f)
            => (x1, x2, x3) => (x1, x2, x3) >f;

        /// <summary>
        /// Transforms a lifted Function back to its canonical/original system form
        /// </summary>
        /// <typeparam name="X1">The type of the first parameter</typeparam>
        /// <typeparam name="X2">The type of the second parameter</typeparam>
        /// <typeparam name="X3">The type of the third parameter</typeparam>
        /// <typeparam name="X4">The type of the fourth parameter</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f">The function</param>
        /// <returns></returns>
        public static Func<X1, X2, X3, X4, Y> value<X1, X2, X3, X4, Y>(Function<X1, X2, X3, X4, Y> f)
            => (x1, x2, x3, x4) => (x1, x2, x3, x4) > f;

        /// <summary>
        /// Defines a composition h:X->Z from functions f:X-Y and g:Y-Z
        /// </summary>
        /// <typeparam name="X1"></typeparam>
        /// <typeparam name="X2"></typeparam>
        /// <typeparam name="X3"></typeparam>
        /// <param name="f"></param>
        /// <param name="g"></param>
        /// <returns></returns>
        public static Function<X1, X3> compose<X1, X2, X3>(Function<X1, X2> f, Function<X2, X3> g)
            => new Function<X1, X3>(x1 => x1 > f > g);

        //=> new Function<X1, X3>(x => g(f(x)));

        /// <summary>
        /// Defines a composition g:X1->X4 via binary compositions X1->X2->X3->X4
        /// </summary>
        /// <typeparam name="X1">The domain of f1</typeparam>
        /// <typeparam name="X2">The codomain of f1 and the domain of f2</typeparam>
        /// <typeparam name="X3">The codomain of f2 and the domain of f3</typeparam>
        /// <typeparam name="X4">The codomain of f3</typeparam>
        /// <param name="f1">The first function</param>
        /// <param name="f2">The second function</param>
        /// <param name="f3">The third function</param>
        /// <returns></returns>
        public static Function<X1, X4> compose<X1, X2, X3, X4>(Function<X1, X2> f1, Function<X2, X3> f2, Function<X3, X4> f3)
            => new Function<X1, X4>(x => x > f1 > f2 > f3);

        /// <summary>
        /// Evaluates f(x)
        /// </summary>
        /// <typeparam name="X">The function domain type</typeparam>
        /// <typeparam name="Y">The function codomain</typeparam>
        /// <param name="f">The function</param>
        /// <param name="x">The point of evaluation</param>
        /// <returns></returns>
        public static Y eval<X, Y>(Function<X, Y> f, X x)
            => x > f;

        /// <summary>
        /// Lazily evaluate the function over a sequence
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <param name="values">The value over which evaluation will occur</param>
        /// <returns></returns>
        public static Seq<Y> eval<X, Y>(Function<X, Y> f, Seq<X> values)
            => Seq.map(f.F, values);

        /// <summary>
        /// Eagerly evaluates the function over a list
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <param name="values">The values over which evaluation will occur</param>
        /// <returns></returns>
        public static Lst<Y> eval<X, Y>(Function<X, Y> f, Lst<X> values)
            => Lst.map(f.F, values);

        /// <summary>
        /// Evaluates f(x1,x2,x3)
        /// </summary>
        /// <typeparam name="X1">The type of the first argument</typeparam>
        /// <typeparam name="X2">The type of the second argument</typeparam>
        /// <typeparam name="X3">The type of the third argument</typeparam>
        /// <typeparam name="Y">The function codomain</typeparam>
        /// <param name="f">The function</param>
        /// <param name="x1">The first argument</param>
        /// <param name="x2">The second argument</param>
        /// <param name="x3">The third argument</param>
        /// <returns></returns>
        public static Y eval<X1, X2, X3, Y>(Function<X1, X2, X3, Y> f, X1 x1, X2 x2, X3 x3)
            => (x1,x2,x3) > f;

        /// <summary>
        /// Evaluates f(x1,x2)
        /// </summary>
        /// <typeparam name="X1">The type of the first argument</typeparam>
        /// <typeparam name="X2">The type of the second argument</typeparam>
        /// <typeparam name="Y">The function codomain</typeparam>
        /// <param name="f">The function</param>
        /// <param name="x1">The first argument</param>
        /// <param name="x2">The second argument</param>
        /// <returns></returns>
        public static Y eval<X1, X2, Y>(Function<X1, X2, Y> f, X1 x1, X2 x2)
            => (x1, x2) > f;

        /// <summary>
        /// Evaluates f(x1,x2,x3)
        /// </summary>
        /// <typeparam name="X1">The type of the first argument</typeparam>
        /// <typeparam name="X2">The type of the second argument</typeparam>
        /// <typeparam name="X3">The type of the third argument</typeparam>
        /// <typeparam name="X4">The type of the fourth argument</typeparam>
        /// <typeparam name="Y">The function codomain</typeparam>
        /// <param name="f">The function</param>
        /// <param name="x1">The first argument</param>
        /// <param name="x2">The second argument</param>
        /// <param name="x3">The third argument</param>
        /// <param name="x4">The fourth argument</param>
        /// <returns></returns>
        public static Y eval<X1, X2, X3, X4, Y>(Function<X1, X2, X3, X4, Y> f, X1 x1, X2 x2, X3 x3, X4 x4)
            => f.Eval(x1, x2, x3, x4);


        /// <summary>
        /// Renders a function to a canonical display format
        /// </summary>
        /// <typeparam name="X">The first argument type</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f">The function to format</param>
        /// <returns></returns>
        public static string format<X, Y>(Function<X, Y> f)
            => format(types<X, Y>());

        /// <summary>
        /// Renders a function to a canonical display format
        /// </summary>
        /// <typeparam name="X1">The first argument type</typeparam>
        /// <typeparam name="X2">The second argument type</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f">The function to format</param>
        /// <returns></returns>
        public static string format<X1, X2, Y>(Function<X1, X2, Y> f)
            => format(types<X1, X2, Y>());

        /// <summary>
        /// Renders a function to a canonical display format
        /// </summary>
        /// <typeparam name="X1">The first argument type</typeparam>
        /// <typeparam name="X2">The second argument type</typeparam>
        /// <typeparam name="X3">The third argument type</typeparam>
        /// <typeparam name="X4">The fourth argument type</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f">The function to format</param>
        /// <returns></returns>
        public static string format<X1, X2, X3, X4, Y>(Function<X1, X2, X3, X4, Y> f)
            => format(types<X1, X2, X3, X4, Y>());

        /// <summary>
        /// Renders a function to a canonical display format
        /// </summary>
        /// <typeparam name="X1">The first argument type</typeparam>
        /// <typeparam name="X2">The second argument type</typeparam>
        /// <typeparam name="X3">The third argument type</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f">The function to format</param>
        /// <returns></returns>
        public static string format<X1, X2, X3, Y>(Function<X1, X2, X3, Y> f)
            => format(types<X1, X2, X3, Y>());

        /// <summary>
        /// Creates a new predicate by negating an existing predicate
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="p">The predicate to negate</param>
        /// <returns></returns>
        public static Function<X, bool> not<X>(Func<X, bool> p)
            => make((X x) => !p(x));

        /// <summary>
        /// Creates a new predicate by taking the logical and of two existing pedicates
        /// </summary>
        /// <typeparam name="X">The test value type</typeparam>
        /// <param name="left">The left predicate</param>
        /// <param name="right">The right predicate</param>
        /// <returns></returns>
        public static Function<X, bool> and<X>(Func<X, bool> left, Func<X, bool> right)
            => make((X x) => left(x) && right(x));

        /// <summary>
        /// Creates a new predicate by taking the logical or of two existing pedicates
        /// </summary>
        /// <typeparam name="X">The test value type</typeparam>
        /// <param name="left">The left predicate</param>
        /// <param name="right">The right predicate</param>
        /// <returns></returns>
        public static Function<X, bool> or<X>(Func<X, bool> left, Func<X, bool> right)
            => make((X a) => left(a) || right(a));

        /// <summary>
        /// Helper to format signatures for an arbitrary number of arguments/types
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        static string format(params ClrType[] types)
            => Lst.foldl((x1, x2) => x1 + x2, string.Empty,
                    Lst.intersperse(" -> ",
                        Lst.make(array(types, t => t.Name))));

    }
}