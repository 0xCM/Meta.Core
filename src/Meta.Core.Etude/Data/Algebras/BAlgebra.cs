//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public interface IBAlgebra<A> : IHAlgebra<A>
    {

    }

    public readonly struct BAlgebra<A> : IBAlgebra<A>
    {
        public BAlgebra(A ff, A tt)
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

}