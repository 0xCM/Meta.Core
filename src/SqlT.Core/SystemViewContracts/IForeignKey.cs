//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;

    [SystemViewContract(SystemViewNames.foreign_keys)]
    public interface IForeignKey  : ISystemObject
    {        

        bool is_schema_published { get; }

        int? referenced_object_id { get; }

        int? key_index_id { get; }

        bool is_disabled { get; }

        bool is_not_for_replication { get; }

        bool is_not_trusted { get; }

        byte? delete_referential_action { get; }

        string delete_referential_action_desc { get; }

        byte? update_referential_action { get; }

        string update_referential_action_desc { get; }

        bool is_system_named { get; }

    }
}
