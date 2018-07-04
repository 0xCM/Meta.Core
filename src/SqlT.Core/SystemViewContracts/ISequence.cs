//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{

    [SystemViewContract(SystemViewNames.sequences)]
    public interface ISequence : ISystemObject
    {
         bool is_published { get; set; }

         bool is_schema_published { get; set; }

        object start_value { get; set; }

        object increment { get; set; }

        object minimum_value { get; set; }

        object maximum_value { get; set; }

        bool? is_cycling { get; set; }

        bool? is_cached { get; set; }

        int? cache_size { get; set; }

        byte system_type_id { get; set; }

        int user_type_id { get; set; }

        byte precision { get; set; }

        byte? scale { get; set; }

        object current_value { get; set; }

        bool is_exhausted { get; set; }

    }

}