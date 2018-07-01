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
    /// Specifies a <see cref="IFunctor"/> typeclass predicated on a
    /// constructor-injected transformer
    /// </summary>
    /// <typeparam name="X">The type of the source</typeparam>
    /// <typeparam name="CX">A constructed source container type</typeparam>
    /// <typeparam name="CY">A construction target container type</typeparam>
    /// <typeparam name="Y">The type of the target</typeparam>
    public readonly struct Functor<X, CX, Y, CY> : IFunctor<X, CX, Y, CY>
        where CX : IContainer<X>
        where CY : IContainer<Y>
    {

        public Functor(FunctorMap<X, CX, Y, CY> fmap)
            => this._fmap = fmap;

        FunctorMap<X,CX,Y,CY>  _fmap { get; }

        public Func<CX, CY> fmap(Func<X, Y> f)
            => _fmap(f);

    }

}