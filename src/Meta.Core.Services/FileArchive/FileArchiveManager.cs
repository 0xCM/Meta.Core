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
    using System.IO.Compression;
    

    using static metacore;
    using static ArchiveManagerMessages;

    using FlowManyToOne = Link<ReadOnlyList<FilePath>, FilePath>;
    using FlowOneToOne = Link<FilePath, FilePath>;
    using FlowOneToMany = Link<FilePath, ReadOnlyList<FilePath>>;
    using NodeFiles = ReadOnlyList<NodeFilePath>;

    class FileArchiveManager : ApplicationService<FileArchiveManager, IFileArchiveManager>, IFileArchiveManager
    {
        public FileArchiveManager(IApplicationContext C)
            : base(C) { }

       

        ZipArchiveEntry CreateEntry(FolderPath SrcDir, FilePath SrcFile, ZipArchive archive)
        {
            var entryName = SrcFile.Value.Replace(SrcDir.Value, string.Empty).RightOf('\\');
            var entry = archive.CreateEntry(entryName, CompressionLevel.Optimal);
            entry.LastWriteTime = SrcFile.UpdatedTS();             
            return entry;
        }

        public Option<Link<NodeFolderPath, NodeFilePath>> CreateArchive(NodeFolderPath SrcDir, 
            NodeFilePath DstPath,  bool Overwrite = true, AppMessageObserver Observer = null)
        {
            try
            {
                DstPath.Folder.CreateIfMissing();

                var dstPath = Overwrite
                    ? DstPath.DeleteIfExists().Require()
                    : (DstPath.Exists() ? DstPath.UniqueName() : DstPath);

                using (var stream = new FileStream(dstPath.AbsolutePath, FileMode.OpenOrCreate))
                {
                    using (var archive = new ZipArchive(stream, ZipArchiveMode.Create))
                    {
                        foreach (var srcFile in SrcDir.Files("*.*", true))
                        {

                            Observer?.Invoke(AddingFileToArchive(srcFile, dstPath));
                            var entry = CreateEntry(SrcDir, srcFile, archive);
                            using (var writer = new StreamWriter(entry.Open()))
                            using (var reader = new StreamReader(srcFile.AbsolutePath))
                                reader.BaseStream.CopyTo(writer.BaseStream);
                        }
                    }

                }
                return link(SrcDir, dstPath);
            }
            catch (Exception e)
            {
                return none<Link<NodeFolderPath, NodeFilePath>>(e);
            }
        }

        public Option<Link<FolderPath,FilePath>> CreateArchive(FolderPath SrcDir, FilePath DstPath, 
            bool Overwrite = true, AppMessageObserver Observer = null)
        {
            try
            {
                DstPath.Folder.CreateIfMissing();

                var dstPath = Overwrite
                    ? DstPath.DeleteIfExists().Require()
                    : (DstPath.Exists() ? DstPath.UniqueName() : DstPath);

                using (var stream = new FileStream(DstPath, FileMode.OpenOrCreate))
                {
                    using (var archive = new ZipArchive(stream, ZipArchiveMode.Create))
                    {
                        foreach (var srcFile in SrcDir.Files("*.*", true))
                        {

                            Observer?.Invoke(AddingFileToArchive(srcFile, dstPath));
                            var entry = CreateEntry(SrcDir, srcFile, archive);
                            using (var writer = new StreamWriter(entry.Open()))
                            using (var reader = new StreamReader(srcFile))
                                reader.BaseStream.CopyTo(writer.BaseStream);
                        }
                    }

                }
                return link(SrcDir, dstPath);
            }
            catch(Exception e)
            {
                return none<Link<FolderPath, FilePath>>(e);
            }
        }

        public Option<Link<NodeFilePath>> CreateArchive(NodeFilePath Src, NodeFilePath Dst, 
            bool Overwrite = true)
                => from link in CreateArchive(stream(Src), Dst, Overwrite)
                   select new Link<NodeFilePath>(link.Source.Single(), link.Target);

        public Option<Link<NodeFiles, NodeFilePath>> CreateArchive(IEnumerable<NodeFilePath> Src, 
            NodeFilePath Dst, bool Overwrite = true)
        {
            try
            {
                var folder = Dst.Folder.CreateIfMissing();
                if (folder.IsNone())
                    return folder.ToNone<Link<NodeFiles, NodeFilePath>>();

                var dstPath = Overwrite
                    ? Dst.DeleteIfExists().Require()
                    : (Dst.Exists() ? Dst.UniqueName() : Dst);

                using (var stream = new FileStream(Dst.AbsolutePath, FileMode.OpenOrCreate))
                {
                    using (var archive = new ZipArchive(stream, ZipArchiveMode.Create))
                    {
                        foreach (var srcFile in Src)
                        {
                            var entry = CreateEntry(srcFile.Folder.AbsolutePath, srcFile.AbsolutePath, archive);
                            using (var writer = new StreamWriter(entry.Open()))
                            using (var reader = new StreamReader(srcFile.AbsolutePath))
                                reader.BaseStream.CopyTo(writer.BaseStream);
                        }
                    }

                    return new Link<ReadOnlyList<NodeFilePath>, NodeFilePath>(metacore.rolist(Src), Dst);
                }
            }
            catch (Exception e)
            {
                return none<Link<NodeFiles, NodeFilePath>>(e);
            }
        }

        public Option<FlowManyToOne> CreateArchive(IEnumerable<FilePath> Src, FilePath Dst, bool Overwrite = true)
        {
            try
            {
                var folder = Dst.Folder.CreateIfMissing();
                if (folder.IsNone())
                    return folder.ToNone<FlowManyToOne>();

                var dstPath = Overwrite
                    ? Dst.DeleteIfExists().Require()
                    : (Dst.Exists() ? Dst.UniqueName() : Dst);

                using (var stream = new FileStream(dstPath, FileMode.OpenOrCreate))
                {
                    using (var archive = new ZipArchive(stream, ZipArchiveMode.Create))
                    {
                        foreach (var srcFile in Src)
                        {
                            var entry = CreateEntry(srcFile.Folder, srcFile, archive);
                            using (var writer = new StreamWriter(entry.Open()))
                            using (var reader = new StreamReader(srcFile))
                                reader.BaseStream.CopyTo(writer.BaseStream);
                        }
                    }

                    return new FlowManyToOne(metacore.rolist(Src), dstPath);
                }
            }
            catch (Exception e)
            {
                return none<FlowManyToOne>(e);
            }
        }


        /// <summary>
        /// Creates a zip archive from one file
        /// </summary>
        /// <param name="Src">Path to the file that will be archived</param>
        /// <param name="Dst">Path to which the archive will be written</param>
        public Option<Link<FilePath>> CreateArchive(FilePath Src, FilePath Dst, bool Overwrite = true)
            => CreateArchive(stream(Src), Dst, Overwrite).Map(x => new Link<FilePath>(x.Source.Single(), Dst));

        public Option<Link<FilePath>> CreateArchive(Link<FilePath> Path, bool Overwrite = true)
            => CreateArchive(Path.Source, Path.Target, Overwrite);

        public Option<Link<NodeFilePath>> CreateArchive(Link<NodeFilePath> Path, bool Overwrite = true)
            => CreateArchive(Path.Source, Path.Target, Overwrite);

        public Option<FlowManyToOne> CreateArchive(Link<FolderPath, FilePath> Path, bool Overwrite = true)
            => CreateArchive(Path.Source.Files(recursive:true), Path.Target, Overwrite);

        Link<ZipArchiveEntry, FilePath> Expand(ZipArchiveEntry Src, FilePath Dst)
        {
            Notify(ExtractingFile(Src.Name, Dst));
            
            Dst.Folder.CreateIfMissing().Require();            
            using (var reader = new StreamReader(Src.Open()))
            using (var writer = new StreamWriter(Dst))
                reader.BaseStream.CopyTo(writer.BaseStream);
            Dst.UpdatedTS(Src.LastWriteTime.LocalDateTime);
            return link(Src,Dst);
        }

        public Option<FlowOneToMany> ExpandArchive(FilePath Src, FolderPath Dst, bool Overwrite = true)
        {
            try
            {
                Dst.CreateIfMissing().Require();

                var paths = MutableList.Create<FilePath>();
                using (var stream = new FileStream(Src, FileMode.Open))
                {
                    using (var archive = new ZipArchive(stream, ZipArchiveMode.Read))
                    {
                        foreach (var entry in archive.Entries)
                        {
                            var dstPath = Dst.GetCombinedFilePath(RelativePath.Parse(entry.FullName));
                            if (dstPath.Exists() && not(Overwrite))
                                dstPath = dstPath.UniqueName();
                            else
                                dstPath.DeleteIfExists().Require();                            
                            paths.Add(Expand(entry, dstPath).Target);
                        }

                    }
                }
                return new FlowOneToMany(Src, paths.ToReadOnlyList());
            }
            catch (Exception e)
            {
                return none<FlowOneToMany>(e);
            }
        }

        public IEnumerable<Option<Link<FilePath>>> CreateArchives(Link<FolderPath> Path, bool Overwrite = true, 
            bool PLL = true)
                => PLL
                    ? from srcFile in Path.Source.Files().AsParallel()
                      let dstFile = Path.Target + srcFile.FileName.ChangeExtension(".zip")
                      select CreateArchive(link(srcFile,dstFile), Overwrite)
                   : from srcFile in Path.Source.Files()
                     let dstFile = Path.Target + srcFile.FileName.ChangeExtension(".zip")
                     select CreateArchive(link(srcFile,dstFile), Overwrite);

        public IEnumerable<Option<Link<NodeFilePath>>> CreateArchives(Link<NodeFolderPath> Path, bool Overwrite = true, 
            bool PLL = true)
                => PLL
                    ? from srcFile in Path.Source.Files().AsParallel()
                      let dstFile = Path.Target + srcFile.FileName.ChangeExtension(".zip")
                      select CreateArchive(link(srcFile,dstFile),Overwrite)
                   : from srcFile in Path.Source.Files()
                     let dstFile = Path.Target + srcFile.FileName.ChangeExtension(".zip")
                     select CreateArchive(link(srcFile,dstFile),Overwrite);

        public Option<Link<FilePath, ReadOnlyList<FilePath>>> ExpandArchive(Link<FilePath, FolderPath> flow, bool Overwrite = true)
            => ExpandArchive(flow.Source, flow.Target, Overwrite);

        public Option<Link<FilePath, FilePath>> ExpandArchive(Link<FilePath, FilePath> flow, bool Overwrite = true)
            => ExpandArchive(flow.Source, flow.Target, Overwrite);
    
        public IEnumerable<Option<Link<FilePath, ReadOnlyList<FilePath>>>> ExpandArchives(FolderPath SrcFolder, 
            FolderPath DstFolder, bool Overwrite = true)
                => from src in SrcFolder.Files()
                   let dst = FolderPath.Parse(DstFolder)
                   select ExpandArchive(new Link<FilePath, FolderPath>(src, dst), Overwrite);

        public IEnumerable<Option<FlowOneToMany>> ExpandArchives(IEnumerable<FilePath> Src, FolderPath Dst, bool Overwrite = true, 
            bool PLL = true)
                => PLL ? from point in Src.AsParallel()
                            select ExpandArchive(point, Dst, Overwrite)
                       : from point in Src
                           select ExpandArchive(point, Dst, Overwrite);

        public Option<FlowOneToOne> ExpandArchive(FilePath Src, FilePath Dst, bool Overwrite = true)
        {
            try
            {
                var dstPath = Overwrite 
                    ? Dst.DeleteIfExists().Require()
                    : (Dst.Exists() ? Dst.UniqueName() : Dst);

                using (var stream = new FileStream(Src, FileMode.Open))
                    using (var archive = new ZipArchive(stream, ZipArchiveMode.Read))
                        Expand(archive.Entries.Single(), dstPath);

                return new FlowOneToOne(Src, dstPath);
            }
            catch (Exception e)
            {
                return none<FlowOneToOne>(e);
            }
        }
    }
}
