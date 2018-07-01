//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Linq;


    public class Functor : ClassModule<Functor, IFunctor>, IFunctor
    {
        /// <summary>
        /// Constructs a functor from a map
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <typeparam name="CX"></typeparam>
        /// <typeparam name="Y"></typeparam>
        /// <typeparam name="CY"></typeparam>
        /// <param name="fmap"></param>
        /// <returns></returns>
        public static IFunctor<X, CX, Y, CY> make<X, CX, Y, CY>(FunctorMap<X,CX,Y,CY> fmap)
            where CX : IContainer<X>
            where CY : IContainer<Y>
                => new Functor<X, CX, Y, CY>(fmap);



    }

}