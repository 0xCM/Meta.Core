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
    /// Realizes <see cref="IApply"/> predicated on supplied data
    /// </summary>
    /// <typeparam name="X">The function domain</typeparam>
    /// <typeparam name="CX">A domain container</typeparam>
    /// <typeparam name="CFX">A function container</typeparam>
    /// <typeparam name="CY">A codomain container</typeparam>
    /// <typeparam name="Y">The function codomain</typeparam>
    public readonly struct Apply<X, CX,CFX, Y, CY> : IApply<X, CX, CFX, Y, CY>
        where CX : IContainer<X>
        where CFX : IContainer<Func<X, Y>>
        where CY : IContainer<Y>

    {
        public Apply(IFunctor<X, CX, Y, CY> functor, Applier<X, CX, CFX, Y, CY> apply)
        {
            this._functor = functor;
            this._apply = apply;
        }

        IFunctor<X, CX, Y, CY> _functor { get; }

        Applier<X, CX, CFX, Y, CY> _apply { get; }

        public CY apply(CFX cf, CX cx)
            => _apply(cf, cx);

        public Func<CX,CY> fmap(Func<X, Y> f)
            => _functor.fmap(f);
    }
}