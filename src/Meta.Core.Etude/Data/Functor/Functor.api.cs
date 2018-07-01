//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using Meta.Core;
namespace Meta.Core
{
    using System;
    using System.Linq;

    partial class etude
    {
        public static List<Y> fmap<X, Y>(Func<X, Y> f, List<X> list)
            => ListFunctor<X, Y>.instance.fmap(f)(list);

        public static Seq<Y> fmap<X, Y>(Func<X, Y> f, Seq<X> list)
            => SeqFunctor<X, Y>.instance.fmap(f)(list);

        public static Set<Y> fmap<X, Y>(Func<X, Y> f, Set<X> set)
            => SetFunctor<X, Y>.instance.fmap(f)(set);
    }

    public static partial class OX
    {
        public static IFunctor<X, List<X>, Y, List<Y>> list<X, Y>(this classops.fmap op)
            => ListFunctor<X, Y>.instance;

        public static IFunctor<X, Seq<X>, Y, Seq<Y>> Seq<X, Y>(this classops.fmap op)
            => SeqFunctor<X, Y>.instance;

        public static IFunctor<X, Set<X>, Y, Set<Y>> Set<X, Y>(this classops.fmap op)
            => SetFunctor<X, Y>.instance;

       

    }


}


