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

    using N = SystemNode;

    using Meta.Core.Resources;

    /// <summary>
    /// Defines extensions related to node file/folder paths
    /// </summary>
    public static class NodeFileX
    {
        /// <summary>
        /// Obtains a reference to an implementation of the <see cref="INodeFileSystem"/> service
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>
        public static INodeFileSystem NFS(this IApplicationContext C)
            => C.Service<INodeFileSystem>(nameof(MinimalNodeFileSystem));

        public static RelativePath RelativeTo(this NodeFilePath File, FolderPath Folder)
        {
            var srcUri = new Uri(File.AbsolutePath);
            var rootUri = new Uri(Folder);
            var relUri = rootUri.MakeRelativeUri(srcUri);
            return relUri.ToString();
        }

        public static FolderPath AbsoluteLocation(this INodeFileSystemLocator locator, N node, RelativePath relative)
                    => locator.UncShare(node, relative).Share.SharePath;

        public static IResourceCatalog SubjectCatalog(this IApplicationContext C)
            => C.Service<IResourceCatalog>();

        /// <summary>
        /// Moves a file from A to B
        /// </summary>
        /// <param name="Flow">The source/target</param>
        /// <returns></returns>
        public static Option<Link<NodeFilePath>> Move(this Link<NodeFilePath> Flow, bool overwrite = true, bool createFolder = true)
            => Flow.Source.AbsolutePath.MoveTo(Flow.Target.AbsolutePath, src => new NodeFilePath(Flow.Target.Node, src),  overwrite, createFolder)
                   .Map(x => new Link<NodeFilePath>(Flow.Source, new NodeFilePath(Flow.Target.Node, x)));

        /// <summary>
        /// Defines a node-relative file path
        /// </summary>
        /// <param name="n">The node to which the path is relative</param>
        /// <param name="file">The absolute location of the file on the node</param>
        /// <returns></returns>
        public static NodeFilePath NodeFile(this N n, FilePath file)
            => new NodeFilePath(n, file);

        /// <summary>
        /// Defines a node relative folder path
        /// </summary>
        /// <param name="n"></param>
        /// <param name="AbsolutePath"></param>
        /// <returns></returns>
        public static NodeFolderPath NodeFolder(this N n, FolderPath AbsolutePath)
            => new NodeFolderPath(n, AbsolutePath);

        public static Option<Link<NodeFilePath>> CopyTo(this NodeFilePath SrcPath, NodeFilePath DstPath, bool overwrite = true)
            => from result in SrcPath.AbsolutePath.CopyTo(DstPath.AbsolutePath, overwrite)
               select new Link<NodeFilePath>(SrcPath, (new NodeFilePath(DstPath.Node, result)));

        public static Option<Link<NodeFilePath>> CopyTo(this NodeFilePath SrcPath, NodeFolderPath DstPath, bool overwrite = true)
            => from result in SrcPath.AbsolutePath.CopyTo(DstPath + SrcPath.FileName, overwrite)
               select new Link<NodeFilePath>(SrcPath, (new NodeFilePath(DstPath.Node, result)));

        public static Option<Link<NodeFilePath>> MoveTo(this NodeFilePath SrcPath, NodeFilePath DstPath, bool overwrite = true, bool createFolder = true)
            => from result in SrcPath.AbsolutePath.MoveTo(DstPath.AbsolutePath, x => new NodeFilePath(DstPath.Node, x), overwrite, createFolder)
               select new Link<NodeFilePath>(SrcPath, new NodeFilePath(DstPath.Node, result));

        public static Option<Link<NodeFilePath>> MoveTo(this NodeFilePath SrcPath, NodeFolderPath DstFolder, bool overwrite = true, bool createFolder = true)
            => from result in SrcPath.AbsolutePath.MoveTo(DstFolder + SrcPath.FileName, x => new NodeFilePath(DstFolder.Node, x), overwrite, createFolder)
               select new Link<NodeFilePath>(SrcPath, (new NodeFilePath(DstFolder.Node, result)));

    }
}
