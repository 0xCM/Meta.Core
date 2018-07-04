//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    [CommandSpec]
    public class CreateFileArchive : CommandSpec<CreateFileArchive, FileArchiveDescription>
    {

        public static CreateFileArchive DefineZipFileCommand(FilePath srcPath, FilePath dstPath)
            => new CreateFileArchive
               {
                   SourceFiles = roitems(srcPath),
                   ArchivePath = dstPath,
                   Overwrite = true
               };

        public static IEnumerable<CreateFileArchive> DefineZipFilesCommands(FolderPath srcPath, FolderPath dstPath)
            => from srcFile in srcPath.Files()
               select new CreateFileArchive
               {
                   SourceFiles = roitems(FilePath.Parse(srcFile)),
                   ArchivePath = dstPath + srcFile.FileName.AddExtension(".zip"),
                   Overwrite = true
               };

        public static CreateFileArchive DefineZipDirCommand(FolderPath srcPath, FilePath dstPath)
            => new CreateFileArchive
            {
                SourceFolders = roitems(srcPath),
                ArchivePath = dstPath,
                Overwrite = true
            };       

        public CreateFileArchive()
        {
            this.SourceFolders = rolist<FolderPath>();
            this.SourceFiles = rolist<FilePath>();
            this.ArchivePath = FilePath.Empty;
            this.Overwrite = true;

        }

        CreateFileArchive(bool overwrite)
            :this()
        {
            this.SourceFolders = rolist<FolderPath>();
            this.SourceFiles = rolist<FilePath>();
            this.ArchivePath = FilePath.Empty;
            this.Overwrite = overwrite;

        }

        public CreateFileArchive(FolderPath srcFolder, FilePath archivePath, bool overwrite = true)
            : this(overwrite)
        {
            this.SourceFolders = roitems(srcFolder);
            this.ArchivePath = archivePath;
        }

        public CreateFileArchive(IEnumerable<FolderPath> srcFolders, IEnumerable<FilePath> srcFiles, FilePath archivePath, bool overwrite = true)
            : this(overwrite)
        {
            this.SourceFolders = rolist(srcFolders);
            this.SourceFiles = rolist(srcFiles);
            this.ArchivePath = archivePath;
        }

        public CreateFileArchive(IEnumerable<FolderPath> srcFolders, FilePath archivePath, bool overwrite = true)
            : this(overwrite)
        {
            this.SourceFolders = rolist(srcFolders);
            this.ArchivePath = archivePath;
        }

        public CreateFileArchive(IEnumerable<FilePath> srcFiles, FilePath archivePath, bool overwrite = true)
            : this(overwrite)
        {
            this.SourceFiles = rolist(srcFiles);
            this.ArchivePath = archivePath;
        }


        [CommandParameter]
        public IReadOnlyList<FolderPath> SourceFolders { get; set; }

        [CommandParameter]
        public IReadOnlyList<FilePath> SourceFiles { get; set; }

        [CommandParameter]
        public FilePath ArchivePath { get; set; }

        [CommandParameter]
        public bool Overwrite { get; set; }

        public override string ToString()
            => ArchivePath;
    }

}

public class FileArchiveDescription
{
    public FilePath ArchivePath { get; set;  }
}