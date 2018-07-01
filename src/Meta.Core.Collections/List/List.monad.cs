//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using Modules;

    /// <summary>
    /// Defines the canonical see <see cref="List{X}"/> monad for LINQ integration
    /// </summary>
    public static class ListM
    {

        public static List<Y> Select<X, Y>(this List<X> list, Func<X, Y> selector)
             => List.make(from x in list.Stream() select selector(x));

        public static List<Z> SelectMany<X, Y, Z>(this List<X> list, Func<X, List<Y>> lift, Func<X, Y, Z> project)
            => List.make(from x in list.Stream()
                         from y in lift(x).Stream()
                         select project(x, y));

        public static List<X> Where<X>(this List<X> list, Func<X, bool> predicate)
            => List.make(from x in list.Stream() where predicate(x) select x);

    }

}