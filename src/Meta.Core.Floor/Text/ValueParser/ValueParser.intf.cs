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
    /// Characterizes the ValueParser typeclass
    /// </summary>
    public interface IValueParser : ITypeClass
    {

    }

    /// <summary>
    /// Characterizes a production of the <see cref="IValueParser"/> typeclass
    /// </summary>
    /// <typeparam name="X"></typeparam>
    public interface IValueParser<X> : ITypeClass<X>
    {
        /// <summary>
        /// Attempts to create a <typeparamref name="X"/> value from text
        /// </summary>
        /// <param name="text">The text to parse</param>
        /// <returns></returns>
        Option<X> Parse(string text);
    }


}