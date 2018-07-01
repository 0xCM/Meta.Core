//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;    

    using static metacore;


    using N = SystemNode;

    public class NodeFilePath : NodeFileSystemEntry<FilePath>
    {
        public static implicit operator FilePath(NodeFilePath x)
            => x.AbsolutePath;

        public static NodeFilePath Empty(N node = null)
            => new NodeFilePath(node ?? SystemNode.Local, FilePath.Empty);

        public static NodeFilePath operator +(NodeFilePath parent, FileExtension ext)
            => new NodeFilePath(parent.Node, parent.AbsolutePath + ext);

        public NodeFilePath(N Node, FilePath AbsolutePath)
            : base(Node, AbsolutePath)
        { }

        public FileName FileName
            => AbsolutePath.FileName;


        public FileExtension Extension
            => AbsolutePath.Extension;

        public Option<NodeFilePath> Write(string content, bool createDir = true, bool overwrite = true)
            => from result in AbsolutePath.Write(content, createDir, overwrite).ToOption()
               let file = new NodeFilePath(Node, result.FileSystemObject)
               select file;

        public NodeFilePath UniqueName()
            => new NodeFilePath(Node, AbsolutePath.UniqueName());

        /// <summary>
        /// The path of the folder in which the file is defined
        /// </summary>
        public NodeFolderPath Folder
            => new NodeFolderPath(Node, AbsolutePath.Folder);

        /// <summary>
        /// Changes the file extension
        /// </summary>
        /// <param name="NewExtension">The new extension</param>
        /// <returns></returns>
        public NodeFilePath ChangeExtension(FileExtension NewExtension)
            => new NodeFilePath(Node, AbsolutePath.ChangeExtension(NewExtension));

        /// <summary>
        /// Appends an extension to the path
        /// </summary>
        /// <param name="Extension">The extension to append</param>
        /// <param name="OnlyIfMissing"></param>
        /// <returns></returns>
        public NodeFilePath AddExtension(FileExtension Extension, bool OnlyIfMissing = false)
            => new NodeFilePath(Node, AbsolutePath.AddExtension(Extension, OnlyIfMissing));

        /// <summary>
        /// Removes an extension, if present
        /// </summary>
        /// <returns></returns>
        public NodeFilePath RemoveExtension()
            => new NodeFilePath(Node, AbsolutePath.RemoveExtension());

        public Option<NodeFilePath> WriteLines(IEnumerable<string> lines, bool createDir = true)
            => from result in AbsolutePath.WriteLines(lines, createDir)
               select new NodeFilePath(Node, result);

        /// <summary>
        /// Deletes the file if it exists
        /// </summary>
        /// <returns></returns>
        public Option<NodeFilePath> DeleteIfExists()
            => Try(() =>
            {
                AbsolutePath.DeleteIfExists();
                return this;
            });

        public static NodeFilePath CreateTempFile(N Node, string data = null)
            => new NodeFilePath(Node, TextFile.CreateTempFile(data));

        /// <summary>
        /// Specifies the time the file was created
        /// </summary>
        public DateTime CreatedTS
            => AbsolutePath.CreatedTS();

        /// <summary>
        /// Specifies the time the file was last modified
        /// </summary>
        public DateTime? UpdatedTS
            => AbsolutePath.UpdatedTS();

        /// <summary>
        /// Specifies the maximum of created/updated
        /// </summary>
        public DateTime? ChangedTS
            => AbsolutePath.ChangedTS();

        public bool HasExtension(FileExtension x)
            => AbsolutePath.HasExtension(x);
    }
}