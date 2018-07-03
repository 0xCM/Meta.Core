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
    public static List<Y> bind<X, Y>(List<X> list, Function<X, List<Y>> f)
        => List.bind(list, f.F);

}


