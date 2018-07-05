﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;

partial class etude
{
    public static Seq<Y> traverse<X, Y>(Func<X, Seq<Y>> f, Seq<X> sx)
        => SeqTraversable<X, Y>.instance.traverse(f, sx);

    public static Seq<Y> traverse<X, Y>(Func<X, Lst<Y>> f, Lst<X> sx)
        => ListTraversable<X, Y>.instance.traverse(f, sx);

}


