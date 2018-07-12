//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;


    public class Alternative : ClassModule<Alternative, IAlternative>
    {
        public Alternative()
            : base(typeof(Alternative<,,,,>))
        {

        }

        /// <summary>
        /// Constructs a <see cref="IAlternative"/> predicated on supplied data
        /// </summary>
        /// <param name="applicative">A realization of the <see cref="IApplicative"/> typeclass </param>
        /// <typeparam name="X">The function domain</typeparam>
        /// <typeparam name="CX">A domain container</typeparam>
        /// <typeparam name="CFX">A function container</typeparam>
        /// <typeparam name="CY">A codomain container</typeparam>
        /// <typeparam name="Y">The function codomain</typeparam>
        public static IAlternative<X, CX, CFX, Y, CY> make<X, CX, CFX, Y, CY>(IApplicative<X, CX, CFX, Y, CY> applicative, CX zero)
            where CX : IContainer<X>
            where CFX : IContainer<Func<X, Y>>
            where CY : IContainer<Y>
                => new Alternative<X, CX, CFX, Y, CY>(applicative, zero);

    }


}