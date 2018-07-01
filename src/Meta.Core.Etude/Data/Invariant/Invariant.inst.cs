//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;


    public interface IListInvariant<X,Y> : IInvariant<X, List<X>, Y, List<Y>>
    {

    }
    readonly struct ListInvariant<X, Y> : IListInvariant<X,Y>
    {
        public static readonly ListInvariant<X, Y> instance = default;

        public Func<List<X>, List<Y>> imap(Func<X, Y> f, Func<Y, X> g)
            => lx => List.imap(f, g, lx);
    }

}