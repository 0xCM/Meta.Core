//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;
    using static metacore;

    public abstract class SqlXEventFileLog<L> : SqlXEventLog<L, SqlXEventFileTarget>, IFilePath
        where L : SqlXEventFileLog<L>
    {
        public SqlXEventFileLog(FilePath Path)
            : base(new SqlXEventFileTarget(Path))
        {

        }

        public FilePath Path
            => Target.Path;

        public bool IsEmpty 
            => Path.IsEmpty;

        public FileName FileName
            => Path.FileName;

        IFolderPath IFilePath.Folder 
            => cast<IFilePath>(Path).Folder;

        string IFileSystemObject.FileSystemPath
            => cast<IFilePath>(Path).FileSystemPath;

        public bool Exists()
            => Path.Exists();
    }


    public class SqlXEventFileLog : SqlXEventFileLog<SqlXEventFileLog>
    {
        public SqlXEventFileLog(FilePath Path)
            : base(Path)
        {

        }
    }
}