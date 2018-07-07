//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public interface ISet<X> :  IContainer<X,Set<X>>
    {
        bool IsProperSubsetOf(ISet<X> other);

        bool IsProperSupersetOf(ISet<X> other);

        bool IsSubsetOf(ISet<X> other);

        bool IsSupersetOf(ISet<X> other);

        bool Overlaps(ISet<X> other);

        bool SetEquals(ISet<X> other);

        bool Contains(X item);

    }

}