//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    /// <summary>
    /// Realizes <see cref="IApplicative{X, CX, CFX, Y, CY}"/> predicated on supplied data
    /// </summary>
    /// <typeparam name="X">The function domain</typeparam>
    /// <typeparam name="CX">A domain container</typeparam>
    /// <typeparam name="CFX">A function container</typeparam>
    /// <typeparam name="CY">A codomain container</typeparam>
    /// <typeparam name="Y">The function codomain</typeparam>
    public readonly struct Applicative<X, CX, CFX, Y, CY> : IApplicative<X, CX, CFX, Y, CY>
        where CX : IContainer<X>
        where CFX : IContainer<Func<X,Y>>
        where CY : IContainer<Y>

    {
        public Applicative(IApply<X, CX, CFX, Y, CY> apply, Pure<X, CX> pure)
        {
            this._apply = apply;
            this._pure = pure;
        }

        IApply<X, CX, CFX, Y, CY> _apply { get; }

        Pure<X, CX> _pure { get; }

        public CY apply(CFX f, CX Fx)
            => _apply.apply(f, Fx);

        public Func<CX,CY> fmap(Func<X, Y> f)
            => _apply.fmap(f);

        public CY map(Func<X, Y> f, CX cx)
            => fmap(f)(cx);

        public CX pure(X x)
            => _pure(x);
    }
}