//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{

    [SystemViewContract(SystemViewNames.types)]
    public interface IType : ISystemElement
    {
        string collation_name { get; }
        bool is_assembly_type { get; }
        bool? is_nullable { get; }
        bool is_table_type { get; }
        short max_length { get; }
        byte precision { get; }
        byte scale { get; }
        byte system_type_id { get; }
        int user_type_id { get; }
        bool is_user_defined { get; }
        int schema_id { get; }
    }

}