//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using System.IO;

    using Meta.Core;

    using static metacore;

    public sealed class FileSystemOps : ApplicationComponent
    {

        IFileArchiveManager ArchiveManager { get; }

        public FileSystemOps(IApplicationContext C)
            : base(C)
        {
            this.ArchiveManager = C.FileArchiveManager();
        }

        public void ReplaceFileCharacter(string SrcFile)
        {
            var srcPath = FilePath.Parse(SrcFile);
            var tmpPath = FilePath.Parse(Path.GetTempFileName());
            using (var writer = new StreamWriter(tmpPath))
            {
                foreach (var srcLine in srcPath.AsTextFile().Read())
                {
                    var dstLine = srcLine.Data.Replace('\t', ',');
                    writer.WriteLine(dstLine);
                }

            }
            srcPath.Rename(srcPath.FileName.AddExtension("bak"));
            tmpPath.MoveTo(srcPath);
        }

        public void SampleFile(string SrcFile)
        {
            var srcPath = FilePath.Parse(SrcFile);
            var dstPath = srcPath.Folder + srcPath.FileName.ChangeExtension(".sample.txt");
            using (var writer = new StreamWriter(dstPath))
            {
                using (var reader = new StreamReader(srcPath))
                {
                    for (var i = 0; i < 100; i++)
                        writer.WriteLine(reader.ReadLine());
                }
            }
        }

        public void PrependHeader(string SrcFile)
        {
            var header = "EntityId,LocationId,TotalAmount,OriginatedAs,CustomerNumber,ReferenceNumber,CustStateRegion,SequenceId,EventTypeName,EventDateTime";
            var srcPath = FilePath.Parse(SrcFile);
            var dstPath = srcPath.Folder + srcPath.FileName.ChangeExtension(".csv");
            using (var writer = new StreamWriter(dstPath))
            {
                writer.WriteLine(header);
                using (var reader = new StreamReader(srcPath))
                {
                    while (not(reader.EndOfStream))
                        writer.WriteLine(reader.ReadLine());

                }
            }

        }

        public void CopyFiles(string SrcDir, string DstDir)
            => PrintSequence(FolderPath.Parse(SrcDir).CopyFilesTo(DstDir));


        public void ExtractFileArchives(string SrcFolder, string DstFolder)
            => iter(ArchiveManager.ExtractFiles(SrcFolder, DstFolder),
                result => result.OnNone(Notify).OnSome(value => Print(value.Source)));

        public void ArchiveFiles(string SrcFolder, string Match, string DstFolder)
            => iter(C.ArchiveFiles(SrcFolder, Match, DstFolder), Print);

        public void UnzipFile(string srcPath, string dstFolder)
            => Print(ArchiveManager.ExpandArchive(link(FilePath.Parse(srcPath), FolderPath.Parse(dstFolder))));

        public void PreviewFile(string SrcFile, int lineCount)
            => PrintSequence(FilePath.Parse(SrcFile).AsTextFile().ReadFirst(lineCount));

        public void Dir(string SrcDir)
        {
            PrintSequence(FolderPath.Parse(SrcDir).GetFiles());
        }


    }

}