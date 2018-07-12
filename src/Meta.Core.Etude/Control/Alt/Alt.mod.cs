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
    /// Constructs and manipulates <see cref="IAlt"/> types and values
    /// </summary>
    public class Alt : ClassModule<Alt, IAlt>
    {
        public Alt()
            : base(typeof(Alt<,>))
        { }

        /// <summary>
        /// Constructs a <see cref="IAlt"/> value predicated on supplied data
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <typeparam name="CX"></typeparam>
        /// <param name="functor"></param>
        /// <param name="alt"></param>
        /// <returns></returns>
        public static IAlt<X, CX> make<X, CX>(IFunctor<X, CX, X, CX> functor, AltMap<CX> alt)
            where CX : IContainer<X> 
            => new Alt<X, CX>(functor, alt);

    }
}