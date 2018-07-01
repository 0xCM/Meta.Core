//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using static metacore;

    using N = SystemNode;

    
    public class NodeFileSystemNavigator 
    {
        public NodeFileSystemNavigator(N Host, NodeFileSystemRoot Root)
        {
            this.Root = Root;
            this.Host = Host;
        }

        public NodeFileSystemRoot Root { get; }

        public N Host { get; }

        public override string ToString()
            => $"nfs://{Host.NodeIdentifier}";


    }


}