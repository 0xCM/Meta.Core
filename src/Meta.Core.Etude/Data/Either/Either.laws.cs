//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    public interface IEither 
    {

    }

    public interface IEither<L, R> : IEither
    {
        /// <summary>
        /// If <see cref="IsLeft"/> is true, specifies the value of the left alternative
        /// </summary>
        L Left { get; }

        /// <summary>
        /// Specifies whether the left alternative exists
        /// </summary>
        bool IsLeft { get; }

        /// <summary>
        /// If <see cref="IsRight"/> is true, specifies the value of the right alternative
        /// </summary>
        R Right { get; }

        /// <summary>
        /// Specifies whether the right alternative exists
        /// </summary>
        bool IsRight { get; }
    }


}