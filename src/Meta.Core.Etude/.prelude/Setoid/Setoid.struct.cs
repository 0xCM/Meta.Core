//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    using static metacore;

    /// <summary>
    /// Defines a set and a means to determine whether two elements
    /// of a given set are equal.
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    public readonly struct Setoid<X> : ISetoid<X>
    {
        public Setoid(Equator<X> comparer)
            => this.comparer =  comparer ?? ((X x1, X x2) => object.Equals(x1,x2));

        Equator<X> comparer{ get; }


        public bool eq(X a1, X a2)
            => comparer(a1, a2);

        public bool neq(X a1, X a2)
            => not(comparer(a1, a2));

        public override string ToString()
            => "Setoid" + embrace(typeof(X).Name);
    }
}