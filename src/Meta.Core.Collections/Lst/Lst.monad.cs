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
    /// Defines the canonical see <see cref="Lst{X}"/> monad for LINQ integration
    /// </summary>
    public static class LstM
    {

        public static Lst<Y> Select<X, Y>(this Lst<X> list, Func<X, Y> selector)
             => Lst.make(from x in list.Stream() select selector(x));

        public static Lst<Z> SelectMany<X, Y, Z>(this Lst<X> list, Func<X, Lst<Y>> lift, Func<X, Y, Z> project)
            => Lst.make(from x in list.Stream()
                         from y in lift(x).Stream()
                         select project(x, y));

        public static Lst<X> Where<X>(this Lst<X> list, Func<X, bool> predicate)
            => Lst.make(from x in list.Stream() where predicate(x) select x);

    }

}