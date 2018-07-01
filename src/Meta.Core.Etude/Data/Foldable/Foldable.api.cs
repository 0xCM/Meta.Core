//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    partial class etude
    {
        public static Y foldl<X, Y>(Func<Y, X, Y> f, Y y0, List<X> container)
            => ListFoldable<X>.instance.foldl(f, y0, container);

        public static Y foldr<X, Y>(Func<X, Y, Y> f, Y y0, List<X> container)
            => ListFoldable<X>.instance.foldr(f, y0, container);

        public static Y foldl<X, Y>(Func<Y, X, Y> f, Y y0, Seq<X> container)
            => SeqFoldable<X>.instance.foldl(f, y0, container);

        public static Y foldr<X, Y>(Func<X, Y, Y> f, Y y0, Seq<X> container)
            => SeqFoldable<X>.instance.foldr(f, y0, container);


        /// <summary>
        /// Computes a right fold using a specified combiner
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="m"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        public static X fold<X>(IMonoid<X> m, Seq<X> subject)
            => foldr(m.combine, m.zero, subject);

    }

}