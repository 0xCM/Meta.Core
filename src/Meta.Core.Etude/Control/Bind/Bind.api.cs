//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;
using static metacore;

partial class etude
{
    public static Lst<Y> bind<X, Y>(Lst<X> list, Func<X, Lst<Y>> f)
        => ListBind<X, Y>.instance.bind(list, f);

    public static Seq<Y> bind<X, Y>(Seq<X> list, Func<X, Seq<Y>> f)
        => SeqBind<X, Y>.instance.bind(list, f);
}