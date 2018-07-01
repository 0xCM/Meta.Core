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
    /// Realizes <see cref="IPlus{X, CX}"/> predicated on supplied data
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="CX"></typeparam>
    public readonly struct Plus<X, CX> : IPlus<X, CX>
        where CX : IContainer<X>
    {

        public Plus(IAlt<X,CX> alt, CX empty)
        {            
            this._alt = alt;
            this.empty = empty;
        }

        IAlt<X, CX> _alt { get; }

        public CX empty { get; }

        public CX alt(CX f, CX g)
            => _alt.alt(f, g);

        public Func<CX, CX> fmap(Func<X, X> f)
            => _alt.fmap(f);

    }

}