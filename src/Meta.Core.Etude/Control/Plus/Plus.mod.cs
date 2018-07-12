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
    /// Constructs and manipulates <see cref="IPlus"/> types and values
    /// </summary>
    public sealed class Plus : ClassModule<Plus, IPlus>, IPlus
    {
        public Plus()
            :base(typeof(Plus<,>))
        {

        }

        /// <summary>
        /// Constructs a <see cref="IPlus"/> value predicated on supplied data
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <typeparam name="CX"></typeparam>
        /// <param name="functor"></param>
        /// <param name="Plus"></param>
        /// <returns></returns>
        public static IPlus<X, CX> make<X, CX>(IAlt<X,CX> alt, CX empty)
            where CX : IContainer<X>
            => new Plus<X, CX>(alt, empty);
    }
}