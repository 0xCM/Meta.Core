//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{

    [SystemViewContract(SystemViewNames.columns)]
    public interface IColumn : ISystemElement
    {
        int object_id { get; }

        int column_id { get; }

        string collation_name { get; }

        int default_object_id { get; }

        bool is_ansi_padded { get; }

        bool? is_column_set { get; }

        bool is_computed { get; }

        bool? is_dts_replicated { get; }

        bool is_filestream { get; }

        bool is_identity { get; }

        bool? is_merge_published { get; }

        bool? is_non_sql_subscribed { get; }

        bool? is_nullable { get; }

        bool? is_replicated { get; }

        bool is_rowguidcol { get; }

        bool? is_sparse { get; }

        bool is_xml_document { get; }

        short max_length { get; }

        byte precision { get; }

        int rule_object_id { get; }

        byte scale { get; }

        byte system_type_id { get; }

        int user_type_id { get; }

        int xml_collection_id { get; }
    }

}