//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static minicore;

    /// <summary>
    /// Defines delegate that adjudicates index equality
    /// </summary>
    /// <typeparam name="X">The list item type</typeparam>
    public readonly struct IndexEquator<X>
    {
        public static readonly Equator<Index<X>> instance
            = (l1, l2) => l1.AsReadOnlyList().ContentEqualTo(l2.AsReadOnlyList());
    }


}