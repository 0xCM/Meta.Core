//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{

    [SystemViewContract(SystemViewNames.views)]
    public interface IView : ISystemObject
    {
        bool has_opaque_metadata { get; }
        bool? has_replication_filter { get; }
        bool has_unchecked_assembly_data { get; }
        bool is_date_correlation_view { get; }
        bool? is_replicated { get; }
        bool? is_tracked_by_cdc { get; }
        bool with_check_option { get; }
    }

}