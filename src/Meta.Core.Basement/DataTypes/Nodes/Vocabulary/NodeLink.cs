//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using static minicore;

using N = SystemNode;

/// <summary>
/// Defines a directed edge between two nodes
/// </summary>
public struct NodeLink : ILink<N>
{
    public static implicit operator NodeChain(NodeLink link)
        => new NodeChain(stream(link));

    public static implicit operator Link<N,N>(NodeLink link)
        => new Link<N, N>(link.Source, link.Target);

    public static implicit operator NodeLink(Link<N> link)
        => new NodeLink(link.Source, link.Target);

    public static implicit operator NodeLink(Link<N,N> link)
        => new NodeLink(link.Source, link.Target);

    public NodeLink(N Source, N Target)
    {
        this.Source = Source;
        this.Target = Target;
    }

    public N Source { get; }        

    public N Target { get; }

    public LinkIdentifier Name
        => (LinkIdentifier)((Source, Target));

    public NodeLink Reverse()
        => new NodeLink(Target, Source);

    public bool LinkedToSelf
        => Source == Target;

    public override string ToString()
        => Name;

}
