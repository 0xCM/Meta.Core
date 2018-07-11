//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;

using System.Linq;
using System.Collections.Generic;

using static minicore;


using N = SystemNode;
using System.Collections;

/// <summary>
/// Encapsulates an ordered collection of <see cref="NodeLink"/> values
/// such the target of a link at position n-1 is the source of the link at position n.
/// </summary>
public struct NodeChain :  INodeChain
{


    ReadOnlyList<NodeLink> Components { get; }


    static readonly NodeChain Default 
        = new NodeChain(array(new NodeLink(N.Local, N.Local)));    

    public NodeChain(IEnumerable<NodeLink> Links)
    {
        this.Components = Links.ToReadOnlyList();
    }

    public N Source
        => Components.FirstOrDefault().Source;

    public N Target
        => Components.LastOrDefault().Target;

    LinkIdentifier ILink.Name
        => Source.LinkTo(Target).Name;


    N ILink<N>.Source =>
        Components.FirstOrDefault().Source;

    N ILink<N>.Target =>
        Components.LastOrDefault().Target;

    int IReadOnlyCollection<Link<N>>.Count
        => Components.Count;

    Link<N> IReadOnlyList<Link<N>>.this[int index]
    {
        get
        {
            var x = Components[index];
            return new Link<N>(x.Source, x.Target);
        }
    }
   
    public override string ToString()
        => string.Join("=>", Components.ToArray());


    IEnumerator IEnumerable.GetEnumerator()
        => Components.GetEnumerator();

    IEnumerator<Link<N>> IEnumerable<Link<N>>.GetEnumerator()
        => (from x in Components select new Link<N>(x.Source, x.Target)).GetEnumerator();
}