//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    [SystemViewContract(SystemViewNames.schemas)]
    public interface ISchema : ISystemElement
    {
        int schema_id { get; }
        int? principal_id { get; }
        bool is_user_defined { get; }
    }
}