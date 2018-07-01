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
    using System.IO;

    using static metacore;


    using N = SystemNode;

    public class NodeFileSystemEntry<F> : INodeFileSystemObject
        where F : IFileSystemObject
    {
        public static readonly SystemUri.SchemeSegment Scheme = "nfs";

        public NodeFileSystemEntry(N Node, F AbsolutePath)
        {
            this.Node = Node;
            this.AbsolutePath = AbsolutePath;
        }

        public N Node { get; }


        public F AbsolutePath { get; }

        public string ObjectName
            => AbsolutePath.ToString();

        string NodeIdentifier
            => $"{Node.NodeIdentifier.IdentifierText.ToLower()}";

        public bool Exists()
            => File.Exists(AbsolutePath.ToString());

        string IFileSystemObject.FileSystemPath
            => AbsolutePath.ToString();

        string UnrootedPath
        {
            get
            {
                var str = AbsolutePath.ToString();
                if (str.StartsWith("\\\\"))
                    return str.RightOf("\\\\");
                if (str.Contains(":"))
                    return str.RightOf(":");
                return str;                
            }
        }

        public override string ToString()
            => concat
                (
                    Scheme,
                    "://",
                    NodeIdentifier,
                    "/",
                    UnrootedPath.Replace('\\', '/')
                );


        public SystemUri ToSystemUri()
            => new SystemUri(Scheme, NodeIdentifier, UnrootedPath.Replace('\\', '/'));
    }



}