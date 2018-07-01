//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using Modules;

    /// <summary>
    /// The canonical <see cref="Seq{X}"/> monad that facilitates LINQ integration
    /// </summary>
    public static class SeqM
    {       
        public static Seq<Y> Select<X, Y>(this Seq<X> s, Func<X, Y> selector)
             => Seq.make(from x in s.Stream() select selector(x));

        public static Seq<Z> SelectMany<X, Y, Z>(this Seq<X> s, Func<X, Seq<Y>> lift, Func<X, Y, Z> project)
            => Seq.make(from x in s.Stream()
                          from y in lift(x).Stream()
                          select project(x, y));

        public static Seq<Y> SelectMany<X, Y>(this Seq<X> s, Func<X, Seq<Y>> lift)
            => Seq.make(from x in s.Stream()
                          from y in lift(x).Stream()
                          select y);

        public static Seq<X> Where<X>(this Seq<X> s, Func<X, bool> predicate)
            => Seq.make(from x in s.Stream() where predicate(x) select x);

    }
}