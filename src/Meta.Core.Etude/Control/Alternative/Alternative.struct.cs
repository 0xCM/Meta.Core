//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;


    readonly struct Alternative<X, CX,CFX,Y,CY> : IAlternative<X, CX, CFX, Y, CY>
        where CX : IContainer<X>
        where CFX : IContainer<Func<X, Y>>
        where CY : IContainer<Y>
    {
        public Alternative(IApplicative<X, CX, CFX, Y, CY> applicative, CX empty)
        {
            this._applicative = applicative;
            this.empty = empty;
        }

        IApplicative<X, CX, CFX, Y, CY> _applicative { get; }

        public CX empty { get; }

        public CY apply(CFX cf, CX cx)
            => _applicative.apply(cf, cx);

        public Func<CX, CY> fmap(Func<X, Y> f)
            => _applicative.fmap(f);

        public CX pure(X x)
            => _applicative.pure(x);
    }


}