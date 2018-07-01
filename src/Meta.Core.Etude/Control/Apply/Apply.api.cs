//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;


    partial class etude
    {
        public static List<Y> apply<X, Y>(List<Func<X, Y>> lf, List<X> lx)
            => ListApply<X, Y>.instance.apply(lf, lx);

        public static Seq<Y> apply<X, Y>(Seq<Func<X, Y>> sf, Seq<X> sx)
            => SeqApply<X, Y>.instance.apply(sf, sx);

    }


}