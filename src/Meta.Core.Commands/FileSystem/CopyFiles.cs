//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Commands
{
    using System.Collections.Generic;

    [CommandSpec]
    public class CopyFiles : CommandSpec<CopyFiles, FileCopyResults>
    {


        public CopyFiles()
        {
            SourceFiles = new List<FilePath>();
            TargetFolder = FolderPath.Empty;
        }

        public CopyFiles(IEnumerable<FilePath> SourceFiles, FolderPath TargetFolder, bool Overwrite = true, bool CreateFolder = true)
        {
            this.SourceFiles = SourceFiles.ToReadOnlyList();
            this.TargetFolder = TargetFolder;
            this.Overwrite = Overwrite;
            this.CreateFolder = CreateFolder;
            this.SpecName = FormatSpecName(TargetFolder.FolderName);
        }

        [CommandParameter]
        public IReadOnlyList<FilePath> SourceFiles { get; set; }

        [CommandParameter]
        public FolderPath TargetFolder { get; set; }

        [CommandParameter]
        public bool Overwrite { get; set; }

        [CommandParameter]
        public bool CreateFolder { get; set; }
    }
}