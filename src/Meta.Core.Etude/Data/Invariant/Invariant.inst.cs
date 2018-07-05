//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;


    public interface IListInvariant<X,Y> : IInvariant<X, Lst<X>, Y, Lst<Y>>
    {

    }
    readonly struct ListInvariant<X, Y> : IListInvariant<X,Y>
    {
        public static readonly ListInvariant<X, Y> instance = default;

        public Func<Lst<X>, Lst<Y>> imap(Func<X, Y> f, Func<Y, X> g)
            => lx => List.imap(f, g, lx);
    }

}