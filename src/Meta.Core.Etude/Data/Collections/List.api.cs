//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using Meta.Core;

partial class etude
{
    public static Lst<Y> bind<X, Y>(Lst<X> list, Function<X, Lst<Y>> f)
        => Lst.bind(list, f.F);

}


