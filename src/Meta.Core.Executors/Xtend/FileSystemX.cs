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
    
    using Meta.Core.Commands;

    using static metacore;
    using static FileSystemMessages;
    using FlowOneToMany = Link<FilePath, ReadOnlyList<FilePath>>;

    public static class ZipFileX
    {
        static IEnumerable<Link<FilePath>> ArchiveFlows(FolderPath SrcFolder, FolderPath DstFolder)
            => from src in SrcFolder.Files()
               let dst = DstFolder + src.FileName.ChangeExtension("zip")
               select new Link<FilePath>(src, dst);

        static IEnumerable<Link<FilePath>> ArchiveFlows(FolderPath SrcFolder, string Match, FolderPath DstFolder)
            => from src in SrcFolder.Files(Match)
               let dst = DstFolder + src.FileName.ChangeExtension("zip")
               select new Link<FilePath>(src, dst);

        /// <summary>
        /// Creates a zip archive from one file
        /// </summary>
        /// <param name="C">The context</param>
        /// <param name="SrcFile">Path to the file that will be archived</param>
        /// <param name="DstFile">Path to which the archive will be written</param>
        public static Option<Link<FilePath>> ZipFile(this IApplicationContext C, FilePath SrcFile, FilePath DstFile)
        {
            var cmd = CreateFileArchive.DefineZipFileCommand(SrcFile, DstFile);
            var result = C.CPS().ExecuteCommand(cmd);
            return result.IsSome
                ? some(new Link<FilePath>(SrcFile, DstFile))
                : none<Link<FilePath>>(result.Message);                   
        }

        /// <summary>
        /// Creates a zip archive from one file
        /// </summary>
        /// <param name="C">The context</param>
        /// <param name="Flow">The source/target</param>
        public static Option<Link<FilePath>> ZipFile(this IApplicationContext C, Link<FilePath> Flow)
        {
            var cmd = CreateFileArchive.DefineZipFileCommand(Flow.Source, Flow.Target);
            var result = C.CPS().ExecuteCommand(cmd);
            return result.IsSome
                ? some(Flow)
                : none<Link<FilePath>>(result.Message);
        }

        /// <summary>
        /// Creates a zip archive from the contents of a Folder
        /// </summary>
        /// <param name="C">The context</param>
        /// <param name="SrcFolder">Path to the folder that will be archived</param>
        /// <param name="DstFile">Path to which the archive will be written</param>
        public static Option<FilePath> ZipDir(this IApplicationContext C,  
            FolderPath SrcFolder, FilePath DstFile)
        {
            var command = CreateFileArchive.DefineZipDirCommand(SrcFolder, DstFile);
            var result = C.CPS().Execute(command);
            return result.IsNone()
                ? result.ToNone<FilePath>()
                : new Option<FilePath>(DstFile, ArchivedFolder(SrcFolder, DstFile));
        }

        /// <summary>
        /// Creates a zip archive for each file in a folder
        /// </summary>
        /// <param name="C">The context</param>
        /// <param name="SrcFolder">The folder that contains the files to be archived</param>
        /// <param name="DstFolder">The folder that will receive the archived files</param>
        /// <param name="PLL">Whether operations should be executed concurently</param>
        public static void ZipDirFiles(this IApplicationContext C, 
                FolderPath SrcFolder, FolderPath DstFolder, bool PLL = true)
                    => iter(SrcFolder.CreateFileArchiveCommands(DstFolder),
                        command => C.Notify(C.CPS().ExecuteCommand(command).Message), PLL);

        /// <summary>
        /// Extracts each zip archive in a folder
        /// </summary>
        /// <param name="C"></param>
        /// <param name="SrcFolder">The folder that contains the zip archives</param>
        /// <param name="DstFolder">The folder that will receive the archive extractions</param>
        /// <param name="PLL">Whether operations should be executed concurently</param>
        /// <returns></returns>
        public static IEnumerable<Option<FlowOneToMany>> UnzipDirFiles(this IApplicationContext C,
            FolderPath SrcFolder, FolderPath DstFolder, bool PLL = true)
                => C.FileArchiveManager().ExpandArchives(SrcFolder.Files("*.zip"), DstFolder, true, PLL);


        public static IEnumerable<Option<Link<FilePath>>> ArchiveFiles(this IApplicationContext C, FolderPath SrcFolder, FolderPath DstFolder)
            => from flow in ArchiveFlows(SrcFolder, DstFolder)
               select C.ZipFile(flow);

        public static IEnumerable<Option<Link<FilePath>>> ArchiveFiles(this IApplicationContext C, Link<FolderPath> Path)
            => from flow in ArchiveFlows(Path.Source, Path.Target)
               select C.ZipFile(flow);

        public static IEnumerable<Option<Link<FilePath>>> ArchiveFiles(this IApplicationContext C, FolderPath SrcFolder, string Match, FolderPath DstFolder)
            => from flow in ArchiveFlows(SrcFolder, Match, DstFolder)
               select C.ZipFile(flow);
    }
}