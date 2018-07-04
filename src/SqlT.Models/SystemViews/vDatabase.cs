//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using SqlT.Core;

    public class vDatabase : vSystemElement, IDatabase
    {

        static IReadOnlyDictionary<string, IExtendedProperty> Index(IDatabase subject, IEnumerable<IExtendedProperty> properties)
            => properties.Where(x => x.major_id == 0 && x.minor_id == 0).ToDictionary(x => x.name);

        readonly IDatabase _database;

        public vDatabase(IDatabase database, IEnumerable<IExtendedProperty> properties)
            : base(database.name, Index(database, properties), database.is_user_defined)
        {
            this._database = database;
        }

        SqlDatabaseName DatabaseName
            => new SqlDatabaseName(_database.name);

        #region IDatabase

        public string collation_name 
            => _database.collation_name;

        public byte compatibility_level 
            => _database.compatibility_level;

        public byte? containment 
            => _database.containment;

        public string containment_desc 
            => _database.containment_desc;

        public DateTime create_date 
            => _database.create_date;

        public int database_id 
            => _database.database_id;

        public int? default_fulltext_language_lcid 
            => _database.default_fulltext_language_lcid;

        public string default_fulltext_language_name 
            => _database.default_fulltext_language_name;

        public short? default_language_lcid 
            => _database.default_language_lcid;

        public string default_language_name 
            => _database.default_language_name;

        public int? delayed_durability 
            => _database.delayed_durability;

        public string delayed_durability_desc 
            => _database.delayed_durability_desc;

        public Guid? group_database_id 
            => _database.group_database_id;

        public bool? is_ansi_nulls_on 
            => _database.is_ansi_nulls_on;

        public bool? is_ansi_null_default_on 
            => _database.is_ansi_null_default_on;

        public bool? is_ansi_padding_on 
            => _database.is_ansi_padding_on;

        public bool? is_ansi_warnings_on 
            => _database.is_ansi_warnings_on;

        public bool? is_arithabort_on 
            => _database.is_arithabort_on;

        public bool is_auto_close_on 
            => _database.is_auto_close_on;

        public bool? is_auto_create_stats_incremental_on 
            => _database.is_auto_create_stats_incremental_on;

        public bool? is_auto_create_stats_on 
            => _database.is_auto_create_stats_on;

        public bool? is_auto_shrink_on 
            => _database.is_auto_shrink_on;

        public bool? is_auto_update_stats_async_on 
            => _database.is_auto_update_stats_async_on;

        public bool? is_auto_update_stats_on 
            => _database.is_auto_update_stats_on;

        public bool is_broker_enabled 
            => _database.is_broker_enabled;

        public bool is_cdc_enabled => 
            _database.is_cdc_enabled;

        public bool? is_cleanly_shutdown 
            => _database.is_cleanly_shutdown;

        public bool? is_concat_null_yields_null_on 
            => _database.is_concat_null_yields_null_on;

        public bool? is_cursor_close_on_commit_on 
            => _database.is_cursor_close_on_commit_on;

        public bool is_date_correlation_on 
            => _database.is_date_correlation_on;

        public bool? is_db_chaining_on 
            => _database.is_db_chaining_on;

        public bool is_distributor 
            => _database.is_distributor;

        public bool? is_encrypted 
            => _database.is_encrypted;

        public bool? is_federation_member 
            => _database.is_federation_member;

        public bool? is_fulltext_enabled 
            => _database.is_fulltext_enabled;

        public bool? is_honor_broker_priority_on 
            => _database.is_honor_broker_priority_on;

        public bool? is_in_standby 
            => _database.is_in_standby;

        public bool? is_local_cursor_default 
            => _database.is_local_cursor_default;

        public bool is_master_key_encrypted_by_server 
            => _database.is_master_key_encrypted_by_server;

        public bool? is_memory_optimized_elevate_to_snapshot_on 
            => _database.is_memory_optimized_elevate_to_snapshot_on;

        public bool is_merge_published 
            => _database.is_merge_published;

        public bool? is_mixed_page_allocation_on 
            => _database.is_mixed_page_allocation_on;

        public bool? is_nested_triggers_on 
            => _database.is_nested_triggers_on;

        public bool? is_numeric_roundabort_on 
            => _database.is_numeric_roundabort_on;

        public bool? is_parameterization_forced 
            => _database.is_parameterization_forced;

        public bool is_published 
            => _database.is_published;

        public bool? is_query_store_on 
            => _database.is_query_store_on;

        public bool? is_quoted_identifier_on 
            => _database.is_quoted_identifier_on;

        public bool? is_read_committed_snapshot_on 
            => _database.is_read_committed_snapshot_on;

        public bool? is_read_only 
            => _database.is_read_only;

        public bool? is_recursive_triggers_on 
            => _database.is_recursive_triggers_on;

        public bool? is_remote_data_archive_enabled 
            => _database.is_remote_data_archive_enabled;

        public bool is_subscribed 
            => _database.is_subscribed;

        public bool? is_supplemental_logging_enabled 
            => _database.is_supplemental_logging_enabled;

        public bool is_sync_with_backup 
            => _database.is_sync_with_backup;

        public bool is_system_defined 
            => _database.is_system_defined;

        public bool? is_transform_noise_words_on 
            => _database.is_transform_noise_words_on;

        public bool? is_trustworthy_on 
            => _database.is_trustworthy_on;

        public bool is_user_defined 
            => _database.is_user_defined;

        public byte? log_reuse_wait 
            => _database.log_reuse_wait;

        public string log_reuse_wait_desc 
            => _database.log_reuse_wait_desc;

        public byte[] owner_sid 
            => _database.owner_sid;

        public byte? page_verify_option 
            => _database.page_verify_option;

        public string page_verify_option_desc 
            => _database.page_verify_option_desc;

        public byte? recovery_model 
            => _database.recovery_model;

        public string recovery_model_desc 
            => _database.recovery_model_desc;

        public Guid? replica_id
            => _database.replica_id;

        public int? resource_pool_id 
            => _database.resource_pool_id;

        public Guid service_broker_guid 
            => _database.service_broker_guid;

        public byte? snapshot_isolation_state 
            => _database.snapshot_isolation_state;

        public string snapshot_isolation_state_desc 
            => _database.snapshot_isolation_state_desc;

        public int? source_database_id 
            => _database.source_database_id;

        public byte? state 
            => _database.state;

        public string state_desc 
            => _database.state_desc;

        public int? target_recovery_time_in_seconds 
            => _database.target_recovery_time_in_seconds;

        public short? two_digit_year_cutoff 
            => _database.two_digit_year_cutoff;

        public byte? user_access 
            => _database.user_access;

        public string user_access_desc 
            => _database.user_access_desc;

        #endregion
    }

}