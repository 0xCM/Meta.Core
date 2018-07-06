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
    using static metacore;

    readonly struct SeqEq<X> : IEq<Seq<X>>
    {
        public static readonly SeqEq<X> instance = default;

        public bool eq(Seq<X> s1, Seq<X> s2)
            => Seq.eq(s1, s2);

        public bool neq(Seq<X> s1, Seq<X> s2)
            => not(eq(s1, s2));
    }

    readonly struct ListEq<X> : IEq<Lst<X>>
    {
        public static readonly ListEq<X> instance = default;

        public bool eq(Lst<X> l1, Lst<X> l2)
            => Lst.eq(l1, l2);

        public bool neq(Lst<X> l1, Lst<X> l2)
            => not(eq(l1, l2));
    }




}