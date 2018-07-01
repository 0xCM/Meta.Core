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
    using System.Linq;

    using static metacore;


    using N = SystemNode;

    public class NodeFolderPath : NodeFileSystemEntry<FolderPath>
    {
        public static readonly NodeFolderPath Empty = new NodeFolderPath(N.Local, FolderPath.Empty);

        public static NodeFolderPath Define(N Host, FolderPath AbsolutePath)
            => new NodeFolderPath(Host, AbsolutePath);

        public static NodeFolderPath operator + (NodeFolderPath parent, FolderName child)
            => isNull(parent) 
            ? NodeFolderPath.Empty 
            : new NodeFolderPath(parent.Node, parent.AbsolutePath + (child ?? FolderName.None));

        public static NodeFilePath operator +(NodeFolderPath parent, FileName child)
            => new NodeFilePath(parent.Node, parent.AbsolutePath + child);

        public static implicit operator NodeFolderPath(FolderPath AbsolutePath)
            => new NodeFolderPath(N.Local, AbsolutePath);


        public static implicit operator FolderPath(NodeFolderPath x)
            => x?.AbsolutePath ?? FolderPath.Empty;

        public NodeFolderPath(N Node, FolderPath AbsolutePath)
            : base(Node, AbsolutePath)
        { }

        public FolderName FolderName
            => AbsolutePath.FolderName;

        public Option<NodeFolderPath> CreateIfMissing()
            => from creation in AbsolutePath.CreateIfMissing()
               select new NodeFolderPath(Node, creation);

        public Option<NodeFilePath> File(FileName FileName)
           => new NodeFilePath(Node, AbsolutePath + FileName).Exists()
                ? this + FileName
                : none<NodeFilePath>();

        /// <summary>
        /// Returns true if the path is unspecified
        /// </summary>
        public bool IsUnspecified
            => AbsolutePath.IsUnspecified;

        public IEnumerable<NodeFilePath> Files(FileExtension match, bool recursive = false)
            => (match != null && !match.IsEmpty)
            ? Files($"*.{match}", recursive)
                : Files("*.*", recursive);            

        public IEnumerable<NodeFilePath> Files(IEnumerable<FileExtension> extensions, bool recursive = false)
            => extensions.Any()
            ? Files(recursive: recursive).Where(f => extensions.Contains(f.Extension))
            : Files(recursive: recursive);

        public IEnumerable<NodeFilePath> Files(string match = null, bool recursive = false)
            => from f in AbsolutePath.Files(match, recursive)
               select new NodeFilePath(Node, f.FileSystemPath);

        public IEnumerable<NodeFolderPath> Folders(string match = null, bool recursive = false)
            => from f in AbsolutePath.GetFolders(match, recursive)
               select new NodeFolderPath(Node, f);

        public Option<NodeFolderPath> ParentFolder
            => AbsolutePath.ParentFolder().Map(x => new NodeFolderPath(Node, x));
    }


}