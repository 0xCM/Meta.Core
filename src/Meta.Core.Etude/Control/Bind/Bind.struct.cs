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
    /// Realizes <see cref="IBind{X, CX, CFX, Y, CY}"/> predicated on supplied data
    /// </summary>
    /// <typeparam name="X">The function domain</typeparam>
    /// <typeparam name="CX">A domain container</typeparam>
    /// <typeparam name="CFX">A function container</typeparam>
    /// <typeparam name="CY">A codomain container</typeparam>
    /// <typeparam name="Y">The function codomain</typeparam>
    public readonly struct Bind<X, CX, CFX, Y, CY> : IBind<X, CX, CFX, Y, CY>
        where CX : IContainer<X>
        where CFX : IContainer<Func<X, Y>>
        where CY : IContainer<Y>
    {

        public Bind(IApply<X, CX, CFX, Y, CY> apply, Binder<X, CX, CFX, Y, CY> bind)
        {
            this._apply = apply;
            this._bind = bind;            
        }

        IApply<X, CX, CFX, Y, CY> _apply { get; }

        Binder<X, CX, CFX, Y, CY> _bind { get; }

        public CY apply(CFX cf, CX Fx)
            => _apply.apply(cf, Fx);

        public CY bind(CX Fx, Func<X, CY> g)
            => _bind(Fx, g);

        public Func<CX, CY> fmap(Func<X, Y> f)
            => _apply.fmap(f);
    }

}