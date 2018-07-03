//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    

    /// <summary>
    /// Specifies the canonical fmap signature
    /// </summary>
    /// <typeparam name="X">The sorce item type</typeparam>
    /// <typeparam name="CX">The source container type</typeparam>
    /// <typeparam name="Y">The target item type</typeparam>
    /// <typeparam name="CY">The target container type</typeparam>
    /// <param name="f"></param>
    /// <returns></returns>
    public delegate Func<CX, CY> FunctorMap<X, CX, Y, CY>(Func<X, Y> f)
        where CX : IContainer<X>
        where CY : IContainer<Y>;


    public interface IFunctor : ITypeClass
    {
                
    }



    public interface IFunctor<X, CX, Y, CY> : IFunctor
        where CX : IContainer<X>
        where CY : IContainer<Y>
    {
        /// <summary>
        /// Lifts a function f:X->Y into a functor F:CX->CY
        /// </summary>
        /// <param name="f">The function to lift</param>
        /// <returns></returns>
        Func<CX, CY> fmap(Func<X, Y> f);
    }


    partial class classops
    {

        /// <summary>
        /// Represents the <see cref="IFunctor"/> fmap operation
        /// </summary>
        public readonly struct fmap : IClassOp<fmap>
        {
            public static readonly fmap op = default;
            public const string S = "<$>";             
        }

    }



}
