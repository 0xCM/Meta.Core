//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public interface IIndex : IDataModule
    {

    }

    /// <summary>
    /// Characterizes an immutable associative array keyed with ingeger values
    /// </summary>
    /// <typeparam name="X">The contained item type</typeparam>
    public interface IIndex<X> : IIndex, IDataModule<X,Index<X>>,  IContainer<X,Index<X>>
    {
        /// <summary>
        /// Retrieves the value stored at a specified index position
        /// </summary>
        /// <param name="idx">The zero-based position</param>
        /// <exception cref="IndexOutOfRangeException"/>
        /// <returns></returns>
        X this[int idx] { get; }

        
    }
}