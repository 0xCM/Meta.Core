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
    using Meta.Core;

    using static metacore;

    public abstract class FileSystemNavigator<N> : ApplicationComponent, IFileSystemNavigator
        where N : FileSystemNavigator<N>
    {

        protected FileSystemNavigator(INodeContext C)
            : this(C, C.Host)
        {

        }

        protected FileSystemNavigator(IApplicationContext C, SystemNode Host)
            : base(C)
        {
            this.Host = Host;
            this.TopUncRoot = new NodeFolderPath(Host, "Z:\\unc");
            this.HostFolderName = FolderName.Parse(Host.NodeIdentifier);                       
        }

        /// <summary>
        /// The hosting node
        /// </summary>
        public SystemNode Host { get; }

        /// <summary>
        /// The host's canonical folder name
        /// </summary>
        protected FolderName HostFolderName { get; }

        /// <summary>
        /// The host's top UNC share
        /// </summary>
        public NodeFolderPath TopUncRoot { get; }

        public NodeFolderPath HostUncRoot
            => TopUncRoot + HostFolderName;

        protected NodeFolderPath ShareRoot(string ShareIdentifier)
            => HostUncRoot + FolderName.Parse(ShareIdentifier);

        public abstract NodeFolderPath NavRoot { get; }

        public virtual IEnumerable<NodeFolderPath> Folders
            => SegmentPaths.Any() 
            ? from s in SegmentPaths
              from f in unionize(stream(s), s.Folders(recursive: Recursive))
              select f
            : NavRoot.Folders(recursive: Recursive);

        public virtual IEnumerable<FolderName> SegmentNames
            => stream<FolderName>();

        public IEnumerable<NodeFolderPath> SegmentPaths
            => from s in SegmentNames
               select NavRoot + s;

        public virtual IEnumerable<NodeFilePath> Files
            => from folder in Folders
               from file in folder.Files()
               let include = SupportedExtensions.Any() 
                    ? SupportedExtensions.Contains(file.Extension) 
                    : true
               where include
               select file;

        public virtual IEnumerable<FileExtension> SupportedExtensions { get; }
            = rolist<FileExtension>();

        public virtual bool Recursive
            => false;

        public override string ToString()
            => NavRoot.ToString();
    }
}