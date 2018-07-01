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

    public readonly struct Traversable<X, CX, Y, CY> : ITraversable<X, CX, Y, CY>
        where CX : IContainer<X>
        where CY : IContainer<Y>
    {

        public Traversable(FunctorMap<X, CX, Y, CY> map, Func<Func<X,CY>, CX, CY> traverse)
        {
            this._map = map;
            this._traverse = traverse;
        }

        FunctorMap<X, CX, Y, CY> _map { get; }

        Func<Func<X, CY>, CX, CY> _traverse { get; }

        public Func<CX,CY> fmap(Func<X, Y> f)
            => _map(f);

        public CY traverse(Func<X, CY> f, CX cx)
            => _traverse(f, cx);
    }

}