//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

using static metacore;

public struct NodeFlow 
{
    public static implicit operator NodeFlow((SystemNode host, SystemNode source, SystemNode target) f)
        => new NodeFlow(f.host, f.source, f.target);

    public static implicit operator Link<SystemNode>(NodeFlow flow)
        => new Link<SystemNode>(flow.SourceNode, flow.TargetNode);

    public static implicit operator NodeFlow(Link<SystemNode> flow)
        => new NodeFlow(flow.Source, flow.Source, flow.Target);


    public NodeFlow(SystemNode HostNode, SystemNode SourceNode, SystemNode TargetNode)
    {
        this.HostNode = HostNode;
        this.SourceNode = SourceNode;
        this.TargetNode = TargetNode;

    }


    public SystemNode HostNode { get; }

    public SystemNode SourceNode { get; }

    public SystemNode TargetNode { get; }

    public override string ToString()
        => $"{HostNode}:{SourceNode}->{TargetNode}";


}
