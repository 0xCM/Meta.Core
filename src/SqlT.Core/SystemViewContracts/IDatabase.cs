//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;

    [SystemViewContract(SystemViewNames.databases)]
    public interface IDatabase : ISystemElement
    {
        string collation_name {get;}

        byte compatibility_level {get;}

        byte? containment {get;}

        string containment_desc {get;}

        DateTime create_date {get;}

        int database_id {get;}

        int? default_fulltext_language_lcid {get;}

        string default_fulltext_language_name {get;}

        short? default_language_lcid {get;}

        string default_language_name {get;}

        int? delayed_durability {get;}

        string delayed_durability_desc {get;}

        Guid? group_database_id {get;}

        bool? is_ansi_nulls_on {get;}

        bool? is_ansi_null_default_on {get;}

        bool? is_ansi_padding_on {get;}

        bool? is_ansi_warnings_on {get;}

        bool? is_arithabort_on {get;}

        bool is_auto_close_on {get;}

        bool? is_auto_create_stats_incremental_on {get;}

        bool? is_auto_create_stats_on {get;}

        bool? is_auto_shrink_on {get;}

        bool? is_auto_update_stats_async_on {get;}

        bool? is_auto_update_stats_on {get;}

        bool is_broker_enabled {get;}

        bool is_cdc_enabled {get;}

        bool? is_cleanly_shutdown {get;}

        bool? is_concat_null_yields_null_on {get;}

        bool? is_cursor_close_on_commit_on {get;}

        bool is_date_correlation_on {get;}

        bool? is_db_chaining_on {get;}

        bool is_distributor {get;}

        bool? is_encrypted {get;}

        bool? is_federation_member {get;}

        bool? is_fulltext_enabled {get;}

        bool? is_honor_broker_priority_on {get;}

        bool? is_in_standby {get;}

        bool? is_local_cursor_default {get;}

        bool is_master_key_encrypted_by_server {get;}

        bool? is_memory_optimized_elevate_to_snapshot_on {get;}

        bool is_merge_published {get;}

        bool? is_mixed_page_allocation_on {get;}

        bool? is_nested_triggers_on {get;}

        bool? is_numeric_roundabort_on {get;}

        bool? is_parameterization_forced {get;}

        bool is_published {get;}

        bool? is_query_store_on {get;}

        bool? is_quoted_identifier_on {get;}

        bool? is_read_committed_snapshot_on {get;}

        bool? is_read_only {get;}

        bool? is_recursive_triggers_on {get;}

        bool? is_remote_data_archive_enabled {get;}

        bool is_subscribed {get;}

        bool? is_supplemental_logging_enabled {get;}

        bool is_sync_with_backup {get;}

        bool is_system_defined { get; }

        bool? is_transform_noise_words_on {get;}

        bool? is_trustworthy_on {get;}

        bool is_user_defined { get; }

        byte? log_reuse_wait {get;}

        string log_reuse_wait_desc {get;}
        
        byte[] owner_sid {get;}

        byte? page_verify_option {get;}

        string page_verify_option_desc {get;}

        byte? recovery_model {get;}

        string recovery_model_desc {get;}

        Guid? replica_id {get;}

        int? resource_pool_id {get;}

        Guid service_broker_guid {get;}

        byte? snapshot_isolation_state {get;}

        string snapshot_isolation_state_desc {get;}

        int? source_database_id {get;}

        byte? state {get;}

        string state_desc {get;}

        int? target_recovery_time_in_seconds {get;}

        short? two_digit_year_cutoff {get;}

        byte? user_access {get;}

        string user_access_desc {get;}        
    }
}