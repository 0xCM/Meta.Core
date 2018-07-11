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
    using System.IO;

    using static metacore;
    using static FileSystemMessages;

    /// <summary>
    /// Defines <see cref="FolderPath"/> related extensions
    /// </summary>
    public static class FolderX
    {
        static FolderPath _CreateIfMissing(FolderPath folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
                return folder;
            }
            return folder;
        }

        /// <summary>
        /// Attempts to create the directory if it doesn't already exist and
        /// returns true if the directory was created, false if it already existed
        /// and None if an error was encountered
        /// </summary>
        /// <returns></returns>
        public static Option<FolderPath> CreateIfMissing(this IFolderPath folder)
            => Try(() => _CreateIfMissing(folder.FileSystemPath));


        /// <summary>
        /// Maps a boolean value to a <see cref="SearchOption"/>
        /// </summary>
        /// <param name="recursive">Whether search should be recursive</param>
        /// <returns></returns>
        static SearchOption RecursiveOption(bool recursive)
            => recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;


        /// <summary>
        /// Enumerates the files contained in the folder or subfolders accoring to the
        /// match criteria and recursion option
        /// </summary>
        /// <param name="match">The files to match</param>
        /// <param name="recursive">Whether to recurse subfolders</param>
        /// <returns></returns>
        public static IEnumerable<FilePath> GetFiles(this FolderPath folder, string match = null, bool recursive = false)
            => Directory.Exists(folder.FileSystemPath)
                ? Directory.EnumerateFiles(folder.FileSystemPath, ifBlank(match, "*.*"),
                        RecursiveOption(recursive)).Select(FilePath.Parse)
                : stream<FilePath>();

        /// <summary>
        /// Enumerates the files contained in the folder or subfolders accoring to the
        /// match criteria and recursion option
        /// </summary>
        /// <param name="match">The files to match</param>
        /// <param name="recursive">Whether to recurse subfolders</param>
        /// <returns></returns>
        public static IEnumerable<FilePath> Files(this FolderPath folder, string match = null, bool recursive = false)
            => folder.GetFiles(match, recursive);

        /// <summary>
        /// Enumerates the files contained in the folder or subfolders accoring to the
        /// match criteria and recursion option
        /// </summary>
        /// <param name="extensions">The file extension to match</param>
        /// <param name="recursive">Whether to recurse subfolders</param>
        /// <returns></returns>
        public static IEnumerable<FilePath> Files(this FolderPath folder, IEnumerable<FileExtension> extensions, bool recursive = false)
            => folder.GetFiles(extensions, recursive);

        /// <summary>
        /// Copies (non-recursively) the files in the folder to a target folder
        /// </summary>
        /// <param name="dstFolder">The target folder</param>
        /// <param name="match">The files to match</param>
        /// <returns></returns>
        public static IEnumerable<FileCopyResult> CopyFilesTo(this FolderPath folder, FolderPath dstFolder, string match = null)
            => from srcFile in folder.Files(match)
               select srcFile.CopyTo(dstFolder);

        /// <summary>
        /// Enumerates the folders contained in the folder or subfolders accoring to the
        /// match criteria and recursion option
        /// </summary>
        /// <param name="match">The folders to match</param>
        /// <param name="recursive">Whether to recurse subfolders</param>
        /// <returns></returns>
        public static IEnumerable<FolderPath> GetFolders(this FolderPath folder, string match = null, bool recursive = false)
        {
            if (Directory.Exists(folder.FileSystemPath))
            {
                foreach (var d in Directory.EnumerateDirectories(folder.FileSystemPath, ifBlank(match, "*.*"),
                           RecursiveOption(recursive)))
                    yield return d;
            }
        }

        /// <summary>
        /// Copies a source folder into a target folder accoring to specified options
        /// </summary>
        /// <param name="SrcFolder">The folder that will be copied</param>
        /// <param name="DstFolder">The folder that will receive the copies</param>
        /// <param name="recursive">Whether to deep-copy</param>
        /// <param name="cloneFiles">Whether to copy files</param>
        /// <param name="fileMatch">Criteria filenames must satisfy to be copied</param>
        /// <returns></returns>
        public static IEnumerable<FileCopyResult> Clone(this FolderPath SrcFolder, FolderPath DstFolder,
            bool recursive = true, bool cloneFiles = false, string fileMatch = null)
        {
            DstFolder.CreateIfMissing().Require();
            if (cloneFiles)
                foreach (var x in SrcFolder.CopyFilesTo(DstFolder, fileMatch))
                    yield return x;

            if (recursive)
                foreach (var srcSubfolder in SrcFolder.Subfolders())
                    foreach (var x in srcSubfolder.Clone(DstFolder + srcSubfolder.FolderName, recursive, cloneFiles, fileMatch))
                        yield return x;
        }


        /// <summary>
        /// Assigns an icon to a folder via the windows shell API
        /// </summary>
        /// <param name="iconFilePath">The path to the ICO file</param>
        /// <param name="tooltip">Hint text</param>
        /// <returns></returns>
        public static Option<Link<FolderPath, FilePath>> AssignIcon(this FolderPath SrcPath, FilePath iconFilePath = null, string tooltip = null)
            => Try(() =>
            {
                var icoPath = iconFilePath ?? (SrcPath + FileName.Parse("folder.ico"));
                var iniPath = SrcPath + FileName.Parse("desktop.ini");

                WinIni.WriteValue(".ShellClassInfo", "IconFile", iconFilePath, iniPath);
                WinIni.WriteValue(".ShellClassInfo", "IconIndex", 0.ToString(), iniPath);
                WinIni.WriteValue(".ShellClassInfo", "InfoTip", tooltip ?? string.Empty, iniPath);

                iniPath.SetHiddenFlag(true);
                iniPath.SetSystemFlag(true);
                if ((File.GetAttributes(SrcPath) & FileAttributes.System) != FileAttributes.System)
                    File.SetAttributes(SrcPath, File.GetAttributes(SrcPath) | FileAttributes.System);

                return link(SrcPath, icoPath);
            });

        /// <summary>
        /// Returns true if the folder exists, false otherwise
        /// </summary>
        /// <returns></returns>
        public static bool Exists(this FolderPath folder)
            => Directory.Exists(folder.FileSystemPath);

        /// <summary>
        /// Deletes the folder if it exists
        /// </summary>
        /// <returns>The path to the deleted folder if applicable</returns>
        public static Option<FolderPath> DeleteIfExists(this FolderPath folder)
            => Try(() =>
            {
                if (folder.Exists())
                    Directory.Delete(folder.FileSystemPath, true);
                return folder;
            });

        /// <summary>
        /// Creates a folder, overwriting anything that currently exists
        /// </summary>
        /// <returns></returns>
        public static Option<FolderPath> Recreate(this FolderPath folder)
            => Try(() =>
                from x in folder.DeleteIfExists()
                from y in folder.CreateIfMissing()
                select y
                );

        /// <summary>
        /// Determines whether the folder is virtualized
        /// </summary>
        /// <param name="folder">The folder to test</param>
        /// <returns></returns>
        public static bool IsLink(this FolderPath folder)
            => new FileInfo(folder.FileSystemPath).Attributes.HasFlag(FileAttributes.ReparsePoint);


        /// <summary>
        /// Constructs a <see cref="FolderPath"/> for a subdirectory
        /// </summary>
        /// <param name="folder">The parent folder</param>
        /// <param name="ChildFolder">The child folder name</param>
        /// <returns></returns>
        public static FolderPath Subfolder(this FolderPath folder, FolderName ChildFolder)
           => folder + ChildFolder;

        /// <summary>
        /// Creates a symbolick link to the folder
        /// </summary>
        /// <param name="DstLink">The folder that will receive the link</param>
        /// <param name="overwrite">Whether to overwrite an existing link if present</param>
        /// <remarks>
        /// Adapted from: https://stackoverflow.com/questions/11156754/what-the-c-sharp-equivalent-of-mklink-j
        /// </remarks>
        /// <returns></returns>
        public static Option<FolderSymLink> CreateSymLink(this FolderPath SrcPath, FolderPath DstLink, bool overwrite = true)
            => Try(() =>
            {
                if (overwrite && DstLink.IsLink())
                    DstLink.DeleteIfExists().Require();

                var succeeded = SymbolicLinks.CreateSymbolicLink(DstLink, SrcPath.FileSystemPath, SymbolicLinkKind.Directory);
                if (not(succeeded))
                    return none<FolderSymLink>(SymbolicLinkCreationFailed(SrcPath, DstLink));
                else
                    return new FolderSymLink(SrcPath, DstLink);
            });


        /// <summary>
        /// Enumerates the files contained in the folder or subfolders accoring to the
        /// match criteria and recursion option
        /// </summary>
        /// <param name="ext">The file extension to match</param>
        /// <param name="recursive">Whether to recurse subfolders</param>
        /// <returns></returns>
        public static IEnumerable<FilePath> GetFiles(this FolderPath folder, FileExtension ext, bool recursive = false)
            => Directory.Exists(folder.FileSystemPath)
              ? Directory.EnumerateFiles(folder.FileSystemPath, $"*.{ext}",
                    RecursiveOption(recursive)).Select(FilePath.Parse)
              : stream<FilePath>();

        /// <summary>
        /// Enumerates the files contained in the folder or subfolders accoring to the
        /// match criteria and recursion option
        /// </summary>
        /// <param name="ext">The file extension to match</param>
        /// <param name="recursive">Whether to recurse subfolders</param>
        /// <returns></returns>
        public static IEnumerable<FilePath> Files(this FolderPath folder, FileExtension ext, bool recursive = false)
            => folder.GetFiles(ext, recursive);

        /// <summary>
        /// Enumerates the files contained in the folder or subfolders accoring to the
        /// match criteria and recursion option
        /// </summary>
        /// <param name="extensions">The file extension to match</param>
        /// <param name="recursive">Whether to recurse subfolders</param>
        /// <returns></returns>
        public static IEnumerable<FilePath> GetFiles(this FolderPath folder, IEnumerable<FileExtension> extensions, bool recursive = false)
        {
            if (Directory.Exists(folder.FileSystemPath))
            {
                var match = extensions.Select(x => $".{x.Value}").ToReadOnlySet();
                var query = from file in Directory.EnumerateFiles(folder.FileSystemPath, "*.*", RecursiveOption(recursive))
                            where file.EndsWithAny(match)
                            select FilePath.Parse(file);
                return query;
            }
            else
                return stream<FilePath>();
        }

        /// <summary>
        /// The paths to the folder's top-level subfolders
        /// </summary>
        public static IEnumerable<FolderPath> Subfolders(this FolderPath folder)
            => from subfolder in folder.GetFolders()
               select subfolder;

        /// <summary>
        /// Returns true if a specified file is contained (directly) by the folder
        /// </summary>
        public static bool ContainsFile(this FolderPath folder, FileName name) 
            => (folder + name).Exists();

        /// <summary>
        /// Gets the parent folder, if it exists
        /// </summary>
        public static Option<FolderPath> ParentFolder(this FolderPath folder)
            => ifNotNull(Directory.GetParent(folder.FileSystemPath),
                    p => some(new FolderPath(p.FullName)),
                    () => none<FolderPath>());
    

        /// <summary>
        /// Gets the current folder relative to the environment
        /// </summary>
        /// <param name="env">The system environment</param>
        /// <returns></returns>
        public static FolderPath CurrentFolder(this IEnvironment env)
            => FolderPath.Parse(Environment.CurrentDirectory);

    }
}