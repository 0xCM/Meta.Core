//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{

    using System;
    using System.Linq;

    public static class LinqMonadX
    {
        /// <summary>
        /// Drops a value from monadic X-space to its base, applies a selection function F:X->Y that yields
        /// a point y in the base space Y and finally lifts the point y to m(y) in monadic Y-space M(Y)
        /// </summary>
        /// <typeparam name="X">The domain of the selector</typeparam>
        /// <typeparam name="Y">The range of the selector</typeparam>
        /// <param name="selector">The function to apply</param>
        /// <returns>A point in M(Y) that originated in M(X)</returns>
        public static LinqMonad<Y> Select<X, Y>(this LinqMonad<X> mx, Func<X, Y> selector)
            => LinqMonad.fmap(mx, selector);

        /// <summary>
        /// Binds a value in monadic space M(X) to a function that carries a value
        /// from the base space X into the monadic space M(Y)
        /// </summary>
        /// <typeparam name="X">The base space for the function domain</typeparam>
        /// <typeparam name="Y">The base space for the function codomain</typeparam>
        /// <returns>A point in M(Y) that originated in M(X)</returns>
        public static LinqMonad<Y> Bind<X, Y>(this LinqMonad<X> mx, Func<X, LinqMonad<Y>> f)
            => LinqMonad.bind(mx, f);

        /// <summary>
        /// 1. Drops a point x from monadic X-space to the base
        /// 2. Applies a selector to x which yields a value m(y) that lives in monadic Y-space 
        /// 3. Binds the point m(y) to a function F:X x Y -> Z that is evaluated over the point (x,y) to yield a point in Z
        /// 4. Finally, lifts the point z into monadic Z-space 
        /// </summary>
        /// <typeparam name="X">The domain of the selector</typeparam>
        /// <typeparam name="Y">The base space for the range of the selector</typeparam>
        /// <typeparam name="Z">The domain for the projector</typeparam>
        /// <param name="select">The selection function</param>
        /// <param name="project">The projection function</param>
        /// <returns>A point in M(Z) that originated in M(X)</returns>
        public static LinqMonad<Z> SelectMany<X, Y, Z>(this LinqMonad<X> mx, Func<X, LinqMonad<Y>> select, Func<X, Y, Z> project)
            => LinqMonad.bind<Y, Z>(select((X)mx), y => project((X)mx, y));

    }



}