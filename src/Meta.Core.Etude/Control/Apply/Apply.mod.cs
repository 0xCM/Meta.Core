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
    /// Constructs and manipulates <see cref="IApply"/> types and values
    /// </summary>
    public class Apply : ClassModule<Apply, IApply>, IApply
    {
        public Apply()
            : base(typeof(Apply<,,,,>))
        {

        }

        /// <summary>
        /// Constructs a <see cref="IApply"/> value from a <see cref="IFunctor"/> instance and an applier delegate
        /// </summary>
        /// <typeparam name="X">The domain of application</typeparam>
        /// <typeparam name="CX">A domain container</typeparam>
        /// <typeparam name="CFX">A function container</typeparam>
        /// <typeparam name="Y">The application codomain</typeparam>
        /// <typeparam name="CY">A application codomain container</typeparam>
        /// <param name="F">A functor value</param>
        /// <param name="applier">An applier delegate</param>
        /// <returns></returns>
        public static Apply<X, CX, CFX, Y, CY> make<X, CX, CFX, Y, CY>(IFunctor<X, CX, Y, CY> F, Applier<X, CX, CFX, Y, CY> applier)
            where CX : IContainer<X>
            where CFX : IContainer<Func<X,Y>>
            where CY : IContainer<Y>
                => new Apply<X, CX,CFX, Y, CY>(F, applier);


    }
}