//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem.SQL13.sys
{
    public partial class service_message_types : IServiceMessageType
    {
        public bool is_user_defined
            => message_type_id >= 65000;

        public override string ToString() 
            => name;

    }
}