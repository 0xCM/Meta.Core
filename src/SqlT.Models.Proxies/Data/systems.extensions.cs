//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem.systems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;


    using SqlT.Core;

    using static DebuggerDisplayFormats;

    static class DebuggerDisplayFormats
    {
        public const string NamedElement = "{name}";
        public const string SchemaObject = "[{systems_schema_name, nq}].[{name, nq}]";
    }

    [DebuggerDisplay(NamedElement)]
    public partial class v_schemas
    {
        public SqlName systems_full_name
            => new SqlName(systems_server_name, systems_database_name, name);
    }

    [DebuggerDisplay(SchemaObject)]
    public partial class v_tables
    {
        public SqlName systems_full_name
            => new SqlName(systems_server_name, systems_database_name, systems_schema_name, name);

    }

    [DebuggerDisplay(SchemaObject)]
    public partial class v_types
    {
        public SqlName systems_full_name
             => new SqlName(systems_server_name, systems_database_name, systems_schema_name, name);
    }

    [DebuggerDisplay(SchemaObject)]
    public partial class v_views
    {
        public SqlName systems_full_name
            => new SqlName(systems_server_name, systems_database_name, systems_schema_name, name);
    }

    [DebuggerDisplay(NamedElement)]
    public partial class v_table_indexes
    {
        public SqlName systems_full_name
         => new SqlName(systems_server_name, systems_database_name, systems_schema_name, systems_parent_name, name);
    }

    [DebuggerDisplay(NamedElement)]
    public partial class v_servers
    {
        public SqlName systems_full_name
         => new SqlName(systems_server_name);

    }

    [DebuggerDisplay(NamedElement)]
    public partial class v_databases
    {
        public SqlName systems_full_name
         => new SqlName(systems_server_name, name);

    }

    [DebuggerDisplay(NamedElement)]
    public partial class v_extended_properties
    {
        public SqlName systems_full_name
         => new SqlName(systems_server_name, systems_database_name, major_id.ToString(), minor_id.ToString(),class_desc, name);

    }

    public partial class v_table_index_columns
    {
        public SqlName systems_full_name
            => new SqlName(
                    systems_server_name, 
                    systems_database_name, 
                    systems_schema_name, 
                    systems_parent_name, 
                    systems_index_name, 
                    systems_column_name
                );
    }
}
