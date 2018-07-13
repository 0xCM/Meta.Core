//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

public interface IReadOnlySet<T> : IEnumerable<T>
{
    /// <summary>
    /// Determines whether a specified set is contained as a proper subset
    /// </summary>
    /// <param name="other">The set to compare</param>
    /// <returns></returns>
    bool IsProperSubsetOf(IEnumerable<T> other);

    bool IsProperSupersetOf(IEnumerable<T> other);

    bool IsSubsetOf(IEnumerable<T> other);

    bool IsSupersetOf(IEnumerable<T> other);

    bool Overlaps(IEnumerable<T> other);

    bool SetEquals(IEnumerable<T> other);

    bool Contains(T item);
}



