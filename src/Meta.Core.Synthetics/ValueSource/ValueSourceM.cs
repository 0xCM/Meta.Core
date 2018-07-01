//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    public delegate V ValueSource<out V>();

    public delegate IEnumerable<V> ValuesSource<out V>();

    /// <summary>
    /// A <see cref="ValueSource{V}"/> monad
    /// </summary>
    public static class ValueSourceM
    {
        public static IEnumerable<T> Values<T>(this ValueSource<T> source)
            => from i in Enumerable.Range(0, int.MaxValue) select source();
        
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
