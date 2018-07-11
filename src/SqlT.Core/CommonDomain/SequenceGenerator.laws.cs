//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines non-generic contract for a stateful component that produce a sequence of values
    /// </summary>
    /// <remarks>
    /// The contract and its generic counterpart a sufficiently general to support yielding a
    /// sequence with any item type but, in practice, it is usually used for providing a sequence
    /// of distinct integers
    /// </remarks>
    public interface ISequenceGenerator
    {
        /// <summary>
        /// Retrieves the next set of values in the sequence
        /// </summary>
        /// <param name="count">The number of values to retrieve</param>
        /// <returns></returns>
        IEnumerable<object> NextRange(int count);

        /// <summary>
        /// Retrieves the next value in the sequence
        /// </summary>
        /// <returns></returns>
        object NextValue();
    }

    /// <summary>
    /// Defines generic contract for elements that produce a sequence of values
    /// </summary>
    public interface ISequenceGenerator<T> : ISequenceGenerator
    {
        /// <summary>
        /// Retrieves the next set of values in the sequence
        /// </summary>
        /// <param name="count">The number of values to retrieve</param>
        /// <returns></returns>
        new IEnumerable<T> NextRange(int count);

        /// <summary>
        /// Retrieves the next value in the sequence
        /// </summary>
        /// <returns></returns>
        new T NextValue();
    }

    /// <summary>
    /// Defines non-generic contract for obtaining generic sequence values
    /// </summary>
    public interface ISequenceProvider
    {
        IEnumerable<T> NextRange<T>(int value);

        T NextValue<T>();
    }

}

