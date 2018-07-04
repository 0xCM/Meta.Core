//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{

    public interface IPrimaryKeyColumn : ISystemElement
    {
        string table_schema { get; }
        string table_name { get; }
        string primary_key_name { get; }
        int column_position { get; }

    }

}