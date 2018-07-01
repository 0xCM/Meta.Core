//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Meta.Core;

    using static metacore;

    using DistId = DistributionIdentifier;
    using N = SystemNode;

    partial class Distribution
    {

        public class DistributionNavigator : FileSystemNavigator<DistributionNavigator>
        {

            public DistributionNavigator(INodeContext C, FolderPath HostRoot)
                : base(C)
            {

                NavRoot = new NodeFolderPath(Host, HostRoot);
            }

            public NodeFolderPath DistributionLocation(DistId Identifier)
                => (NavRoot + FolderName.Parse(Identifier));

            public IEnumerable<NodeFolderPath> SegmentFolders(DistId Identifier)
                => DistributionLocation(Identifier).Folders();


            public override NodeFolderPath NavRoot { get; }

            public IEnumerable<NodeFolderPath> DistributionLocations
                => NavRoot.Folders();
        }
    }
}