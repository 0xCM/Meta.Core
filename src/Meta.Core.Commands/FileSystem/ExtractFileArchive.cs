//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Commands
{
    using System.Collections.Generic;
    using static metacore;

    [CommandSpec]
    public class ExtractFileArchive : CommandSpec<ExtractFileArchive, ArchiveExtractionInfo>
    {
        public ExtractFileArchive()
        { }

        public ExtractFileArchive(FilePath ArchivePath, FolderPath TargetFolder, bool overwrite = true)
        {
            this.ArchivePath = ArchivePath;
            this.TargetFolder = TargetFolder;
            this.Overwrite = overwrite;
            this.SpecName = FormatSpecName(ArchivePath.FileName, TargetFolder.FolderName);
        }

        [CommandParameter]
        public FilePath ArchivePath { get; set; }

        [CommandParameter]
        public FolderPath TargetFolder { get; set; }

        [CommandParameter]
        public bool Overwrite { get; set; }
    }

}

public class ArchiveExtractionInfo
{
    public FilePath ArchivePath { get; set; }
}