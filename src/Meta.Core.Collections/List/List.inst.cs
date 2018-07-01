//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Immutable;

    using G = System.Collections.Generic;

    using static minicore;

    /// <summary>
    /// Defines delegate that adjudicates list equality
    /// </summary>
    /// <typeparam name="X">The list item type</typeparam>
    public readonly struct ListEquator<X>
    {
        public static readonly Equator<List<X>> instance
            = Equals;

        static bool Equals(List<X> l1, List<X> l2)
        {
            if (l1.Count != l2.Count)
                return false;

            for (var i = 0; i < l2.Count; i++)
            {
                var left = l1[i];
                var right = l2[i];
                var same = Equals(left, right);
                if (not(same))
                    return false;
            }
            return true;

        }
    }



}