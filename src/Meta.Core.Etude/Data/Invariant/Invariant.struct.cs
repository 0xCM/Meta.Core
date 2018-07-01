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
        public Invariant(Func<Func<X, Y>, Func<Y, X>, CX, CY> imap)
            => this._imap = imap;

        Func<Func<X, Y>, Func<Y, X>, CX, CY> _imap { get; }

        public CY imap(Func<X, Y> f, Func<Y, X> g, CX Fx)
            => _imap(f, g, Fx);
    }


}