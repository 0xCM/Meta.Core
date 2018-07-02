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
    /// Defines delegate that adjudicates list equality
    /// </summary>
    /// <typeparam name="X">The list item type</typeparam>
    readonly struct ListEquator<X>
    {
        public static readonly Equator<List<X>> instance
            = (l1, l2) => l1.AsReadOnlyList().ContentEqualTo(l2.AsReadOnlyList());
    }

    readonly struct ListFormatter<X> : IValueFormatter<List<X>>
    {
        public static readonly ListFormatter<X> instance = default;

        public string Format(List<X> list)
            => "[" + string.Join(",", list.Stream()) + "]";
    }



}