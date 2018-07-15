//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using Modules;

    using static minicore;

    public readonly struct FP<X1,Y1,X2,Y2> : IProduct<Function<X1,Y1>, Function<X2,Y2>>
    {
        public FP(Function<X1,Y1> x1, Function<X2,Y2> x2)
        {
            this.x1 = x1;
            this.x2 = x2;
        }

        public Function<X1,Y1> x1 { get; }

        public Function<X2, Y2> x2 { get; }

        object ITuple.this[int n]
            => n is 0 ? x1 :
               n is 1 ? x2 : fail<object>(IndexOutOfRange(n));

        int ITuple.Length
            => 2;

        public (Function<X1, Y1> x1, Function<X2, Y2> x2) AsTuple()
            => (x1, x2);
    }

}