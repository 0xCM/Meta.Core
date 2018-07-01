//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

using static metacore;

public class NodeUncRoot : ValueObject<NodeUncRoot>
{
    public static implicit operator NodeUncRoot((SystemNode node, FolderName root) x)
        => new NodeUncRoot(x.node, x.root);

    public static implicit operator UncRoot(NodeUncRoot x)
        => x.Folder;

    public NodeUncRoot(SystemNode Node, FolderName UncRoot)
    {
        this.Node = Node;
        this.Folder = UncRoot;
    }


    public SystemNode Node { get; }

    public FolderName Folder { get; }

    public override string ToString()
        => $"//{Node}/{Folder}";
}