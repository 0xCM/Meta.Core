//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{

    [SystemViewContract(SystemViewNames.tables)]
    public interface ITable : ISystemObject
    {
        byte? durability { get; }

        string durability_desc { get; }

        int? filestream_data_space_id { get; }

        bool? has_replication_filter { get; }

        bool has_unchecked_assembly_data { get; }

        bool? is_filetable { get; }

        bool? is_memory_optimized { get; }

        bool? is_merge_published { get; }

        bool is_published { get; }

        bool? is_replicated { get; }

        bool is_schema_published { get; }

        bool? is_sync_tran_subscribed { get; }

        bool? is_tracked_by_cdc { get; }

        bool? large_value_types_out_of_row { get; }

        int lob_data_space_id { get; }

        byte? lock_escalation { get; }

        string lock_escalation_desc { get; }

        bool lock_on_bulk_load { get; }

        int max_column_id_used { get; }

        int? text_in_row_limit { get; }

        bool? uses_ansi_nulls { get; }
    }


}