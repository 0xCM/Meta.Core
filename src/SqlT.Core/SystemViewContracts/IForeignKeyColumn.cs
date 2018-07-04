//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;

    [SystemViewContract(SystemViewNames.foreign_key_columns)]
    public interface IForeignKeyColumn : ISystemElement
    {
        int constraint_object_id { get; }

        int constraint_column_id { get; }

        int parent_object_id { get; }

        int parent_column_id { get; }

        int referenced_object_id { get; }

        int referenced_column_id { get; }
    }
}