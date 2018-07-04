//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{

    /// <summary>
    /// See: https://msdn.microsoft.com/en-us/library/ms173760.aspx
    /// </summary>
    [SystemViewContract(SystemViewNames.indexes)]
    public interface IIndex : ISystemElement
    {
        int object_id {get;}

        int index_id {get;}

        byte type {get;}

        string type_desc {get;}

        bool? is_unique {get;}

        int? data_space_id {get;}

        bool? ignore_dup_key {get;}

        bool? is_primary_key {get;}

        bool? is_unique_constraint {get;}

        byte fill_factor {get;}

        bool? is_padded {get;}

        bool? is_disabled {get;}

        bool? is_hypothetical {get;}

        bool? allow_row_locks {get;}

        bool? allow_page_locks {get;}

        bool? has_filter {get;}

        string filter_definition {get;}

        int? compression_delay { get; }

    }


}