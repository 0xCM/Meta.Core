//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using G = System.Collections.Generic;

    using static minicore;

    /// <summary>
    /// Defines delegate that adjudicates list equality
    /// </summary>
    /// <typeparam name="X">The list item type</typeparam>
    readonly struct SeqEquator<X>
    {
        public static readonly Equator<Seq<X>> instance
            = Equals;

        static bool Equals(Seq<X> s1, Seq<X> s2)
        {

            if (s1.IsEmpty && s2.IsEmpty)
                return true;

            if (s1.IsUnbounded || s1.IsUnbounded)
                return false;

            var _l1 = s1.AsArray();
            var _l2 = s2.AsArray();

            if (_l1.Length != _l2.Length)
                return false;

            for (var i = 0; i < _l2.Length; i++)
            {
                var left = _l1[i];
                var right = _l2[i];
                var same = Equals(left, right);
                if (not(same))
                    return false;
            }
            return true;

        }
    }

    readonly struct SeqFormatter<X> : IValueFormatter<Seq<X>>
    {
        public static readonly SeqFormatter<X> instance = default;

        public string Format(Seq<X> s)
        {
            var name = typeof(X).Name;
            switch (s.Cardinality)
            {
                case Cardinality.Finite:
                    return embrace($"{name} | (1..n)");
                case Cardinality.Zero:
                    return embrace($"{name} | ()");
                case Cardinality.Infinite:
                    return embrace($"{name} | (1..*)");
                default:
                    return embrace($"{name} | (?)");
            }
        }
    }


}