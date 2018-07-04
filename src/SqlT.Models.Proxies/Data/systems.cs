//This file was generated at 4/13/2018 12:30:14 PM using version 1.2018.3.26411 the SqT data access toolset.
namespace SqlT.SqlSystem.systems
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    public sealed class systemsTableTypeNames
    {
        public readonly static SqlTableTypeName databases_record = "[systems].[databases_record]";
        public readonly static SqlTableTypeName host_servers_record = "[systems].[host_servers_record]";
        public readonly static SqlTableTypeName servers_record = "[systems].[servers_record]";
    }

    /// <summary>
    /// Routines defined in the systems schema
    /// </summary>
    [SqlOperationContract()]
    public interface IsystemsOperations
    {
        [SqlProcedure("systems", "p_servers_merge")]
        SqlOutcome<Int32> p_servers_merge([SqlParameter("@Records", 0, true, false), SqlTypeFacets("[systems].[servers_record]", true)] IEnumerable<servers_record> Records);
        [SqlProcedure("systems", "p_host_server_save")]
        SqlOutcome<Int32> p_host_server_save([SqlParameter("@systems_server_name", 0, false, false), SqlTypeFacets("sysname", true)] string systems_server_name);
        [SqlProcedure("systems", "p_host_servers_merge")]
        SqlOutcome<Int32> p_host_servers_merge([SqlParameter("@Records", 0, true, false), SqlTypeFacets("[systems].[host_servers_record]", true)] IEnumerable<host_servers_record> Records);
        [SqlProcedure("systems", "p_host_server_delete")]
        SqlOutcome<Int32> p_host_server_delete([SqlParameter("@systems_server_name", 0, false, false), SqlTypeFacets("sysname", true)] string systems_server_name);
        [SqlProcedure("systems", "p_databases_merge")]
        SqlOutcome<Int32> p_databases_merge([SqlParameter("@Records", 0, true, false), SqlTypeFacets("[systems].[databases_record]", true)] IEnumerable<databases_record> Records);
        [SqlProcedure("systems", "p_databases_delete")]
        SqlOutcome<Int32> p_databases_delete([SqlParameter("@systems_server_name", 0, false, false), SqlTypeFacets("sysname", true)] string systems_server_name, [SqlParameter("@database_name", 1, false, false), SqlTypeFacets("sysname", true)] string database_name);
    }

    public sealed class systemsViewNames
    {
        public readonly static SqlViewName v_databases = "[systems].[v_databases]";
        public readonly static SqlViewName v_extended_properties = "[systems].[v_extended_properties]";
        public readonly static SqlViewName v_host_servers = "[systems].[v_host_servers]";
        public readonly static SqlViewName v_schemas = "[systems].[v_schemas]";
        public readonly static SqlViewName v_servers = "[systems].[v_servers]";
        public readonly static SqlViewName v_table_columns = "[systems].[v_table_columns]";
        public readonly static SqlViewName v_table_index_columns = "[systems].[v_table_index_columns]";
        public readonly static SqlViewName v_table_indexes = "[systems].[v_table_indexes]";
        public readonly static SqlViewName v_tables = "[systems].[v_tables]";
        public readonly static SqlViewName v_types = "[systems].[v_types]";
        public readonly static SqlViewName v_views = "[systems].[v_views]";
    }

    public sealed class systemsTableNames
    {
        public readonly static SqlTableName databases = "[systems].[databases]";
        public readonly static SqlTableName extended_properties = "[systems].[extended_properties]";
        public readonly static SqlTableName host_servers = "[systems].[host_servers]";
        public readonly static SqlTableName schemas = "[systems].[schemas]";
        public readonly static SqlTableName servers = "[systems].[servers]";
        public readonly static SqlTableName table_columns = "[systems].[table_columns]";
        public readonly static SqlTableName table_index_columns = "[systems].[table_index_columns]";
        public readonly static SqlTableName table_indexes = "[systems].[table_indexes]";
        public readonly static SqlTableName tables = "[systems].[tables]";
        public readonly static SqlTableName types = "[systems].[types]";
        public readonly static SqlTableName views = "[systems].[views]";
    }

    public sealed class systemsSequenceNames
    {
        public readonly static SqlSequenceName columns_key = "[systems].[columns_key]";
        public readonly static SqlSequenceName databases_key = "[systems].[databases_key]";
        public readonly static SqlSequenceName extended_properties_key = "[systems].[extended_properties_key]";
        public readonly static SqlSequenceName host_servers_key = "[systems].[host_servers_key]";
        public readonly static SqlSequenceName schemas_key = "[systems].[schemas_key]";
        public readonly static SqlSequenceName servers_key = "[systems].[servers_key]";
        public readonly static SqlSequenceName table_index_columns_key = "[systems].[table_index_columns_key]";
        public readonly static SqlSequenceName table_indexes_key = "[systems].[table_indexes_key]";
        public readonly static SqlSequenceName tables_key = "[systems].[tables_key]";
        public readonly static SqlSequenceName types_key = "[systems].[types_key]";
        public readonly static SqlSequenceName views_key = "[systems].[views_key]";
    }

    /// <summary>
    /// Declares the columns defined by the systems schema
    /// </summary>
    [SqlDataContract()]
    public interface Iservers_record
    {
        [SqlColumn("systems_server_name", 0), SqlTypeFacets("sysname", false)]
        string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("server_id", 1), SqlTypeFacets("int", false)]
        int server_id
        {
            get;
            set;
        }

        [SqlColumn("name", 2), SqlTypeFacets("sysname", false)]
        string name
        {
            get;
            set;
        }

        [SqlColumn("product", 3), SqlTypeFacets("sysname", false)]
        string product
        {
            get;
            set;
        }

        [SqlColumn("provider", 4), SqlTypeFacets("sysname", false)]
        string provider
        {
            get;
            set;
        }

        [SqlColumn("data_source", 5), SqlTypeFacets("nvarchar", true, 8000)]
        string data_source
        {
            get;
            set;
        }

        [SqlColumn("location", 6), SqlTypeFacets("nvarchar", true, 8000)]
        string location
        {
            get;
            set;
        }

        [SqlColumn("provider_string", 7), SqlTypeFacets("nvarchar", true, 8000)]
        string provider_string
        {
            get;
            set;
        }

        [SqlColumn("catalog", 8), SqlTypeFacets("sysname", true)]
        string catalog
        {
            get;
            set;
        }

        [SqlColumn("connect_timeout", 9), SqlTypeFacets("int", true)]
        int? connect_timeout
        {
            get;
            set;
        }

        [SqlColumn("query_timeout", 10), SqlTypeFacets("int", true)]
        int? query_timeout
        {
            get;
            set;
        }

        [SqlColumn("is_linked", 11), SqlTypeFacets("bit", false)]
        bool is_linked
        {
            get;
            set;
        }

        [SqlColumn("is_remote_login_enabled", 12), SqlTypeFacets("bit", false)]
        bool is_remote_login_enabled
        {
            get;
            set;
        }

        [SqlColumn("is_rpc_out_enabled", 13), SqlTypeFacets("bit", false)]
        bool is_rpc_out_enabled
        {
            get;
            set;
        }

        [SqlColumn("is_data_access_enabled", 14), SqlTypeFacets("bit", false)]
        bool is_data_access_enabled
        {
            get;
            set;
        }

        [SqlColumn("is_collation_compatible", 15), SqlTypeFacets("bit", false)]
        bool is_collation_compatible
        {
            get;
            set;
        }

        [SqlColumn("uses_remote_collation", 16), SqlTypeFacets("bit", false)]
        bool uses_remote_collation
        {
            get;
            set;
        }

        [SqlColumn("collation_name", 17), SqlTypeFacets("sysname", true)]
        string collation_name
        {
            get;
            set;
        }

        [SqlColumn("lazy_schema_validation", 18), SqlTypeFacets("bit", false)]
        bool lazy_schema_validation
        {
            get;
            set;
        }

        [SqlColumn("is_system", 19), SqlTypeFacets("bit", false)]
        bool is_system
        {
            get;
            set;
        }

        [SqlColumn("is_publisher", 20), SqlTypeFacets("bit", false)]
        bool is_publisher
        {
            get;
            set;
        }

        [SqlColumn("is_subscriber", 21), SqlTypeFacets("bit", true)]
        bool? is_subscriber
        {
            get;
            set;
        }

        [SqlColumn("is_distributor", 22), SqlTypeFacets("bit", true)]
        bool? is_distributor
        {
            get;
            set;
        }

        [SqlColumn("is_nonsql_subscriber", 23), SqlTypeFacets("bit", true)]
        bool? is_nonsql_subscriber
        {
            get;
            set;
        }

        [SqlColumn("is_remote_proc_transaction_promotion_enabled", 24), SqlTypeFacets("bit", true)]
        bool? is_remote_proc_transaction_promotion_enabled
        {
            get;
            set;
        }

        [SqlColumn("modify_date", 25), SqlTypeFacets("datetime", false)]
        DateTime modify_date
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the systems schema
    /// </summary>
    [SqlDataContract()]
    public interface Ihost_servers_record
    {
        [SqlColumn("systems_server_name", 0), SqlTypeFacets("sysname", false)]
        string systems_server_name
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the systems schema
    /// </summary>
    [SqlDataContract()]
    public interface Idatabases_record
    {
        [SqlColumn("systems_server_name", 0), SqlTypeFacets("sysname", false)]
        string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("name", 1), SqlTypeFacets("sysname", false)]
        string name
        {
            get;
            set;
        }

        [SqlColumn("database_id", 2), SqlTypeFacets("int", false)]
        int database_id
        {
            get;
            set;
        }

        [SqlColumn("source_database_id", 3), SqlTypeFacets("int", true)]
        int? source_database_id
        {
            get;
            set;
        }

        [SqlColumn("owner_sid", 4), SqlTypeFacets("varbinary", true, 85)]
        Byte[] owner_sid
        {
            get;
            set;
        }

        [SqlColumn("create_date", 5), SqlTypeFacets("datetime", false)]
        DateTime create_date
        {
            get;
            set;
        }

        [SqlColumn("compatibility_level", 6), SqlTypeFacets("tinyint", false)]
        byte compatibility_level
        {
            get;
            set;
        }

        [SqlColumn("collation_name", 7), SqlTypeFacets("nvarchar", true, 256)]
        string collation_name
        {
            get;
            set;
        }

        [SqlColumn("user_access", 8), SqlTypeFacets("tinyint", true)]
        byte? user_access
        {
            get;
            set;
        }

        [SqlColumn("user_access_desc", 9), SqlTypeFacets("nvarchar", true, 120)]
        string user_access_desc
        {
            get;
            set;
        }

        [SqlColumn("is_read_only", 10), SqlTypeFacets("bit", true)]
        bool? is_read_only
        {
            get;
            set;
        }

        [SqlColumn("is_auto_close_on", 11), SqlTypeFacets("bit", false)]
        bool is_auto_close_on
        {
            get;
            set;
        }

        [SqlColumn("is_auto_shrink_on", 12), SqlTypeFacets("bit", true)]
        bool? is_auto_shrink_on
        {
            get;
            set;
        }

        [SqlColumn("state", 13), SqlTypeFacets("tinyint", true)]
        byte? state
        {
            get;
            set;
        }

        [SqlColumn("state_desc", 14), SqlTypeFacets("nvarchar", true, 120)]
        string state_desc
        {
            get;
            set;
        }

        [SqlColumn("is_in_standby", 15), SqlTypeFacets("bit", true)]
        bool? is_in_standby
        {
            get;
            set;
        }

        [SqlColumn("is_cleanly_shutdown", 16), SqlTypeFacets("bit", true)]
        bool? is_cleanly_shutdown
        {
            get;
            set;
        }

        [SqlColumn("is_supplemental_logging_enabled", 17), SqlTypeFacets("bit", true)]
        bool? is_supplemental_logging_enabled
        {
            get;
            set;
        }

        [SqlColumn("snapshot_isolation_state", 18), SqlTypeFacets("tinyint", true)]
        byte? snapshot_isolation_state
        {
            get;
            set;
        }

        [SqlColumn("snapshot_isolation_state_desc", 19), SqlTypeFacets("nvarchar", true, 120)]
        string snapshot_isolation_state_desc
        {
            get;
            set;
        }

        [SqlColumn("is_read_committed_snapshot_on", 20), SqlTypeFacets("bit", true)]
        bool? is_read_committed_snapshot_on
        {
            get;
            set;
        }

        [SqlColumn("recovery_model", 21), SqlTypeFacets("tinyint", true)]
        byte? recovery_model
        {
            get;
            set;
        }

        [SqlColumn("recovery_model_desc", 22), SqlTypeFacets("nvarchar", true, 120)]
        string recovery_model_desc
        {
            get;
            set;
        }

        [SqlColumn("page_verify_option", 23), SqlTypeFacets("tinyint", true)]
        byte? page_verify_option
        {
            get;
            set;
        }

        [SqlColumn("page_verify_option_desc", 24), SqlTypeFacets("nvarchar", true, 120)]
        string page_verify_option_desc
        {
            get;
            set;
        }

        [SqlColumn("is_auto_create_stats_on", 25), SqlTypeFacets("bit", true)]
        bool? is_auto_create_stats_on
        {
            get;
            set;
        }

        [SqlColumn("is_auto_update_stats_on", 26), SqlTypeFacets("bit", true)]
        bool? is_auto_update_stats_on
        {
            get;
            set;
        }

        [SqlColumn("is_auto_update_stats_async_on", 27), SqlTypeFacets("bit", true)]
        bool? is_auto_update_stats_async_on
        {
            get;
            set;
        }

        [SqlColumn("is_ansi_null_default_on", 28), SqlTypeFacets("bit", true)]
        bool? is_ansi_null_default_on
        {
            get;
            set;
        }

        [SqlColumn("is_ansi_nulls_on", 29), SqlTypeFacets("bit", true)]
        bool? is_ansi_nulls_on
        {
            get;
            set;
        }

        [SqlColumn("is_ansi_padding_on", 30), SqlTypeFacets("bit", true)]
        bool? is_ansi_padding_on
        {
            get;
            set;
        }

        [SqlColumn("is_ansi_warnings_on", 31), SqlTypeFacets("bit", true)]
        bool? is_ansi_warnings_on
        {
            get;
            set;
        }

        [SqlColumn("is_arithabort_on", 32), SqlTypeFacets("bit", true)]
        bool? is_arithabort_on
        {
            get;
            set;
        }

        [SqlColumn("is_concat_null_yields_null_on", 33), SqlTypeFacets("bit", true)]
        bool? is_concat_null_yields_null_on
        {
            get;
            set;
        }

        [SqlColumn("is_numeric_roundabort_on", 34), SqlTypeFacets("bit", true)]
        bool? is_numeric_roundabort_on
        {
            get;
            set;
        }

        [SqlColumn("is_quoted_identifier_on", 35), SqlTypeFacets("bit", true)]
        bool? is_quoted_identifier_on
        {
            get;
            set;
        }

        [SqlColumn("is_recursive_triggers_on", 36), SqlTypeFacets("bit", true)]
        bool? is_recursive_triggers_on
        {
            get;
            set;
        }

        [SqlColumn("is_cursor_close_on_commit_on", 37), SqlTypeFacets("bit", true)]
        bool? is_cursor_close_on_commit_on
        {
            get;
            set;
        }

        [SqlColumn("is_local_cursor_default", 38), SqlTypeFacets("bit", true)]
        bool? is_local_cursor_default
        {
            get;
            set;
        }

        [SqlColumn("is_fulltext_enabled", 39), SqlTypeFacets("bit", true)]
        bool? is_fulltext_enabled
        {
            get;
            set;
        }

        [SqlColumn("is_trustworthy_on", 40), SqlTypeFacets("bit", true)]
        bool? is_trustworthy_on
        {
            get;
            set;
        }

        [SqlColumn("is_db_chaining_on", 41), SqlTypeFacets("bit", true)]
        bool? is_db_chaining_on
        {
            get;
            set;
        }

        [SqlColumn("is_parameterization_forced", 42), SqlTypeFacets("bit", true)]
        bool? is_parameterization_forced
        {
            get;
            set;
        }

        [SqlColumn("is_master_key_encrypted_by_server", 43), SqlTypeFacets("bit", false)]
        bool is_master_key_encrypted_by_server
        {
            get;
            set;
        }

        [SqlColumn("is_published", 44), SqlTypeFacets("bit", false)]
        bool is_published
        {
            get;
            set;
        }

        [SqlColumn("is_subscribed", 45), SqlTypeFacets("bit", false)]
        bool is_subscribed
        {
            get;
            set;
        }

        [SqlColumn("is_merge_published", 46), SqlTypeFacets("bit", false)]
        bool is_merge_published
        {
            get;
            set;
        }

        [SqlColumn("is_distributor", 47), SqlTypeFacets("bit", false)]
        bool is_distributor
        {
            get;
            set;
        }

        [SqlColumn("is_sync_with_backup", 48), SqlTypeFacets("bit", false)]
        bool is_sync_with_backup
        {
            get;
            set;
        }

        [SqlColumn("service_broker_guid", 49), SqlTypeFacets("uniqueidentifier", false)]
        Guid service_broker_guid
        {
            get;
            set;
        }

        [SqlColumn("is_broker_enabled", 50), SqlTypeFacets("bit", false)]
        bool is_broker_enabled
        {
            get;
            set;
        }

        [SqlColumn("log_reuse_wait", 51), SqlTypeFacets("tinyint", true)]
        byte? log_reuse_wait
        {
            get;
            set;
        }

        [SqlColumn("log_reuse_wait_desc", 52), SqlTypeFacets("nvarchar", true, 120)]
        string log_reuse_wait_desc
        {
            get;
            set;
        }

        [SqlColumn("is_date_correlation_on", 53), SqlTypeFacets("bit", false)]
        bool is_date_correlation_on
        {
            get;
            set;
        }

        [SqlColumn("is_cdc_enabled", 54), SqlTypeFacets("bit", false)]
        bool is_cdc_enabled
        {
            get;
            set;
        }

        [SqlColumn("is_encrypted", 55), SqlTypeFacets("bit", true)]
        bool? is_encrypted
        {
            get;
            set;
        }

        [SqlColumn("is_honor_broker_priority_on", 56), SqlTypeFacets("bit", true)]
        bool? is_honor_broker_priority_on
        {
            get;
            set;
        }

        [SqlColumn("replica_id", 57), SqlTypeFacets("uniqueidentifier", true)]
        Guid? replica_id
        {
            get;
            set;
        }

        [SqlColumn("group_database_id", 58), SqlTypeFacets("uniqueidentifier", true)]
        Guid? group_database_id
        {
            get;
            set;
        }

        [SqlColumn("default_language_lcid", 59), SqlTypeFacets("smallint", true)]
        short? default_language_lcid
        {
            get;
            set;
        }

        [SqlColumn("default_language_name", 60), SqlTypeFacets("nvarchar", true, 256)]
        string default_language_name
        {
            get;
            set;
        }

        [SqlColumn("default_fulltext_language_lcid", 61), SqlTypeFacets("int", true)]
        int? default_fulltext_language_lcid
        {
            get;
            set;
        }

        [SqlColumn("default_fulltext_language_name", 62), SqlTypeFacets("nvarchar", true, 256)]
        string default_fulltext_language_name
        {
            get;
            set;
        }

        [SqlColumn("is_nested_triggers_on", 63), SqlTypeFacets("bit", true)]
        bool? is_nested_triggers_on
        {
            get;
            set;
        }

        [SqlColumn("is_transform_noise_words_on", 64), SqlTypeFacets("bit", true)]
        bool? is_transform_noise_words_on
        {
            get;
            set;
        }

        [SqlColumn("two_digit_year_cutoff", 65), SqlTypeFacets("smallint", true)]
        short? two_digit_year_cutoff
        {
            get;
            set;
        }

        [SqlColumn("containment", 66), SqlTypeFacets("tinyint", true)]
        byte? containment
        {
            get;
            set;
        }

        [SqlColumn("containment_desc", 67), SqlTypeFacets("nvarchar", true, 120)]
        string containment_desc
        {
            get;
            set;
        }

        [SqlColumn("target_recovery_time_in_seconds", 68), SqlTypeFacets("int", true)]
        int? target_recovery_time_in_seconds
        {
            get;
            set;
        }
    }

    [SqlView("systems", "v_extended_properties")]
    public partial class v_extended_properties : SqlViewProxy
    {
        [SqlColumn("systems_server_name", 0), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("systems_database_name", 1), SqlTypeFacets("sysname", false)]
        public string systems_database_name
        {
            get;
            set;
        }

        [SqlColumn("class", 2), SqlTypeFacets("tinyint", false)]
        public byte @class
        {
            get;
            set;
        }

        [SqlColumn("class_desc", 3), SqlTypeFacets("nvarchar", true, 240)]
        public string class_desc
        {
            get;
            set;
        }

        [SqlColumn("major_id", 4), SqlTypeFacets("int", false)]
        public int major_id
        {
            get;
            set;
        }

        [SqlColumn("minor_id", 5), SqlTypeFacets("int", false)]
        public int minor_id
        {
            get;
            set;
        }

        [SqlColumn("name", 6), SqlTypeFacets("sysname", false)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("value", 7), SqlTypeFacets("sql_variant", true)]
        public Object value
        {
            get;
            set;
        }

        public v_extended_properties()
        {
        }

        public v_extended_properties(object[] items)
        {
            systems_server_name = (string)items[0];
            systems_database_name = (string)items[1];
            @class = (byte)items[2];
            class_desc = (string)items[3];
            major_id = (int)items[4];
            minor_id = (int)items[5];
            name = (string)items[6];
            value = (Object)items[7];
        }

        public v_extended_properties(string systems_server_name, string systems_database_name, byte @class, string class_desc, int major_id, int minor_id, string name, Object value)
        {
            this.systems_server_name = systems_server_name;
            this.systems_database_name = systems_database_name;
            this.@class = @class;
            this.class_desc = class_desc;
            this.major_id = major_id;
            this.minor_id = minor_id;
            this.name = name;
            this.value = value;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_server_name, systems_database_name, @class, class_desc, major_id, minor_id, name, value };
        }

        public override void SetItemArray(object[] items)
        {
            systems_server_name = (string)items[0];
            systems_database_name = (string)items[1];
            @class = (byte)items[2];
            class_desc = (string)items[3];
            major_id = (int)items[4];
            minor_id = (int)items[5];
            name = (string)items[6];
            value = (Object)items[7];
        }
    }

    [SqlView("systems", "v_table_indexes")]
    public partial class v_table_indexes : SqlViewProxy
    {
        [SqlColumn("systems_server_name", 0), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("systems_database_name", 1), SqlTypeFacets("sysname", false)]
        public string systems_database_name
        {
            get;
            set;
        }

        [SqlColumn("systems_schema_name", 2), SqlTypeFacets("sysname", false)]
        public string systems_schema_name
        {
            get;
            set;
        }

        [SqlColumn("systems_parent_name", 3), SqlTypeFacets("sysname", false)]
        public string systems_parent_name
        {
            get;
            set;
        }

        [SqlColumn("systems_parent_type", 4), SqlTypeFacets("char", false, 2)]
        public string systems_parent_type
        {
            get;
            set;
        }

        [SqlColumn("object_id", 5), SqlTypeFacets("int", false)]
        public int object_id
        {
            get;
            set;
        }

        [SqlColumn("name", 6), SqlTypeFacets("sysname", true)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("index_id", 7), SqlTypeFacets("int", false)]
        public int index_id
        {
            get;
            set;
        }

        [SqlColumn("type", 8), SqlTypeFacets("tinyint", false)]
        public byte type
        {
            get;
            set;
        }

        [SqlColumn("type_desc", 9), SqlTypeFacets("nvarchar", true, 120)]
        public string type_desc
        {
            get;
            set;
        }

        [SqlColumn("is_unique", 10), SqlTypeFacets("bit", true)]
        public bool? is_unique
        {
            get;
            set;
        }

        [SqlColumn("data_space_id", 11), SqlTypeFacets("int", true)]
        public int? data_space_id
        {
            get;
            set;
        }

        [SqlColumn("ignore_dup_key", 12), SqlTypeFacets("bit", true)]
        public bool? ignore_dup_key
        {
            get;
            set;
        }

        [SqlColumn("is_primary_key", 13), SqlTypeFacets("bit", true)]
        public bool? is_primary_key
        {
            get;
            set;
        }

        [SqlColumn("is_unique_constraint", 14), SqlTypeFacets("bit", true)]
        public bool? is_unique_constraint
        {
            get;
            set;
        }

        [SqlColumn("fill_factor", 15), SqlTypeFacets("tinyint", false)]
        public byte fill_factor
        {
            get;
            set;
        }

        [SqlColumn("is_padded", 16), SqlTypeFacets("bit", true)]
        public bool? is_padded
        {
            get;
            set;
        }

        [SqlColumn("is_disabled", 17), SqlTypeFacets("bit", true)]
        public bool? is_disabled
        {
            get;
            set;
        }

        [SqlColumn("is_hypothetical", 18), SqlTypeFacets("bit", true)]
        public bool? is_hypothetical
        {
            get;
            set;
        }

        [SqlColumn("allow_row_locks", 19), SqlTypeFacets("bit", true)]
        public bool? allow_row_locks
        {
            get;
            set;
        }

        [SqlColumn("allow_page_locks", 20), SqlTypeFacets("bit", true)]
        public bool? allow_page_locks
        {
            get;
            set;
        }

        [SqlColumn("has_filter", 21), SqlTypeFacets("bit", true)]
        public bool? has_filter
        {
            get;
            set;
        }

        [SqlColumn("filter_definition", 22), SqlTypeFacets("nvarchar", true, -1)]
        public string filter_definition
        {
            get;
            set;
        }

        public v_table_indexes()
        {
        }

        public v_table_indexes(object[] items)
        {
            systems_server_name = (string)items[0];
            systems_database_name = (string)items[1];
            systems_schema_name = (string)items[2];
            systems_parent_name = (string)items[3];
            systems_parent_type = (string)items[4];
            object_id = (int)items[5];
            name = (string)items[6];
            index_id = (int)items[7];
            type = (byte)items[8];
            type_desc = (string)items[9];
            is_unique = (bool?)items[10];
            data_space_id = (int?)items[11];
            ignore_dup_key = (bool?)items[12];
            is_primary_key = (bool?)items[13];
            is_unique_constraint = (bool?)items[14];
            fill_factor = (byte)items[15];
            is_padded = (bool?)items[16];
            is_disabled = (bool?)items[17];
            is_hypothetical = (bool?)items[18];
            allow_row_locks = (bool?)items[19];
            allow_page_locks = (bool?)items[20];
            has_filter = (bool?)items[21];
            filter_definition = (string)items[22];
        }

        public v_table_indexes(string systems_server_name, string systems_database_name, string systems_schema_name, string systems_parent_name, string systems_parent_type, int object_id, string name, int index_id, byte type, string type_desc, bool? is_unique, int? data_space_id, bool? ignore_dup_key, bool? is_primary_key, bool? is_unique_constraint, byte fill_factor, bool? is_padded, bool? is_disabled, bool? is_hypothetical, bool? allow_row_locks, bool? allow_page_locks, bool? has_filter, string filter_definition)
        {
            this.systems_server_name = systems_server_name;
            this.systems_database_name = systems_database_name;
            this.systems_schema_name = systems_schema_name;
            this.systems_parent_name = systems_parent_name;
            this.systems_parent_type = systems_parent_type;
            this.object_id = object_id;
            this.name = name;
            this.index_id = index_id;
            this.type = type;
            this.type_desc = type_desc;
            this.is_unique = is_unique;
            this.data_space_id = data_space_id;
            this.ignore_dup_key = ignore_dup_key;
            this.is_primary_key = is_primary_key;
            this.is_unique_constraint = is_unique_constraint;
            this.fill_factor = fill_factor;
            this.is_padded = is_padded;
            this.is_disabled = is_disabled;
            this.is_hypothetical = is_hypothetical;
            this.allow_row_locks = allow_row_locks;
            this.allow_page_locks = allow_page_locks;
            this.has_filter = has_filter;
            this.filter_definition = filter_definition;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_server_name, systems_database_name, systems_schema_name, systems_parent_name, systems_parent_type, object_id, name, index_id, type, type_desc, is_unique, data_space_id, ignore_dup_key, is_primary_key, is_unique_constraint, fill_factor, is_padded, is_disabled, is_hypothetical, allow_row_locks, allow_page_locks, has_filter, filter_definition };
        }

        public override void SetItemArray(object[] items)
        {
            systems_server_name = (string)items[0];
            systems_database_name = (string)items[1];
            systems_schema_name = (string)items[2];
            systems_parent_name = (string)items[3];
            systems_parent_type = (string)items[4];
            object_id = (int)items[5];
            name = (string)items[6];
            index_id = (int)items[7];
            type = (byte)items[8];
            type_desc = (string)items[9];
            is_unique = (bool?)items[10];
            data_space_id = (int?)items[11];
            ignore_dup_key = (bool?)items[12];
            is_primary_key = (bool?)items[13];
            is_unique_constraint = (bool?)items[14];
            fill_factor = (byte)items[15];
            is_padded = (bool?)items[16];
            is_disabled = (bool?)items[17];
            is_hypothetical = (bool?)items[18];
            allow_row_locks = (bool?)items[19];
            allow_page_locks = (bool?)items[20];
            has_filter = (bool?)items[21];
            filter_definition = (string)items[22];
        }
    }

    [SqlView("systems", "v_tables")]
    public partial class v_tables : SqlViewProxy
    {
        [SqlColumn("systems_server_name", 0), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("systems_database_name", 1), SqlTypeFacets("sysname", false)]
        public string systems_database_name
        {
            get;
            set;
        }

        [SqlColumn("systems_schema_name", 2), SqlTypeFacets("sysname", false)]
        public string systems_schema_name
        {
            get;
            set;
        }

        [SqlColumn("name", 3), SqlTypeFacets("sysname", false)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("object_id", 4), SqlTypeFacets("int", false)]
        public int object_id
        {
            get;
            set;
        }

        [SqlColumn("principal_id", 5), SqlTypeFacets("int", true)]
        public int? principal_id
        {
            get;
            set;
        }

        [SqlColumn("schema_id", 6), SqlTypeFacets("int", false)]
        public int schema_id
        {
            get;
            set;
        }

        [SqlColumn("parent_object_id", 7), SqlTypeFacets("int", false)]
        public int parent_object_id
        {
            get;
            set;
        }

        [SqlColumn("type", 8), SqlTypeFacets("char", true, 2)]
        public string type
        {
            get;
            set;
        }

        [SqlColumn("type_desc", 9), SqlTypeFacets("nvarchar", true, 120)]
        public string type_desc
        {
            get;
            set;
        }

        [SqlColumn("create_date", 10), SqlTypeFacets("datetime", false)]
        public DateTime create_date
        {
            get;
            set;
        }

        [SqlColumn("modify_date", 11), SqlTypeFacets("datetime", false)]
        public DateTime modify_date
        {
            get;
            set;
        }

        [SqlColumn("is_ms_shipped", 12), SqlTypeFacets("bit", false)]
        public bool is_ms_shipped
        {
            get;
            set;
        }

        [SqlColumn("is_published", 13), SqlTypeFacets("bit", false)]
        public bool is_published
        {
            get;
            set;
        }

        [SqlColumn("is_schema_published", 14), SqlTypeFacets("bit", false)]
        public bool is_schema_published
        {
            get;
            set;
        }

        [SqlColumn("lob_data_space_id", 15), SqlTypeFacets("int", false)]
        public int lob_data_space_id
        {
            get;
            set;
        }

        [SqlColumn("filestream_data_space_id", 16), SqlTypeFacets("int", true)]
        public int? filestream_data_space_id
        {
            get;
            set;
        }

        [SqlColumn("max_column_id_used", 17), SqlTypeFacets("int", false)]
        public int max_column_id_used
        {
            get;
            set;
        }

        [SqlColumn("lock_on_bulk_load", 18), SqlTypeFacets("bit", false)]
        public bool lock_on_bulk_load
        {
            get;
            set;
        }

        [SqlColumn("uses_ansi_nulls", 19), SqlTypeFacets("bit", true)]
        public bool? uses_ansi_nulls
        {
            get;
            set;
        }

        [SqlColumn("is_replicated", 20), SqlTypeFacets("bit", true)]
        public bool? is_replicated
        {
            get;
            set;
        }

        [SqlColumn("has_replication_filter", 21), SqlTypeFacets("bit", true)]
        public bool? has_replication_filter
        {
            get;
            set;
        }

        [SqlColumn("is_merge_published", 22), SqlTypeFacets("bit", true)]
        public bool? is_merge_published
        {
            get;
            set;
        }

        [SqlColumn("is_sync_tran_subscribed", 23), SqlTypeFacets("bit", true)]
        public bool? is_sync_tran_subscribed
        {
            get;
            set;
        }

        [SqlColumn("has_unchecked_assembly_data", 24), SqlTypeFacets("bit", false)]
        public bool has_unchecked_assembly_data
        {
            get;
            set;
        }

        [SqlColumn("text_in_row_limit", 25), SqlTypeFacets("int", true)]
        public int? text_in_row_limit
        {
            get;
            set;
        }

        [SqlColumn("large_value_types_out_of_row", 26), SqlTypeFacets("bit", true)]
        public bool? large_value_types_out_of_row
        {
            get;
            set;
        }

        [SqlColumn("is_tracked_by_cdc", 27), SqlTypeFacets("bit", true)]
        public bool? is_tracked_by_cdc
        {
            get;
            set;
        }

        [SqlColumn("lock_escalation", 28), SqlTypeFacets("tinyint", true)]
        public byte? lock_escalation
        {
            get;
            set;
        }

        [SqlColumn("lock_escalation_desc", 29), SqlTypeFacets("nvarchar", true, 120)]
        public string lock_escalation_desc
        {
            get;
            set;
        }

        [SqlColumn("is_filetable", 30), SqlTypeFacets("bit", true)]
        public bool? is_filetable
        {
            get;
            set;
        }

        [SqlColumn("is_memory_optimized", 31), SqlTypeFacets("bit", true)]
        public bool? is_memory_optimized
        {
            get;
            set;
        }

        [SqlColumn("durability", 32), SqlTypeFacets("tinyint", true)]
        public byte? durability
        {
            get;
            set;
        }

        [SqlColumn("durability_desc", 33), SqlTypeFacets("nvarchar", true, 120)]
        public string durability_desc
        {
            get;
            set;
        }

        public v_tables()
        {
        }

        public v_tables(object[] items)
        {
            systems_server_name = (string)items[0];
            systems_database_name = (string)items[1];
            systems_schema_name = (string)items[2];
            name = (string)items[3];
            object_id = (int)items[4];
            principal_id = (int?)items[5];
            schema_id = (int)items[6];
            parent_object_id = (int)items[7];
            type = (string)items[8];
            type_desc = (string)items[9];
            create_date = (DateTime)items[10];
            modify_date = (DateTime)items[11];
            is_ms_shipped = (bool)items[12];
            is_published = (bool)items[13];
            is_schema_published = (bool)items[14];
            lob_data_space_id = (int)items[15];
            filestream_data_space_id = (int?)items[16];
            max_column_id_used = (int)items[17];
            lock_on_bulk_load = (bool)items[18];
            uses_ansi_nulls = (bool?)items[19];
            is_replicated = (bool?)items[20];
            has_replication_filter = (bool?)items[21];
            is_merge_published = (bool?)items[22];
            is_sync_tran_subscribed = (bool?)items[23];
            has_unchecked_assembly_data = (bool)items[24];
            text_in_row_limit = (int?)items[25];
            large_value_types_out_of_row = (bool?)items[26];
            is_tracked_by_cdc = (bool?)items[27];
            lock_escalation = (byte?)items[28];
            lock_escalation_desc = (string)items[29];
            is_filetable = (bool?)items[30];
            is_memory_optimized = (bool?)items[31];
            durability = (byte?)items[32];
            durability_desc = (string)items[33];
        }

        public v_tables(string systems_server_name, string systems_database_name, string systems_schema_name, string name, int object_id, int? principal_id, int schema_id, int parent_object_id, string type, string type_desc, DateTime create_date, DateTime modify_date, bool is_ms_shipped, bool is_published, bool is_schema_published, int lob_data_space_id, int? filestream_data_space_id, int max_column_id_used, bool lock_on_bulk_load, bool? uses_ansi_nulls, bool? is_replicated, bool? has_replication_filter, bool? is_merge_published, bool? is_sync_tran_subscribed, bool has_unchecked_assembly_data, int? text_in_row_limit, bool? large_value_types_out_of_row, bool? is_tracked_by_cdc, byte? lock_escalation, string lock_escalation_desc, bool? is_filetable, bool? is_memory_optimized, byte? durability, string durability_desc)
        {
            this.systems_server_name = systems_server_name;
            this.systems_database_name = systems_database_name;
            this.systems_schema_name = systems_schema_name;
            this.name = name;
            this.object_id = object_id;
            this.principal_id = principal_id;
            this.schema_id = schema_id;
            this.parent_object_id = parent_object_id;
            this.type = type;
            this.type_desc = type_desc;
            this.create_date = create_date;
            this.modify_date = modify_date;
            this.is_ms_shipped = is_ms_shipped;
            this.is_published = is_published;
            this.is_schema_published = is_schema_published;
            this.lob_data_space_id = lob_data_space_id;
            this.filestream_data_space_id = filestream_data_space_id;
            this.max_column_id_used = max_column_id_used;
            this.lock_on_bulk_load = lock_on_bulk_load;
            this.uses_ansi_nulls = uses_ansi_nulls;
            this.is_replicated = is_replicated;
            this.has_replication_filter = has_replication_filter;
            this.is_merge_published = is_merge_published;
            this.is_sync_tran_subscribed = is_sync_tran_subscribed;
            this.has_unchecked_assembly_data = has_unchecked_assembly_data;
            this.text_in_row_limit = text_in_row_limit;
            this.large_value_types_out_of_row = large_value_types_out_of_row;
            this.is_tracked_by_cdc = is_tracked_by_cdc;
            this.lock_escalation = lock_escalation;
            this.lock_escalation_desc = lock_escalation_desc;
            this.is_filetable = is_filetable;
            this.is_memory_optimized = is_memory_optimized;
            this.durability = durability;
            this.durability_desc = durability_desc;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_server_name, systems_database_name, systems_schema_name, name, object_id, principal_id, schema_id, parent_object_id, type, type_desc, create_date, modify_date, is_ms_shipped, is_published, is_schema_published, lob_data_space_id, filestream_data_space_id, max_column_id_used, lock_on_bulk_load, uses_ansi_nulls, is_replicated, has_replication_filter, is_merge_published, is_sync_tran_subscribed, has_unchecked_assembly_data, text_in_row_limit, large_value_types_out_of_row, is_tracked_by_cdc, lock_escalation, lock_escalation_desc, is_filetable, is_memory_optimized, durability, durability_desc };
        }

        public override void SetItemArray(object[] items)
        {
            systems_server_name = (string)items[0];
            systems_database_name = (string)items[1];
            systems_schema_name = (string)items[2];
            name = (string)items[3];
            object_id = (int)items[4];
            principal_id = (int?)items[5];
            schema_id = (int)items[6];
            parent_object_id = (int)items[7];
            type = (string)items[8];
            type_desc = (string)items[9];
            create_date = (DateTime)items[10];
            modify_date = (DateTime)items[11];
            is_ms_shipped = (bool)items[12];
            is_published = (bool)items[13];
            is_schema_published = (bool)items[14];
            lob_data_space_id = (int)items[15];
            filestream_data_space_id = (int?)items[16];
            max_column_id_used = (int)items[17];
            lock_on_bulk_load = (bool)items[18];
            uses_ansi_nulls = (bool?)items[19];
            is_replicated = (bool?)items[20];
            has_replication_filter = (bool?)items[21];
            is_merge_published = (bool?)items[22];
            is_sync_tran_subscribed = (bool?)items[23];
            has_unchecked_assembly_data = (bool)items[24];
            text_in_row_limit = (int?)items[25];
            large_value_types_out_of_row = (bool?)items[26];
            is_tracked_by_cdc = (bool?)items[27];
            lock_escalation = (byte?)items[28];
            lock_escalation_desc = (string)items[29];
            is_filetable = (bool?)items[30];
            is_memory_optimized = (bool?)items[31];
            durability = (byte?)items[32];
            durability_desc = (string)items[33];
        }
    }

    [SqlView("systems", "v_types")]
    public partial class v_types : SqlViewProxy
    {
        [SqlColumn("systems_server_name", 0), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("systems_database_name", 1), SqlTypeFacets("sysname", false)]
        public string systems_database_name
        {
            get;
            set;
        }

        [SqlColumn("systems_schema_name", 2), SqlTypeFacets("sysname", false)]
        public string systems_schema_name
        {
            get;
            set;
        }

        [SqlColumn("name", 3), SqlTypeFacets("sysname", false)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("system_type_id", 4), SqlTypeFacets("tinyint", false)]
        public byte system_type_id
        {
            get;
            set;
        }

        [SqlColumn("user_type_id", 5), SqlTypeFacets("int", false)]
        public int user_type_id
        {
            get;
            set;
        }

        [SqlColumn("schema_id", 6), SqlTypeFacets("int", false)]
        public int schema_id
        {
            get;
            set;
        }

        [SqlColumn("principal_id", 7), SqlTypeFacets("int", true)]
        public int? principal_id
        {
            get;
            set;
        }

        [SqlColumn("max_length", 8), SqlTypeFacets("smallint", false)]
        public short max_length
        {
            get;
            set;
        }

        [SqlColumn("precision", 9), SqlTypeFacets("tinyint", false)]
        public byte precision
        {
            get;
            set;
        }

        [SqlColumn("scale", 10), SqlTypeFacets("tinyint", false)]
        public byte scale
        {
            get;
            set;
        }

        [SqlColumn("collation_name", 11), SqlTypeFacets("sysname", true)]
        public string collation_name
        {
            get;
            set;
        }

        [SqlColumn("is_nullable", 12), SqlTypeFacets("bit", true)]
        public bool? is_nullable
        {
            get;
            set;
        }

        [SqlColumn("is_user_defined", 13), SqlTypeFacets("bit", false)]
        public bool is_user_defined
        {
            get;
            set;
        }

        [SqlColumn("is_assembly_type", 14), SqlTypeFacets("bit", false)]
        public bool is_assembly_type
        {
            get;
            set;
        }

        [SqlColumn("default_object_id", 15), SqlTypeFacets("int", false)]
        public int default_object_id
        {
            get;
            set;
        }

        [SqlColumn("rule_object_id", 16), SqlTypeFacets("int", false)]
        public int rule_object_id
        {
            get;
            set;
        }

        [SqlColumn("is_table_type", 17), SqlTypeFacets("bit", false)]
        public bool is_table_type
        {
            get;
            set;
        }

        public v_types()
        {
        }

        public v_types(object[] items)
        {
            systems_server_name = (string)items[0];
            systems_database_name = (string)items[1];
            systems_schema_name = (string)items[2];
            name = (string)items[3];
            system_type_id = (byte)items[4];
            user_type_id = (int)items[5];
            schema_id = (int)items[6];
            principal_id = (int?)items[7];
            max_length = (short)items[8];
            precision = (byte)items[9];
            scale = (byte)items[10];
            collation_name = (string)items[11];
            is_nullable = (bool?)items[12];
            is_user_defined = (bool)items[13];
            is_assembly_type = (bool)items[14];
            default_object_id = (int)items[15];
            rule_object_id = (int)items[16];
            is_table_type = (bool)items[17];
        }

        public v_types(string systems_server_name, string systems_database_name, string systems_schema_name, string name, byte system_type_id, int user_type_id, int schema_id, int? principal_id, short max_length, byte precision, byte scale, string collation_name, bool? is_nullable, bool is_user_defined, bool is_assembly_type, int default_object_id, int rule_object_id, bool is_table_type)
        {
            this.systems_server_name = systems_server_name;
            this.systems_database_name = systems_database_name;
            this.systems_schema_name = systems_schema_name;
            this.name = name;
            this.system_type_id = system_type_id;
            this.user_type_id = user_type_id;
            this.schema_id = schema_id;
            this.principal_id = principal_id;
            this.max_length = max_length;
            this.precision = precision;
            this.scale = scale;
            this.collation_name = collation_name;
            this.is_nullable = is_nullable;
            this.is_user_defined = is_user_defined;
            this.is_assembly_type = is_assembly_type;
            this.default_object_id = default_object_id;
            this.rule_object_id = rule_object_id;
            this.is_table_type = is_table_type;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_server_name, systems_database_name, systems_schema_name, name, system_type_id, user_type_id, schema_id, principal_id, max_length, precision, scale, collation_name, is_nullable, is_user_defined, is_assembly_type, default_object_id, rule_object_id, is_table_type };
        }

        public override void SetItemArray(object[] items)
        {
            systems_server_name = (string)items[0];
            systems_database_name = (string)items[1];
            systems_schema_name = (string)items[2];
            name = (string)items[3];
            system_type_id = (byte)items[4];
            user_type_id = (int)items[5];
            schema_id = (int)items[6];
            principal_id = (int?)items[7];
            max_length = (short)items[8];
            precision = (byte)items[9];
            scale = (byte)items[10];
            collation_name = (string)items[11];
            is_nullable = (bool?)items[12];
            is_user_defined = (bool)items[13];
            is_assembly_type = (bool)items[14];
            default_object_id = (int)items[15];
            rule_object_id = (int)items[16];
            is_table_type = (bool)items[17];
        }
    }

    [SqlView("systems", "v_views")]
    public partial class v_views : SqlViewProxy
    {
        [SqlColumn("systems_server_name", 0), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("systems_database_name", 1), SqlTypeFacets("sysname", false)]
        public string systems_database_name
        {
            get;
            set;
        }

        [SqlColumn("systems_schema_name", 2), SqlTypeFacets("sysname", false)]
        public string systems_schema_name
        {
            get;
            set;
        }

        [SqlColumn("name", 3), SqlTypeFacets("sysname", false)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("object_id", 4), SqlTypeFacets("int", false)]
        public int object_id
        {
            get;
            set;
        }

        [SqlColumn("principal_id", 5), SqlTypeFacets("int", true)]
        public int? principal_id
        {
            get;
            set;
        }

        [SqlColumn("schema_id", 6), SqlTypeFacets("int", false)]
        public int schema_id
        {
            get;
            set;
        }

        [SqlColumn("parent_object_id", 7), SqlTypeFacets("int", false)]
        public int parent_object_id
        {
            get;
            set;
        }

        [SqlColumn("type", 8), SqlTypeFacets("char", true, 2)]
        public string type
        {
            get;
            set;
        }

        [SqlColumn("type_desc", 9), SqlTypeFacets("nvarchar", true, 120)]
        public string type_desc
        {
            get;
            set;
        }

        [SqlColumn("create_date", 10), SqlTypeFacets("datetime", false)]
        public DateTime create_date
        {
            get;
            set;
        }

        [SqlColumn("modify_date", 11), SqlTypeFacets("datetime", false)]
        public DateTime modify_date
        {
            get;
            set;
        }

        [SqlColumn("is_ms_shipped", 12), SqlTypeFacets("bit", false)]
        public bool is_ms_shipped
        {
            get;
            set;
        }

        [SqlColumn("is_published", 13), SqlTypeFacets("bit", false)]
        public bool is_published
        {
            get;
            set;
        }

        [SqlColumn("is_schema_published", 14), SqlTypeFacets("bit", false)]
        public bool is_schema_published
        {
            get;
            set;
        }

        [SqlColumn("is_replicated", 15), SqlTypeFacets("bit", true)]
        public bool? is_replicated
        {
            get;
            set;
        }

        [SqlColumn("has_replication_filter", 16), SqlTypeFacets("bit", true)]
        public bool? has_replication_filter
        {
            get;
            set;
        }

        [SqlColumn("has_opaque_metadata", 17), SqlTypeFacets("bit", false)]
        public bool has_opaque_metadata
        {
            get;
            set;
        }

        [SqlColumn("has_unchecked_assembly_data", 18), SqlTypeFacets("bit", false)]
        public bool has_unchecked_assembly_data
        {
            get;
            set;
        }

        [SqlColumn("with_check_option", 19), SqlTypeFacets("bit", false)]
        public bool with_check_option
        {
            get;
            set;
        }

        [SqlColumn("is_date_correlation_view", 20), SqlTypeFacets("bit", false)]
        public bool is_date_correlation_view
        {
            get;
            set;
        }

        [SqlColumn("is_tracked_by_cdc", 21), SqlTypeFacets("bit", true)]
        public bool? is_tracked_by_cdc
        {
            get;
            set;
        }

        public v_views()
        {
        }

        public v_views(object[] items)
        {
            systems_server_name = (string)items[0];
            systems_database_name = (string)items[1];
            systems_schema_name = (string)items[2];
            name = (string)items[3];
            object_id = (int)items[4];
            principal_id = (int?)items[5];
            schema_id = (int)items[6];
            parent_object_id = (int)items[7];
            type = (string)items[8];
            type_desc = (string)items[9];
            create_date = (DateTime)items[10];
            modify_date = (DateTime)items[11];
            is_ms_shipped = (bool)items[12];
            is_published = (bool)items[13];
            is_schema_published = (bool)items[14];
            is_replicated = (bool?)items[15];
            has_replication_filter = (bool?)items[16];
            has_opaque_metadata = (bool)items[17];
            has_unchecked_assembly_data = (bool)items[18];
            with_check_option = (bool)items[19];
            is_date_correlation_view = (bool)items[20];
            is_tracked_by_cdc = (bool?)items[21];
        }

        public v_views(string systems_server_name, string systems_database_name, string systems_schema_name, string name, int object_id, int? principal_id, int schema_id, int parent_object_id, string type, string type_desc, DateTime create_date, DateTime modify_date, bool is_ms_shipped, bool is_published, bool is_schema_published, bool? is_replicated, bool? has_replication_filter, bool has_opaque_metadata, bool has_unchecked_assembly_data, bool with_check_option, bool is_date_correlation_view, bool? is_tracked_by_cdc)
        {
            this.systems_server_name = systems_server_name;
            this.systems_database_name = systems_database_name;
            this.systems_schema_name = systems_schema_name;
            this.name = name;
            this.object_id = object_id;
            this.principal_id = principal_id;
            this.schema_id = schema_id;
            this.parent_object_id = parent_object_id;
            this.type = type;
            this.type_desc = type_desc;
            this.create_date = create_date;
            this.modify_date = modify_date;
            this.is_ms_shipped = is_ms_shipped;
            this.is_published = is_published;
            this.is_schema_published = is_schema_published;
            this.is_replicated = is_replicated;
            this.has_replication_filter = has_replication_filter;
            this.has_opaque_metadata = has_opaque_metadata;
            this.has_unchecked_assembly_data = has_unchecked_assembly_data;
            this.with_check_option = with_check_option;
            this.is_date_correlation_view = is_date_correlation_view;
            this.is_tracked_by_cdc = is_tracked_by_cdc;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_server_name, systems_database_name, systems_schema_name, name, object_id, principal_id, schema_id, parent_object_id, type, type_desc, create_date, modify_date, is_ms_shipped, is_published, is_schema_published, is_replicated, has_replication_filter, has_opaque_metadata, has_unchecked_assembly_data, with_check_option, is_date_correlation_view, is_tracked_by_cdc };
        }

        public override void SetItemArray(object[] items)
        {
            systems_server_name = (string)items[0];
            systems_database_name = (string)items[1];
            systems_schema_name = (string)items[2];
            name = (string)items[3];
            object_id = (int)items[4];
            principal_id = (int?)items[5];
            schema_id = (int)items[6];
            parent_object_id = (int)items[7];
            type = (string)items[8];
            type_desc = (string)items[9];
            create_date = (DateTime)items[10];
            modify_date = (DateTime)items[11];
            is_ms_shipped = (bool)items[12];
            is_published = (bool)items[13];
            is_schema_published = (bool)items[14];
            is_replicated = (bool?)items[15];
            has_replication_filter = (bool?)items[16];
            has_opaque_metadata = (bool)items[17];
            has_unchecked_assembly_data = (bool)items[18];
            with_check_option = (bool)items[19];
            is_date_correlation_view = (bool)items[20];
            is_tracked_by_cdc = (bool?)items[21];
        }
    }

    [SqlView("systems", "v_databases")]
    public partial class v_databases : SqlViewProxy
    {
        [SqlColumn("systems_server_name", 0), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("name", 1), SqlTypeFacets("sysname", false)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("database_id", 2), SqlTypeFacets("int", false)]
        public int database_id
        {
            get;
            set;
        }

        [SqlColumn("source_database_id", 3), SqlTypeFacets("int", true)]
        public int? source_database_id
        {
            get;
            set;
        }

        [SqlColumn("owner_sid", 4), SqlTypeFacets("varbinary", true, 85)]
        public Byte[] owner_sid
        {
            get;
            set;
        }

        [SqlColumn("create_date", 5), SqlTypeFacets("datetime", false)]
        public DateTime create_date
        {
            get;
            set;
        }

        [SqlColumn("compatibility_level", 6), SqlTypeFacets("tinyint", false)]
        public byte compatibility_level
        {
            get;
            set;
        }

        [SqlColumn("collation_name", 7), SqlTypeFacets("nvarchar", true, 256)]
        public string collation_name
        {
            get;
            set;
        }

        [SqlColumn("user_access", 8), SqlTypeFacets("tinyint", true)]
        public byte? user_access
        {
            get;
            set;
        }

        [SqlColumn("user_access_desc", 9), SqlTypeFacets("nvarchar", true, 120)]
        public string user_access_desc
        {
            get;
            set;
        }

        [SqlColumn("is_read_only", 10), SqlTypeFacets("bit", true)]
        public bool? is_read_only
        {
            get;
            set;
        }

        [SqlColumn("is_auto_close_on", 11), SqlTypeFacets("bit", false)]
        public bool is_auto_close_on
        {
            get;
            set;
        }

        [SqlColumn("is_auto_shrink_on", 12), SqlTypeFacets("bit", true)]
        public bool? is_auto_shrink_on
        {
            get;
            set;
        }

        [SqlColumn("state", 13), SqlTypeFacets("tinyint", true)]
        public byte? state
        {
            get;
            set;
        }

        [SqlColumn("state_desc", 14), SqlTypeFacets("nvarchar", true, 120)]
        public string state_desc
        {
            get;
            set;
        }

        [SqlColumn("is_in_standby", 15), SqlTypeFacets("bit", true)]
        public bool? is_in_standby
        {
            get;
            set;
        }

        [SqlColumn("is_cleanly_shutdown", 16), SqlTypeFacets("bit", true)]
        public bool? is_cleanly_shutdown
        {
            get;
            set;
        }

        [SqlColumn("is_supplemental_logging_enabled", 17), SqlTypeFacets("bit", true)]
        public bool? is_supplemental_logging_enabled
        {
            get;
            set;
        }

        [SqlColumn("snapshot_isolation_state", 18), SqlTypeFacets("tinyint", true)]
        public byte? snapshot_isolation_state
        {
            get;
            set;
        }

        [SqlColumn("snapshot_isolation_state_desc", 19), SqlTypeFacets("nvarchar", true, 120)]
        public string snapshot_isolation_state_desc
        {
            get;
            set;
        }

        [SqlColumn("is_read_committed_snapshot_on", 20), SqlTypeFacets("bit", true)]
        public bool? is_read_committed_snapshot_on
        {
            get;
            set;
        }

        [SqlColumn("recovery_model", 21), SqlTypeFacets("tinyint", true)]
        public byte? recovery_model
        {
            get;
            set;
        }

        [SqlColumn("recovery_model_desc", 22), SqlTypeFacets("nvarchar", true, 120)]
        public string recovery_model_desc
        {
            get;
            set;
        }

        [SqlColumn("page_verify_option", 23), SqlTypeFacets("tinyint", true)]
        public byte? page_verify_option
        {
            get;
            set;
        }

        [SqlColumn("page_verify_option_desc", 24), SqlTypeFacets("nvarchar", true, 120)]
        public string page_verify_option_desc
        {
            get;
            set;
        }

        [SqlColumn("is_auto_create_stats_on", 25), SqlTypeFacets("bit", true)]
        public bool? is_auto_create_stats_on
        {
            get;
            set;
        }

        [SqlColumn("is_auto_update_stats_on", 26), SqlTypeFacets("bit", true)]
        public bool? is_auto_update_stats_on
        {
            get;
            set;
        }

        [SqlColumn("is_auto_update_stats_async_on", 27), SqlTypeFacets("bit", true)]
        public bool? is_auto_update_stats_async_on
        {
            get;
            set;
        }

        [SqlColumn("is_ansi_null_default_on", 28), SqlTypeFacets("bit", true)]
        public bool? is_ansi_null_default_on
        {
            get;
            set;
        }

        [SqlColumn("is_ansi_nulls_on", 29), SqlTypeFacets("bit", true)]
        public bool? is_ansi_nulls_on
        {
            get;
            set;
        }

        [SqlColumn("is_ansi_padding_on", 30), SqlTypeFacets("bit", true)]
        public bool? is_ansi_padding_on
        {
            get;
            set;
        }

        [SqlColumn("is_ansi_warnings_on", 31), SqlTypeFacets("bit", true)]
        public bool? is_ansi_warnings_on
        {
            get;
            set;
        }

        [SqlColumn("is_arithabort_on", 32), SqlTypeFacets("bit", true)]
        public bool? is_arithabort_on
        {
            get;
            set;
        }

        [SqlColumn("is_concat_null_yields_null_on", 33), SqlTypeFacets("bit", true)]
        public bool? is_concat_null_yields_null_on
        {
            get;
            set;
        }

        [SqlColumn("is_numeric_roundabort_on", 34), SqlTypeFacets("bit", true)]
        public bool? is_numeric_roundabort_on
        {
            get;
            set;
        }

        [SqlColumn("is_quoted_identifier_on", 35), SqlTypeFacets("bit", true)]
        public bool? is_quoted_identifier_on
        {
            get;
            set;
        }

        [SqlColumn("is_recursive_triggers_on", 36), SqlTypeFacets("bit", true)]
        public bool? is_recursive_triggers_on
        {
            get;
            set;
        }

        [SqlColumn("is_cursor_close_on_commit_on", 37), SqlTypeFacets("bit", true)]
        public bool? is_cursor_close_on_commit_on
        {
            get;
            set;
        }

        [SqlColumn("is_local_cursor_default", 38), SqlTypeFacets("bit", true)]
        public bool? is_local_cursor_default
        {
            get;
            set;
        }

        [SqlColumn("is_fulltext_enabled", 39), SqlTypeFacets("bit", true)]
        public bool? is_fulltext_enabled
        {
            get;
            set;
        }

        [SqlColumn("is_trustworthy_on", 40), SqlTypeFacets("bit", true)]
        public bool? is_trustworthy_on
        {
            get;
            set;
        }

        [SqlColumn("is_db_chaining_on", 41), SqlTypeFacets("bit", true)]
        public bool? is_db_chaining_on
        {
            get;
            set;
        }

        [SqlColumn("is_parameterization_forced", 42), SqlTypeFacets("bit", true)]
        public bool? is_parameterization_forced
        {
            get;
            set;
        }

        [SqlColumn("is_master_key_encrypted_by_server", 43), SqlTypeFacets("bit", false)]
        public bool is_master_key_encrypted_by_server
        {
            get;
            set;
        }

        [SqlColumn("is_published", 44), SqlTypeFacets("bit", false)]
        public bool is_published
        {
            get;
            set;
        }

        [SqlColumn("is_subscribed", 45), SqlTypeFacets("bit", false)]
        public bool is_subscribed
        {
            get;
            set;
        }

        [SqlColumn("is_merge_published", 46), SqlTypeFacets("bit", false)]
        public bool is_merge_published
        {
            get;
            set;
        }

        [SqlColumn("is_distributor", 47), SqlTypeFacets("bit", false)]
        public bool is_distributor
        {
            get;
            set;
        }

        [SqlColumn("is_sync_with_backup", 48), SqlTypeFacets("bit", false)]
        public bool is_sync_with_backup
        {
            get;
            set;
        }

        [SqlColumn("service_broker_guid", 49), SqlTypeFacets("uniqueidentifier", false)]
        public Guid service_broker_guid
        {
            get;
            set;
        }

        [SqlColumn("is_broker_enabled", 50), SqlTypeFacets("bit", false)]
        public bool is_broker_enabled
        {
            get;
            set;
        }

        [SqlColumn("log_reuse_wait", 51), SqlTypeFacets("tinyint", true)]
        public byte? log_reuse_wait
        {
            get;
            set;
        }

        [SqlColumn("log_reuse_wait_desc", 52), SqlTypeFacets("nvarchar", true, 120)]
        public string log_reuse_wait_desc
        {
            get;
            set;
        }

        [SqlColumn("is_date_correlation_on", 53), SqlTypeFacets("bit", false)]
        public bool is_date_correlation_on
        {
            get;
            set;
        }

        [SqlColumn("is_cdc_enabled", 54), SqlTypeFacets("bit", false)]
        public bool is_cdc_enabled
        {
            get;
            set;
        }

        [SqlColumn("is_encrypted", 55), SqlTypeFacets("bit", true)]
        public bool? is_encrypted
        {
            get;
            set;
        }

        [SqlColumn("is_honor_broker_priority_on", 56), SqlTypeFacets("bit", true)]
        public bool? is_honor_broker_priority_on
        {
            get;
            set;
        }

        [SqlColumn("replica_id", 57), SqlTypeFacets("uniqueidentifier", true)]
        public Guid? replica_id
        {
            get;
            set;
        }

        [SqlColumn("group_database_id", 58), SqlTypeFacets("uniqueidentifier", true)]
        public Guid? group_database_id
        {
            get;
            set;
        }

        [SqlColumn("default_language_lcid", 59), SqlTypeFacets("smallint", true)]
        public short? default_language_lcid
        {
            get;
            set;
        }

        [SqlColumn("default_language_name", 60), SqlTypeFacets("nvarchar", true, 256)]
        public string default_language_name
        {
            get;
            set;
        }

        [SqlColumn("default_fulltext_language_lcid", 61), SqlTypeFacets("int", true)]
        public int? default_fulltext_language_lcid
        {
            get;
            set;
        }

        [SqlColumn("default_fulltext_language_name", 62), SqlTypeFacets("nvarchar", true, 256)]
        public string default_fulltext_language_name
        {
            get;
            set;
        }

        [SqlColumn("is_nested_triggers_on", 63), SqlTypeFacets("bit", true)]
        public bool? is_nested_triggers_on
        {
            get;
            set;
        }

        [SqlColumn("is_transform_noise_words_on", 64), SqlTypeFacets("bit", true)]
        public bool? is_transform_noise_words_on
        {
            get;
            set;
        }

        [SqlColumn("two_digit_year_cutoff", 65), SqlTypeFacets("smallint", true)]
        public short? two_digit_year_cutoff
        {
            get;
            set;
        }

        [SqlColumn("containment", 66), SqlTypeFacets("tinyint", true)]
        public byte? containment
        {
            get;
            set;
        }

        [SqlColumn("containment_desc", 67), SqlTypeFacets("nvarchar", true, 120)]
        public string containment_desc
        {
            get;
            set;
        }

        [SqlColumn("target_recovery_time_in_seconds", 68), SqlTypeFacets("int", true)]
        public int? target_recovery_time_in_seconds
        {
            get;
            set;
        }

        public v_databases()
        {
        }

        public v_databases(object[] items)
        {
            systems_server_name = (string)items[0];
            name = (string)items[1];
            database_id = (int)items[2];
            source_database_id = (int?)items[3];
            owner_sid = (Byte[])items[4];
            create_date = (DateTime)items[5];
            compatibility_level = (byte)items[6];
            collation_name = (string)items[7];
            user_access = (byte?)items[8];
            user_access_desc = (string)items[9];
            is_read_only = (bool?)items[10];
            is_auto_close_on = (bool)items[11];
            is_auto_shrink_on = (bool?)items[12];
            state = (byte?)items[13];
            state_desc = (string)items[14];
            is_in_standby = (bool?)items[15];
            is_cleanly_shutdown = (bool?)items[16];
            is_supplemental_logging_enabled = (bool?)items[17];
            snapshot_isolation_state = (byte?)items[18];
            snapshot_isolation_state_desc = (string)items[19];
            is_read_committed_snapshot_on = (bool?)items[20];
            recovery_model = (byte?)items[21];
            recovery_model_desc = (string)items[22];
            page_verify_option = (byte?)items[23];
            page_verify_option_desc = (string)items[24];
            is_auto_create_stats_on = (bool?)items[25];
            is_auto_update_stats_on = (bool?)items[26];
            is_auto_update_stats_async_on = (bool?)items[27];
            is_ansi_null_default_on = (bool?)items[28];
            is_ansi_nulls_on = (bool?)items[29];
            is_ansi_padding_on = (bool?)items[30];
            is_ansi_warnings_on = (bool?)items[31];
            is_arithabort_on = (bool?)items[32];
            is_concat_null_yields_null_on = (bool?)items[33];
            is_numeric_roundabort_on = (bool?)items[34];
            is_quoted_identifier_on = (bool?)items[35];
            is_recursive_triggers_on = (bool?)items[36];
            is_cursor_close_on_commit_on = (bool?)items[37];
            is_local_cursor_default = (bool?)items[38];
            is_fulltext_enabled = (bool?)items[39];
            is_trustworthy_on = (bool?)items[40];
            is_db_chaining_on = (bool?)items[41];
            is_parameterization_forced = (bool?)items[42];
            is_master_key_encrypted_by_server = (bool)items[43];
            is_published = (bool)items[44];
            is_subscribed = (bool)items[45];
            is_merge_published = (bool)items[46];
            is_distributor = (bool)items[47];
            is_sync_with_backup = (bool)items[48];
            service_broker_guid = (Guid)items[49];
            is_broker_enabled = (bool)items[50];
            log_reuse_wait = (byte?)items[51];
            log_reuse_wait_desc = (string)items[52];
            is_date_correlation_on = (bool)items[53];
            is_cdc_enabled = (bool)items[54];
            is_encrypted = (bool?)items[55];
            is_honor_broker_priority_on = (bool?)items[56];
            replica_id = (Guid?)items[57];
            group_database_id = (Guid?)items[58];
            default_language_lcid = (short?)items[59];
            default_language_name = (string)items[60];
            default_fulltext_language_lcid = (int?)items[61];
            default_fulltext_language_name = (string)items[62];
            is_nested_triggers_on = (bool?)items[63];
            is_transform_noise_words_on = (bool?)items[64];
            two_digit_year_cutoff = (short?)items[65];
            containment = (byte?)items[66];
            containment_desc = (string)items[67];
            target_recovery_time_in_seconds = (int?)items[68];
        }

        public v_databases(string systems_server_name, string name, int database_id, int? source_database_id, Byte[] owner_sid, DateTime create_date, byte compatibility_level, string collation_name, byte? user_access, string user_access_desc, bool? is_read_only, bool is_auto_close_on, bool? is_auto_shrink_on, byte? state, string state_desc, bool? is_in_standby, bool? is_cleanly_shutdown, bool? is_supplemental_logging_enabled, byte? snapshot_isolation_state, string snapshot_isolation_state_desc, bool? is_read_committed_snapshot_on, byte? recovery_model, string recovery_model_desc, byte? page_verify_option, string page_verify_option_desc, bool? is_auto_create_stats_on, bool? is_auto_update_stats_on, bool? is_auto_update_stats_async_on, bool? is_ansi_null_default_on, bool? is_ansi_nulls_on, bool? is_ansi_padding_on, bool? is_ansi_warnings_on, bool? is_arithabort_on, bool? is_concat_null_yields_null_on, bool? is_numeric_roundabort_on, bool? is_quoted_identifier_on, bool? is_recursive_triggers_on, bool? is_cursor_close_on_commit_on, bool? is_local_cursor_default, bool? is_fulltext_enabled, bool? is_trustworthy_on, bool? is_db_chaining_on, bool? is_parameterization_forced, bool is_master_key_encrypted_by_server, bool is_published, bool is_subscribed, bool is_merge_published, bool is_distributor, bool is_sync_with_backup, Guid service_broker_guid, bool is_broker_enabled, byte? log_reuse_wait, string log_reuse_wait_desc, bool is_date_correlation_on, bool is_cdc_enabled, bool? is_encrypted, bool? is_honor_broker_priority_on, Guid? replica_id, Guid? group_database_id, short? default_language_lcid, string default_language_name, int? default_fulltext_language_lcid, string default_fulltext_language_name, bool? is_nested_triggers_on, bool? is_transform_noise_words_on, short? two_digit_year_cutoff, byte? containment, string containment_desc, int? target_recovery_time_in_seconds)
        {
            this.systems_server_name = systems_server_name;
            this.name = name;
            this.database_id = database_id;
            this.source_database_id = source_database_id;
            this.owner_sid = owner_sid;
            this.create_date = create_date;
            this.compatibility_level = compatibility_level;
            this.collation_name = collation_name;
            this.user_access = user_access;
            this.user_access_desc = user_access_desc;
            this.is_read_only = is_read_only;
            this.is_auto_close_on = is_auto_close_on;
            this.is_auto_shrink_on = is_auto_shrink_on;
            this.state = state;
            this.state_desc = state_desc;
            this.is_in_standby = is_in_standby;
            this.is_cleanly_shutdown = is_cleanly_shutdown;
            this.is_supplemental_logging_enabled = is_supplemental_logging_enabled;
            this.snapshot_isolation_state = snapshot_isolation_state;
            this.snapshot_isolation_state_desc = snapshot_isolation_state_desc;
            this.is_read_committed_snapshot_on = is_read_committed_snapshot_on;
            this.recovery_model = recovery_model;
            this.recovery_model_desc = recovery_model_desc;
            this.page_verify_option = page_verify_option;
            this.page_verify_option_desc = page_verify_option_desc;
            this.is_auto_create_stats_on = is_auto_create_stats_on;
            this.is_auto_update_stats_on = is_auto_update_stats_on;
            this.is_auto_update_stats_async_on = is_auto_update_stats_async_on;
            this.is_ansi_null_default_on = is_ansi_null_default_on;
            this.is_ansi_nulls_on = is_ansi_nulls_on;
            this.is_ansi_padding_on = is_ansi_padding_on;
            this.is_ansi_warnings_on = is_ansi_warnings_on;
            this.is_arithabort_on = is_arithabort_on;
            this.is_concat_null_yields_null_on = is_concat_null_yields_null_on;
            this.is_numeric_roundabort_on = is_numeric_roundabort_on;
            this.is_quoted_identifier_on = is_quoted_identifier_on;
            this.is_recursive_triggers_on = is_recursive_triggers_on;
            this.is_cursor_close_on_commit_on = is_cursor_close_on_commit_on;
            this.is_local_cursor_default = is_local_cursor_default;
            this.is_fulltext_enabled = is_fulltext_enabled;
            this.is_trustworthy_on = is_trustworthy_on;
            this.is_db_chaining_on = is_db_chaining_on;
            this.is_parameterization_forced = is_parameterization_forced;
            this.is_master_key_encrypted_by_server = is_master_key_encrypted_by_server;
            this.is_published = is_published;
            this.is_subscribed = is_subscribed;
            this.is_merge_published = is_merge_published;
            this.is_distributor = is_distributor;
            this.is_sync_with_backup = is_sync_with_backup;
            this.service_broker_guid = service_broker_guid;
            this.is_broker_enabled = is_broker_enabled;
            this.log_reuse_wait = log_reuse_wait;
            this.log_reuse_wait_desc = log_reuse_wait_desc;
            this.is_date_correlation_on = is_date_correlation_on;
            this.is_cdc_enabled = is_cdc_enabled;
            this.is_encrypted = is_encrypted;
            this.is_honor_broker_priority_on = is_honor_broker_priority_on;
            this.replica_id = replica_id;
            this.group_database_id = group_database_id;
            this.default_language_lcid = default_language_lcid;
            this.default_language_name = default_language_name;
            this.default_fulltext_language_lcid = default_fulltext_language_lcid;
            this.default_fulltext_language_name = default_fulltext_language_name;
            this.is_nested_triggers_on = is_nested_triggers_on;
            this.is_transform_noise_words_on = is_transform_noise_words_on;
            this.two_digit_year_cutoff = two_digit_year_cutoff;
            this.containment = containment;
            this.containment_desc = containment_desc;
            this.target_recovery_time_in_seconds = target_recovery_time_in_seconds;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_server_name, name, database_id, source_database_id, owner_sid, create_date, compatibility_level, collation_name, user_access, user_access_desc, is_read_only, is_auto_close_on, is_auto_shrink_on, state, state_desc, is_in_standby, is_cleanly_shutdown, is_supplemental_logging_enabled, snapshot_isolation_state, snapshot_isolation_state_desc, is_read_committed_snapshot_on, recovery_model, recovery_model_desc, page_verify_option, page_verify_option_desc, is_auto_create_stats_on, is_auto_update_stats_on, is_auto_update_stats_async_on, is_ansi_null_default_on, is_ansi_nulls_on, is_ansi_padding_on, is_ansi_warnings_on, is_arithabort_on, is_concat_null_yields_null_on, is_numeric_roundabort_on, is_quoted_identifier_on, is_recursive_triggers_on, is_cursor_close_on_commit_on, is_local_cursor_default, is_fulltext_enabled, is_trustworthy_on, is_db_chaining_on, is_parameterization_forced, is_master_key_encrypted_by_server, is_published, is_subscribed, is_merge_published, is_distributor, is_sync_with_backup, service_broker_guid, is_broker_enabled, log_reuse_wait, log_reuse_wait_desc, is_date_correlation_on, is_cdc_enabled, is_encrypted, is_honor_broker_priority_on, replica_id, group_database_id, default_language_lcid, default_language_name, default_fulltext_language_lcid, default_fulltext_language_name, is_nested_triggers_on, is_transform_noise_words_on, two_digit_year_cutoff, containment, containment_desc, target_recovery_time_in_seconds };
        }

        public override void SetItemArray(object[] items)
        {
            systems_server_name = (string)items[0];
            name = (string)items[1];
            database_id = (int)items[2];
            source_database_id = (int?)items[3];
            owner_sid = (Byte[])items[4];
            create_date = (DateTime)items[5];
            compatibility_level = (byte)items[6];
            collation_name = (string)items[7];
            user_access = (byte?)items[8];
            user_access_desc = (string)items[9];
            is_read_only = (bool?)items[10];
            is_auto_close_on = (bool)items[11];
            is_auto_shrink_on = (bool?)items[12];
            state = (byte?)items[13];
            state_desc = (string)items[14];
            is_in_standby = (bool?)items[15];
            is_cleanly_shutdown = (bool?)items[16];
            is_supplemental_logging_enabled = (bool?)items[17];
            snapshot_isolation_state = (byte?)items[18];
            snapshot_isolation_state_desc = (string)items[19];
            is_read_committed_snapshot_on = (bool?)items[20];
            recovery_model = (byte?)items[21];
            recovery_model_desc = (string)items[22];
            page_verify_option = (byte?)items[23];
            page_verify_option_desc = (string)items[24];
            is_auto_create_stats_on = (bool?)items[25];
            is_auto_update_stats_on = (bool?)items[26];
            is_auto_update_stats_async_on = (bool?)items[27];
            is_ansi_null_default_on = (bool?)items[28];
            is_ansi_nulls_on = (bool?)items[29];
            is_ansi_padding_on = (bool?)items[30];
            is_ansi_warnings_on = (bool?)items[31];
            is_arithabort_on = (bool?)items[32];
            is_concat_null_yields_null_on = (bool?)items[33];
            is_numeric_roundabort_on = (bool?)items[34];
            is_quoted_identifier_on = (bool?)items[35];
            is_recursive_triggers_on = (bool?)items[36];
            is_cursor_close_on_commit_on = (bool?)items[37];
            is_local_cursor_default = (bool?)items[38];
            is_fulltext_enabled = (bool?)items[39];
            is_trustworthy_on = (bool?)items[40];
            is_db_chaining_on = (bool?)items[41];
            is_parameterization_forced = (bool?)items[42];
            is_master_key_encrypted_by_server = (bool)items[43];
            is_published = (bool)items[44];
            is_subscribed = (bool)items[45];
            is_merge_published = (bool)items[46];
            is_distributor = (bool)items[47];
            is_sync_with_backup = (bool)items[48];
            service_broker_guid = (Guid)items[49];
            is_broker_enabled = (bool)items[50];
            log_reuse_wait = (byte?)items[51];
            log_reuse_wait_desc = (string)items[52];
            is_date_correlation_on = (bool)items[53];
            is_cdc_enabled = (bool)items[54];
            is_encrypted = (bool?)items[55];
            is_honor_broker_priority_on = (bool?)items[56];
            replica_id = (Guid?)items[57];
            group_database_id = (Guid?)items[58];
            default_language_lcid = (short?)items[59];
            default_language_name = (string)items[60];
            default_fulltext_language_lcid = (int?)items[61];
            default_fulltext_language_name = (string)items[62];
            is_nested_triggers_on = (bool?)items[63];
            is_transform_noise_words_on = (bool?)items[64];
            two_digit_year_cutoff = (short?)items[65];
            containment = (byte?)items[66];
            containment_desc = (string)items[67];
            target_recovery_time_in_seconds = (int?)items[68];
        }
    }

    [SqlView("systems", "v_host_servers")]
    public partial class v_host_servers : SqlViewProxy
    {
        [SqlColumn("systems_server_name", 0), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        public v_host_servers()
        {
        }

        public v_host_servers(object[] items)
        {
            systems_server_name = (string)items[0];
        }

        public v_host_servers(string systems_server_name)
        {
            this.systems_server_name = systems_server_name;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_server_name };
        }

        public override void SetItemArray(object[] items)
        {
            systems_server_name = (string)items[0];
        }
    }

    [SqlView("systems", "v_schemas")]
    public partial class v_schemas : SqlViewProxy
    {
        [SqlColumn("systems_server_name", 0), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("systems_database_name", 1), SqlTypeFacets("sysname", false)]
        public string systems_database_name
        {
            get;
            set;
        }

        [SqlColumn("name", 2), SqlTypeFacets("sysname", false)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("schema_id", 3), SqlTypeFacets("int", false)]
        public int schema_id
        {
            get;
            set;
        }

        [SqlColumn("principal_id", 4), SqlTypeFacets("int", true)]
        public int? principal_id
        {
            get;
            set;
        }

        public v_schemas()
        {
        }

        public v_schemas(object[] items)
        {
            systems_server_name = (string)items[0];
            systems_database_name = (string)items[1];
            name = (string)items[2];
            schema_id = (int)items[3];
            principal_id = (int?)items[4];
        }

        public v_schemas(string systems_server_name, string systems_database_name, string name, int schema_id, int? principal_id)
        {
            this.systems_server_name = systems_server_name;
            this.systems_database_name = systems_database_name;
            this.name = name;
            this.schema_id = schema_id;
            this.principal_id = principal_id;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_server_name, systems_database_name, name, schema_id, principal_id };
        }

        public override void SetItemArray(object[] items)
        {
            systems_server_name = (string)items[0];
            systems_database_name = (string)items[1];
            name = (string)items[2];
            schema_id = (int)items[3];
            principal_id = (int?)items[4];
        }
    }

    [SqlView("systems", "v_servers")]
    public partial class v_servers : SqlViewProxy
    {
        [SqlColumn("systems_server_name", 0), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("server_id", 1), SqlTypeFacets("int", false)]
        public int server_id
        {
            get;
            set;
        }

        [SqlColumn("name", 2), SqlTypeFacets("sysname", false)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("product", 3), SqlTypeFacets("sysname", false)]
        public string product
        {
            get;
            set;
        }

        [SqlColumn("provider", 4), SqlTypeFacets("sysname", false)]
        public string provider
        {
            get;
            set;
        }

        [SqlColumn("data_source", 5), SqlTypeFacets("nvarchar", true, 8000)]
        public string data_source
        {
            get;
            set;
        }

        [SqlColumn("location", 6), SqlTypeFacets("nvarchar", true, 8000)]
        public string location
        {
            get;
            set;
        }

        [SqlColumn("provider_string", 7), SqlTypeFacets("nvarchar", true, 8000)]
        public string provider_string
        {
            get;
            set;
        }

        [SqlColumn("catalog", 8), SqlTypeFacets("sysname", true)]
        public string catalog
        {
            get;
            set;
        }

        [SqlColumn("connect_timeout", 9), SqlTypeFacets("int", true)]
        public int? connect_timeout
        {
            get;
            set;
        }

        [SqlColumn("query_timeout", 10), SqlTypeFacets("int", true)]
        public int? query_timeout
        {
            get;
            set;
        }

        [SqlColumn("is_linked", 11), SqlTypeFacets("bit", false)]
        public bool is_linked
        {
            get;
            set;
        }

        [SqlColumn("is_remote_login_enabled", 12), SqlTypeFacets("bit", false)]
        public bool is_remote_login_enabled
        {
            get;
            set;
        }

        [SqlColumn("is_rpc_out_enabled", 13), SqlTypeFacets("bit", false)]
        public bool is_rpc_out_enabled
        {
            get;
            set;
        }

        [SqlColumn("is_data_access_enabled", 14), SqlTypeFacets("bit", false)]
        public bool is_data_access_enabled
        {
            get;
            set;
        }

        [SqlColumn("is_collation_compatible", 15), SqlTypeFacets("bit", false)]
        public bool is_collation_compatible
        {
            get;
            set;
        }

        [SqlColumn("uses_remote_collation", 16), SqlTypeFacets("bit", false)]
        public bool uses_remote_collation
        {
            get;
            set;
        }

        [SqlColumn("collation_name", 17), SqlTypeFacets("sysname", true)]
        public string collation_name
        {
            get;
            set;
        }

        [SqlColumn("lazy_schema_validation", 18), SqlTypeFacets("bit", false)]
        public bool lazy_schema_validation
        {
            get;
            set;
        }

        [SqlColumn("is_system", 19), SqlTypeFacets("bit", false)]
        public bool is_system
        {
            get;
            set;
        }

        [SqlColumn("is_publisher", 20), SqlTypeFacets("bit", false)]
        public bool is_publisher
        {
            get;
            set;
        }

        [SqlColumn("is_subscriber", 21), SqlTypeFacets("bit", true)]
        public bool? is_subscriber
        {
            get;
            set;
        }

        [SqlColumn("is_distributor", 22), SqlTypeFacets("bit", true)]
        public bool? is_distributor
        {
            get;
            set;
        }

        [SqlColumn("is_nonsql_subscriber", 23), SqlTypeFacets("bit", true)]
        public bool? is_nonsql_subscriber
        {
            get;
            set;
        }

        [SqlColumn("is_remote_proc_transaction_promotion_enabled", 24), SqlTypeFacets("bit", true)]
        public bool? is_remote_proc_transaction_promotion_enabled
        {
            get;
            set;
        }

        [SqlColumn("modify_date", 25), SqlTypeFacets("datetime", false)]
        public DateTime modify_date
        {
            get;
            set;
        }

        public v_servers()
        {
        }

        public v_servers(object[] items)
        {
            systems_server_name = (string)items[0];
            server_id = (int)items[1];
            name = (string)items[2];
            product = (string)items[3];
            provider = (string)items[4];
            data_source = (string)items[5];
            location = (string)items[6];
            provider_string = (string)items[7];
            catalog = (string)items[8];
            connect_timeout = (int?)items[9];
            query_timeout = (int?)items[10];
            is_linked = (bool)items[11];
            is_remote_login_enabled = (bool)items[12];
            is_rpc_out_enabled = (bool)items[13];
            is_data_access_enabled = (bool)items[14];
            is_collation_compatible = (bool)items[15];
            uses_remote_collation = (bool)items[16];
            collation_name = (string)items[17];
            lazy_schema_validation = (bool)items[18];
            is_system = (bool)items[19];
            is_publisher = (bool)items[20];
            is_subscriber = (bool?)items[21];
            is_distributor = (bool?)items[22];
            is_nonsql_subscriber = (bool?)items[23];
            is_remote_proc_transaction_promotion_enabled = (bool?)items[24];
            modify_date = (DateTime)items[25];
        }

        public v_servers(string systems_server_name, int server_id, string name, string product, string provider, string data_source, string location, string provider_string, string catalog, int? connect_timeout, int? query_timeout, bool is_linked, bool is_remote_login_enabled, bool is_rpc_out_enabled, bool is_data_access_enabled, bool is_collation_compatible, bool uses_remote_collation, string collation_name, bool lazy_schema_validation, bool is_system, bool is_publisher, bool? is_subscriber, bool? is_distributor, bool? is_nonsql_subscriber, bool? is_remote_proc_transaction_promotion_enabled, DateTime modify_date)
        {
            this.systems_server_name = systems_server_name;
            this.server_id = server_id;
            this.name = name;
            this.product = product;
            this.provider = provider;
            this.data_source = data_source;
            this.location = location;
            this.provider_string = provider_string;
            this.catalog = catalog;
            this.connect_timeout = connect_timeout;
            this.query_timeout = query_timeout;
            this.is_linked = is_linked;
            this.is_remote_login_enabled = is_remote_login_enabled;
            this.is_rpc_out_enabled = is_rpc_out_enabled;
            this.is_data_access_enabled = is_data_access_enabled;
            this.is_collation_compatible = is_collation_compatible;
            this.uses_remote_collation = uses_remote_collation;
            this.collation_name = collation_name;
            this.lazy_schema_validation = lazy_schema_validation;
            this.is_system = is_system;
            this.is_publisher = is_publisher;
            this.is_subscriber = is_subscriber;
            this.is_distributor = is_distributor;
            this.is_nonsql_subscriber = is_nonsql_subscriber;
            this.is_remote_proc_transaction_promotion_enabled = is_remote_proc_transaction_promotion_enabled;
            this.modify_date = modify_date;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_server_name, server_id, name, product, provider, data_source, location, provider_string, catalog, connect_timeout, query_timeout, is_linked, is_remote_login_enabled, is_rpc_out_enabled, is_data_access_enabled, is_collation_compatible, uses_remote_collation, collation_name, lazy_schema_validation, is_system, is_publisher, is_subscriber, is_distributor, is_nonsql_subscriber, is_remote_proc_transaction_promotion_enabled, modify_date };
        }

        public override void SetItemArray(object[] items)
        {
            systems_server_name = (string)items[0];
            server_id = (int)items[1];
            name = (string)items[2];
            product = (string)items[3];
            provider = (string)items[4];
            data_source = (string)items[5];
            location = (string)items[6];
            provider_string = (string)items[7];
            catalog = (string)items[8];
            connect_timeout = (int?)items[9];
            query_timeout = (int?)items[10];
            is_linked = (bool)items[11];
            is_remote_login_enabled = (bool)items[12];
            is_rpc_out_enabled = (bool)items[13];
            is_data_access_enabled = (bool)items[14];
            is_collation_compatible = (bool)items[15];
            uses_remote_collation = (bool)items[16];
            collation_name = (string)items[17];
            lazy_schema_validation = (bool)items[18];
            is_system = (bool)items[19];
            is_publisher = (bool)items[20];
            is_subscriber = (bool?)items[21];
            is_distributor = (bool?)items[22];
            is_nonsql_subscriber = (bool?)items[23];
            is_remote_proc_transaction_promotion_enabled = (bool?)items[24];
            modify_date = (DateTime)items[25];
        }
    }

    [SqlView("systems", "v_table_columns")]
    public partial class v_table_columns : SqlViewProxy
    {
        [SqlColumn("systems_server_name", 0), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("systems_database_name", 1), SqlTypeFacets("sysname", false)]
        public string systems_database_name
        {
            get;
            set;
        }

        [SqlColumn("systems_schema_name", 2), SqlTypeFacets("sysname", false)]
        public string systems_schema_name
        {
            get;
            set;
        }

        [SqlColumn("systems_parent_name", 3), SqlTypeFacets("sysname", false)]
        public string systems_parent_name
        {
            get;
            set;
        }

        [SqlColumn("systems_parent_type", 4), SqlTypeFacets("char", false, 2)]
        public string systems_parent_type
        {
            get;
            set;
        }

        [SqlColumn("object_id", 5), SqlTypeFacets("int", false)]
        public int object_id
        {
            get;
            set;
        }

        [SqlColumn("name", 6), SqlTypeFacets("sysname", true)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("column_id", 7), SqlTypeFacets("int", false)]
        public int column_id
        {
            get;
            set;
        }

        [SqlColumn("system_type_id", 8), SqlTypeFacets("tinyint", false)]
        public byte system_type_id
        {
            get;
            set;
        }

        [SqlColumn("user_type_id", 9), SqlTypeFacets("int", false)]
        public int user_type_id
        {
            get;
            set;
        }

        [SqlColumn("max_length", 10), SqlTypeFacets("smallint", false)]
        public short max_length
        {
            get;
            set;
        }

        [SqlColumn("precision", 11), SqlTypeFacets("tinyint", false)]
        public byte precision
        {
            get;
            set;
        }

        [SqlColumn("scale", 12), SqlTypeFacets("tinyint", false)]
        public byte scale
        {
            get;
            set;
        }

        [SqlColumn("collation_name", 13), SqlTypeFacets("sysname", true)]
        public string collation_name
        {
            get;
            set;
        }

        [SqlColumn("is_nullable", 14), SqlTypeFacets("bit", true)]
        public bool? is_nullable
        {
            get;
            set;
        }

        [SqlColumn("is_ansi_padded", 15), SqlTypeFacets("bit", false)]
        public bool is_ansi_padded
        {
            get;
            set;
        }

        [SqlColumn("is_rowguidcol", 16), SqlTypeFacets("bit", false)]
        public bool is_rowguidcol
        {
            get;
            set;
        }

        [SqlColumn("is_identity", 17), SqlTypeFacets("bit", false)]
        public bool is_identity
        {
            get;
            set;
        }

        [SqlColumn("is_computed", 18), SqlTypeFacets("bit", false)]
        public bool is_computed
        {
            get;
            set;
        }

        [SqlColumn("is_filestream", 19), SqlTypeFacets("bit", false)]
        public bool is_filestream
        {
            get;
            set;
        }

        [SqlColumn("is_replicated", 20), SqlTypeFacets("bit", true)]
        public bool? is_replicated
        {
            get;
            set;
        }

        [SqlColumn("is_non_sql_subscribed", 21), SqlTypeFacets("bit", true)]
        public bool? is_non_sql_subscribed
        {
            get;
            set;
        }

        [SqlColumn("is_merge_published", 22), SqlTypeFacets("bit", true)]
        public bool? is_merge_published
        {
            get;
            set;
        }

        [SqlColumn("is_dts_replicated", 23), SqlTypeFacets("bit", true)]
        public bool? is_dts_replicated
        {
            get;
            set;
        }

        [SqlColumn("is_xml_document", 24), SqlTypeFacets("bit", false)]
        public bool is_xml_document
        {
            get;
            set;
        }

        [SqlColumn("xml_collection_id", 25), SqlTypeFacets("int", false)]
        public int xml_collection_id
        {
            get;
            set;
        }

        [SqlColumn("default_object_id", 26), SqlTypeFacets("int", false)]
        public int default_object_id
        {
            get;
            set;
        }

        [SqlColumn("rule_object_id", 27), SqlTypeFacets("int", false)]
        public int rule_object_id
        {
            get;
            set;
        }

        [SqlColumn("is_sparse", 28), SqlTypeFacets("bit", true)]
        public bool? is_sparse
        {
            get;
            set;
        }

        [SqlColumn("is_column_set", 29), SqlTypeFacets("bit", true)]
        public bool? is_column_set
        {
            get;
            set;
        }

        public v_table_columns()
        {
        }

        public v_table_columns(object[] items)
        {
            systems_server_name = (string)items[0];
            systems_database_name = (string)items[1];
            systems_schema_name = (string)items[2];
            systems_parent_name = (string)items[3];
            systems_parent_type = (string)items[4];
            object_id = (int)items[5];
            name = (string)items[6];
            column_id = (int)items[7];
            system_type_id = (byte)items[8];
            user_type_id = (int)items[9];
            max_length = (short)items[10];
            precision = (byte)items[11];
            scale = (byte)items[12];
            collation_name = (string)items[13];
            is_nullable = (bool?)items[14];
            is_ansi_padded = (bool)items[15];
            is_rowguidcol = (bool)items[16];
            is_identity = (bool)items[17];
            is_computed = (bool)items[18];
            is_filestream = (bool)items[19];
            is_replicated = (bool?)items[20];
            is_non_sql_subscribed = (bool?)items[21];
            is_merge_published = (bool?)items[22];
            is_dts_replicated = (bool?)items[23];
            is_xml_document = (bool)items[24];
            xml_collection_id = (int)items[25];
            default_object_id = (int)items[26];
            rule_object_id = (int)items[27];
            is_sparse = (bool?)items[28];
            is_column_set = (bool?)items[29];
        }

        public v_table_columns(string systems_server_name, string systems_database_name, string systems_schema_name, string systems_parent_name, string systems_parent_type, int object_id, string name, int column_id, byte system_type_id, int user_type_id, short max_length, byte precision, byte scale, string collation_name, bool? is_nullable, bool is_ansi_padded, bool is_rowguidcol, bool is_identity, bool is_computed, bool is_filestream, bool? is_replicated, bool? is_non_sql_subscribed, bool? is_merge_published, bool? is_dts_replicated, bool is_xml_document, int xml_collection_id, int default_object_id, int rule_object_id, bool? is_sparse, bool? is_column_set)
        {
            this.systems_server_name = systems_server_name;
            this.systems_database_name = systems_database_name;
            this.systems_schema_name = systems_schema_name;
            this.systems_parent_name = systems_parent_name;
            this.systems_parent_type = systems_parent_type;
            this.object_id = object_id;
            this.name = name;
            this.column_id = column_id;
            this.system_type_id = system_type_id;
            this.user_type_id = user_type_id;
            this.max_length = max_length;
            this.precision = precision;
            this.scale = scale;
            this.collation_name = collation_name;
            this.is_nullable = is_nullable;
            this.is_ansi_padded = is_ansi_padded;
            this.is_rowguidcol = is_rowguidcol;
            this.is_identity = is_identity;
            this.is_computed = is_computed;
            this.is_filestream = is_filestream;
            this.is_replicated = is_replicated;
            this.is_non_sql_subscribed = is_non_sql_subscribed;
            this.is_merge_published = is_merge_published;
            this.is_dts_replicated = is_dts_replicated;
            this.is_xml_document = is_xml_document;
            this.xml_collection_id = xml_collection_id;
            this.default_object_id = default_object_id;
            this.rule_object_id = rule_object_id;
            this.is_sparse = is_sparse;
            this.is_column_set = is_column_set;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_server_name, systems_database_name, systems_schema_name, systems_parent_name, systems_parent_type, object_id, name, column_id, system_type_id, user_type_id, max_length, precision, scale, collation_name, is_nullable, is_ansi_padded, is_rowguidcol, is_identity, is_computed, is_filestream, is_replicated, is_non_sql_subscribed, is_merge_published, is_dts_replicated, is_xml_document, xml_collection_id, default_object_id, rule_object_id, is_sparse, is_column_set };
        }

        public override void SetItemArray(object[] items)
        {
            systems_server_name = (string)items[0];
            systems_database_name = (string)items[1];
            systems_schema_name = (string)items[2];
            systems_parent_name = (string)items[3];
            systems_parent_type = (string)items[4];
            object_id = (int)items[5];
            name = (string)items[6];
            column_id = (int)items[7];
            system_type_id = (byte)items[8];
            user_type_id = (int)items[9];
            max_length = (short)items[10];
            precision = (byte)items[11];
            scale = (byte)items[12];
            collation_name = (string)items[13];
            is_nullable = (bool?)items[14];
            is_ansi_padded = (bool)items[15];
            is_rowguidcol = (bool)items[16];
            is_identity = (bool)items[17];
            is_computed = (bool)items[18];
            is_filestream = (bool)items[19];
            is_replicated = (bool?)items[20];
            is_non_sql_subscribed = (bool?)items[21];
            is_merge_published = (bool?)items[22];
            is_dts_replicated = (bool?)items[23];
            is_xml_document = (bool)items[24];
            xml_collection_id = (int)items[25];
            default_object_id = (int)items[26];
            rule_object_id = (int)items[27];
            is_sparse = (bool?)items[28];
            is_column_set = (bool?)items[29];
        }
    }

    [SqlView("systems", "v_table_index_columns")]
    public partial class v_table_index_columns : SqlViewProxy
    {
        [SqlColumn("systems_server_name", 0), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("systems_database_name", 1), SqlTypeFacets("sysname", false)]
        public string systems_database_name
        {
            get;
            set;
        }

        [SqlColumn("systems_schema_name", 2), SqlTypeFacets("sysname", false)]
        public string systems_schema_name
        {
            get;
            set;
        }

        [SqlColumn("systems_parent_name", 3), SqlTypeFacets("sysname", false)]
        public string systems_parent_name
        {
            get;
            set;
        }

        [SqlColumn("systems_parent_type", 4), SqlTypeFacets("char", false, 2)]
        public string systems_parent_type
        {
            get;
            set;
        }

        [SqlColumn("systems_column_name", 5), SqlTypeFacets("sysname", false)]
        public string systems_column_name
        {
            get;
            set;
        }

        [SqlColumn("systems_index_name", 6), SqlTypeFacets("sysname", false)]
        public string systems_index_name
        {
            get;
            set;
        }

        [SqlColumn("object_id", 7), SqlTypeFacets("int", false)]
        public int object_id
        {
            get;
            set;
        }

        [SqlColumn("index_id", 8), SqlTypeFacets("int", false)]
        public int index_id
        {
            get;
            set;
        }

        [SqlColumn("index_column_id", 9), SqlTypeFacets("int", false)]
        public int index_column_id
        {
            get;
            set;
        }

        [SqlColumn("column_id", 10), SqlTypeFacets("int", false)]
        public int column_id
        {
            get;
            set;
        }

        [SqlColumn("key_ordinal", 11), SqlTypeFacets("tinyint", false)]
        public byte key_ordinal
        {
            get;
            set;
        }

        [SqlColumn("partition_ordinal", 12), SqlTypeFacets("tinyint", false)]
        public byte partition_ordinal
        {
            get;
            set;
        }

        [SqlColumn("is_descending_key", 13), SqlTypeFacets("bit", true)]
        public bool? is_descending_key
        {
            get;
            set;
        }

        [SqlColumn("is_included_column", 14), SqlTypeFacets("bit", true)]
        public bool? is_included_column
        {
            get;
            set;
        }

        public v_table_index_columns()
        {
        }

        public v_table_index_columns(object[] items)
        {
            systems_server_name = (string)items[0];
            systems_database_name = (string)items[1];
            systems_schema_name = (string)items[2];
            systems_parent_name = (string)items[3];
            systems_parent_type = (string)items[4];
            systems_column_name = (string)items[5];
            systems_index_name = (string)items[6];
            object_id = (int)items[7];
            index_id = (int)items[8];
            index_column_id = (int)items[9];
            column_id = (int)items[10];
            key_ordinal = (byte)items[11];
            partition_ordinal = (byte)items[12];
            is_descending_key = (bool?)items[13];
            is_included_column = (bool?)items[14];
        }

        public v_table_index_columns(string systems_server_name, string systems_database_name, string systems_schema_name, string systems_parent_name, string systems_parent_type, string systems_column_name, string systems_index_name, int object_id, int index_id, int index_column_id, int column_id, byte key_ordinal, byte partition_ordinal, bool? is_descending_key, bool? is_included_column)
        {
            this.systems_server_name = systems_server_name;
            this.systems_database_name = systems_database_name;
            this.systems_schema_name = systems_schema_name;
            this.systems_parent_name = systems_parent_name;
            this.systems_parent_type = systems_parent_type;
            this.systems_column_name = systems_column_name;
            this.systems_index_name = systems_index_name;
            this.object_id = object_id;
            this.index_id = index_id;
            this.index_column_id = index_column_id;
            this.column_id = column_id;
            this.key_ordinal = key_ordinal;
            this.partition_ordinal = partition_ordinal;
            this.is_descending_key = is_descending_key;
            this.is_included_column = is_included_column;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_server_name, systems_database_name, systems_schema_name, systems_parent_name, systems_parent_type, systems_column_name, systems_index_name, object_id, index_id, index_column_id, column_id, key_ordinal, partition_ordinal, is_descending_key, is_included_column };
        }

        public override void SetItemArray(object[] items)
        {
            systems_server_name = (string)items[0];
            systems_database_name = (string)items[1];
            systems_schema_name = (string)items[2];
            systems_parent_name = (string)items[3];
            systems_parent_type = (string)items[4];
            systems_column_name = (string)items[5];
            systems_index_name = (string)items[6];
            object_id = (int)items[7];
            index_id = (int)items[8];
            index_column_id = (int)items[9];
            column_id = (int)items[10];
            key_ordinal = (byte)items[11];
            partition_ordinal = (byte)items[12];
            is_descending_key = (bool?)items[13];
            is_included_column = (bool?)items[14];
        }
    }

    [SqlTable("systems", "extended_properties")]
    public partial class extended_properties : SqlTableProxy
    {
        [SqlColumn("systems_key", 0), SqlTypeFacets("int", false)]
        public int systems_key
        {
            get;
            set;
        }

        [SqlColumn("systems_server_name", 1), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("systems_database_name", 2), SqlTypeFacets("sysname", false)]
        public string systems_database_name
        {
            get;
            set;
        }

        [SqlColumn("class", 3), SqlTypeFacets("tinyint", false)]
        public byte @class
        {
            get;
            set;
        }

        [SqlColumn("class_desc", 4), SqlTypeFacets("nvarchar", true, 240)]
        public string class_desc
        {
            get;
            set;
        }

        [SqlColumn("major_id", 5), SqlTypeFacets("int", false)]
        public int major_id
        {
            get;
            set;
        }

        [SqlColumn("minor_id", 6), SqlTypeFacets("int", false)]
        public int minor_id
        {
            get;
            set;
        }

        [SqlColumn("name", 7), SqlTypeFacets("sysname", false)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("value", 8), SqlTypeFacets("sql_variant", true)]
        public Object value
        {
            get;
            set;
        }

        [SqlColumn("as_of", 9), SqlTypeFacets("datetime2", false, -1, 3)]
        public DateTime as_of
        {
            get;
            set;
        }

        public extended_properties()
        {
        }

        public extended_properties(object[] items)
        {
            systems_key = (int)items[0];
            systems_server_name = (string)items[1];
            systems_database_name = (string)items[2];
            @class = (byte)items[3];
            class_desc = (string)items[4];
            major_id = (int)items[5];
            minor_id = (int)items[6];
            name = (string)items[7];
            value = (Object)items[8];
            as_of = (DateTime)items[9];
        }

        public extended_properties(int systems_key, string systems_server_name, string systems_database_name, byte @class, string class_desc, int major_id, int minor_id, string name, Object value, DateTime as_of)
        {
            this.systems_key = systems_key;
            this.systems_server_name = systems_server_name;
            this.systems_database_name = systems_database_name;
            this.@class = @class;
            this.class_desc = class_desc;
            this.major_id = major_id;
            this.minor_id = minor_id;
            this.name = name;
            this.value = value;
            this.as_of = as_of;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_key, systems_server_name, systems_database_name, @class, class_desc, major_id, minor_id, name, value, as_of };
        }

        public override void SetItemArray(object[] items)
        {
            systems_key = (int)items[0];
            systems_server_name = (string)items[1];
            systems_database_name = (string)items[2];
            @class = (byte)items[3];
            class_desc = (string)items[4];
            major_id = (int)items[5];
            minor_id = (int)items[6];
            name = (string)items[7];
            value = (Object)items[8];
            as_of = (DateTime)items[9];
        }
    }

    [SqlTable("systems", "databases")]
    public partial class databases : SqlTableProxy
    {
        [SqlColumn("systems_key", 0), SqlTypeFacets("int", false)]
        public int systems_key
        {
            get;
            set;
        }

        [SqlColumn("systems_server_name", 1), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("name", 2), SqlTypeFacets("sysname", false)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("database_id", 3), SqlTypeFacets("int", false)]
        public int database_id
        {
            get;
            set;
        }

        [SqlColumn("source_database_id", 4), SqlTypeFacets("int", true)]
        public int? source_database_id
        {
            get;
            set;
        }

        [SqlColumn("owner_sid", 5), SqlTypeFacets("varbinary", true, 85)]
        public Byte[] owner_sid
        {
            get;
            set;
        }

        [SqlColumn("create_date", 6), SqlTypeFacets("datetime", false)]
        public DateTime create_date
        {
            get;
            set;
        }

        [SqlColumn("compatibility_level", 7), SqlTypeFacets("tinyint", false)]
        public byte compatibility_level
        {
            get;
            set;
        }

        [SqlColumn("collation_name", 8), SqlTypeFacets("nvarchar", true, 256)]
        public string collation_name
        {
            get;
            set;
        }

        [SqlColumn("user_access", 9), SqlTypeFacets("tinyint", true)]
        public byte? user_access
        {
            get;
            set;
        }

        [SqlColumn("user_access_desc", 10), SqlTypeFacets("nvarchar", true, 120)]
        public string user_access_desc
        {
            get;
            set;
        }

        [SqlColumn("is_read_only", 11), SqlTypeFacets("bit", true)]
        public bool? is_read_only
        {
            get;
            set;
        }

        [SqlColumn("is_auto_close_on", 12), SqlTypeFacets("bit", false)]
        public bool is_auto_close_on
        {
            get;
            set;
        }

        [SqlColumn("is_auto_shrink_on", 13), SqlTypeFacets("bit", true)]
        public bool? is_auto_shrink_on
        {
            get;
            set;
        }

        [SqlColumn("state", 14), SqlTypeFacets("tinyint", true)]
        public byte? state
        {
            get;
            set;
        }

        [SqlColumn("state_desc", 15), SqlTypeFacets("nvarchar", true, 120)]
        public string state_desc
        {
            get;
            set;
        }

        [SqlColumn("is_in_standby", 16), SqlTypeFacets("bit", true)]
        public bool? is_in_standby
        {
            get;
            set;
        }

        [SqlColumn("is_cleanly_shutdown", 17), SqlTypeFacets("bit", true)]
        public bool? is_cleanly_shutdown
        {
            get;
            set;
        }

        [SqlColumn("is_supplemental_logging_enabled", 18), SqlTypeFacets("bit", true)]
        public bool? is_supplemental_logging_enabled
        {
            get;
            set;
        }

        [SqlColumn("snapshot_isolation_state", 19), SqlTypeFacets("tinyint", true)]
        public byte? snapshot_isolation_state
        {
            get;
            set;
        }

        [SqlColumn("snapshot_isolation_state_desc", 20), SqlTypeFacets("nvarchar", true, 120)]
        public string snapshot_isolation_state_desc
        {
            get;
            set;
        }

        [SqlColumn("is_read_committed_snapshot_on", 21), SqlTypeFacets("bit", true)]
        public bool? is_read_committed_snapshot_on
        {
            get;
            set;
        }

        [SqlColumn("recovery_model", 22), SqlTypeFacets("tinyint", true)]
        public byte? recovery_model
        {
            get;
            set;
        }

        [SqlColumn("recovery_model_desc", 23), SqlTypeFacets("nvarchar", true, 120)]
        public string recovery_model_desc
        {
            get;
            set;
        }

        [SqlColumn("page_verify_option", 24), SqlTypeFacets("tinyint", true)]
        public byte? page_verify_option
        {
            get;
            set;
        }

        [SqlColumn("page_verify_option_desc", 25), SqlTypeFacets("nvarchar", true, 120)]
        public string page_verify_option_desc
        {
            get;
            set;
        }

        [SqlColumn("is_auto_create_stats_on", 26), SqlTypeFacets("bit", true)]
        public bool? is_auto_create_stats_on
        {
            get;
            set;
        }

        [SqlColumn("is_auto_update_stats_on", 27), SqlTypeFacets("bit", true)]
        public bool? is_auto_update_stats_on
        {
            get;
            set;
        }

        [SqlColumn("is_auto_update_stats_async_on", 28), SqlTypeFacets("bit", true)]
        public bool? is_auto_update_stats_async_on
        {
            get;
            set;
        }

        [SqlColumn("is_ansi_null_default_on", 29), SqlTypeFacets("bit", true)]
        public bool? is_ansi_null_default_on
        {
            get;
            set;
        }

        [SqlColumn("is_ansi_nulls_on", 30), SqlTypeFacets("bit", true)]
        public bool? is_ansi_nulls_on
        {
            get;
            set;
        }

        [SqlColumn("is_ansi_padding_on", 31), SqlTypeFacets("bit", true)]
        public bool? is_ansi_padding_on
        {
            get;
            set;
        }

        [SqlColumn("is_ansi_warnings_on", 32), SqlTypeFacets("bit", true)]
        public bool? is_ansi_warnings_on
        {
            get;
            set;
        }

        [SqlColumn("is_arithabort_on", 33), SqlTypeFacets("bit", true)]
        public bool? is_arithabort_on
        {
            get;
            set;
        }

        [SqlColumn("is_concat_null_yields_null_on", 34), SqlTypeFacets("bit", true)]
        public bool? is_concat_null_yields_null_on
        {
            get;
            set;
        }

        [SqlColumn("is_numeric_roundabort_on", 35), SqlTypeFacets("bit", true)]
        public bool? is_numeric_roundabort_on
        {
            get;
            set;
        }

        [SqlColumn("is_quoted_identifier_on", 36), SqlTypeFacets("bit", true)]
        public bool? is_quoted_identifier_on
        {
            get;
            set;
        }

        [SqlColumn("is_recursive_triggers_on", 37), SqlTypeFacets("bit", true)]
        public bool? is_recursive_triggers_on
        {
            get;
            set;
        }

        [SqlColumn("is_cursor_close_on_commit_on", 38), SqlTypeFacets("bit", true)]
        public bool? is_cursor_close_on_commit_on
        {
            get;
            set;
        }

        [SqlColumn("is_local_cursor_default", 39), SqlTypeFacets("bit", true)]
        public bool? is_local_cursor_default
        {
            get;
            set;
        }

        [SqlColumn("is_fulltext_enabled", 40), SqlTypeFacets("bit", true)]
        public bool? is_fulltext_enabled
        {
            get;
            set;
        }

        [SqlColumn("is_trustworthy_on", 41), SqlTypeFacets("bit", true)]
        public bool? is_trustworthy_on
        {
            get;
            set;
        }

        [SqlColumn("is_db_chaining_on", 42), SqlTypeFacets("bit", true)]
        public bool? is_db_chaining_on
        {
            get;
            set;
        }

        [SqlColumn("is_parameterization_forced", 43), SqlTypeFacets("bit", true)]
        public bool? is_parameterization_forced
        {
            get;
            set;
        }

        [SqlColumn("is_master_key_encrypted_by_server", 44), SqlTypeFacets("bit", false)]
        public bool is_master_key_encrypted_by_server
        {
            get;
            set;
        }

        [SqlColumn("is_published", 45), SqlTypeFacets("bit", false)]
        public bool is_published
        {
            get;
            set;
        }

        [SqlColumn("is_subscribed", 46), SqlTypeFacets("bit", false)]
        public bool is_subscribed
        {
            get;
            set;
        }

        [SqlColumn("is_merge_published", 47), SqlTypeFacets("bit", false)]
        public bool is_merge_published
        {
            get;
            set;
        }

        [SqlColumn("is_distributor", 48), SqlTypeFacets("bit", false)]
        public bool is_distributor
        {
            get;
            set;
        }

        [SqlColumn("is_sync_with_backup", 49), SqlTypeFacets("bit", false)]
        public bool is_sync_with_backup
        {
            get;
            set;
        }

        [SqlColumn("service_broker_guid", 50), SqlTypeFacets("uniqueidentifier", false)]
        public Guid service_broker_guid
        {
            get;
            set;
        }

        [SqlColumn("is_broker_enabled", 51), SqlTypeFacets("bit", false)]
        public bool is_broker_enabled
        {
            get;
            set;
        }

        [SqlColumn("log_reuse_wait", 52), SqlTypeFacets("tinyint", true)]
        public byte? log_reuse_wait
        {
            get;
            set;
        }

        [SqlColumn("log_reuse_wait_desc", 53), SqlTypeFacets("nvarchar", true, 120)]
        public string log_reuse_wait_desc
        {
            get;
            set;
        }

        [SqlColumn("is_date_correlation_on", 54), SqlTypeFacets("bit", false)]
        public bool is_date_correlation_on
        {
            get;
            set;
        }

        [SqlColumn("is_cdc_enabled", 55), SqlTypeFacets("bit", false)]
        public bool is_cdc_enabled
        {
            get;
            set;
        }

        [SqlColumn("is_encrypted", 56), SqlTypeFacets("bit", true)]
        public bool? is_encrypted
        {
            get;
            set;
        }

        [SqlColumn("is_honor_broker_priority_on", 57), SqlTypeFacets("bit", true)]
        public bool? is_honor_broker_priority_on
        {
            get;
            set;
        }

        [SqlColumn("replica_id", 58), SqlTypeFacets("uniqueidentifier", true)]
        public Guid? replica_id
        {
            get;
            set;
        }

        [SqlColumn("group_database_id", 59), SqlTypeFacets("uniqueidentifier", true)]
        public Guid? group_database_id
        {
            get;
            set;
        }

        [SqlColumn("default_language_lcid", 60), SqlTypeFacets("smallint", true)]
        public short? default_language_lcid
        {
            get;
            set;
        }

        [SqlColumn("default_language_name", 61), SqlTypeFacets("nvarchar", true, 256)]
        public string default_language_name
        {
            get;
            set;
        }

        [SqlColumn("default_fulltext_language_lcid", 62), SqlTypeFacets("int", true)]
        public int? default_fulltext_language_lcid
        {
            get;
            set;
        }

        [SqlColumn("default_fulltext_language_name", 63), SqlTypeFacets("nvarchar", true, 256)]
        public string default_fulltext_language_name
        {
            get;
            set;
        }

        [SqlColumn("is_nested_triggers_on", 64), SqlTypeFacets("bit", true)]
        public bool? is_nested_triggers_on
        {
            get;
            set;
        }

        [SqlColumn("is_transform_noise_words_on", 65), SqlTypeFacets("bit", true)]
        public bool? is_transform_noise_words_on
        {
            get;
            set;
        }

        [SqlColumn("two_digit_year_cutoff", 66), SqlTypeFacets("smallint", true)]
        public short? two_digit_year_cutoff
        {
            get;
            set;
        }

        [SqlColumn("containment", 67), SqlTypeFacets("tinyint", true)]
        public byte? containment
        {
            get;
            set;
        }

        [SqlColumn("containment_desc", 68), SqlTypeFacets("nvarchar", true, 120)]
        public string containment_desc
        {
            get;
            set;
        }

        [SqlColumn("target_recovery_time_in_seconds", 69), SqlTypeFacets("int", true)]
        public int? target_recovery_time_in_seconds
        {
            get;
            set;
        }

        [SqlColumn("as_of", 70), SqlTypeFacets("datetime2", false, -1, 3)]
        public DateTime as_of
        {
            get;
            set;
        }

        public databases()
        {
        }

        public databases(object[] items)
        {
            systems_key = (int)items[0];
            systems_server_name = (string)items[1];
            name = (string)items[2];
            database_id = (int)items[3];
            source_database_id = (int?)items[4];
            owner_sid = (Byte[])items[5];
            create_date = (DateTime)items[6];
            compatibility_level = (byte)items[7];
            collation_name = (string)items[8];
            user_access = (byte?)items[9];
            user_access_desc = (string)items[10];
            is_read_only = (bool?)items[11];
            is_auto_close_on = (bool)items[12];
            is_auto_shrink_on = (bool?)items[13];
            state = (byte?)items[14];
            state_desc = (string)items[15];
            is_in_standby = (bool?)items[16];
            is_cleanly_shutdown = (bool?)items[17];
            is_supplemental_logging_enabled = (bool?)items[18];
            snapshot_isolation_state = (byte?)items[19];
            snapshot_isolation_state_desc = (string)items[20];
            is_read_committed_snapshot_on = (bool?)items[21];
            recovery_model = (byte?)items[22];
            recovery_model_desc = (string)items[23];
            page_verify_option = (byte?)items[24];
            page_verify_option_desc = (string)items[25];
            is_auto_create_stats_on = (bool?)items[26];
            is_auto_update_stats_on = (bool?)items[27];
            is_auto_update_stats_async_on = (bool?)items[28];
            is_ansi_null_default_on = (bool?)items[29];
            is_ansi_nulls_on = (bool?)items[30];
            is_ansi_padding_on = (bool?)items[31];
            is_ansi_warnings_on = (bool?)items[32];
            is_arithabort_on = (bool?)items[33];
            is_concat_null_yields_null_on = (bool?)items[34];
            is_numeric_roundabort_on = (bool?)items[35];
            is_quoted_identifier_on = (bool?)items[36];
            is_recursive_triggers_on = (bool?)items[37];
            is_cursor_close_on_commit_on = (bool?)items[38];
            is_local_cursor_default = (bool?)items[39];
            is_fulltext_enabled = (bool?)items[40];
            is_trustworthy_on = (bool?)items[41];
            is_db_chaining_on = (bool?)items[42];
            is_parameterization_forced = (bool?)items[43];
            is_master_key_encrypted_by_server = (bool)items[44];
            is_published = (bool)items[45];
            is_subscribed = (bool)items[46];
            is_merge_published = (bool)items[47];
            is_distributor = (bool)items[48];
            is_sync_with_backup = (bool)items[49];
            service_broker_guid = (Guid)items[50];
            is_broker_enabled = (bool)items[51];
            log_reuse_wait = (byte?)items[52];
            log_reuse_wait_desc = (string)items[53];
            is_date_correlation_on = (bool)items[54];
            is_cdc_enabled = (bool)items[55];
            is_encrypted = (bool?)items[56];
            is_honor_broker_priority_on = (bool?)items[57];
            replica_id = (Guid?)items[58];
            group_database_id = (Guid?)items[59];
            default_language_lcid = (short?)items[60];
            default_language_name = (string)items[61];
            default_fulltext_language_lcid = (int?)items[62];
            default_fulltext_language_name = (string)items[63];
            is_nested_triggers_on = (bool?)items[64];
            is_transform_noise_words_on = (bool?)items[65];
            two_digit_year_cutoff = (short?)items[66];
            containment = (byte?)items[67];
            containment_desc = (string)items[68];
            target_recovery_time_in_seconds = (int?)items[69];
            as_of = (DateTime)items[70];
        }

        public databases(int systems_key, string systems_server_name, string name, int database_id, int? source_database_id, Byte[] owner_sid, DateTime create_date, byte compatibility_level, string collation_name, byte? user_access, string user_access_desc, bool? is_read_only, bool is_auto_close_on, bool? is_auto_shrink_on, byte? state, string state_desc, bool? is_in_standby, bool? is_cleanly_shutdown, bool? is_supplemental_logging_enabled, byte? snapshot_isolation_state, string snapshot_isolation_state_desc, bool? is_read_committed_snapshot_on, byte? recovery_model, string recovery_model_desc, byte? page_verify_option, string page_verify_option_desc, bool? is_auto_create_stats_on, bool? is_auto_update_stats_on, bool? is_auto_update_stats_async_on, bool? is_ansi_null_default_on, bool? is_ansi_nulls_on, bool? is_ansi_padding_on, bool? is_ansi_warnings_on, bool? is_arithabort_on, bool? is_concat_null_yields_null_on, bool? is_numeric_roundabort_on, bool? is_quoted_identifier_on, bool? is_recursive_triggers_on, bool? is_cursor_close_on_commit_on, bool? is_local_cursor_default, bool? is_fulltext_enabled, bool? is_trustworthy_on, bool? is_db_chaining_on, bool? is_parameterization_forced, bool is_master_key_encrypted_by_server, bool is_published, bool is_subscribed, bool is_merge_published, bool is_distributor, bool is_sync_with_backup, Guid service_broker_guid, bool is_broker_enabled, byte? log_reuse_wait, string log_reuse_wait_desc, bool is_date_correlation_on, bool is_cdc_enabled, bool? is_encrypted, bool? is_honor_broker_priority_on, Guid? replica_id, Guid? group_database_id, short? default_language_lcid, string default_language_name, int? default_fulltext_language_lcid, string default_fulltext_language_name, bool? is_nested_triggers_on, bool? is_transform_noise_words_on, short? two_digit_year_cutoff, byte? containment, string containment_desc, int? target_recovery_time_in_seconds, DateTime as_of)
        {
            this.systems_key = systems_key;
            this.systems_server_name = systems_server_name;
            this.name = name;
            this.database_id = database_id;
            this.source_database_id = source_database_id;
            this.owner_sid = owner_sid;
            this.create_date = create_date;
            this.compatibility_level = compatibility_level;
            this.collation_name = collation_name;
            this.user_access = user_access;
            this.user_access_desc = user_access_desc;
            this.is_read_only = is_read_only;
            this.is_auto_close_on = is_auto_close_on;
            this.is_auto_shrink_on = is_auto_shrink_on;
            this.state = state;
            this.state_desc = state_desc;
            this.is_in_standby = is_in_standby;
            this.is_cleanly_shutdown = is_cleanly_shutdown;
            this.is_supplemental_logging_enabled = is_supplemental_logging_enabled;
            this.snapshot_isolation_state = snapshot_isolation_state;
            this.snapshot_isolation_state_desc = snapshot_isolation_state_desc;
            this.is_read_committed_snapshot_on = is_read_committed_snapshot_on;
            this.recovery_model = recovery_model;
            this.recovery_model_desc = recovery_model_desc;
            this.page_verify_option = page_verify_option;
            this.page_verify_option_desc = page_verify_option_desc;
            this.is_auto_create_stats_on = is_auto_create_stats_on;
            this.is_auto_update_stats_on = is_auto_update_stats_on;
            this.is_auto_update_stats_async_on = is_auto_update_stats_async_on;
            this.is_ansi_null_default_on = is_ansi_null_default_on;
            this.is_ansi_nulls_on = is_ansi_nulls_on;
            this.is_ansi_padding_on = is_ansi_padding_on;
            this.is_ansi_warnings_on = is_ansi_warnings_on;
            this.is_arithabort_on = is_arithabort_on;
            this.is_concat_null_yields_null_on = is_concat_null_yields_null_on;
            this.is_numeric_roundabort_on = is_numeric_roundabort_on;
            this.is_quoted_identifier_on = is_quoted_identifier_on;
            this.is_recursive_triggers_on = is_recursive_triggers_on;
            this.is_cursor_close_on_commit_on = is_cursor_close_on_commit_on;
            this.is_local_cursor_default = is_local_cursor_default;
            this.is_fulltext_enabled = is_fulltext_enabled;
            this.is_trustworthy_on = is_trustworthy_on;
            this.is_db_chaining_on = is_db_chaining_on;
            this.is_parameterization_forced = is_parameterization_forced;
            this.is_master_key_encrypted_by_server = is_master_key_encrypted_by_server;
            this.is_published = is_published;
            this.is_subscribed = is_subscribed;
            this.is_merge_published = is_merge_published;
            this.is_distributor = is_distributor;
            this.is_sync_with_backup = is_sync_with_backup;
            this.service_broker_guid = service_broker_guid;
            this.is_broker_enabled = is_broker_enabled;
            this.log_reuse_wait = log_reuse_wait;
            this.log_reuse_wait_desc = log_reuse_wait_desc;
            this.is_date_correlation_on = is_date_correlation_on;
            this.is_cdc_enabled = is_cdc_enabled;
            this.is_encrypted = is_encrypted;
            this.is_honor_broker_priority_on = is_honor_broker_priority_on;
            this.replica_id = replica_id;
            this.group_database_id = group_database_id;
            this.default_language_lcid = default_language_lcid;
            this.default_language_name = default_language_name;
            this.default_fulltext_language_lcid = default_fulltext_language_lcid;
            this.default_fulltext_language_name = default_fulltext_language_name;
            this.is_nested_triggers_on = is_nested_triggers_on;
            this.is_transform_noise_words_on = is_transform_noise_words_on;
            this.two_digit_year_cutoff = two_digit_year_cutoff;
            this.containment = containment;
            this.containment_desc = containment_desc;
            this.target_recovery_time_in_seconds = target_recovery_time_in_seconds;
            this.as_of = as_of;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_key, systems_server_name, name, database_id, source_database_id, owner_sid, create_date, compatibility_level, collation_name, user_access, user_access_desc, is_read_only, is_auto_close_on, is_auto_shrink_on, state, state_desc, is_in_standby, is_cleanly_shutdown, is_supplemental_logging_enabled, snapshot_isolation_state, snapshot_isolation_state_desc, is_read_committed_snapshot_on, recovery_model, recovery_model_desc, page_verify_option, page_verify_option_desc, is_auto_create_stats_on, is_auto_update_stats_on, is_auto_update_stats_async_on, is_ansi_null_default_on, is_ansi_nulls_on, is_ansi_padding_on, is_ansi_warnings_on, is_arithabort_on, is_concat_null_yields_null_on, is_numeric_roundabort_on, is_quoted_identifier_on, is_recursive_triggers_on, is_cursor_close_on_commit_on, is_local_cursor_default, is_fulltext_enabled, is_trustworthy_on, is_db_chaining_on, is_parameterization_forced, is_master_key_encrypted_by_server, is_published, is_subscribed, is_merge_published, is_distributor, is_sync_with_backup, service_broker_guid, is_broker_enabled, log_reuse_wait, log_reuse_wait_desc, is_date_correlation_on, is_cdc_enabled, is_encrypted, is_honor_broker_priority_on, replica_id, group_database_id, default_language_lcid, default_language_name, default_fulltext_language_lcid, default_fulltext_language_name, is_nested_triggers_on, is_transform_noise_words_on, two_digit_year_cutoff, containment, containment_desc, target_recovery_time_in_seconds, as_of };
        }

        public override void SetItemArray(object[] items)
        {
            systems_key = (int)items[0];
            systems_server_name = (string)items[1];
            name = (string)items[2];
            database_id = (int)items[3];
            source_database_id = (int?)items[4];
            owner_sid = (Byte[])items[5];
            create_date = (DateTime)items[6];
            compatibility_level = (byte)items[7];
            collation_name = (string)items[8];
            user_access = (byte?)items[9];
            user_access_desc = (string)items[10];
            is_read_only = (bool?)items[11];
            is_auto_close_on = (bool)items[12];
            is_auto_shrink_on = (bool?)items[13];
            state = (byte?)items[14];
            state_desc = (string)items[15];
            is_in_standby = (bool?)items[16];
            is_cleanly_shutdown = (bool?)items[17];
            is_supplemental_logging_enabled = (bool?)items[18];
            snapshot_isolation_state = (byte?)items[19];
            snapshot_isolation_state_desc = (string)items[20];
            is_read_committed_snapshot_on = (bool?)items[21];
            recovery_model = (byte?)items[22];
            recovery_model_desc = (string)items[23];
            page_verify_option = (byte?)items[24];
            page_verify_option_desc = (string)items[25];
            is_auto_create_stats_on = (bool?)items[26];
            is_auto_update_stats_on = (bool?)items[27];
            is_auto_update_stats_async_on = (bool?)items[28];
            is_ansi_null_default_on = (bool?)items[29];
            is_ansi_nulls_on = (bool?)items[30];
            is_ansi_padding_on = (bool?)items[31];
            is_ansi_warnings_on = (bool?)items[32];
            is_arithabort_on = (bool?)items[33];
            is_concat_null_yields_null_on = (bool?)items[34];
            is_numeric_roundabort_on = (bool?)items[35];
            is_quoted_identifier_on = (bool?)items[36];
            is_recursive_triggers_on = (bool?)items[37];
            is_cursor_close_on_commit_on = (bool?)items[38];
            is_local_cursor_default = (bool?)items[39];
            is_fulltext_enabled = (bool?)items[40];
            is_trustworthy_on = (bool?)items[41];
            is_db_chaining_on = (bool?)items[42];
            is_parameterization_forced = (bool?)items[43];
            is_master_key_encrypted_by_server = (bool)items[44];
            is_published = (bool)items[45];
            is_subscribed = (bool)items[46];
            is_merge_published = (bool)items[47];
            is_distributor = (bool)items[48];
            is_sync_with_backup = (bool)items[49];
            service_broker_guid = (Guid)items[50];
            is_broker_enabled = (bool)items[51];
            log_reuse_wait = (byte?)items[52];
            log_reuse_wait_desc = (string)items[53];
            is_date_correlation_on = (bool)items[54];
            is_cdc_enabled = (bool)items[55];
            is_encrypted = (bool?)items[56];
            is_honor_broker_priority_on = (bool?)items[57];
            replica_id = (Guid?)items[58];
            group_database_id = (Guid?)items[59];
            default_language_lcid = (short?)items[60];
            default_language_name = (string)items[61];
            default_fulltext_language_lcid = (int?)items[62];
            default_fulltext_language_name = (string)items[63];
            is_nested_triggers_on = (bool?)items[64];
            is_transform_noise_words_on = (bool?)items[65];
            two_digit_year_cutoff = (short?)items[66];
            containment = (byte?)items[67];
            containment_desc = (string)items[68];
            target_recovery_time_in_seconds = (int?)items[69];
            as_of = (DateTime)items[70];
        }
    }

    [SqlTable("systems", "host_servers")]
    public partial class host_servers : SqlTableProxy
    {
        [SqlColumn("systems_key", 0), SqlTypeFacets("int", false)]
        public int systems_key
        {
            get;
            set;
        }

        [SqlColumn("systems_server_name", 1), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("as_of", 2), SqlTypeFacets("datetime2", false, -1, 3)]
        public DateTime as_of
        {
            get;
            set;
        }

        public host_servers()
        {
        }

        public host_servers(object[] items)
        {
            systems_key = (int)items[0];
            systems_server_name = (string)items[1];
            as_of = (DateTime)items[2];
        }

        public host_servers(int systems_key, string systems_server_name, DateTime as_of)
        {
            this.systems_key = systems_key;
            this.systems_server_name = systems_server_name;
            this.as_of = as_of;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_key, systems_server_name, as_of };
        }

        public override void SetItemArray(object[] items)
        {
            systems_key = (int)items[0];
            systems_server_name = (string)items[1];
            as_of = (DateTime)items[2];
        }
    }

    [SqlTable("systems", "schemas")]
    public partial class schemas : SqlTableProxy
    {
        [SqlColumn("systems_key", 0), SqlTypeFacets("int", false)]
        public int systems_key
        {
            get;
            set;
        }

        [SqlColumn("systems_server_name", 1), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("systems_database_name", 2), SqlTypeFacets("sysname", false)]
        public string systems_database_name
        {
            get;
            set;
        }

        [SqlColumn("name", 3), SqlTypeFacets("sysname", false)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("schema_id", 4), SqlTypeFacets("int", false)]
        public int schema_id
        {
            get;
            set;
        }

        [SqlColumn("principal_id", 5), SqlTypeFacets("int", true)]
        public int? principal_id
        {
            get;
            set;
        }

        [SqlColumn("as_of", 6), SqlTypeFacets("datetime2", false, -1, 3)]
        public DateTime as_of
        {
            get;
            set;
        }

        public schemas()
        {
        }

        public schemas(object[] items)
        {
            systems_key = (int)items[0];
            systems_server_name = (string)items[1];
            systems_database_name = (string)items[2];
            name = (string)items[3];
            schema_id = (int)items[4];
            principal_id = (int?)items[5];
            as_of = (DateTime)items[6];
        }

        public schemas(int systems_key, string systems_server_name, string systems_database_name, string name, int schema_id, int? principal_id, DateTime as_of)
        {
            this.systems_key = systems_key;
            this.systems_server_name = systems_server_name;
            this.systems_database_name = systems_database_name;
            this.name = name;
            this.schema_id = schema_id;
            this.principal_id = principal_id;
            this.as_of = as_of;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_key, systems_server_name, systems_database_name, name, schema_id, principal_id, as_of };
        }

        public override void SetItemArray(object[] items)
        {
            systems_key = (int)items[0];
            systems_server_name = (string)items[1];
            systems_database_name = (string)items[2];
            name = (string)items[3];
            schema_id = (int)items[4];
            principal_id = (int?)items[5];
            as_of = (DateTime)items[6];
        }
    }

    [SqlTable("systems", "servers")]
    public partial class servers : SqlTableProxy
    {
        [SqlColumn("systems_key", 0), SqlTypeFacets("int", false)]
        public int systems_key
        {
            get;
            set;
        }

        [SqlColumn("systems_server_name", 1), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("server_id", 2), SqlTypeFacets("int", false)]
        public int server_id
        {
            get;
            set;
        }

        [SqlColumn("name", 3), SqlTypeFacets("sysname", false)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("product", 4), SqlTypeFacets("sysname", false)]
        public string product
        {
            get;
            set;
        }

        [SqlColumn("provider", 5), SqlTypeFacets("sysname", false)]
        public string provider
        {
            get;
            set;
        }

        [SqlColumn("data_source", 6), SqlTypeFacets("nvarchar", true, 8000)]
        public string data_source
        {
            get;
            set;
        }

        [SqlColumn("location", 7), SqlTypeFacets("nvarchar", true, 8000)]
        public string location
        {
            get;
            set;
        }

        [SqlColumn("provider_string", 8), SqlTypeFacets("nvarchar", true, 8000)]
        public string provider_string
        {
            get;
            set;
        }

        [SqlColumn("catalog", 9), SqlTypeFacets("sysname", true)]
        public string catalog
        {
            get;
            set;
        }

        [SqlColumn("connect_timeout", 10), SqlTypeFacets("int", true)]
        public int? connect_timeout
        {
            get;
            set;
        }

        [SqlColumn("query_timeout", 11), SqlTypeFacets("int", true)]
        public int? query_timeout
        {
            get;
            set;
        }

        [SqlColumn("is_linked", 12), SqlTypeFacets("bit", false)]
        public bool is_linked
        {
            get;
            set;
        }

        [SqlColumn("is_remote_login_enabled", 13), SqlTypeFacets("bit", false)]
        public bool is_remote_login_enabled
        {
            get;
            set;
        }

        [SqlColumn("is_rpc_out_enabled", 14), SqlTypeFacets("bit", false)]
        public bool is_rpc_out_enabled
        {
            get;
            set;
        }

        [SqlColumn("is_data_access_enabled", 15), SqlTypeFacets("bit", false)]
        public bool is_data_access_enabled
        {
            get;
            set;
        }

        [SqlColumn("is_collation_compatible", 16), SqlTypeFacets("bit", false)]
        public bool is_collation_compatible
        {
            get;
            set;
        }

        [SqlColumn("uses_remote_collation", 17), SqlTypeFacets("bit", false)]
        public bool uses_remote_collation
        {
            get;
            set;
        }

        [SqlColumn("collation_name", 18), SqlTypeFacets("sysname", true)]
        public string collation_name
        {
            get;
            set;
        }

        [SqlColumn("lazy_schema_validation", 19), SqlTypeFacets("bit", false)]
        public bool lazy_schema_validation
        {
            get;
            set;
        }

        [SqlColumn("is_system", 20), SqlTypeFacets("bit", false)]
        public bool is_system
        {
            get;
            set;
        }

        [SqlColumn("is_publisher", 21), SqlTypeFacets("bit", false)]
        public bool is_publisher
        {
            get;
            set;
        }

        [SqlColumn("is_subscriber", 22), SqlTypeFacets("bit", true)]
        public bool? is_subscriber
        {
            get;
            set;
        }

        [SqlColumn("is_distributor", 23), SqlTypeFacets("bit", true)]
        public bool? is_distributor
        {
            get;
            set;
        }

        [SqlColumn("is_nonsql_subscriber", 24), SqlTypeFacets("bit", true)]
        public bool? is_nonsql_subscriber
        {
            get;
            set;
        }

        [SqlColumn("is_remote_proc_transaction_promotion_enabled", 25), SqlTypeFacets("bit", true)]
        public bool? is_remote_proc_transaction_promotion_enabled
        {
            get;
            set;
        }

        [SqlColumn("modify_date", 26), SqlTypeFacets("datetime", false)]
        public DateTime modify_date
        {
            get;
            set;
        }

        [SqlColumn("as_of", 27), SqlTypeFacets("datetime2", false, -1, 3)]
        public DateTime as_of
        {
            get;
            set;
        }

        public servers()
        {
        }

        public servers(object[] items)
        {
            systems_key = (int)items[0];
            systems_server_name = (string)items[1];
            server_id = (int)items[2];
            name = (string)items[3];
            product = (string)items[4];
            provider = (string)items[5];
            data_source = (string)items[6];
            location = (string)items[7];
            provider_string = (string)items[8];
            catalog = (string)items[9];
            connect_timeout = (int?)items[10];
            query_timeout = (int?)items[11];
            is_linked = (bool)items[12];
            is_remote_login_enabled = (bool)items[13];
            is_rpc_out_enabled = (bool)items[14];
            is_data_access_enabled = (bool)items[15];
            is_collation_compatible = (bool)items[16];
            uses_remote_collation = (bool)items[17];
            collation_name = (string)items[18];
            lazy_schema_validation = (bool)items[19];
            is_system = (bool)items[20];
            is_publisher = (bool)items[21];
            is_subscriber = (bool?)items[22];
            is_distributor = (bool?)items[23];
            is_nonsql_subscriber = (bool?)items[24];
            is_remote_proc_transaction_promotion_enabled = (bool?)items[25];
            modify_date = (DateTime)items[26];
            as_of = (DateTime)items[27];
        }

        public servers(int systems_key, string systems_server_name, int server_id, string name, string product, string provider, string data_source, string location, string provider_string, string catalog, int? connect_timeout, int? query_timeout, bool is_linked, bool is_remote_login_enabled, bool is_rpc_out_enabled, bool is_data_access_enabled, bool is_collation_compatible, bool uses_remote_collation, string collation_name, bool lazy_schema_validation, bool is_system, bool is_publisher, bool? is_subscriber, bool? is_distributor, bool? is_nonsql_subscriber, bool? is_remote_proc_transaction_promotion_enabled, DateTime modify_date, DateTime as_of)
        {
            this.systems_key = systems_key;
            this.systems_server_name = systems_server_name;
            this.server_id = server_id;
            this.name = name;
            this.product = product;
            this.provider = provider;
            this.data_source = data_source;
            this.location = location;
            this.provider_string = provider_string;
            this.catalog = catalog;
            this.connect_timeout = connect_timeout;
            this.query_timeout = query_timeout;
            this.is_linked = is_linked;
            this.is_remote_login_enabled = is_remote_login_enabled;
            this.is_rpc_out_enabled = is_rpc_out_enabled;
            this.is_data_access_enabled = is_data_access_enabled;
            this.is_collation_compatible = is_collation_compatible;
            this.uses_remote_collation = uses_remote_collation;
            this.collation_name = collation_name;
            this.lazy_schema_validation = lazy_schema_validation;
            this.is_system = is_system;
            this.is_publisher = is_publisher;
            this.is_subscriber = is_subscriber;
            this.is_distributor = is_distributor;
            this.is_nonsql_subscriber = is_nonsql_subscriber;
            this.is_remote_proc_transaction_promotion_enabled = is_remote_proc_transaction_promotion_enabled;
            this.modify_date = modify_date;
            this.as_of = as_of;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_key, systems_server_name, server_id, name, product, provider, data_source, location, provider_string, catalog, connect_timeout, query_timeout, is_linked, is_remote_login_enabled, is_rpc_out_enabled, is_data_access_enabled, is_collation_compatible, uses_remote_collation, collation_name, lazy_schema_validation, is_system, is_publisher, is_subscriber, is_distributor, is_nonsql_subscriber, is_remote_proc_transaction_promotion_enabled, modify_date, as_of };
        }

        public override void SetItemArray(object[] items)
        {
            systems_key = (int)items[0];
            systems_server_name = (string)items[1];
            server_id = (int)items[2];
            name = (string)items[3];
            product = (string)items[4];
            provider = (string)items[5];
            data_source = (string)items[6];
            location = (string)items[7];
            provider_string = (string)items[8];
            catalog = (string)items[9];
            connect_timeout = (int?)items[10];
            query_timeout = (int?)items[11];
            is_linked = (bool)items[12];
            is_remote_login_enabled = (bool)items[13];
            is_rpc_out_enabled = (bool)items[14];
            is_data_access_enabled = (bool)items[15];
            is_collation_compatible = (bool)items[16];
            uses_remote_collation = (bool)items[17];
            collation_name = (string)items[18];
            lazy_schema_validation = (bool)items[19];
            is_system = (bool)items[20];
            is_publisher = (bool)items[21];
            is_subscriber = (bool?)items[22];
            is_distributor = (bool?)items[23];
            is_nonsql_subscriber = (bool?)items[24];
            is_remote_proc_transaction_promotion_enabled = (bool?)items[25];
            modify_date = (DateTime)items[26];
            as_of = (DateTime)items[27];
        }
    }

    [SqlTable("systems", "table_columns")]
    public partial class table_columns : SqlTableProxy
    {
        [SqlColumn("systems_key", 0), SqlTypeFacets("int", false)]
        public int systems_key
        {
            get;
            set;
        }

        [SqlColumn("systems_server_name", 1), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("systems_database_name", 2), SqlTypeFacets("sysname", false)]
        public string systems_database_name
        {
            get;
            set;
        }

        [SqlColumn("systems_schema_name", 3), SqlTypeFacets("sysname", false)]
        public string systems_schema_name
        {
            get;
            set;
        }

        [SqlColumn("systems_parent_name", 4), SqlTypeFacets("sysname", false)]
        public string systems_parent_name
        {
            get;
            set;
        }

        [SqlColumn("systems_parent_type", 5), SqlTypeFacets("char", false, 2)]
        public string systems_parent_type
        {
            get;
            set;
        }

        [SqlColumn("object_id", 6), SqlTypeFacets("int", false)]
        public int object_id
        {
            get;
            set;
        }

        [SqlColumn("name", 7), SqlTypeFacets("sysname", true)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("column_id", 8), SqlTypeFacets("int", false)]
        public int column_id
        {
            get;
            set;
        }

        [SqlColumn("system_type_id", 9), SqlTypeFacets("tinyint", false)]
        public byte system_type_id
        {
            get;
            set;
        }

        [SqlColumn("user_type_id", 10), SqlTypeFacets("int", false)]
        public int user_type_id
        {
            get;
            set;
        }

        [SqlColumn("max_length", 11), SqlTypeFacets("smallint", false)]
        public short max_length
        {
            get;
            set;
        }

        [SqlColumn("precision", 12), SqlTypeFacets("tinyint", false)]
        public byte precision
        {
            get;
            set;
        }

        [SqlColumn("scale", 13), SqlTypeFacets("tinyint", false)]
        public byte scale
        {
            get;
            set;
        }

        [SqlColumn("collation_name", 14), SqlTypeFacets("sysname", true)]
        public string collation_name
        {
            get;
            set;
        }

        [SqlColumn("is_nullable", 15), SqlTypeFacets("bit", true)]
        public bool? is_nullable
        {
            get;
            set;
        }

        [SqlColumn("is_ansi_padded", 16), SqlTypeFacets("bit", false)]
        public bool is_ansi_padded
        {
            get;
            set;
        }

        [SqlColumn("is_rowguidcol", 17), SqlTypeFacets("bit", false)]
        public bool is_rowguidcol
        {
            get;
            set;
        }

        [SqlColumn("is_identity", 18), SqlTypeFacets("bit", false)]
        public bool is_identity
        {
            get;
            set;
        }

        [SqlColumn("is_computed", 19), SqlTypeFacets("bit", false)]
        public bool is_computed
        {
            get;
            set;
        }

        [SqlColumn("is_filestream", 20), SqlTypeFacets("bit", false)]
        public bool is_filestream
        {
            get;
            set;
        }

        [SqlColumn("is_replicated", 21), SqlTypeFacets("bit", true)]
        public bool? is_replicated
        {
            get;
            set;
        }

        [SqlColumn("is_non_sql_subscribed", 22), SqlTypeFacets("bit", true)]
        public bool? is_non_sql_subscribed
        {
            get;
            set;
        }

        [SqlColumn("is_merge_published", 23), SqlTypeFacets("bit", true)]
        public bool? is_merge_published
        {
            get;
            set;
        }

        [SqlColumn("is_dts_replicated", 24), SqlTypeFacets("bit", true)]
        public bool? is_dts_replicated
        {
            get;
            set;
        }

        [SqlColumn("is_xml_document", 25), SqlTypeFacets("bit", false)]
        public bool is_xml_document
        {
            get;
            set;
        }

        [SqlColumn("xml_collection_id", 26), SqlTypeFacets("int", false)]
        public int xml_collection_id
        {
            get;
            set;
        }

        [SqlColumn("default_object_id", 27), SqlTypeFacets("int", false)]
        public int default_object_id
        {
            get;
            set;
        }

        [SqlColumn("rule_object_id", 28), SqlTypeFacets("int", false)]
        public int rule_object_id
        {
            get;
            set;
        }

        [SqlColumn("is_sparse", 29), SqlTypeFacets("bit", true)]
        public bool? is_sparse
        {
            get;
            set;
        }

        [SqlColumn("is_column_set", 30), SqlTypeFacets("bit", true)]
        public bool? is_column_set
        {
            get;
            set;
        }

        [SqlColumn("as_of", 31), SqlTypeFacets("datetime2", false, -1, 3)]
        public DateTime as_of
        {
            get;
            set;
        }

        public table_columns()
        {
        }

        public table_columns(object[] items)
        {
            systems_key = (int)items[0];
            systems_server_name = (string)items[1];
            systems_database_name = (string)items[2];
            systems_schema_name = (string)items[3];
            systems_parent_name = (string)items[4];
            systems_parent_type = (string)items[5];
            object_id = (int)items[6];
            name = (string)items[7];
            column_id = (int)items[8];
            system_type_id = (byte)items[9];
            user_type_id = (int)items[10];
            max_length = (short)items[11];
            precision = (byte)items[12];
            scale = (byte)items[13];
            collation_name = (string)items[14];
            is_nullable = (bool?)items[15];
            is_ansi_padded = (bool)items[16];
            is_rowguidcol = (bool)items[17];
            is_identity = (bool)items[18];
            is_computed = (bool)items[19];
            is_filestream = (bool)items[20];
            is_replicated = (bool?)items[21];
            is_non_sql_subscribed = (bool?)items[22];
            is_merge_published = (bool?)items[23];
            is_dts_replicated = (bool?)items[24];
            is_xml_document = (bool)items[25];
            xml_collection_id = (int)items[26];
            default_object_id = (int)items[27];
            rule_object_id = (int)items[28];
            is_sparse = (bool?)items[29];
            is_column_set = (bool?)items[30];
            as_of = (DateTime)items[31];
        }

        public table_columns(int systems_key, string systems_server_name, string systems_database_name, string systems_schema_name, string systems_parent_name, string systems_parent_type, int object_id, string name, int column_id, byte system_type_id, int user_type_id, short max_length, byte precision, byte scale, string collation_name, bool? is_nullable, bool is_ansi_padded, bool is_rowguidcol, bool is_identity, bool is_computed, bool is_filestream, bool? is_replicated, bool? is_non_sql_subscribed, bool? is_merge_published, bool? is_dts_replicated, bool is_xml_document, int xml_collection_id, int default_object_id, int rule_object_id, bool? is_sparse, bool? is_column_set, DateTime as_of)
        {
            this.systems_key = systems_key;
            this.systems_server_name = systems_server_name;
            this.systems_database_name = systems_database_name;
            this.systems_schema_name = systems_schema_name;
            this.systems_parent_name = systems_parent_name;
            this.systems_parent_type = systems_parent_type;
            this.object_id = object_id;
            this.name = name;
            this.column_id = column_id;
            this.system_type_id = system_type_id;
            this.user_type_id = user_type_id;
            this.max_length = max_length;
            this.precision = precision;
            this.scale = scale;
            this.collation_name = collation_name;
            this.is_nullable = is_nullable;
            this.is_ansi_padded = is_ansi_padded;
            this.is_rowguidcol = is_rowguidcol;
            this.is_identity = is_identity;
            this.is_computed = is_computed;
            this.is_filestream = is_filestream;
            this.is_replicated = is_replicated;
            this.is_non_sql_subscribed = is_non_sql_subscribed;
            this.is_merge_published = is_merge_published;
            this.is_dts_replicated = is_dts_replicated;
            this.is_xml_document = is_xml_document;
            this.xml_collection_id = xml_collection_id;
            this.default_object_id = default_object_id;
            this.rule_object_id = rule_object_id;
            this.is_sparse = is_sparse;
            this.is_column_set = is_column_set;
            this.as_of = as_of;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_key, systems_server_name, systems_database_name, systems_schema_name, systems_parent_name, systems_parent_type, object_id, name, column_id, system_type_id, user_type_id, max_length, precision, scale, collation_name, is_nullable, is_ansi_padded, is_rowguidcol, is_identity, is_computed, is_filestream, is_replicated, is_non_sql_subscribed, is_merge_published, is_dts_replicated, is_xml_document, xml_collection_id, default_object_id, rule_object_id, is_sparse, is_column_set, as_of };
        }

        public override void SetItemArray(object[] items)
        {
            systems_key = (int)items[0];
            systems_server_name = (string)items[1];
            systems_database_name = (string)items[2];
            systems_schema_name = (string)items[3];
            systems_parent_name = (string)items[4];
            systems_parent_type = (string)items[5];
            object_id = (int)items[6];
            name = (string)items[7];
            column_id = (int)items[8];
            system_type_id = (byte)items[9];
            user_type_id = (int)items[10];
            max_length = (short)items[11];
            precision = (byte)items[12];
            scale = (byte)items[13];
            collation_name = (string)items[14];
            is_nullable = (bool?)items[15];
            is_ansi_padded = (bool)items[16];
            is_rowguidcol = (bool)items[17];
            is_identity = (bool)items[18];
            is_computed = (bool)items[19];
            is_filestream = (bool)items[20];
            is_replicated = (bool?)items[21];
            is_non_sql_subscribed = (bool?)items[22];
            is_merge_published = (bool?)items[23];
            is_dts_replicated = (bool?)items[24];
            is_xml_document = (bool)items[25];
            xml_collection_id = (int)items[26];
            default_object_id = (int)items[27];
            rule_object_id = (int)items[28];
            is_sparse = (bool?)items[29];
            is_column_set = (bool?)items[30];
            as_of = (DateTime)items[31];
        }
    }

    [SqlTable("systems", "table_index_columns")]
    public partial class table_index_columns : SqlTableProxy
    {
        [SqlColumn("systems_key", 0), SqlTypeFacets("int", false)]
        public int systems_key
        {
            get;
            set;
        }

        [SqlColumn("systems_server_name", 1), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("systems_database_name", 2), SqlTypeFacets("sysname", false)]
        public string systems_database_name
        {
            get;
            set;
        }

        [SqlColumn("systems_schema_name", 3), SqlTypeFacets("sysname", false)]
        public string systems_schema_name
        {
            get;
            set;
        }

        [SqlColumn("systems_parent_name", 4), SqlTypeFacets("sysname", false)]
        public string systems_parent_name
        {
            get;
            set;
        }

        [SqlColumn("systems_parent_type", 5), SqlTypeFacets("char", false, 2)]
        public string systems_parent_type
        {
            get;
            set;
        }

        [SqlColumn("systems_column_name", 6), SqlTypeFacets("sysname", false)]
        public string systems_column_name
        {
            get;
            set;
        }

        [SqlColumn("systems_index_name", 7), SqlTypeFacets("sysname", false)]
        public string systems_index_name
        {
            get;
            set;
        }

        [SqlColumn("object_id", 8), SqlTypeFacets("int", false)]
        public int object_id
        {
            get;
            set;
        }

        [SqlColumn("index_id", 9), SqlTypeFacets("int", false)]
        public int index_id
        {
            get;
            set;
        }

        [SqlColumn("index_column_id", 10), SqlTypeFacets("int", false)]
        public int index_column_id
        {
            get;
            set;
        }

        [SqlColumn("column_id", 11), SqlTypeFacets("int", false)]
        public int column_id
        {
            get;
            set;
        }

        [SqlColumn("key_ordinal", 12), SqlTypeFacets("tinyint", false)]
        public byte key_ordinal
        {
            get;
            set;
        }

        [SqlColumn("partition_ordinal", 13), SqlTypeFacets("tinyint", false)]
        public byte partition_ordinal
        {
            get;
            set;
        }

        [SqlColumn("is_descending_key", 14), SqlTypeFacets("bit", true)]
        public bool? is_descending_key
        {
            get;
            set;
        }

        [SqlColumn("is_included_column", 15), SqlTypeFacets("bit", true)]
        public bool? is_included_column
        {
            get;
            set;
        }

        [SqlColumn("as_of", 16), SqlTypeFacets("datetime2", false, -1, 3)]
        public DateTime as_of
        {
            get;
            set;
        }

        public table_index_columns()
        {
        }

        public table_index_columns(object[] items)
        {
            systems_key = (int)items[0];
            systems_server_name = (string)items[1];
            systems_database_name = (string)items[2];
            systems_schema_name = (string)items[3];
            systems_parent_name = (string)items[4];
            systems_parent_type = (string)items[5];
            systems_column_name = (string)items[6];
            systems_index_name = (string)items[7];
            object_id = (int)items[8];
            index_id = (int)items[9];
            index_column_id = (int)items[10];
            column_id = (int)items[11];
            key_ordinal = (byte)items[12];
            partition_ordinal = (byte)items[13];
            is_descending_key = (bool?)items[14];
            is_included_column = (bool?)items[15];
            as_of = (DateTime)items[16];
        }

        public table_index_columns(int systems_key, string systems_server_name, string systems_database_name, string systems_schema_name, string systems_parent_name, string systems_parent_type, string systems_column_name, string systems_index_name, int object_id, int index_id, int index_column_id, int column_id, byte key_ordinal, byte partition_ordinal, bool? is_descending_key, bool? is_included_column, DateTime as_of)
        {
            this.systems_key = systems_key;
            this.systems_server_name = systems_server_name;
            this.systems_database_name = systems_database_name;
            this.systems_schema_name = systems_schema_name;
            this.systems_parent_name = systems_parent_name;
            this.systems_parent_type = systems_parent_type;
            this.systems_column_name = systems_column_name;
            this.systems_index_name = systems_index_name;
            this.object_id = object_id;
            this.index_id = index_id;
            this.index_column_id = index_column_id;
            this.column_id = column_id;
            this.key_ordinal = key_ordinal;
            this.partition_ordinal = partition_ordinal;
            this.is_descending_key = is_descending_key;
            this.is_included_column = is_included_column;
            this.as_of = as_of;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_key, systems_server_name, systems_database_name, systems_schema_name, systems_parent_name, systems_parent_type, systems_column_name, systems_index_name, object_id, index_id, index_column_id, column_id, key_ordinal, partition_ordinal, is_descending_key, is_included_column, as_of };
        }

        public override void SetItemArray(object[] items)
        {
            systems_key = (int)items[0];
            systems_server_name = (string)items[1];
            systems_database_name = (string)items[2];
            systems_schema_name = (string)items[3];
            systems_parent_name = (string)items[4];
            systems_parent_type = (string)items[5];
            systems_column_name = (string)items[6];
            systems_index_name = (string)items[7];
            object_id = (int)items[8];
            index_id = (int)items[9];
            index_column_id = (int)items[10];
            column_id = (int)items[11];
            key_ordinal = (byte)items[12];
            partition_ordinal = (byte)items[13];
            is_descending_key = (bool?)items[14];
            is_included_column = (bool?)items[15];
            as_of = (DateTime)items[16];
        }
    }

    [SqlTable("systems", "table_indexes")]
    public partial class table_indexes : SqlTableProxy
    {
        [SqlColumn("systems_key", 0), SqlTypeFacets("int", false)]
        public int systems_key
        {
            get;
            set;
        }

        [SqlColumn("systems_server_name", 1), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("systems_database_name", 2), SqlTypeFacets("sysname", false)]
        public string systems_database_name
        {
            get;
            set;
        }

        [SqlColumn("systems_schema_name", 3), SqlTypeFacets("sysname", false)]
        public string systems_schema_name
        {
            get;
            set;
        }

        [SqlColumn("systems_parent_name", 4), SqlTypeFacets("sysname", false)]
        public string systems_parent_name
        {
            get;
            set;
        }

        [SqlColumn("systems_parent_type", 5), SqlTypeFacets("char", false, 2)]
        public string systems_parent_type
        {
            get;
            set;
        }

        [SqlColumn("object_id", 6), SqlTypeFacets("int", false)]
        public int object_id
        {
            get;
            set;
        }

        [SqlColumn("name", 7), SqlTypeFacets("sysname", true)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("index_id", 8), SqlTypeFacets("int", false)]
        public int index_id
        {
            get;
            set;
        }

        [SqlColumn("type", 9), SqlTypeFacets("tinyint", false)]
        public byte type
        {
            get;
            set;
        }

        [SqlColumn("type_desc", 10), SqlTypeFacets("nvarchar", true, 120)]
        public string type_desc
        {
            get;
            set;
        }

        [SqlColumn("is_unique", 11), SqlTypeFacets("bit", true)]
        public bool? is_unique
        {
            get;
            set;
        }

        [SqlColumn("data_space_id", 12), SqlTypeFacets("int", true)]
        public int? data_space_id
        {
            get;
            set;
        }

        [SqlColumn("ignore_dup_key", 13), SqlTypeFacets("bit", true)]
        public bool? ignore_dup_key
        {
            get;
            set;
        }

        [SqlColumn("is_primary_key", 14), SqlTypeFacets("bit", true)]
        public bool? is_primary_key
        {
            get;
            set;
        }

        [SqlColumn("is_unique_constraint", 15), SqlTypeFacets("bit", true)]
        public bool? is_unique_constraint
        {
            get;
            set;
        }

        [SqlColumn("fill_factor", 16), SqlTypeFacets("tinyint", false)]
        public byte fill_factor
        {
            get;
            set;
        }

        [SqlColumn("is_padded", 17), SqlTypeFacets("bit", true)]
        public bool? is_padded
        {
            get;
            set;
        }

        [SqlColumn("is_disabled", 18), SqlTypeFacets("bit", true)]
        public bool? is_disabled
        {
            get;
            set;
        }

        [SqlColumn("is_hypothetical", 19), SqlTypeFacets("bit", true)]
        public bool? is_hypothetical
        {
            get;
            set;
        }

        [SqlColumn("allow_row_locks", 20), SqlTypeFacets("bit", true)]
        public bool? allow_row_locks
        {
            get;
            set;
        }

        [SqlColumn("allow_page_locks", 21), SqlTypeFacets("bit", true)]
        public bool? allow_page_locks
        {
            get;
            set;
        }

        [SqlColumn("has_filter", 22), SqlTypeFacets("bit", true)]
        public bool? has_filter
        {
            get;
            set;
        }

        [SqlColumn("filter_definition", 23), SqlTypeFacets("nvarchar", true, -1)]
        public string filter_definition
        {
            get;
            set;
        }

        [SqlColumn("as_of", 24), SqlTypeFacets("datetime2", false, -1, 3)]
        public DateTime as_of
        {
            get;
            set;
        }

        public table_indexes()
        {
        }

        public table_indexes(object[] items)
        {
            systems_key = (int)items[0];
            systems_server_name = (string)items[1];
            systems_database_name = (string)items[2];
            systems_schema_name = (string)items[3];
            systems_parent_name = (string)items[4];
            systems_parent_type = (string)items[5];
            object_id = (int)items[6];
            name = (string)items[7];
            index_id = (int)items[8];
            type = (byte)items[9];
            type_desc = (string)items[10];
            is_unique = (bool?)items[11];
            data_space_id = (int?)items[12];
            ignore_dup_key = (bool?)items[13];
            is_primary_key = (bool?)items[14];
            is_unique_constraint = (bool?)items[15];
            fill_factor = (byte)items[16];
            is_padded = (bool?)items[17];
            is_disabled = (bool?)items[18];
            is_hypothetical = (bool?)items[19];
            allow_row_locks = (bool?)items[20];
            allow_page_locks = (bool?)items[21];
            has_filter = (bool?)items[22];
            filter_definition = (string)items[23];
            as_of = (DateTime)items[24];
        }

        public table_indexes(int systems_key, string systems_server_name, string systems_database_name, string systems_schema_name, string systems_parent_name, string systems_parent_type, int object_id, string name, int index_id, byte type, string type_desc, bool? is_unique, int? data_space_id, bool? ignore_dup_key, bool? is_primary_key, bool? is_unique_constraint, byte fill_factor, bool? is_padded, bool? is_disabled, bool? is_hypothetical, bool? allow_row_locks, bool? allow_page_locks, bool? has_filter, string filter_definition, DateTime as_of)
        {
            this.systems_key = systems_key;
            this.systems_server_name = systems_server_name;
            this.systems_database_name = systems_database_name;
            this.systems_schema_name = systems_schema_name;
            this.systems_parent_name = systems_parent_name;
            this.systems_parent_type = systems_parent_type;
            this.object_id = object_id;
            this.name = name;
            this.index_id = index_id;
            this.type = type;
            this.type_desc = type_desc;
            this.is_unique = is_unique;
            this.data_space_id = data_space_id;
            this.ignore_dup_key = ignore_dup_key;
            this.is_primary_key = is_primary_key;
            this.is_unique_constraint = is_unique_constraint;
            this.fill_factor = fill_factor;
            this.is_padded = is_padded;
            this.is_disabled = is_disabled;
            this.is_hypothetical = is_hypothetical;
            this.allow_row_locks = allow_row_locks;
            this.allow_page_locks = allow_page_locks;
            this.has_filter = has_filter;
            this.filter_definition = filter_definition;
            this.as_of = as_of;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_key, systems_server_name, systems_database_name, systems_schema_name, systems_parent_name, systems_parent_type, object_id, name, index_id, type, type_desc, is_unique, data_space_id, ignore_dup_key, is_primary_key, is_unique_constraint, fill_factor, is_padded, is_disabled, is_hypothetical, allow_row_locks, allow_page_locks, has_filter, filter_definition, as_of };
        }

        public override void SetItemArray(object[] items)
        {
            systems_key = (int)items[0];
            systems_server_name = (string)items[1];
            systems_database_name = (string)items[2];
            systems_schema_name = (string)items[3];
            systems_parent_name = (string)items[4];
            systems_parent_type = (string)items[5];
            object_id = (int)items[6];
            name = (string)items[7];
            index_id = (int)items[8];
            type = (byte)items[9];
            type_desc = (string)items[10];
            is_unique = (bool?)items[11];
            data_space_id = (int?)items[12];
            ignore_dup_key = (bool?)items[13];
            is_primary_key = (bool?)items[14];
            is_unique_constraint = (bool?)items[15];
            fill_factor = (byte)items[16];
            is_padded = (bool?)items[17];
            is_disabled = (bool?)items[18];
            is_hypothetical = (bool?)items[19];
            allow_row_locks = (bool?)items[20];
            allow_page_locks = (bool?)items[21];
            has_filter = (bool?)items[22];
            filter_definition = (string)items[23];
            as_of = (DateTime)items[24];
        }
    }

    [SqlTable("systems", "tables")]
    public partial class tables : SqlTableProxy
    {
        [SqlColumn("systems_key", 0), SqlTypeFacets("int", false)]
        public int systems_key
        {
            get;
            set;
        }

        [SqlColumn("systems_server_name", 1), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("systems_database_name", 2), SqlTypeFacets("sysname", false)]
        public string systems_database_name
        {
            get;
            set;
        }

        [SqlColumn("systems_schema_name", 3), SqlTypeFacets("sysname", false)]
        public string systems_schema_name
        {
            get;
            set;
        }

        [SqlColumn("name", 4), SqlTypeFacets("sysname", false)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("object_id", 5), SqlTypeFacets("int", false)]
        public int object_id
        {
            get;
            set;
        }

        [SqlColumn("principal_id", 6), SqlTypeFacets("int", true)]
        public int? principal_id
        {
            get;
            set;
        }

        [SqlColumn("schema_id", 7), SqlTypeFacets("int", false)]
        public int schema_id
        {
            get;
            set;
        }

        [SqlColumn("parent_object_id", 8), SqlTypeFacets("int", false)]
        public int parent_object_id
        {
            get;
            set;
        }

        [SqlColumn("type", 9), SqlTypeFacets("char", true, 2)]
        public string type
        {
            get;
            set;
        }

        [SqlColumn("type_desc", 10), SqlTypeFacets("nvarchar", true, 120)]
        public string type_desc
        {
            get;
            set;
        }

        [SqlColumn("create_date", 11), SqlTypeFacets("datetime", false)]
        public DateTime create_date
        {
            get;
            set;
        }

        [SqlColumn("modify_date", 12), SqlTypeFacets("datetime", false)]
        public DateTime modify_date
        {
            get;
            set;
        }

        [SqlColumn("is_ms_shipped", 13), SqlTypeFacets("bit", false)]
        public bool is_ms_shipped
        {
            get;
            set;
        }

        [SqlColumn("is_published", 14), SqlTypeFacets("bit", false)]
        public bool is_published
        {
            get;
            set;
        }

        [SqlColumn("is_schema_published", 15), SqlTypeFacets("bit", false)]
        public bool is_schema_published
        {
            get;
            set;
        }

        [SqlColumn("lob_data_space_id", 16), SqlTypeFacets("int", false)]
        public int lob_data_space_id
        {
            get;
            set;
        }

        [SqlColumn("filestream_data_space_id", 17), SqlTypeFacets("int", true)]
        public int? filestream_data_space_id
        {
            get;
            set;
        }

        [SqlColumn("max_column_id_used", 18), SqlTypeFacets("int", false)]
        public int max_column_id_used
        {
            get;
            set;
        }

        [SqlColumn("lock_on_bulk_load", 19), SqlTypeFacets("bit", false)]
        public bool lock_on_bulk_load
        {
            get;
            set;
        }

        [SqlColumn("uses_ansi_nulls", 20), SqlTypeFacets("bit", true)]
        public bool? uses_ansi_nulls
        {
            get;
            set;
        }

        [SqlColumn("is_replicated", 21), SqlTypeFacets("bit", true)]
        public bool? is_replicated
        {
            get;
            set;
        }

        [SqlColumn("has_replication_filter", 22), SqlTypeFacets("bit", true)]
        public bool? has_replication_filter
        {
            get;
            set;
        }

        [SqlColumn("is_merge_published", 23), SqlTypeFacets("bit", true)]
        public bool? is_merge_published
        {
            get;
            set;
        }

        [SqlColumn("is_sync_tran_subscribed", 24), SqlTypeFacets("bit", true)]
        public bool? is_sync_tran_subscribed
        {
            get;
            set;
        }

        [SqlColumn("has_unchecked_assembly_data", 25), SqlTypeFacets("bit", false)]
        public bool has_unchecked_assembly_data
        {
            get;
            set;
        }

        [SqlColumn("text_in_row_limit", 26), SqlTypeFacets("int", true)]
        public int? text_in_row_limit
        {
            get;
            set;
        }

        [SqlColumn("large_value_types_out_of_row", 27), SqlTypeFacets("bit", true)]
        public bool? large_value_types_out_of_row
        {
            get;
            set;
        }

        [SqlColumn("is_tracked_by_cdc", 28), SqlTypeFacets("bit", true)]
        public bool? is_tracked_by_cdc
        {
            get;
            set;
        }

        [SqlColumn("lock_escalation", 29), SqlTypeFacets("tinyint", true)]
        public byte? lock_escalation
        {
            get;
            set;
        }

        [SqlColumn("lock_escalation_desc", 30), SqlTypeFacets("nvarchar", true, 120)]
        public string lock_escalation_desc
        {
            get;
            set;
        }

        [SqlColumn("is_filetable", 31), SqlTypeFacets("bit", true)]
        public bool? is_filetable
        {
            get;
            set;
        }

        [SqlColumn("is_memory_optimized", 32), SqlTypeFacets("bit", true)]
        public bool? is_memory_optimized
        {
            get;
            set;
        }

        [SqlColumn("durability", 33), SqlTypeFacets("tinyint", true)]
        public byte? durability
        {
            get;
            set;
        }

        [SqlColumn("durability_desc", 34), SqlTypeFacets("nvarchar", true, 120)]
        public string durability_desc
        {
            get;
            set;
        }

        [SqlColumn("as_of", 35), SqlTypeFacets("datetime2", false, -1, 3)]
        public DateTime as_of
        {
            get;
            set;
        }

        public tables()
        {
        }

        public tables(object[] items)
        {
            systems_key = (int)items[0];
            systems_server_name = (string)items[1];
            systems_database_name = (string)items[2];
            systems_schema_name = (string)items[3];
            name = (string)items[4];
            object_id = (int)items[5];
            principal_id = (int?)items[6];
            schema_id = (int)items[7];
            parent_object_id = (int)items[8];
            type = (string)items[9];
            type_desc = (string)items[10];
            create_date = (DateTime)items[11];
            modify_date = (DateTime)items[12];
            is_ms_shipped = (bool)items[13];
            is_published = (bool)items[14];
            is_schema_published = (bool)items[15];
            lob_data_space_id = (int)items[16];
            filestream_data_space_id = (int?)items[17];
            max_column_id_used = (int)items[18];
            lock_on_bulk_load = (bool)items[19];
            uses_ansi_nulls = (bool?)items[20];
            is_replicated = (bool?)items[21];
            has_replication_filter = (bool?)items[22];
            is_merge_published = (bool?)items[23];
            is_sync_tran_subscribed = (bool?)items[24];
            has_unchecked_assembly_data = (bool)items[25];
            text_in_row_limit = (int?)items[26];
            large_value_types_out_of_row = (bool?)items[27];
            is_tracked_by_cdc = (bool?)items[28];
            lock_escalation = (byte?)items[29];
            lock_escalation_desc = (string)items[30];
            is_filetable = (bool?)items[31];
            is_memory_optimized = (bool?)items[32];
            durability = (byte?)items[33];
            durability_desc = (string)items[34];
            as_of = (DateTime)items[35];
        }

        public tables(int systems_key, string systems_server_name, string systems_database_name, string systems_schema_name, string name, int object_id, int? principal_id, int schema_id, int parent_object_id, string type, string type_desc, DateTime create_date, DateTime modify_date, bool is_ms_shipped, bool is_published, bool is_schema_published, int lob_data_space_id, int? filestream_data_space_id, int max_column_id_used, bool lock_on_bulk_load, bool? uses_ansi_nulls, bool? is_replicated, bool? has_replication_filter, bool? is_merge_published, bool? is_sync_tran_subscribed, bool has_unchecked_assembly_data, int? text_in_row_limit, bool? large_value_types_out_of_row, bool? is_tracked_by_cdc, byte? lock_escalation, string lock_escalation_desc, bool? is_filetable, bool? is_memory_optimized, byte? durability, string durability_desc, DateTime as_of)
        {
            this.systems_key = systems_key;
            this.systems_server_name = systems_server_name;
            this.systems_database_name = systems_database_name;
            this.systems_schema_name = systems_schema_name;
            this.name = name;
            this.object_id = object_id;
            this.principal_id = principal_id;
            this.schema_id = schema_id;
            this.parent_object_id = parent_object_id;
            this.type = type;
            this.type_desc = type_desc;
            this.create_date = create_date;
            this.modify_date = modify_date;
            this.is_ms_shipped = is_ms_shipped;
            this.is_published = is_published;
            this.is_schema_published = is_schema_published;
            this.lob_data_space_id = lob_data_space_id;
            this.filestream_data_space_id = filestream_data_space_id;
            this.max_column_id_used = max_column_id_used;
            this.lock_on_bulk_load = lock_on_bulk_load;
            this.uses_ansi_nulls = uses_ansi_nulls;
            this.is_replicated = is_replicated;
            this.has_replication_filter = has_replication_filter;
            this.is_merge_published = is_merge_published;
            this.is_sync_tran_subscribed = is_sync_tran_subscribed;
            this.has_unchecked_assembly_data = has_unchecked_assembly_data;
            this.text_in_row_limit = text_in_row_limit;
            this.large_value_types_out_of_row = large_value_types_out_of_row;
            this.is_tracked_by_cdc = is_tracked_by_cdc;
            this.lock_escalation = lock_escalation;
            this.lock_escalation_desc = lock_escalation_desc;
            this.is_filetable = is_filetable;
            this.is_memory_optimized = is_memory_optimized;
            this.durability = durability;
            this.durability_desc = durability_desc;
            this.as_of = as_of;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_key, systems_server_name, systems_database_name, systems_schema_name, name, object_id, principal_id, schema_id, parent_object_id, type, type_desc, create_date, modify_date, is_ms_shipped, is_published, is_schema_published, lob_data_space_id, filestream_data_space_id, max_column_id_used, lock_on_bulk_load, uses_ansi_nulls, is_replicated, has_replication_filter, is_merge_published, is_sync_tran_subscribed, has_unchecked_assembly_data, text_in_row_limit, large_value_types_out_of_row, is_tracked_by_cdc, lock_escalation, lock_escalation_desc, is_filetable, is_memory_optimized, durability, durability_desc, as_of };
        }

        public override void SetItemArray(object[] items)
        {
            systems_key = (int)items[0];
            systems_server_name = (string)items[1];
            systems_database_name = (string)items[2];
            systems_schema_name = (string)items[3];
            name = (string)items[4];
            object_id = (int)items[5];
            principal_id = (int?)items[6];
            schema_id = (int)items[7];
            parent_object_id = (int)items[8];
            type = (string)items[9];
            type_desc = (string)items[10];
            create_date = (DateTime)items[11];
            modify_date = (DateTime)items[12];
            is_ms_shipped = (bool)items[13];
            is_published = (bool)items[14];
            is_schema_published = (bool)items[15];
            lob_data_space_id = (int)items[16];
            filestream_data_space_id = (int?)items[17];
            max_column_id_used = (int)items[18];
            lock_on_bulk_load = (bool)items[19];
            uses_ansi_nulls = (bool?)items[20];
            is_replicated = (bool?)items[21];
            has_replication_filter = (bool?)items[22];
            is_merge_published = (bool?)items[23];
            is_sync_tran_subscribed = (bool?)items[24];
            has_unchecked_assembly_data = (bool)items[25];
            text_in_row_limit = (int?)items[26];
            large_value_types_out_of_row = (bool?)items[27];
            is_tracked_by_cdc = (bool?)items[28];
            lock_escalation = (byte?)items[29];
            lock_escalation_desc = (string)items[30];
            is_filetable = (bool?)items[31];
            is_memory_optimized = (bool?)items[32];
            durability = (byte?)items[33];
            durability_desc = (string)items[34];
            as_of = (DateTime)items[35];
        }
    }

    [SqlTable("systems", "types")]
    public partial class types : SqlTableProxy
    {
        [SqlColumn("systems_key", 0), SqlTypeFacets("int", false)]
        public int systems_key
        {
            get;
            set;
        }

        [SqlColumn("systems_server_name", 1), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("systems_database_name", 2), SqlTypeFacets("sysname", false)]
        public string systems_database_name
        {
            get;
            set;
        }

        [SqlColumn("systems_schema_name", 3), SqlTypeFacets("sysname", false)]
        public string systems_schema_name
        {
            get;
            set;
        }

        [SqlColumn("name", 4), SqlTypeFacets("sysname", false)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("system_type_id", 5), SqlTypeFacets("tinyint", false)]
        public byte system_type_id
        {
            get;
            set;
        }

        [SqlColumn("user_type_id", 6), SqlTypeFacets("int", false)]
        public int user_type_id
        {
            get;
            set;
        }

        [SqlColumn("schema_id", 7), SqlTypeFacets("int", false)]
        public int schema_id
        {
            get;
            set;
        }

        [SqlColumn("principal_id", 8), SqlTypeFacets("int", true)]
        public int? principal_id
        {
            get;
            set;
        }

        [SqlColumn("max_length", 9), SqlTypeFacets("smallint", false)]
        public short max_length
        {
            get;
            set;
        }

        [SqlColumn("precision", 10), SqlTypeFacets("tinyint", false)]
        public byte precision
        {
            get;
            set;
        }

        [SqlColumn("scale", 11), SqlTypeFacets("tinyint", false)]
        public byte scale
        {
            get;
            set;
        }

        [SqlColumn("collation_name", 12), SqlTypeFacets("sysname", true)]
        public string collation_name
        {
            get;
            set;
        }

        [SqlColumn("is_nullable", 13), SqlTypeFacets("bit", true)]
        public bool? is_nullable
        {
            get;
            set;
        }

        [SqlColumn("is_user_defined", 14), SqlTypeFacets("bit", false)]
        public bool is_user_defined
        {
            get;
            set;
        }

        [SqlColumn("is_assembly_type", 15), SqlTypeFacets("bit", false)]
        public bool is_assembly_type
        {
            get;
            set;
        }

        [SqlColumn("default_object_id", 16), SqlTypeFacets("int", false)]
        public int default_object_id
        {
            get;
            set;
        }

        [SqlColumn("rule_object_id", 17), SqlTypeFacets("int", false)]
        public int rule_object_id
        {
            get;
            set;
        }

        [SqlColumn("is_table_type", 18), SqlTypeFacets("bit", false)]
        public bool is_table_type
        {
            get;
            set;
        }

        [SqlColumn("as_of", 19), SqlTypeFacets("datetime2", false, -1, 3)]
        public DateTime as_of
        {
            get;
            set;
        }

        public types()
        {
        }

        public types(object[] items)
        {
            systems_key = (int)items[0];
            systems_server_name = (string)items[1];
            systems_database_name = (string)items[2];
            systems_schema_name = (string)items[3];
            name = (string)items[4];
            system_type_id = (byte)items[5];
            user_type_id = (int)items[6];
            schema_id = (int)items[7];
            principal_id = (int?)items[8];
            max_length = (short)items[9];
            precision = (byte)items[10];
            scale = (byte)items[11];
            collation_name = (string)items[12];
            is_nullable = (bool?)items[13];
            is_user_defined = (bool)items[14];
            is_assembly_type = (bool)items[15];
            default_object_id = (int)items[16];
            rule_object_id = (int)items[17];
            is_table_type = (bool)items[18];
            as_of = (DateTime)items[19];
        }

        public types(int systems_key, string systems_server_name, string systems_database_name, string systems_schema_name, string name, byte system_type_id, int user_type_id, int schema_id, int? principal_id, short max_length, byte precision, byte scale, string collation_name, bool? is_nullable, bool is_user_defined, bool is_assembly_type, int default_object_id, int rule_object_id, bool is_table_type, DateTime as_of)
        {
            this.systems_key = systems_key;
            this.systems_server_name = systems_server_name;
            this.systems_database_name = systems_database_name;
            this.systems_schema_name = systems_schema_name;
            this.name = name;
            this.system_type_id = system_type_id;
            this.user_type_id = user_type_id;
            this.schema_id = schema_id;
            this.principal_id = principal_id;
            this.max_length = max_length;
            this.precision = precision;
            this.scale = scale;
            this.collation_name = collation_name;
            this.is_nullable = is_nullable;
            this.is_user_defined = is_user_defined;
            this.is_assembly_type = is_assembly_type;
            this.default_object_id = default_object_id;
            this.rule_object_id = rule_object_id;
            this.is_table_type = is_table_type;
            this.as_of = as_of;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_key, systems_server_name, systems_database_name, systems_schema_name, name, system_type_id, user_type_id, schema_id, principal_id, max_length, precision, scale, collation_name, is_nullable, is_user_defined, is_assembly_type, default_object_id, rule_object_id, is_table_type, as_of };
        }

        public override void SetItemArray(object[] items)
        {
            systems_key = (int)items[0];
            systems_server_name = (string)items[1];
            systems_database_name = (string)items[2];
            systems_schema_name = (string)items[3];
            name = (string)items[4];
            system_type_id = (byte)items[5];
            user_type_id = (int)items[6];
            schema_id = (int)items[7];
            principal_id = (int?)items[8];
            max_length = (short)items[9];
            precision = (byte)items[10];
            scale = (byte)items[11];
            collation_name = (string)items[12];
            is_nullable = (bool?)items[13];
            is_user_defined = (bool)items[14];
            is_assembly_type = (bool)items[15];
            default_object_id = (int)items[16];
            rule_object_id = (int)items[17];
            is_table_type = (bool)items[18];
            as_of = (DateTime)items[19];
        }
    }

    [SqlTable("systems", "views")]
    public partial class views : SqlTableProxy
    {
        [SqlColumn("systems_key", 0), SqlTypeFacets("int", false)]
        public int systems_key
        {
            get;
            set;
        }

        [SqlColumn("systems_server_name", 1), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("systems_database_name", 2), SqlTypeFacets("sysname", false)]
        public string systems_database_name
        {
            get;
            set;
        }

        [SqlColumn("systems_schema_name", 3), SqlTypeFacets("sysname", false)]
        public string systems_schema_name
        {
            get;
            set;
        }

        [SqlColumn("name", 4), SqlTypeFacets("sysname", false)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("object_id", 5), SqlTypeFacets("int", false)]
        public int object_id
        {
            get;
            set;
        }

        [SqlColumn("principal_id", 6), SqlTypeFacets("int", true)]
        public int? principal_id
        {
            get;
            set;
        }

        [SqlColumn("schema_id", 7), SqlTypeFacets("int", false)]
        public int schema_id
        {
            get;
            set;
        }

        [SqlColumn("parent_object_id", 8), SqlTypeFacets("int", false)]
        public int parent_object_id
        {
            get;
            set;
        }

        [SqlColumn("type", 9), SqlTypeFacets("char", true, 2)]
        public string type
        {
            get;
            set;
        }

        [SqlColumn("type_desc", 10), SqlTypeFacets("nvarchar", true, 120)]
        public string type_desc
        {
            get;
            set;
        }

        [SqlColumn("create_date", 11), SqlTypeFacets("datetime", false)]
        public DateTime create_date
        {
            get;
            set;
        }

        [SqlColumn("modify_date", 12), SqlTypeFacets("datetime", false)]
        public DateTime modify_date
        {
            get;
            set;
        }

        [SqlColumn("is_ms_shipped", 13), SqlTypeFacets("bit", false)]
        public bool is_ms_shipped
        {
            get;
            set;
        }

        [SqlColumn("is_published", 14), SqlTypeFacets("bit", false)]
        public bool is_published
        {
            get;
            set;
        }

        [SqlColumn("is_schema_published", 15), SqlTypeFacets("bit", false)]
        public bool is_schema_published
        {
            get;
            set;
        }

        [SqlColumn("is_replicated", 16), SqlTypeFacets("bit", true)]
        public bool? is_replicated
        {
            get;
            set;
        }

        [SqlColumn("has_replication_filter", 17), SqlTypeFacets("bit", true)]
        public bool? has_replication_filter
        {
            get;
            set;
        }

        [SqlColumn("has_opaque_metadata", 18), SqlTypeFacets("bit", false)]
        public bool has_opaque_metadata
        {
            get;
            set;
        }

        [SqlColumn("has_unchecked_assembly_data", 19), SqlTypeFacets("bit", false)]
        public bool has_unchecked_assembly_data
        {
            get;
            set;
        }

        [SqlColumn("with_check_option", 20), SqlTypeFacets("bit", false)]
        public bool with_check_option
        {
            get;
            set;
        }

        [SqlColumn("is_date_correlation_view", 21), SqlTypeFacets("bit", false)]
        public bool is_date_correlation_view
        {
            get;
            set;
        }

        [SqlColumn("is_tracked_by_cdc", 22), SqlTypeFacets("bit", true)]
        public bool? is_tracked_by_cdc
        {
            get;
            set;
        }

        [SqlColumn("as_of", 23), SqlTypeFacets("datetime2", false, -1, 3)]
        public DateTime as_of
        {
            get;
            set;
        }

        public views()
        {
        }

        public views(object[] items)
        {
            systems_key = (int)items[0];
            systems_server_name = (string)items[1];
            systems_database_name = (string)items[2];
            systems_schema_name = (string)items[3];
            name = (string)items[4];
            object_id = (int)items[5];
            principal_id = (int?)items[6];
            schema_id = (int)items[7];
            parent_object_id = (int)items[8];
            type = (string)items[9];
            type_desc = (string)items[10];
            create_date = (DateTime)items[11];
            modify_date = (DateTime)items[12];
            is_ms_shipped = (bool)items[13];
            is_published = (bool)items[14];
            is_schema_published = (bool)items[15];
            is_replicated = (bool?)items[16];
            has_replication_filter = (bool?)items[17];
            has_opaque_metadata = (bool)items[18];
            has_unchecked_assembly_data = (bool)items[19];
            with_check_option = (bool)items[20];
            is_date_correlation_view = (bool)items[21];
            is_tracked_by_cdc = (bool?)items[22];
            as_of = (DateTime)items[23];
        }

        public views(int systems_key, string systems_server_name, string systems_database_name, string systems_schema_name, string name, int object_id, int? principal_id, int schema_id, int parent_object_id, string type, string type_desc, DateTime create_date, DateTime modify_date, bool is_ms_shipped, bool is_published, bool is_schema_published, bool? is_replicated, bool? has_replication_filter, bool has_opaque_metadata, bool has_unchecked_assembly_data, bool with_check_option, bool is_date_correlation_view, bool? is_tracked_by_cdc, DateTime as_of)
        {
            this.systems_key = systems_key;
            this.systems_server_name = systems_server_name;
            this.systems_database_name = systems_database_name;
            this.systems_schema_name = systems_schema_name;
            this.name = name;
            this.object_id = object_id;
            this.principal_id = principal_id;
            this.schema_id = schema_id;
            this.parent_object_id = parent_object_id;
            this.type = type;
            this.type_desc = type_desc;
            this.create_date = create_date;
            this.modify_date = modify_date;
            this.is_ms_shipped = is_ms_shipped;
            this.is_published = is_published;
            this.is_schema_published = is_schema_published;
            this.is_replicated = is_replicated;
            this.has_replication_filter = has_replication_filter;
            this.has_opaque_metadata = has_opaque_metadata;
            this.has_unchecked_assembly_data = has_unchecked_assembly_data;
            this.with_check_option = with_check_option;
            this.is_date_correlation_view = is_date_correlation_view;
            this.is_tracked_by_cdc = is_tracked_by_cdc;
            this.as_of = as_of;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_key, systems_server_name, systems_database_name, systems_schema_name, name, object_id, principal_id, schema_id, parent_object_id, type, type_desc, create_date, modify_date, is_ms_shipped, is_published, is_schema_published, is_replicated, has_replication_filter, has_opaque_metadata, has_unchecked_assembly_data, with_check_option, is_date_correlation_view, is_tracked_by_cdc, as_of };
        }

        public override void SetItemArray(object[] items)
        {
            systems_key = (int)items[0];
            systems_server_name = (string)items[1];
            systems_database_name = (string)items[2];
            systems_schema_name = (string)items[3];
            name = (string)items[4];
            object_id = (int)items[5];
            principal_id = (int?)items[6];
            schema_id = (int)items[7];
            parent_object_id = (int)items[8];
            type = (string)items[9];
            type_desc = (string)items[10];
            create_date = (DateTime)items[11];
            modify_date = (DateTime)items[12];
            is_ms_shipped = (bool)items[13];
            is_published = (bool)items[14];
            is_schema_published = (bool)items[15];
            is_replicated = (bool?)items[16];
            has_replication_filter = (bool?)items[17];
            has_opaque_metadata = (bool)items[18];
            has_unchecked_assembly_data = (bool)items[19];
            with_check_option = (bool)items[20];
            is_date_correlation_view = (bool)items[21];
            is_tracked_by_cdc = (bool?)items[22];
            as_of = (DateTime)items[23];
        }
    }

    [SqlRecord("systems", "servers_record")]
    public partial class servers_record : SqlTableTypeProxy<servers_record>, Iservers_record
    {
        [SqlColumn("systems_server_name", 0), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("server_id", 1), SqlTypeFacets("int", false)]
        public int server_id
        {
            get;
            set;
        }

        [SqlColumn("name", 2), SqlTypeFacets("sysname", false)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("product", 3), SqlTypeFacets("sysname", false)]
        public string product
        {
            get;
            set;
        }

        [SqlColumn("provider", 4), SqlTypeFacets("sysname", false)]
        public string provider
        {
            get;
            set;
        }

        [SqlColumn("data_source", 5), SqlTypeFacets("nvarchar", true, 8000)]
        public string data_source
        {
            get;
            set;
        }

        [SqlColumn("location", 6), SqlTypeFacets("nvarchar", true, 8000)]
        public string location
        {
            get;
            set;
        }

        [SqlColumn("provider_string", 7), SqlTypeFacets("nvarchar", true, 8000)]
        public string provider_string
        {
            get;
            set;
        }

        [SqlColumn("catalog", 8), SqlTypeFacets("sysname", true)]
        public string catalog
        {
            get;
            set;
        }

        [SqlColumn("connect_timeout", 9), SqlTypeFacets("int", true)]
        public int? connect_timeout
        {
            get;
            set;
        }

        [SqlColumn("query_timeout", 10), SqlTypeFacets("int", true)]
        public int? query_timeout
        {
            get;
            set;
        }

        [SqlColumn("is_linked", 11), SqlTypeFacets("bit", false)]
        public bool is_linked
        {
            get;
            set;
        }

        [SqlColumn("is_remote_login_enabled", 12), SqlTypeFacets("bit", false)]
        public bool is_remote_login_enabled
        {
            get;
            set;
        }

        [SqlColumn("is_rpc_out_enabled", 13), SqlTypeFacets("bit", false)]
        public bool is_rpc_out_enabled
        {
            get;
            set;
        }

        [SqlColumn("is_data_access_enabled", 14), SqlTypeFacets("bit", false)]
        public bool is_data_access_enabled
        {
            get;
            set;
        }

        [SqlColumn("is_collation_compatible", 15), SqlTypeFacets("bit", false)]
        public bool is_collation_compatible
        {
            get;
            set;
        }

        [SqlColumn("uses_remote_collation", 16), SqlTypeFacets("bit", false)]
        public bool uses_remote_collation
        {
            get;
            set;
        }

        [SqlColumn("collation_name", 17), SqlTypeFacets("sysname", true)]
        public string collation_name
        {
            get;
            set;
        }

        [SqlColumn("lazy_schema_validation", 18), SqlTypeFacets("bit", false)]
        public bool lazy_schema_validation
        {
            get;
            set;
        }

        [SqlColumn("is_system", 19), SqlTypeFacets("bit", false)]
        public bool is_system
        {
            get;
            set;
        }

        [SqlColumn("is_publisher", 20), SqlTypeFacets("bit", false)]
        public bool is_publisher
        {
            get;
            set;
        }

        [SqlColumn("is_subscriber", 21), SqlTypeFacets("bit", true)]
        public bool? is_subscriber
        {
            get;
            set;
        }

        [SqlColumn("is_distributor", 22), SqlTypeFacets("bit", true)]
        public bool? is_distributor
        {
            get;
            set;
        }

        [SqlColumn("is_nonsql_subscriber", 23), SqlTypeFacets("bit", true)]
        public bool? is_nonsql_subscriber
        {
            get;
            set;
        }

        [SqlColumn("is_remote_proc_transaction_promotion_enabled", 24), SqlTypeFacets("bit", true)]
        public bool? is_remote_proc_transaction_promotion_enabled
        {
            get;
            set;
        }

        [SqlColumn("modify_date", 25), SqlTypeFacets("datetime", false)]
        public DateTime modify_date
        {
            get;
            set;
        }

        public servers_record()
        {
        }

        public servers_record(object[] items)
        {
            systems_server_name = (string)items[0];
            server_id = (int)items[1];
            name = (string)items[2];
            product = (string)items[3];
            provider = (string)items[4];
            data_source = (string)items[5];
            location = (string)items[6];
            provider_string = (string)items[7];
            catalog = (string)items[8];
            connect_timeout = (int?)items[9];
            query_timeout = (int?)items[10];
            is_linked = (bool)items[11];
            is_remote_login_enabled = (bool)items[12];
            is_rpc_out_enabled = (bool)items[13];
            is_data_access_enabled = (bool)items[14];
            is_collation_compatible = (bool)items[15];
            uses_remote_collation = (bool)items[16];
            collation_name = (string)items[17];
            lazy_schema_validation = (bool)items[18];
            is_system = (bool)items[19];
            is_publisher = (bool)items[20];
            is_subscriber = (bool?)items[21];
            is_distributor = (bool?)items[22];
            is_nonsql_subscriber = (bool?)items[23];
            is_remote_proc_transaction_promotion_enabled = (bool?)items[24];
            modify_date = (DateTime)items[25];
        }

        public servers_record(string systems_server_name, int server_id, string name, string product, string provider, string data_source, string location, string provider_string, string catalog, int? connect_timeout, int? query_timeout, bool is_linked, bool is_remote_login_enabled, bool is_rpc_out_enabled, bool is_data_access_enabled, bool is_collation_compatible, bool uses_remote_collation, string collation_name, bool lazy_schema_validation, bool is_system, bool is_publisher, bool? is_subscriber, bool? is_distributor, bool? is_nonsql_subscriber, bool? is_remote_proc_transaction_promotion_enabled, DateTime modify_date)
        {
            this.systems_server_name = systems_server_name;
            this.server_id = server_id;
            this.name = name;
            this.product = product;
            this.provider = provider;
            this.data_source = data_source;
            this.location = location;
            this.provider_string = provider_string;
            this.catalog = catalog;
            this.connect_timeout = connect_timeout;
            this.query_timeout = query_timeout;
            this.is_linked = is_linked;
            this.is_remote_login_enabled = is_remote_login_enabled;
            this.is_rpc_out_enabled = is_rpc_out_enabled;
            this.is_data_access_enabled = is_data_access_enabled;
            this.is_collation_compatible = is_collation_compatible;
            this.uses_remote_collation = uses_remote_collation;
            this.collation_name = collation_name;
            this.lazy_schema_validation = lazy_schema_validation;
            this.is_system = is_system;
            this.is_publisher = is_publisher;
            this.is_subscriber = is_subscriber;
            this.is_distributor = is_distributor;
            this.is_nonsql_subscriber = is_nonsql_subscriber;
            this.is_remote_proc_transaction_promotion_enabled = is_remote_proc_transaction_promotion_enabled;
            this.modify_date = modify_date;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_server_name, server_id, name, product, provider, data_source, location, provider_string, catalog, connect_timeout, query_timeout, is_linked, is_remote_login_enabled, is_rpc_out_enabled, is_data_access_enabled, is_collation_compatible, uses_remote_collation, collation_name, lazy_schema_validation, is_system, is_publisher, is_subscriber, is_distributor, is_nonsql_subscriber, is_remote_proc_transaction_promotion_enabled, modify_date };
        }

        public override void SetItemArray(object[] items)
        {
            systems_server_name = (string)items[0];
            server_id = (int)items[1];
            name = (string)items[2];
            product = (string)items[3];
            provider = (string)items[4];
            data_source = (string)items[5];
            location = (string)items[6];
            provider_string = (string)items[7];
            catalog = (string)items[8];
            connect_timeout = (int?)items[9];
            query_timeout = (int?)items[10];
            is_linked = (bool)items[11];
            is_remote_login_enabled = (bool)items[12];
            is_rpc_out_enabled = (bool)items[13];
            is_data_access_enabled = (bool)items[14];
            is_collation_compatible = (bool)items[15];
            uses_remote_collation = (bool)items[16];
            collation_name = (string)items[17];
            lazy_schema_validation = (bool)items[18];
            is_system = (bool)items[19];
            is_publisher = (bool)items[20];
            is_subscriber = (bool?)items[21];
            is_distributor = (bool?)items[22];
            is_nonsql_subscriber = (bool?)items[23];
            is_remote_proc_transaction_promotion_enabled = (bool?)items[24];
            modify_date = (DateTime)items[25];
        }
    }

    [SqlRecord("systems", "host_servers_record")]
    public partial class host_servers_record : SqlTableTypeProxy<host_servers_record>, Ihost_servers_record
    {
        [SqlColumn("systems_server_name", 0), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        public host_servers_record()
        {
        }

        public host_servers_record(object[] items)
        {
            systems_server_name = (string)items[0];
        }

        public host_servers_record(string systems_server_name)
        {
            this.systems_server_name = systems_server_name;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_server_name };
        }

        public override void SetItemArray(object[] items)
        {
            systems_server_name = (string)items[0];
        }
    }

    [SqlRecord("systems", "databases_record")]
    public partial class databases_record : SqlTableTypeProxy<databases_record>, Idatabases_record
    {
        [SqlColumn("systems_server_name", 0), SqlTypeFacets("sysname", false)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlColumn("name", 1), SqlTypeFacets("sysname", false)]
        public string name
        {
            get;
            set;
        }

        [SqlColumn("database_id", 2), SqlTypeFacets("int", false)]
        public int database_id
        {
            get;
            set;
        }

        [SqlColumn("source_database_id", 3), SqlTypeFacets("int", true)]
        public int? source_database_id
        {
            get;
            set;
        }

        [SqlColumn("owner_sid", 4), SqlTypeFacets("varbinary", true, 85)]
        public Byte[] owner_sid
        {
            get;
            set;
        }

        [SqlColumn("create_date", 5), SqlTypeFacets("datetime", false)]
        public DateTime create_date
        {
            get;
            set;
        }

        [SqlColumn("compatibility_level", 6), SqlTypeFacets("tinyint", false)]
        public byte compatibility_level
        {
            get;
            set;
        }

        [SqlColumn("collation_name", 7), SqlTypeFacets("nvarchar", true, 256)]
        public string collation_name
        {
            get;
            set;
        }

        [SqlColumn("user_access", 8), SqlTypeFacets("tinyint", true)]
        public byte? user_access
        {
            get;
            set;
        }

        [SqlColumn("user_access_desc", 9), SqlTypeFacets("nvarchar", true, 120)]
        public string user_access_desc
        {
            get;
            set;
        }

        [SqlColumn("is_read_only", 10), SqlTypeFacets("bit", true)]
        public bool? is_read_only
        {
            get;
            set;
        }

        [SqlColumn("is_auto_close_on", 11), SqlTypeFacets("bit", false)]
        public bool is_auto_close_on
        {
            get;
            set;
        }

        [SqlColumn("is_auto_shrink_on", 12), SqlTypeFacets("bit", true)]
        public bool? is_auto_shrink_on
        {
            get;
            set;
        }

        [SqlColumn("state", 13), SqlTypeFacets("tinyint", true)]
        public byte? state
        {
            get;
            set;
        }

        [SqlColumn("state_desc", 14), SqlTypeFacets("nvarchar", true, 120)]
        public string state_desc
        {
            get;
            set;
        }

        [SqlColumn("is_in_standby", 15), SqlTypeFacets("bit", true)]
        public bool? is_in_standby
        {
            get;
            set;
        }

        [SqlColumn("is_cleanly_shutdown", 16), SqlTypeFacets("bit", true)]
        public bool? is_cleanly_shutdown
        {
            get;
            set;
        }

        [SqlColumn("is_supplemental_logging_enabled", 17), SqlTypeFacets("bit", true)]
        public bool? is_supplemental_logging_enabled
        {
            get;
            set;
        }

        [SqlColumn("snapshot_isolation_state", 18), SqlTypeFacets("tinyint", true)]
        public byte? snapshot_isolation_state
        {
            get;
            set;
        }

        [SqlColumn("snapshot_isolation_state_desc", 19), SqlTypeFacets("nvarchar", true, 120)]
        public string snapshot_isolation_state_desc
        {
            get;
            set;
        }

        [SqlColumn("is_read_committed_snapshot_on", 20), SqlTypeFacets("bit", true)]
        public bool? is_read_committed_snapshot_on
        {
            get;
            set;
        }

        [SqlColumn("recovery_model", 21), SqlTypeFacets("tinyint", true)]
        public byte? recovery_model
        {
            get;
            set;
        }

        [SqlColumn("recovery_model_desc", 22), SqlTypeFacets("nvarchar", true, 120)]
        public string recovery_model_desc
        {
            get;
            set;
        }

        [SqlColumn("page_verify_option", 23), SqlTypeFacets("tinyint", true)]
        public byte? page_verify_option
        {
            get;
            set;
        }

        [SqlColumn("page_verify_option_desc", 24), SqlTypeFacets("nvarchar", true, 120)]
        public string page_verify_option_desc
        {
            get;
            set;
        }

        [SqlColumn("is_auto_create_stats_on", 25), SqlTypeFacets("bit", true)]
        public bool? is_auto_create_stats_on
        {
            get;
            set;
        }

        [SqlColumn("is_auto_update_stats_on", 26), SqlTypeFacets("bit", true)]
        public bool? is_auto_update_stats_on
        {
            get;
            set;
        }

        [SqlColumn("is_auto_update_stats_async_on", 27), SqlTypeFacets("bit", true)]
        public bool? is_auto_update_stats_async_on
        {
            get;
            set;
        }

        [SqlColumn("is_ansi_null_default_on", 28), SqlTypeFacets("bit", true)]
        public bool? is_ansi_null_default_on
        {
            get;
            set;
        }

        [SqlColumn("is_ansi_nulls_on", 29), SqlTypeFacets("bit", true)]
        public bool? is_ansi_nulls_on
        {
            get;
            set;
        }

        [SqlColumn("is_ansi_padding_on", 30), SqlTypeFacets("bit", true)]
        public bool? is_ansi_padding_on
        {
            get;
            set;
        }

        [SqlColumn("is_ansi_warnings_on", 31), SqlTypeFacets("bit", true)]
        public bool? is_ansi_warnings_on
        {
            get;
            set;
        }

        [SqlColumn("is_arithabort_on", 32), SqlTypeFacets("bit", true)]
        public bool? is_arithabort_on
        {
            get;
            set;
        }

        [SqlColumn("is_concat_null_yields_null_on", 33), SqlTypeFacets("bit", true)]
        public bool? is_concat_null_yields_null_on
        {
            get;
            set;
        }

        [SqlColumn("is_numeric_roundabort_on", 34), SqlTypeFacets("bit", true)]
        public bool? is_numeric_roundabort_on
        {
            get;
            set;
        }

        [SqlColumn("is_quoted_identifier_on", 35), SqlTypeFacets("bit", true)]
        public bool? is_quoted_identifier_on
        {
            get;
            set;
        }

        [SqlColumn("is_recursive_triggers_on", 36), SqlTypeFacets("bit", true)]
        public bool? is_recursive_triggers_on
        {
            get;
            set;
        }

        [SqlColumn("is_cursor_close_on_commit_on", 37), SqlTypeFacets("bit", true)]
        public bool? is_cursor_close_on_commit_on
        {
            get;
            set;
        }

        [SqlColumn("is_local_cursor_default", 38), SqlTypeFacets("bit", true)]
        public bool? is_local_cursor_default
        {
            get;
            set;
        }

        [SqlColumn("is_fulltext_enabled", 39), SqlTypeFacets("bit", true)]
        public bool? is_fulltext_enabled
        {
            get;
            set;
        }

        [SqlColumn("is_trustworthy_on", 40), SqlTypeFacets("bit", true)]
        public bool? is_trustworthy_on
        {
            get;
            set;
        }

        [SqlColumn("is_db_chaining_on", 41), SqlTypeFacets("bit", true)]
        public bool? is_db_chaining_on
        {
            get;
            set;
        }

        [SqlColumn("is_parameterization_forced", 42), SqlTypeFacets("bit", true)]
        public bool? is_parameterization_forced
        {
            get;
            set;
        }

        [SqlColumn("is_master_key_encrypted_by_server", 43), SqlTypeFacets("bit", false)]
        public bool is_master_key_encrypted_by_server
        {
            get;
            set;
        }

        [SqlColumn("is_published", 44), SqlTypeFacets("bit", false)]
        public bool is_published
        {
            get;
            set;
        }

        [SqlColumn("is_subscribed", 45), SqlTypeFacets("bit", false)]
        public bool is_subscribed
        {
            get;
            set;
        }

        [SqlColumn("is_merge_published", 46), SqlTypeFacets("bit", false)]
        public bool is_merge_published
        {
            get;
            set;
        }

        [SqlColumn("is_distributor", 47), SqlTypeFacets("bit", false)]
        public bool is_distributor
        {
            get;
            set;
        }

        [SqlColumn("is_sync_with_backup", 48), SqlTypeFacets("bit", false)]
        public bool is_sync_with_backup
        {
            get;
            set;
        }

        [SqlColumn("service_broker_guid", 49), SqlTypeFacets("uniqueidentifier", false)]
        public Guid service_broker_guid
        {
            get;
            set;
        }

        [SqlColumn("is_broker_enabled", 50), SqlTypeFacets("bit", false)]
        public bool is_broker_enabled
        {
            get;
            set;
        }

        [SqlColumn("log_reuse_wait", 51), SqlTypeFacets("tinyint", true)]
        public byte? log_reuse_wait
        {
            get;
            set;
        }

        [SqlColumn("log_reuse_wait_desc", 52), SqlTypeFacets("nvarchar", true, 120)]
        public string log_reuse_wait_desc
        {
            get;
            set;
        }

        [SqlColumn("is_date_correlation_on", 53), SqlTypeFacets("bit", false)]
        public bool is_date_correlation_on
        {
            get;
            set;
        }

        [SqlColumn("is_cdc_enabled", 54), SqlTypeFacets("bit", false)]
        public bool is_cdc_enabled
        {
            get;
            set;
        }

        [SqlColumn("is_encrypted", 55), SqlTypeFacets("bit", true)]
        public bool? is_encrypted
        {
            get;
            set;
        }

        [SqlColumn("is_honor_broker_priority_on", 56), SqlTypeFacets("bit", true)]
        public bool? is_honor_broker_priority_on
        {
            get;
            set;
        }

        [SqlColumn("replica_id", 57), SqlTypeFacets("uniqueidentifier", true)]
        public Guid? replica_id
        {
            get;
            set;
        }

        [SqlColumn("group_database_id", 58), SqlTypeFacets("uniqueidentifier", true)]
        public Guid? group_database_id
        {
            get;
            set;
        }

        [SqlColumn("default_language_lcid", 59), SqlTypeFacets("smallint", true)]
        public short? default_language_lcid
        {
            get;
            set;
        }

        [SqlColumn("default_language_name", 60), SqlTypeFacets("nvarchar", true, 256)]
        public string default_language_name
        {
            get;
            set;
        }

        [SqlColumn("default_fulltext_language_lcid", 61), SqlTypeFacets("int", true)]
        public int? default_fulltext_language_lcid
        {
            get;
            set;
        }

        [SqlColumn("default_fulltext_language_name", 62), SqlTypeFacets("nvarchar", true, 256)]
        public string default_fulltext_language_name
        {
            get;
            set;
        }

        [SqlColumn("is_nested_triggers_on", 63), SqlTypeFacets("bit", true)]
        public bool? is_nested_triggers_on
        {
            get;
            set;
        }

        [SqlColumn("is_transform_noise_words_on", 64), SqlTypeFacets("bit", true)]
        public bool? is_transform_noise_words_on
        {
            get;
            set;
        }

        [SqlColumn("two_digit_year_cutoff", 65), SqlTypeFacets("smallint", true)]
        public short? two_digit_year_cutoff
        {
            get;
            set;
        }

        [SqlColumn("containment", 66), SqlTypeFacets("tinyint", true)]
        public byte? containment
        {
            get;
            set;
        }

        [SqlColumn("containment_desc", 67), SqlTypeFacets("nvarchar", true, 120)]
        public string containment_desc
        {
            get;
            set;
        }

        [SqlColumn("target_recovery_time_in_seconds", 68), SqlTypeFacets("int", true)]
        public int? target_recovery_time_in_seconds
        {
            get;
            set;
        }

        public databases_record()
        {
        }

        public databases_record(object[] items)
        {
            systems_server_name = (string)items[0];
            name = (string)items[1];
            database_id = (int)items[2];
            source_database_id = (int?)items[3];
            owner_sid = (Byte[])items[4];
            create_date = (DateTime)items[5];
            compatibility_level = (byte)items[6];
            collation_name = (string)items[7];
            user_access = (byte?)items[8];
            user_access_desc = (string)items[9];
            is_read_only = (bool?)items[10];
            is_auto_close_on = (bool)items[11];
            is_auto_shrink_on = (bool?)items[12];
            state = (byte?)items[13];
            state_desc = (string)items[14];
            is_in_standby = (bool?)items[15];
            is_cleanly_shutdown = (bool?)items[16];
            is_supplemental_logging_enabled = (bool?)items[17];
            snapshot_isolation_state = (byte?)items[18];
            snapshot_isolation_state_desc = (string)items[19];
            is_read_committed_snapshot_on = (bool?)items[20];
            recovery_model = (byte?)items[21];
            recovery_model_desc = (string)items[22];
            page_verify_option = (byte?)items[23];
            page_verify_option_desc = (string)items[24];
            is_auto_create_stats_on = (bool?)items[25];
            is_auto_update_stats_on = (bool?)items[26];
            is_auto_update_stats_async_on = (bool?)items[27];
            is_ansi_null_default_on = (bool?)items[28];
            is_ansi_nulls_on = (bool?)items[29];
            is_ansi_padding_on = (bool?)items[30];
            is_ansi_warnings_on = (bool?)items[31];
            is_arithabort_on = (bool?)items[32];
            is_concat_null_yields_null_on = (bool?)items[33];
            is_numeric_roundabort_on = (bool?)items[34];
            is_quoted_identifier_on = (bool?)items[35];
            is_recursive_triggers_on = (bool?)items[36];
            is_cursor_close_on_commit_on = (bool?)items[37];
            is_local_cursor_default = (bool?)items[38];
            is_fulltext_enabled = (bool?)items[39];
            is_trustworthy_on = (bool?)items[40];
            is_db_chaining_on = (bool?)items[41];
            is_parameterization_forced = (bool?)items[42];
            is_master_key_encrypted_by_server = (bool)items[43];
            is_published = (bool)items[44];
            is_subscribed = (bool)items[45];
            is_merge_published = (bool)items[46];
            is_distributor = (bool)items[47];
            is_sync_with_backup = (bool)items[48];
            service_broker_guid = (Guid)items[49];
            is_broker_enabled = (bool)items[50];
            log_reuse_wait = (byte?)items[51];
            log_reuse_wait_desc = (string)items[52];
            is_date_correlation_on = (bool)items[53];
            is_cdc_enabled = (bool)items[54];
            is_encrypted = (bool?)items[55];
            is_honor_broker_priority_on = (bool?)items[56];
            replica_id = (Guid?)items[57];
            group_database_id = (Guid?)items[58];
            default_language_lcid = (short?)items[59];
            default_language_name = (string)items[60];
            default_fulltext_language_lcid = (int?)items[61];
            default_fulltext_language_name = (string)items[62];
            is_nested_triggers_on = (bool?)items[63];
            is_transform_noise_words_on = (bool?)items[64];
            two_digit_year_cutoff = (short?)items[65];
            containment = (byte?)items[66];
            containment_desc = (string)items[67];
            target_recovery_time_in_seconds = (int?)items[68];
        }

        public databases_record(string systems_server_name, string name, int database_id, int? source_database_id, Byte[] owner_sid, DateTime create_date, byte compatibility_level, string collation_name, byte? user_access, string user_access_desc, bool? is_read_only, bool is_auto_close_on, bool? is_auto_shrink_on, byte? state, string state_desc, bool? is_in_standby, bool? is_cleanly_shutdown, bool? is_supplemental_logging_enabled, byte? snapshot_isolation_state, string snapshot_isolation_state_desc, bool? is_read_committed_snapshot_on, byte? recovery_model, string recovery_model_desc, byte? page_verify_option, string page_verify_option_desc, bool? is_auto_create_stats_on, bool? is_auto_update_stats_on, bool? is_auto_update_stats_async_on, bool? is_ansi_null_default_on, bool? is_ansi_nulls_on, bool? is_ansi_padding_on, bool? is_ansi_warnings_on, bool? is_arithabort_on, bool? is_concat_null_yields_null_on, bool? is_numeric_roundabort_on, bool? is_quoted_identifier_on, bool? is_recursive_triggers_on, bool? is_cursor_close_on_commit_on, bool? is_local_cursor_default, bool? is_fulltext_enabled, bool? is_trustworthy_on, bool? is_db_chaining_on, bool? is_parameterization_forced, bool is_master_key_encrypted_by_server, bool is_published, bool is_subscribed, bool is_merge_published, bool is_distributor, bool is_sync_with_backup, Guid service_broker_guid, bool is_broker_enabled, byte? log_reuse_wait, string log_reuse_wait_desc, bool is_date_correlation_on, bool is_cdc_enabled, bool? is_encrypted, bool? is_honor_broker_priority_on, Guid? replica_id, Guid? group_database_id, short? default_language_lcid, string default_language_name, int? default_fulltext_language_lcid, string default_fulltext_language_name, bool? is_nested_triggers_on, bool? is_transform_noise_words_on, short? two_digit_year_cutoff, byte? containment, string containment_desc, int? target_recovery_time_in_seconds)
        {
            this.systems_server_name = systems_server_name;
            this.name = name;
            this.database_id = database_id;
            this.source_database_id = source_database_id;
            this.owner_sid = owner_sid;
            this.create_date = create_date;
            this.compatibility_level = compatibility_level;
            this.collation_name = collation_name;
            this.user_access = user_access;
            this.user_access_desc = user_access_desc;
            this.is_read_only = is_read_only;
            this.is_auto_close_on = is_auto_close_on;
            this.is_auto_shrink_on = is_auto_shrink_on;
            this.state = state;
            this.state_desc = state_desc;
            this.is_in_standby = is_in_standby;
            this.is_cleanly_shutdown = is_cleanly_shutdown;
            this.is_supplemental_logging_enabled = is_supplemental_logging_enabled;
            this.snapshot_isolation_state = snapshot_isolation_state;
            this.snapshot_isolation_state_desc = snapshot_isolation_state_desc;
            this.is_read_committed_snapshot_on = is_read_committed_snapshot_on;
            this.recovery_model = recovery_model;
            this.recovery_model_desc = recovery_model_desc;
            this.page_verify_option = page_verify_option;
            this.page_verify_option_desc = page_verify_option_desc;
            this.is_auto_create_stats_on = is_auto_create_stats_on;
            this.is_auto_update_stats_on = is_auto_update_stats_on;
            this.is_auto_update_stats_async_on = is_auto_update_stats_async_on;
            this.is_ansi_null_default_on = is_ansi_null_default_on;
            this.is_ansi_nulls_on = is_ansi_nulls_on;
            this.is_ansi_padding_on = is_ansi_padding_on;
            this.is_ansi_warnings_on = is_ansi_warnings_on;
            this.is_arithabort_on = is_arithabort_on;
            this.is_concat_null_yields_null_on = is_concat_null_yields_null_on;
            this.is_numeric_roundabort_on = is_numeric_roundabort_on;
            this.is_quoted_identifier_on = is_quoted_identifier_on;
            this.is_recursive_triggers_on = is_recursive_triggers_on;
            this.is_cursor_close_on_commit_on = is_cursor_close_on_commit_on;
            this.is_local_cursor_default = is_local_cursor_default;
            this.is_fulltext_enabled = is_fulltext_enabled;
            this.is_trustworthy_on = is_trustworthy_on;
            this.is_db_chaining_on = is_db_chaining_on;
            this.is_parameterization_forced = is_parameterization_forced;
            this.is_master_key_encrypted_by_server = is_master_key_encrypted_by_server;
            this.is_published = is_published;
            this.is_subscribed = is_subscribed;
            this.is_merge_published = is_merge_published;
            this.is_distributor = is_distributor;
            this.is_sync_with_backup = is_sync_with_backup;
            this.service_broker_guid = service_broker_guid;
            this.is_broker_enabled = is_broker_enabled;
            this.log_reuse_wait = log_reuse_wait;
            this.log_reuse_wait_desc = log_reuse_wait_desc;
            this.is_date_correlation_on = is_date_correlation_on;
            this.is_cdc_enabled = is_cdc_enabled;
            this.is_encrypted = is_encrypted;
            this.is_honor_broker_priority_on = is_honor_broker_priority_on;
            this.replica_id = replica_id;
            this.group_database_id = group_database_id;
            this.default_language_lcid = default_language_lcid;
            this.default_language_name = default_language_name;
            this.default_fulltext_language_lcid = default_fulltext_language_lcid;
            this.default_fulltext_language_name = default_fulltext_language_name;
            this.is_nested_triggers_on = is_nested_triggers_on;
            this.is_transform_noise_words_on = is_transform_noise_words_on;
            this.two_digit_year_cutoff = two_digit_year_cutoff;
            this.containment = containment;
            this.containment_desc = containment_desc;
            this.target_recovery_time_in_seconds = target_recovery_time_in_seconds;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_server_name, name, database_id, source_database_id, owner_sid, create_date, compatibility_level, collation_name, user_access, user_access_desc, is_read_only, is_auto_close_on, is_auto_shrink_on, state, state_desc, is_in_standby, is_cleanly_shutdown, is_supplemental_logging_enabled, snapshot_isolation_state, snapshot_isolation_state_desc, is_read_committed_snapshot_on, recovery_model, recovery_model_desc, page_verify_option, page_verify_option_desc, is_auto_create_stats_on, is_auto_update_stats_on, is_auto_update_stats_async_on, is_ansi_null_default_on, is_ansi_nulls_on, is_ansi_padding_on, is_ansi_warnings_on, is_arithabort_on, is_concat_null_yields_null_on, is_numeric_roundabort_on, is_quoted_identifier_on, is_recursive_triggers_on, is_cursor_close_on_commit_on, is_local_cursor_default, is_fulltext_enabled, is_trustworthy_on, is_db_chaining_on, is_parameterization_forced, is_master_key_encrypted_by_server, is_published, is_subscribed, is_merge_published, is_distributor, is_sync_with_backup, service_broker_guid, is_broker_enabled, log_reuse_wait, log_reuse_wait_desc, is_date_correlation_on, is_cdc_enabled, is_encrypted, is_honor_broker_priority_on, replica_id, group_database_id, default_language_lcid, default_language_name, default_fulltext_language_lcid, default_fulltext_language_name, is_nested_triggers_on, is_transform_noise_words_on, two_digit_year_cutoff, containment, containment_desc, target_recovery_time_in_seconds };
        }

        public override void SetItemArray(object[] items)
        {
            systems_server_name = (string)items[0];
            name = (string)items[1];
            database_id = (int)items[2];
            source_database_id = (int?)items[3];
            owner_sid = (Byte[])items[4];
            create_date = (DateTime)items[5];
            compatibility_level = (byte)items[6];
            collation_name = (string)items[7];
            user_access = (byte?)items[8];
            user_access_desc = (string)items[9];
            is_read_only = (bool?)items[10];
            is_auto_close_on = (bool)items[11];
            is_auto_shrink_on = (bool?)items[12];
            state = (byte?)items[13];
            state_desc = (string)items[14];
            is_in_standby = (bool?)items[15];
            is_cleanly_shutdown = (bool?)items[16];
            is_supplemental_logging_enabled = (bool?)items[17];
            snapshot_isolation_state = (byte?)items[18];
            snapshot_isolation_state_desc = (string)items[19];
            is_read_committed_snapshot_on = (bool?)items[20];
            recovery_model = (byte?)items[21];
            recovery_model_desc = (string)items[22];
            page_verify_option = (byte?)items[23];
            page_verify_option_desc = (string)items[24];
            is_auto_create_stats_on = (bool?)items[25];
            is_auto_update_stats_on = (bool?)items[26];
            is_auto_update_stats_async_on = (bool?)items[27];
            is_ansi_null_default_on = (bool?)items[28];
            is_ansi_nulls_on = (bool?)items[29];
            is_ansi_padding_on = (bool?)items[30];
            is_ansi_warnings_on = (bool?)items[31];
            is_arithabort_on = (bool?)items[32];
            is_concat_null_yields_null_on = (bool?)items[33];
            is_numeric_roundabort_on = (bool?)items[34];
            is_quoted_identifier_on = (bool?)items[35];
            is_recursive_triggers_on = (bool?)items[36];
            is_cursor_close_on_commit_on = (bool?)items[37];
            is_local_cursor_default = (bool?)items[38];
            is_fulltext_enabled = (bool?)items[39];
            is_trustworthy_on = (bool?)items[40];
            is_db_chaining_on = (bool?)items[41];
            is_parameterization_forced = (bool?)items[42];
            is_master_key_encrypted_by_server = (bool)items[43];
            is_published = (bool)items[44];
            is_subscribed = (bool)items[45];
            is_merge_published = (bool)items[46];
            is_distributor = (bool)items[47];
            is_sync_with_backup = (bool)items[48];
            service_broker_guid = (Guid)items[49];
            is_broker_enabled = (bool)items[50];
            log_reuse_wait = (byte?)items[51];
            log_reuse_wait_desc = (string)items[52];
            is_date_correlation_on = (bool)items[53];
            is_cdc_enabled = (bool)items[54];
            is_encrypted = (bool?)items[55];
            is_honor_broker_priority_on = (bool?)items[56];
            replica_id = (Guid?)items[57];
            group_database_id = (Guid?)items[58];
            default_language_lcid = (short?)items[59];
            default_language_name = (string)items[60];
            default_fulltext_language_lcid = (int?)items[61];
            default_fulltext_language_name = (string)items[62];
            is_nested_triggers_on = (bool?)items[63];
            is_transform_noise_words_on = (bool?)items[64];
            two_digit_year_cutoff = (short?)items[65];
            containment = (byte?)items[66];
            containment_desc = (string)items[67];
            target_recovery_time_in_seconds = (int?)items[68];
        }
    }

    [SqlProcedure("systems", "p_databases_delete")]
    public partial class p_databases_delete : SqlProcedureProxy
    {
        [SqlParameter("@systems_server_name", 0, false, false), SqlTypeFacets("sysname", true)]
        public string systems_server_name
        {
            get;
            set;
        }

        [SqlParameter("@database_name", 1, false, false), SqlTypeFacets("sysname", true)]
        public string database_name
        {
            get;
            set;
        }

        public p_databases_delete()
        {
        }

        public p_databases_delete(object[] items)
        {
            systems_server_name = (string)items[0];
            database_name = (string)items[1];
        }

        public p_databases_delete(string systems_server_name, string database_name)
        {
            this.systems_server_name = systems_server_name;
            this.database_name = database_name;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_server_name, database_name };
        }

        public override void SetItemArray(object[] items)
        {
            systems_server_name = (string)items[0];
            database_name = (string)items[1];
        }
    }

    [SqlProcedure("systems", "p_databases_merge")]
    public partial class p_databases_merge : SqlProcedureProxy
    {
        [SqlParameter("@Records", 0, true, false), SqlTypeFacets("[systems].[databases_record]", true)]
        public IEnumerable<databases_record> Records
        {
            get;
            set;
        }

        public p_databases_merge()
        {
        }

        public p_databases_merge(object[] items)
        {
            Records = (IEnumerable<databases_record>)items[0];
        }

        public p_databases_merge(IEnumerable<databases_record> Records)
        {
            this.Records = Records;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Records };
        }

        public override void SetItemArray(object[] items)
        {
            Records = (IEnumerable<databases_record>)items[0];
        }
    }

    [SqlProcedure("systems", "p_host_server_delete")]
    public partial class p_host_server_delete : SqlProcedureProxy
    {
        [SqlParameter("@systems_server_name", 0, false, false), SqlTypeFacets("sysname", true)]
        public string systems_server_name
        {
            get;
            set;
        }

        public p_host_server_delete()
        {
        }

        public p_host_server_delete(object[] items)
        {
            systems_server_name = (string)items[0];
        }

        public p_host_server_delete(string systems_server_name)
        {
            this.systems_server_name = systems_server_name;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_server_name };
        }

        public override void SetItemArray(object[] items)
        {
            systems_server_name = (string)items[0];
        }
    }

    [SqlProcedure("systems", "p_host_servers_merge")]
    public partial class p_host_servers_merge : SqlProcedureProxy
    {
        [SqlParameter("@Records", 0, true, false), SqlTypeFacets("[systems].[host_servers_record]", true)]
        public IEnumerable<host_servers_record> Records
        {
            get;
            set;
        }

        public p_host_servers_merge()
        {
        }

        public p_host_servers_merge(object[] items)
        {
            Records = (IEnumerable<host_servers_record>)items[0];
        }

        public p_host_servers_merge(IEnumerable<host_servers_record> Records)
        {
            this.Records = Records;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Records };
        }

        public override void SetItemArray(object[] items)
        {
            Records = (IEnumerable<host_servers_record>)items[0];
        }
    }

    [SqlProcedure("systems", "p_host_server_save")]
    public partial class p_host_server_save : SqlProcedureProxy
    {
        [SqlParameter("@systems_server_name", 0, false, false), SqlTypeFacets("sysname", true)]
        public string systems_server_name
        {
            get;
            set;
        }

        public p_host_server_save()
        {
        }

        public p_host_server_save(object[] items)
        {
            systems_server_name = (string)items[0];
        }

        public p_host_server_save(string systems_server_name)
        {
            this.systems_server_name = systems_server_name;
        }

        public override object[] GetItemArray()
        {
            return new object[] { systems_server_name };
        }

        public override void SetItemArray(object[] items)
        {
            systems_server_name = (string)items[0];
        }
    }

    [SqlProcedure("systems", "p_servers_merge")]
    public partial class p_servers_merge : SqlProcedureProxy
    {
        [SqlParameter("@Records", 0, true, false), SqlTypeFacets("[systems].[servers_record]", true)]
        public IEnumerable<servers_record> Records
        {
            get;
            set;
        }

        public p_servers_merge()
        {
        }

        public p_servers_merge(object[] items)
        {
            Records = (IEnumerable<servers_record>)items[0];
        }

        public p_servers_merge(IEnumerable<servers_record> Records)
        {
            this.Records = Records;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Records };
        }

        public override void SetItemArray(object[] items)
        {
            Records = (IEnumerable<servers_record>)items[0];
        }
    }

    public sealed class systemsProcedureNames
    {
        public readonly static SqlProcedureName p_databases_delete = "[systems].[p_databases_delete]";
        public readonly static SqlProcedureName p_databases_merge = "[systems].[p_databases_merge]";
        public readonly static SqlProcedureName p_host_server_delete = "[systems].[p_host_server_delete]";
        public readonly static SqlProcedureName p_host_server_save = "[systems].[p_host_server_save]";
        public readonly static SqlProcedureName p_host_servers_merge = "[systems].[p_host_servers_merge]";
        public readonly static SqlProcedureName p_servers_merge = "[systems].[p_servers_merge]";
    }
}
// Emission concluded at 4/13/2018 12:30:16 PM
