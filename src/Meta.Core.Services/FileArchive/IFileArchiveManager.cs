//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;

    
    using FilesToArchive = Link<ReadOnlyList<FilePath>, FilePath>;
    using ArchiveToFiles = Link<FilePath, ReadOnlyList<FilePath>>;    
    using ArchiveToFile = Link<FilePath, FilePath>;
    using NodeFileList = ReadOnlyList<NodeFilePath>;

    /// <summary>
    /// Defines operations for file archive manipulation
    /// </summary>
    public interface IFileArchiveManager : IApplicationService
    {

        Option<Link<NodeFolderPath, NodeFilePath>> CreateArchive(NodeFolderPath SrcDir, NodeFilePath DstPath, bool Overwrite = true, AppMessageObserver Observer = null);

        Option<Link<NodeFileList, NodeFilePath>> CreateArchive(IEnumerable<NodeFilePath> Src, NodeFilePath Dst, bool Overwrite = true);

        Option<Link<NodeFilePath>> CreateArchive(NodeFilePath Src, NodeFilePath Dst, bool Overwrite = true);

        Option<Link<NodeFilePath>> CreateArchive(Link<NodeFilePath> Path, bool Ovewrwrite = true);

        IEnumerable<Option<Link<NodeFilePath>>> CreateArchives(Link<NodeFolderPath> Path, bool Overwrite = true, bool PLL = true);

        Option<Link<FolderPath, FilePath>> CreateArchive(FolderPath SrcDir, FilePath DstPath, bool Overwrite = true,  AppMessageObserver Observer = null);

        /// <summary>
        /// Creates a file archive for one or more files
        /// </summary>
        /// <param name="Src">Paths to the source files</param>
        /// <param name="Dst">Path to the target archive file</param>
        /// <returns></returns>
        Option<FilesToArchive> CreateArchive(IEnumerable<FilePath> Src, FilePath Dst, bool Overwrite = true);

        /// <summary>
        /// Creates a file archive for one file
        /// </summary>
        /// <param name="Src">Path to the source file</param>
        /// <param name="Dst">Path to the target archive file</param>
        /// <returns></returns>
        Option<Link<FilePath>> CreateArchive(FilePath Src, FilePath Dst, bool Overwrite = true);

        /// <summary>
        /// Creates an archive from a file
        /// </summary>
        /// <param name="Path">The data flow path</param>
        /// <returns></returns>
        Option<Link<FilePath>> CreateArchive(Link<FilePath> Path, bool Overwrite = true);

        /// <summary>
        /// Creates an archive based on the content of a folder
        /// </summary>
        /// <param name="Path">A linke from the source folder to the target archive path</param>
        /// <returns></returns>
        Option<FilesToArchive> CreateArchive(Link<FolderPath, FilePath> Path, bool Overwrite = true);

        /// <summary>
        /// Creates an archive for each file in a folder
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        IEnumerable<Option<Link<FilePath>>> CreateArchives(Link<FolderPath> Path, bool Overwrite = true, bool PLL = true);

        /// <summary>
        /// Extracts one or more files in an archive to a folder
        /// </summary>
        /// <param name="Src"></param>
        /// <param name="Dst"></param>
        /// <param name="Overwrite"></param>
        /// <returns></returns>
        Option<ArchiveToFiles> ExpandArchive(FilePath Src, FolderPath Dst, bool Overwrite = true);

        /// <summary>
        /// Expands an archive containing a single file
        /// </summary>
        /// <param name="Src"></param>
        /// <param name="Dst"></param>
        /// <param name="Overwrite"></param>
        /// <returns></returns>
        Option<ArchiveToFile> ExpandArchive(FilePath Src, FilePath Dst, bool Overwrite = true);

        /// <summary>
        /// Expands an archive containing a single file
        /// </summary>
        /// <param name="path">The data flow path</param>
        /// <returns></returns>
        Option<Link<FilePath, FilePath>> ExpandArchive(Link<FilePath, FilePath> path, bool Overwrite = true);

        /// <summary>
        /// Expands one or more archives to a folder
        /// </summary>
        /// <param name="Src">The archives to expand</param>
        /// <param name="Dst">The target folder</param>
        /// <param name="Overwrite"></param>        
        /// <param name="PLL">Indicates whether to execute concurrently</param>
        /// <returns></returns>
        IEnumerable<Option<ArchiveToFiles>> ExpandArchives(IEnumerable<FilePath> Src, FolderPath Dst, bool Overwrite = true, bool PLL = true);


        Option<Link<FilePath, ReadOnlyList<FilePath>>> ExpandArchive(Link<FilePath, FolderPath> flow, bool Overwrite = true);


        IEnumerable<Option<Link<FilePath, ReadOnlyList<FilePath>>>> ExpandArchives(FolderPath SrcFolder, FolderPath DstFolder, bool Overwrite = true);


        

    }
}