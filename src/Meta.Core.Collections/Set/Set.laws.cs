//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
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