//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Linq;


    /// <summary>
    /// Realizes <see cref="IAlt{X, CX}"/> predicated on supplied data
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="CX"></typeparam>
    public readonly struct Alt<X,CX> : IAlt<X,CX>
        where CX : IContainer<X>
    {
        IFunctor<X, CX, X, CX> _functor { get; }

        AltMap<CX> _alt { get; }

        public Alt(IFunctor<X, CX, X, CX> functor, AltMap<CX> alt)
        {
            this._functor = functor;
            this._alt = alt;
        }

        public CX alt(CX f, CX g)
            => _alt(f, g);

        public Func<CX, CX> fmap(Func<X, X> f)
            => _functor.fmap(f);
    }

}