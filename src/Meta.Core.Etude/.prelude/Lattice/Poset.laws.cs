//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public interface IPartialOrder : ITypeClass
    {

    }

    /// <summary>
    /// Requires implementors to support a conforming partial order operation
    /// </summary>
    /// <typeparam name="A"></typeparam>
    /// <remarks>
    /// See https://en.wikipedia.org/wiki/Partially_ordered_set
    /// </remarks>
    public interface IPartialOrder<A> : IPartialOrder, IEq<A>
    {
        Ordering PartialCompare(A a1, A a2);
    }
}