//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Commands
{

    [CommandSpec]
    public class CopyFile : CommandSpec<CopyFile, FileCopyResult>
    {
        public CopyFile()
        {

        }

        public CopyFile(Link<FilePath> Flow, bool Overwrite = true, bool Safe = true, bool CreateDirectory = true)
        {
            this.SrcPath = Flow.Source;
            this.DstPath = Flow.Target;
            this.Overwrite = Overwrite;
            this.Safe = Safe;
            this.CreateDirectory = CreateDirectory;
        }


        public CopyFile(FilePath SrcPath, FilePath DstPath, bool Overwrite = true, bool Safe = true, bool CreateDirectory = true)
        {
            this.SrcPath = SrcPath;
            this.DstPath = DstPath;
            this.Overwrite = Overwrite;
            this.Safe = Safe;
            this.CreateDirectory = CreateDirectory;
        }

        [CommandParameter]
        public FilePath SrcPath { get; set; }

        [CommandParameter]
        public FilePath DstPath { get; set; }

        [CommandParameter]
        public bool Overwrite { get; set; }

        [CommandParameter]
        public bool Safe { get; set; }

        [CommandParameter]
        public bool CreateDirectory { get; set; }
    }
}
