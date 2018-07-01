//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public readonly struct Invariant<X, CX, Y, CY> : IInvariant<X, CX, Y, CY>
       where CX : IContainer<X>
       where CY : IContainer<Y>
    {
        public Invariant(InvariantMap<X, CX, Y, CY> imap)
            => this._imap = imap;

        InvariantMap<X, CX, Y, CY> _imap { get; }

        public Func<CX, CY> imap(Func<X, Y> f, Func<Y, X> g)
            => _imap(f, g);
    }


}