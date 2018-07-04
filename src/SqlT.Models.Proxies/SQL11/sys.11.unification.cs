//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem.SQL11.sys
{
    using System;
    using System.Collections.Generic;

    using static metacore;

    public partial class databases : IDatabase
    {
        static HashSet<string> sysdbnames = new HashSet<string>(array("master", "tempdb", "model", "msdb"));


        public int? delayed_durability => null;

        public string delayed_durability_desc => null;

        public bool? is_auto_create_stats_incremental_on => null;

        public bool? is_federation_member => null;

        public bool? is_memory_optimized_elevate_to_snapshot_on => null;

        public bool? is_mixed_page_allocation_on => null;

        public bool? is_query_store_on => null;

        public bool? is_remote_data_archive_enabled => null;

        public int? resource_pool_id => null;

        public bool is_system_defined => sysdbnames.Contains(name);

        public bool is_user_defined => not(is_system_defined);

        public override string ToString() => name;

    }

    public partial class servers : IServer
    {
        public override string ToString() => name;

        public bool? is_rda_server => null;
    }

    public partial class schemas : ISchema
    {
        private static readonly HashSet<string> sysSchemaNames = new HashSet<string>
            (
                new[]
                {
                    "dbo",
                    "guest",
                    "INFORMATION_SCHEMA",
                    "sys",
                    "db_owner",
                    "db_accessadmin",
                    "db_securityadmin",
                    "db_ddladmin",
                    "db_backupoperator",
                    "db_datareader",
                    "db_datawriter",
                    "db_denydatareader",
                    "db_denydatawriter",
                }

            );


        public override string ToString() => name;

        public bool is_user_defined => not(sysSchemaNames.Contains(name));

    }

    public partial class extended_properties : IExtendedProperty
    {
        public override string ToString() 
            => $"{name} = {value}";
    }


    public partial class all_objects : ISystemObject
    {
        public bool is_user_defined 
            => not(is_ms_shipped ?? false);

        bool ISystemObject.is_ms_shipped 
            => is_ms_shipped ?? false;

        public override string ToString() 
            => name;
    }

    public partial class objects : ISystemObject
    {
        public bool is_user_defined => not(is_ms_shipped);

        public override string ToString() => name;

    }



    public partial class all_views : IView
    {
        bool ISystemObject.is_user_defined => not(is_ms_shipped ?? false);

        bool IView.has_opaque_metadata => has_opaque_metadata ?? false;
        bool IView.has_unchecked_assembly_data => has_unchecked_assembly_data ?? false;
        bool IView.is_date_correlation_view => is_date_correlation_view ?? false;
        bool IView.with_check_option => with_check_option ?? false;
        bool ISystemObject.is_ms_shipped => is_ms_shipped ?? false;
    }

    public partial class views : IView
    {
        bool ISystemObject.is_user_defined => not(is_ms_shipped);
    }



    public partial class tables : ITable
    {
        bool ISystemObject.is_user_defined => not(is_ms_shipped);

        byte? ITable.durability => null;
        string ITable.durability_desc => null;
        bool? ITable.is_memory_optimized => null;



        public override string ToString() => name;

    }


    public partial class all_columns : IColumn
    {
        public override string ToString() => name;

    }

    public partial class columns : IColumn
    {
        public override string ToString() => name;

    }


    public partial class types : IType
    {
        public override string ToString() => name;

    }

    public partial class sequences : ISequence
    {
        public bool is_user_defined => not(is_ms_shipped);

        public override string ToString() => name;
    }

    public partial class procedures : IProcedure
    {
        public bool is_user_defined => not(is_ms_shipped);


        public procedures(ISystemObject o)
        {
            this.create_date = o.create_date;
            this.modify_date = o.modify_date;
            this.name = o.name;
            this.object_id = o.object_id;
            this.parent_object_id = o.parent_object_id;
            this.principal_id = o.principal_id;
            this.schema_id = o.schema_id;
            this.type = o.type;
            this.type_desc = o.type_desc;
            this.is_ms_shipped = o.is_ms_shipped;

        }

        public override string ToString() => name;
    }


    public partial class parameters : IParameter
    {
        public string column_encryption_key_database_name => null;

        public int? column_encryption_key_id => null;

        public string encryption_algorithm_name => null;

        public int? encryption_type => null;

        public string encryption_type_desc => null;

        public bool? is_nullable => null;

        public override string ToString() => name;
    }

    public partial class all_parameters : IParameter
    {
        public string column_encryption_key_database_name => null;

        public int? column_encryption_key_id => null;

        public string encryption_algorithm_name => null;

        public int? encryption_type => null;

        public string encryption_type_desc => null;

        public bool? is_nullable => null;

        public override string ToString() => name;
    }

    public partial class table_types : ITableType
    {
        public override string ToString() => name;

    }

    public partial class indexes : IIndex
    {

        public int? compression_delay => null;


        public override string ToString() => name;
    }


    public partial class index_columns : IIndexColumn
    {
        public string name => String.Empty;
    }

    public partial class master_files : IMasterFile
    {

        public int? credential_id => null;
    }

    public partial class service_message_types : IServiceMessageType
    {
        public bool is_user_defined
            => message_type_id >= 65000;
    }


}