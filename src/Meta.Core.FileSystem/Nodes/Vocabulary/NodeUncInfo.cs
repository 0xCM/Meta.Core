//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    public class NodeUncInfo : ValueObject<NodeUncInfo>
    {

        public NodeUncInfo(SystemNode Node, UncRoot Root, DriveLetter DriveLetter, params FolderName[] TopShareNames)
        {
            this.Node = Node;
            this.UncRoot = new NodeUncRoot(Node, Root);
            this.DriveLetter = new NodeDriveLetter(Node, DriveLetter);
            this.TopShareNames = TopShareNames;
        }

        public SystemNode Node { get; }

        public NodeDriveLetter DriveLetter { get; }

        public NodeUncRoot UncRoot { get; }

        public IReadOnlyList<FolderName> TopShareNames { get; }

        public override string ToString()
            => $"//{Node.NetworkName}/{UncRoot}";

    }

}