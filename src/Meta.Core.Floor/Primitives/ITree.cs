//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;


public interface ITree
{
    /// <summary>
    /// The parent tree, if any
    /// </summary>
    Option<ITree> Parent { get; }

    /// <summary>
    /// The node children
    /// </summary>
    IEnumerable<ITree> Children { get; }
}

/// <summary>
/// Contract for generic tree data structure
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="C"></typeparam>
public interface ITree<T, C> : ITree
    where T : ITree<T, C>
{
    /// <summary>
    /// The node content
    /// </summary>
    C Content { get; }

    /// <summary>
    /// The node children
    /// </summary>
    new IEnumerable<ITree<T, C>> Children { get; }

    /// <summary>
    /// The tree recursion operator
    /// </summary>
    /// <returns></returns>
    IEnumerable<ITree<T, C>> Dive();

    /// <summary>
    /// The parent tree, if any
    /// </summary>
    new Option<T> Parent { get; }

    /// <summary>
    /// Visit the node children
    /// </summary>
    /// <param name="visitor">THe observing visitor</param>
    void VisitChildren(Action<ITree<T, C>> visitor);

    /// <summary>
    /// Visits the node content
    /// </summary>
    /// <param name="visitor"></param>
    void VisitContent(Action<C> visitor);
}

