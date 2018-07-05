//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;

partial class etude
{
    public static Lst<Y> fmap<X, Y>(Func<X, Y> f, Lst<X> list)
        => ListFunctor<X, Y>.instance.fmap(f)(list);

    public static Seq<Y> fmap<X, Y>(Func<X, Y> f, Seq<X> list)
        => SeqFunctor<X, Y>.instance.fmap(f)(list);

}
