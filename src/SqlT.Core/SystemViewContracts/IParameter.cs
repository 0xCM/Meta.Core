//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{

    [SystemViewContract(SystemViewNames.parameters)]
    public interface IParameter : ISystemElement
    {
       int object_id {get;}

       int parameter_id {get;}

       byte system_type_id {get;}

       int user_type_id {get;}

       short max_length {get;}

       byte precision {get;}

       byte scale {get;}

       bool is_output {get;}

       bool is_cursor_ref {get;}

       bool has_default_value {get;}

       bool is_xml_document {get;}

       object default_value {get;}

       int xml_collection_id {get;}
               
        bool is_readonly {get;}

        bool? is_nullable {get;}

        int? encryption_type {get;}

        string encryption_type_desc {get;}
        string encryption_algorithm_name {get;}

        int? column_encryption_key_id {get;}

        string column_encryption_key_database_name {get;}

    }

}