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

    readonly struct SeqFunctor<X, Y> : IFunctor<X, Seq<X>, Y, Seq<Y>>
    {
        public static readonly SeqFunctor<X, Y> instance = default;

        public Func<Seq<X>, Seq<Y>> fmap(Func<X, Y> f)
            => Seq.fmap(f);
    }
    readonly struct ListFunctor<X, Y> : IFunctor<X, List<X>, Y, List<Y>>
    {
        public static readonly ListFunctor<X, Y> instance = default;

        public Func<List<X>, List<Y>> fmap(Func<X, Y> f)
            => List.fmap(f);
    }

    readonly struct SetFunctor<X, Y> : IFunctor<X, Set<X>, Y, Set<Y>>
    {
        public static readonly SetFunctor<X, Y> instance = default;

        public Func<Set<X>, Set<Y>> fmap(Func<X, Y> f)
            => Set.fmap(f);
    }




}