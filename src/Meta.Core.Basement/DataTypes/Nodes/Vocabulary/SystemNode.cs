//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

/// <summary>
/// Represents an describes a computational resource
/// </summary>
/// <typeparam name="T">The specialized subtype</typeparam>
public abstract class SystemNode<T> : ValueObject<T>, ISystemNode
    where T : SystemNode<T>
{

    public static implicit operator SystemNodeIdentifier(SystemNode<T> n)
       => n.NodeIdentifier;

    protected SystemNode(string NodeName, SystemNodeIdentifier NodeIdentifier, string NodeServer, int? Port = null, bool IsLocal = false)
    {
        this.NodeName = NodeName;
        this.NodeIdentifier = NodeIdentifier;
        this.NodeServer = NodeServer;
        this.Port = Port;
        this.IsLocal = IsLocal;
    }

    protected SystemNode(string NodeName, SystemNodeIdentifier NodeIdentifier, string NodeServer)
    {
        this.NodeName = NodeName;
        this.NodeServer = NodeServer;
        this.NodeIdentifier = NodeIdentifier;
    }

    protected SystemNode(string NodeName, SystemNodeIdentifier NodeIdentifier,  string NodeServer, string NetworkName, string ExternalIP, 
        int? Port = null, bool IsLocal = false)
    {
        this.NodeName = NodeName;
        this.NodeServer = NodeServer;
        this.NodeIdentifier = NodeIdentifier;
        this.NetworkName = NetworkName;
        this.ExternalIP = ExternalIP;
        this.Port = Port;
        this.IsLocal = IsLocal;
    }

    protected SystemNode(string NodeName)
    {
        this.NodeName = NodeName;
        this.NodeServer = NodeName;
        this.NodeIdentifier = NodeName.Replace("Node", "n");
        this.IsLocal = true;
        this.NetworkName = "localhost";
                   
    }

    public string NodeName { get; }


    public string NodeServer { get; }

    public string NetworkName { get; }

    public SystemNodeIdentifier NodeIdentifier { get; }

    public string ExternalIP { get; }
    
    public int? Port { get; }

    public bool IsLocal { get; }

    public override string ToString()
        => NodeName;



}


public sealed class SystemNode : SystemNode<SystemNode>
{

    static string ExecutingNodeName { get; }
        = "Nod00"; //EnvironmentVariables.SystemNode.ResolveValue().ValueOrDefault("localhost");


    public static implicit operator SystemNodeIdentifier(SystemNode n)
       => n.NodeIdentifier;


    public static readonly SystemNode Local 
        = new SystemNode(ExecutingNodeName);
    SystemNode(string NodeName)
        : base(NodeName)
    {

    }


    public SystemNode(string NodeName, SystemNodeIdentifier NodeIdentifier, string NodeServer, int? Port = null, bool IsLocal = false)
        : base(NodeName, NodeIdentifier, NodeServer, Port, IsLocal)
    {

    }

    public SystemNode(string NodeName, SystemNodeIdentifier NodeIdentifier, string NodeServer)
        : base(NodeName, NodeIdentifier, NodeServer)
    {

    }


    public SystemNode(string NodeName, SystemNodeIdentifier NodeIdentifier,  string NodeServer, string NetworkName, string ExternalIP, 
            int? Port = null, bool IsLocal = false)
        : base(NodeName, NodeIdentifier, NodeServer, NetworkName, ExternalIP, Port, IsLocal)
    {

    }

    public Link<SystemNode> LinkTo(SystemNode dst)
        => new Link<SystemNode>(this, dst);

    public Link<SystemNode> LinkToSelf()
        => new Link<SystemNode>(this, this);


}


