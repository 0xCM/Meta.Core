//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

public abstract class NodeResource<T> : ValueObject<T>
    where T : NodeResource<T>
{
    protected NodeResource()
    {

    }

    public NodeResource(SystemNode Node, string ResourceName = null)
    {
        this.Node = Node;
        this.ResourceName = ResourceName ?? typeof(T).Name;
    }
    public SystemNode Node { get; }

    public string ResourceName { get; }

    public override string ToString()
        =>  ResourceName;


}
