//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;

    [SystemViewContract(SystemViewNames.service_message_types)]
    public interface IServiceMessageType : ISystemElement
    {
        int message_type_id { get; }

        int? principal_id { get; }
        
        string validation { get; }

        string validation_desc { get; }

        int? xml_collection_id { get; }
        
        bool is_user_defined { get; }

    }
}
