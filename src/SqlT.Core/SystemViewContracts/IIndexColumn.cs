//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    [SystemViewContract(SystemViewNames.index_columns)]
    public interface IIndexColumn : ISystemElement
    {
        int object_id {get; }

        int index_id {get; }

        int index_column_id {get; }

        int column_id {get; }

        byte key_ordinal {get; }

        byte partition_ordinal {get; }

        bool? is_descending_key {get; }

        bool? is_included_column {get; }

    }
}
