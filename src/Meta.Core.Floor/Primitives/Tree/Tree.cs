//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Base type for generic trees
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="C"></typeparam>
public abstract class Tree<T, C> : ITree<T, C>
    where T : ITree<T, C>
{
    Option<T> _Parent;

    public Tree(Func<ITree<T, C>, IEnumerable<ITree<T, C>>> ChildFactory)
    {
        this.ChildFactory = ChildFactory;
    }

    public Tree(T Parent, Func<ITree<T, C>, IEnumerable<ITree<T, C>>> ChildFactory)
        : this(ChildFactory)
    {
        _Parent = Parent;
    }

    Func<ITree<T, C>, IEnumerable<ITree<T, C>>> ChildFactory { get; }

    Option<T> ITree<T, C>.Parent
        => _Parent;

    public IEnumerable<ITree<T, C>> Children
        => ChildFactory(this);

    Option<ITree> ITree.Parent
        => _Parent.MapValueOrDefault(p => (p as ITree).Parent);

    protected abstract C GetContent();

    IEnumerable<ITree> ITree.Children
        => Children;

    C ITree<T, C>.Content 
        => GetContent();

    IEnumerable<ITree<T, C>> Dive(ITree<T, C> parent)
    {
        foreach (var child in parent.Children)
        {
            yield return child;
            foreach (var grandchild in Dive(child))
                yield return grandchild;
        }
    }

    void ITree<T,C>.VisitChildren(Action<ITree<T,C>> visitor)
    {
        foreach (var child in Children)
        {
            visitor(child);
            child.VisitChildren(visitor);
        }
    }

    public void VisitContent(Action<C> visitor)
    {
        foreach(var child in Children)
        {
            visitor(child.Content);
            child.VisitContent(visitor);
        }
    }

    public IEnumerable<ITree<T, C>> Dive()
        => Dive(this);
   
    public override string ToString()
        => GetContent().ToString();
}

