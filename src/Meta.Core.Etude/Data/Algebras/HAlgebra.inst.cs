//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public readonly struct HAlgebra<A> : IHAlgebra<A>
    {

        public HAlgebra(A ff, A tt)
        {
            this.ff = ff;
            this.tt = tt;
        }

        public A ff { get; }

        public A tt { get; }

        public A conj(A a1, A a2)
            => a1.Equals(tt) && a2.Equals(tt) ? tt : ff;

        public A disj(A a1, A a2)
            => a1.Equals(tt) || a2.Equals(tt) ? tt : ff;

        public A not(A a)
            => a.Equals(tt) ? ff : tt;

        public A implies(A a1, A a2)
            => disj(not(a1), a2);
    }


    readonly struct HAlgebraBoolean : IHAlgebra<bool>
    {
        public static readonly HAlgebraBoolean instance = default;
        static readonly HAlgebra<bool> @default = new HAlgebra<bool>(false, true);

        public bool ff
            => @default.ff;

        public bool tt
            => @default.tt;

        public bool conj(bool a1, bool a2)
            => @default.conj(a1, a2);

        public bool disj(bool a1, bool a2)
            => @default.conj(a1, a2);

        public bool not(bool a)
            => @default.not(a);

        public bool implies(bool a1, bool a2)
            => @default.implies(a1, a2);            

    }
}