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
    readonly struct LstEquator<X>
    {
        public static readonly Equator<Lst<X>> instance
            = (l1, l2) => l1.AsReadOnlyList().ContentEqualTo(l2.AsReadOnlyList());
    }

    readonly struct LstFormatter<X> : IValueFormatter<Lst<X>>
    {
        public static readonly LstFormatter<X> instance = default;

        public string Format(Lst<X> list)
            => "[" + string.Join(",", list.Stream()) + "]";
    }



}