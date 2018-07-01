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

    public static class FileArchiveExtensions
    {
        static IEnumerable<Link<FilePath>> ArchiveFlows(FolderPath Src, FolderPath Dst)
            => from src in Src.Files()
               let dst = Dst + src.FileName.ChangeExtension("zip")
               select new Link<FilePath>(src, dst);

        static IEnumerable<Link<FilePath>> ArchiveFlows(FolderPath SrcFolder, string Match, FolderPath DstFolder)
            => from src in SrcFolder.Files(Match)
               let dst = DstFolder + src.FileName.ChangeExtension("zip")
               select new Link<FilePath>(src, dst);

        public static Option<Link<FilePath, ReadOnlyList<FilePath>>> ExpandArchive(this IFileArchiveManager ArchiveManager, Link<FilePath, FolderPath> flow)
            => ArchiveManager.ExpandArchive(flow.Source, flow.Target);

        public static Option<Link<FilePath, FilePath>> ExpandArchive(this IFileArchiveManager ArchiveManager, Link<FilePath, FilePath> flow)
            => ArchiveManager.ExpandArchive(flow.Source, flow.Target);

        public static IEnumerable<Option<Link<FilePath, ReadOnlyList<FilePath>>>> ExtractFiles(this IFileArchiveManager ArchiveManager, FolderPath SrcFolder, FolderPath DstFolder)
            => from src in SrcFolder.Files()
               let dst = FolderPath.Parse(DstFolder)
               select ArchiveManager.ExpandArchive(new Link<FilePath, FolderPath>(src, dst));

    }

}