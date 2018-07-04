//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    public class SqlSaveOptions
    {

        public SqlSaveOptions(int? Timeout = null, int? BatchSize = null)
        {
            this.Timeout = Timeout ?? 60;
            this.BatchSize = BatchSize;
        }

        public int? Timeout { get; }

        public int? BatchSize { get; }
    }

}