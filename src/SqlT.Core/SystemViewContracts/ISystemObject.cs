//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;

    [SystemViewContract(SystemViewNames.objects)]
    public interface ISystemObject : ISystemElement
    {
        int object_id { get; }
        int schema_id { get; }
        DateTime create_date { get; }
        DateTime modify_date { get; }
        int parent_object_id { get; }
        int? principal_id { get; }
        string type { get; }
        string type_desc { get; }
        bool is_user_defined { get; }
        bool is_ms_shipped { get; }

    }

}