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
    /// Constructs and manipulates <see cref="IApplicative"/> types and values
    /// </summary>
    public class Applicative : ClassModule<Applicative,IApplicative>, IApplicative
    {

        public Applicative()
            : base(typeof(Applicative<,,,,>))
        {

        }


        /// <summary>
        /// Constructs a <see cref="IApplicative"/> predicated on supplied data
        /// </summary>
        /// <param name="apply">A realization of the <see cref="IApply"/> typeclass </param>
        /// <typeparam name="X">The function domain</typeparam>
        /// <typeparam name="CX">A domain container</typeparam>
        /// <typeparam name="CFX">A function container</typeparam>
        /// <typeparam name="CY">A codomain container</typeparam>
        /// <typeparam name="Y">The function codomain</typeparam>
        public static IApplicative<X, CX, CFX, Y, CY> make<X, CX, CFX, Y, CY>(IApply<X, CX, CFX, Y, CY> apply, Pure<X, CX> pure)
            where CX : IContainer<X>
            where CFX : IContainer<Func<X, Y>>
            where CY : IContainer<Y>
                => new Applicative<X, CX, CFX, Y, CY>(apply, pure);

    }


}