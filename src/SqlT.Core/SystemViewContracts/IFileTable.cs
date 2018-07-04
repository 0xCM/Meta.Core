//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{

    [SystemViewContract(SystemViewNames.filetables)]
    public interface IFileTable : ISystemElement
    {
        int object_id { get; }

        bool is_enabled { get; }

        string directory_name { get; }

        int filename_collation_id { get; }

        string filename_collation_name { get; }       
    }
}