//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    
    using static metacore;    
    
    readonly struct DigitOrder : IOrdered<Digit>
    {
        public static readonly DigitOrder instance = default;

        public Ordering compare(Digit x1, Digit x2)
            => x1.Value < x2.Value ? Ordering.LT
            : x1.Value > x2.Value ? Ordering.GT
            : Ordering.EQ;

        public bool eq(Digit x1, Digit x2)
            => compare(x1, x2) == Ordering.EQ;
    }
}