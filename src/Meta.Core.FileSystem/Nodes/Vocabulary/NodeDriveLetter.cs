//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using static metacore;

    /// <summary>
    /// Represents a drive letter on an identified node
    /// </summary>
    public class NodeDriveLetter : ValueObject<NodeDriveLetter>
    {
        public static implicit operator NodeDriveLetter((SystemNode node, DriveLetter letter) x)
            => new NodeDriveLetter(x.node, x.letter);

        public static implicit operator DriveLetter(NodeDriveLetter x)
            => x.DriveLetter;

        public static NodeFolderPath operator +(NodeDriveLetter x, FolderName y)
            => new NodeFolderPath(x.Node,  $"{x}:\\{y}");

        public static implicit operator NodeFolderPath(NodeDriveLetter x)
            => new NodeFolderPath(x.Node, x.DriveLetter);

        public NodeDriveLetter(SystemNode Node, DriveLetter DriveLetter)
        {
            this.Node = Node;
            this.DriveLetter = DriveLetter;
        }

        public SystemNode Node { get; }

        public DriveLetter DriveLetter { get; }
        

        public override string ToString()
            => $"{DriveLetter}:\\{Node}";
    }
}