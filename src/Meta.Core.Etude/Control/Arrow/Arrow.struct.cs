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

    public readonly struct Arrow<A, B>
    {
        public static implicit operator Arrow<A, B>(Func<A, B> f)
            => new Arrow<A, B>(f);


        public Arrow(Func<A, B> F)
            => this.F = F;

        Func<A, B> F { get; }

        public Arrow<A, C> compose<C>(Arrow<B, C> bc)
            => metacore.compose(F, bc.F);

        public A id(A a)
            => Category<A>.instance.id(a);

        public Arrow<(A, C), (B, C)> first<C>()
        {
            var _F = F;
            Func<(A, C), (B, C)> f = ((A a, C c) x) => (_F(x.a), x.c);
            return f;
        }

        public Arrow<(C, A), (C, B)> second<C>()
        {
            var _F = F;
            Func<(C, A), (C, B)> f = ((C c, A a) x) => (x.c, _F(x.a));
            return f;
        }

        public B Apply(A a)
            => F(a);
    }


}