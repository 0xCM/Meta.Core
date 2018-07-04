//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{

    /// <summary>
    /// Describes an exported dataset
    /// </summary>
    public sealed class DatasetExportDescription : ValueObject<DatasetExportDescription>
    {
        DatasetExportDescription()
        {

        }

        public DatasetExportDescription(FilePath OutputPath, int RecordCount)
        {
            this.OutputPath = OutputPath;
            this.RecordCount = RecordCount;
        }

        public FilePath OutputPath { get; }

        public int RecordCount { get; }

        public override string ToString()
            => $"Exported {RecordCount} records to {OutputPath}";
    }
}