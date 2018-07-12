//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Linq;


    public class Bifunctor : ClassModule<Bifunctor, IBifunctor>
    {
        public Bifunctor()
            : base(typeof(Bifunctor<,,,,,,,>))
        {

        }

        /// <summary>
        /// Constructs construct the default bifunctor for the supplied types
        /// </summary>
        /// <typeparam name="X1">The type of the first domain coordinate</typeparam>
        /// <typeparam name="CX1">Container of X1</typeparam>
        /// <typeparam name="X2">The type of the second domain coordinate</typeparam>
        /// <typeparam name="CX2">Container of X2</typeparam>
        /// <typeparam name="Y1">The type of the first codomain coordinate</typeparam>
        /// <typeparam name="CY1">Container of Y1</typeparam>
        /// <typeparam name="Y2">The type of the second codomain coordinate</typeparam>
        /// <typeparam name="CY2">Container of Y2</typeparam>
        /// <returns></returns>
        public static IBifunctor<X1, CX1, X2, CX2, Y1, CY1, Y2, CY2> make<X1, CX1, X2, CX2, Y1, CY1, Y2, CY2>()
           where CX1 : IContainer<X1, CX1>, new()
           where CX2 : IContainer<X2, CX2>, new()
           where CY1 : IContainer<Y1, CY1>, new()
           where CY2 : IContainer<Y2, CY2>, new()
                => Bifunctor<X1, CX1, X2, CX2, Y1, CY1, Y2, CY2>.instance;

    }

}