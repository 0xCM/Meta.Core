//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;

using static metacore;

partial class etude
{
    public static Lst<Y> apply<X, Y>(Lst<Func<X, Y>> lf, Lst<X> lx)
        => ListApply<X, Y>.instance.apply(lf, lx);

    public static Seq<Y> apply<X, Y>(Seq<Func<X, Y>> sf, Seq<X> sx)
        => SeqApply<X, Y>.instance.apply(sf, sx);
}
