//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using Meta.Core;
using System;
using System.Linq;

partial class etude
{
    public static Lst<X> alt<X>(Lst<X> l1, Lst<X> l2)
        => ListAlt<X>.instance.alt(l1, l2);

    public static Seq<X> alt<X>(Seq<X> s1, Seq<X> s2)
        => SeqAlt<X>.instance.alt(s1, s2);

    public static Index<X> alt<X>(Index<X> s1, Index<X> s2)
        => SeqAlt<X>.instance.alt(s1, s2);

}


