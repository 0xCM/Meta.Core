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
    /// Specifies the signature of the applicative pure operation
    /// that lifts a value into a computational context
    /// </summary>
    /// <typeparam name="X">The value type</typeparam>
    /// <typeparam name="CX">The context/container type</typeparam>
    /// <param name="value">The value to lift</param>
    /// <returns></returns>
    public delegate CX Pure<X, CX>(X value);

    /// <summary>
    /// Identifies and characterizes the Applicative typeclass
    /// </summary>
    public interface IApplicative :  IFunctor
    {

    }

    /// <summary>
    /// Characterizes productions of the <see cref="IApplicative"/> typeclass
    /// </summary>
    /// <typeparam name="X">The function domain</typeparam>
    /// <typeparam name="CX">A container over X</typeparam>
    /// <typeparam name="CFX">A function container</typeparam>
    /// <typeparam name="Y">The function codomain</typeparam>
    /// <typeparam name="CY">A context over the function codomain</typeparam>
    public interface IApplicative<X, CX, CFX, Y, CY> : IApplicative, IApply<X, CX, CFX, Y, CY>
        where CX : IContainer<X>
        where CFX : IContainer<Func<X, Y>>
        where CY : IContainer<Y>

    {        

        /// <summary>
        /// Lifts a value into the computational context
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        CX pure(X x);
    }
}
