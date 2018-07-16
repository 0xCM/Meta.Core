//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public interface IIdentityFunctor<X,CX> : IFunctor<X, CX, X, CX> 
            where CX : IContainer<X, CX>, new()
    {

    }

    readonly struct IdentityFunctor<X, CX> : IIdentityFunctor<X,CX>
        where CX : IContainer<X, CX>, new()
    {
        public static readonly IdentityFunctor<X, CX> instance = default;

        public Func<CX, CX> fmap(Func<X, X> f)
            => cx => cx;
    }





}