//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using static metacore;


    using I = SystemNodeIdentifier;

    public struct NodeFolderIdentifier : IEquatable<NodeFolderIdentifier>
    {
        public static implicit operator string(NodeFolderIdentifier x)
            => x.ToString();

        public NodeFolderIdentifier(I NodeIdentifier, RelativePath Folder)
        {
            this.NodeIdentifier = NodeIdentifier;
            this.Folder = Folder;
        }

        public I NodeIdentifier { get; }

        public RelativePath Folder { get; }

        public bool Equals(NodeFolderIdentifier other)
            => string.Compare(this, other, true) == 0;

        public override int GetHashCode()
            => this.ToString().GetHashCode();

        public override string ToString()
            => concat(NodeIdentifier, "/",Folder.ToString().RightOf(NodeIdentifier).Replace('\\', '/'));

        public override bool Equals(object obj)
            => (obj is NodeFolderIdentifier) 
            ? Equals(cast<NodeFolderIdentifier>(obj)) 
            : false;
    }

}