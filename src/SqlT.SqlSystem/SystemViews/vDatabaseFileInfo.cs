//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using SqlT.Core;   

    public class vDatabaseFileInfo : vSystemElement
    {
        public vDatabaseFileInfo(string DatabaseName, string LogicalFileName, string PhysicalPath, int FileSize, bool IsDataFile, bool IsLogFile)
            : base(LogicalFileName, true)
        {

            this.DatabaseName = new SqlDatabaseName(DatabaseName);
            this.LogicalFileName = new SqlFileName(LogicalFileName);
            this.PhysicalPath = PhysicalPath;
            this.FileSize = FileSize;
            this.IsDataFile = IsDataFile;
            this.IsLogFile = IsLogFile;
        }

        public SqlDatabaseName DatabaseName { get; }

        public SqlFileName LogicalFileName { get; }

        public FilePath PhysicalPath { get; }

        public int FileSize { get; }

        public bool IsDataFile { get; }

        public bool IsLogFile { get; }

        public override string ToString()
            => LogicalFileName;

    }
}
