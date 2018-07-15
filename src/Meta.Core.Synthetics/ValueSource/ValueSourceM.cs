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

    using static minicore;

    public delegate V ValueSource<out V>();

    
    

    public delegate IEnumerable<V> ValuesSource<out V>();


    /// <summary>
    /// A <see cref="ValueSource{V}"/> monad
    /// </summary>
    public static class ValueSourceM
    {
        static IEnumerable<T> forever<T>(ValueSource<T> source)
        {
            while (true)
                yield return source();

        }

        /// <summary>
        /// Manufactures a pseudoinfinite stream of values
        /// </summary>
        /// <typeparam name="T">The value type</typeparam>
        /// <param name="source">The value source</param>
        /// <returns></returns>
        public static Seq<T> Values<T>(this ValueSource<T> source)
            => Modules.Seq.make(forever(source), Cardinality.Infinite);

        /// <summary>
        /// Manufactures a specified number of values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static Lst<T> Values<T>(this ValueSource<T> source, int count)
            => Modules.Lst.make(from i in Enumerable.Range(1, count) select source());

        public static ValuesSource<Z> Lift<Z>(Z z) 
            => () => array(z);

        public static ValuesSource<Y> Bind<X, Y>(this ValuesSource<X> source, 
            Func<IEnumerable<X>, ValuesSource<Y>> f)  
                => f(source());

        public static ValuesSource<Y> Select<X, Y>(this ValuesSource<X> source, 
            Func<IEnumerable<X>, IEnumerable<Y>> selector)
                => () => selector(source());

        public static ValuesSource<Z> SelectMany<X, Y, Z>(this ValuesSource<X> source, 
            Func<IEnumerable<X>, ValuesSource<Y>> select, Func<IEnumerable<X>, IEnumerable<Y>, Z> project) 
                => source.Bind(x => select(x).Bind(y => Lift(project(x, y))));
    }
}
