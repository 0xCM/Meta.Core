//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

using static metacore;

public class SystemNodeDescription : ValueObject<SystemNodeDescription>
{
    public SystemNodeDescription(SystemNode DescribedNode, params INodeResource[] Resources)
    {
        this.DescribedNode = DescribedNode;
        this.Resources = rolist(Resources);
    }
    public SystemNode DescribedNode { get; }
    public ReadOnlyList<INodeResource> Resources { get; }

    public override string ToString()
        => $"{DescribedNode}";
}
