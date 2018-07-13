//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

public interface ITypedItemList : IEnumerable
{
    /// <summary>
    /// Specifies the type of item contained by the list
    /// </summary>
    Type ItemType { get; }

    /// <summary>
    /// Specifies the concrete list type
    /// </summary>
    Type ListType { get; }
}

public interface ITypedItemList<out T> : ITypedItemList, IReadOnlyList<T>
{


}

public interface ITypedItemList<B, out T> : ITypedItemList<T>
{

}
