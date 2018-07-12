//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{

    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;


    /// <summary>
    /// Implements monadic operators and other utilities 
    /// </summary>
    public class LinqMonad 
    {
        
        /// <summary>
        /// Projects, or lifts, a value from a base space X to its monadic X-Space, M(X)
        /// </summary>
        /// <param name="x">The value to lift</param>
        public static IMonad<X> pure<X>(X x)
            => LinqMonad<X>.Default.pure(x);

        public static LinqMonad<Y> bind<X, Y>(LinqMonad<X> mx, Func<X, LinqMonad<Y>> f)
            => f((X)mx);

        public static LinqMonad<Z> bind<X, Y, Z>(LinqMonad<X> mx, Func<X, LinqMonad<Y>> f, Func<X, Y, Z> compose)
            => bind<Y, Z>(f((X)mx), y => compose((X)mx, y));

        public static LinqMonad<Y> fmap<X, Y>(LinqMonad<X> mx, Func<X, Y> f)
            => f((X)mx);

        /// <summary>
        /// Drops a doubly-monadic value into the base space
        /// </summary>
        /// <typeparam name="X">The base space</typeparam>
        /// <param name="x"></param>
        /// <returns></returns>
        /// <remarks>
        /// This effectively represents a duality operator, that establishes a vector space
        /// isomorphism between a space and the double-dual: the dual of a dual value is just
        /// the original value
        /// </remarks>
        public static X dual<X>(LinqMonad<LinqMonad<X>> x)
            => (X)((LinqMonad<X>)x);

    }
}
