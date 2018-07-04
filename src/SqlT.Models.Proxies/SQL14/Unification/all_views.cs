//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem.SQL14.sys
{
    using static metacore;

    public partial class all_views : IView
    {
        bool ISystemObject.is_user_defined => not(is_ms_shipped ?? false);
        bool ISystemObject.is_ms_shipped => is_ms_shipped ?? false;
        bool IView.has_opaque_metadata => has_opaque_metadata ?? false;
        bool IView.has_unchecked_assembly_data => has_unchecked_assembly_data ?? false;
        bool IView.is_date_correlation_view => is_date_correlation_view ?? false;
        bool IView.with_check_option => with_check_option ?? false;
        public override string ToString() => name;
    }
}