//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public interface IFunction : ITypeclass
    {

    }

    /// <summary>
    /// Defines universal function contract for the mapping X -> Y
    /// </summary>
    /// <typeparam name="X">The input value</typeparam>
    /// <typeparam name="Y">The output value</typeparam>
    public interface IFunction<in X, out Y> : IFunction
    {
        /// <summary>
        /// Binds the function to an input
        /// </summary>
        /// <param name="input">The input value</param>
        /// <returns></returns>
        Y Eval(X input);

        /// <summary>
        /// Renders the canonical display format for the function
        /// </summary>
        /// <returns></returns>
        string Format();
    }
}