create table [systems].[databases]
(
	systems_key int not null 
		constraint DF_databases_key 
			default (next value for systems.databases_key),
	systems_server_name sysname not null,
	name sysname not null,
	database_id int not null,
	source_database_id int NULL,
	owner_sid varbinary(85) NULL,
	create_date datetime not null,
	compatibility_level tinyint not null,
	collation_name nvarchar(128) NULL,
	user_access tinyint NULL,
	user_access_desc nvarchar(60) NULL,
	is_read_only bit NULL,
	is_auto_close_on bit not null,
	is_auto_shrink_on bit NULL,
	state tinyint NULL,
	state_desc nvarchar(60) NULL,
	is_in_standby bit NULL,
	is_cleanly_shutdown bit NULL,
	is_supplemental_logging_enabled bit NULL,
	snapshot_isolation_state tinyint NULL,
	snapshot_isolation_state_desc nvarchar(60) NULL,
	is_read_committed_snapshot_on bit NULL,
	recovery_model tinyint NULL,
	recovery_model_desc nvarchar(60) NULL,
	page_verify_option tinyint NULL,
	page_verify_option_desc nvarchar(60) NULL,
	is_auto_create_stats_on bit NULL,
	is_auto_update_stats_on bit NULL,
	is_auto_update_stats_async_on bit NULL,
	is_ansi_null_default_on bit NULL,
	is_ansi_nulls_on bit NULL,
	is_ansi_padding_on bit NULL,
	is_ansi_warnings_on bit NULL,
	is_arithabort_on bit NULL,
	is_concat_null_yields_null_on bit NULL,
	is_numeric_roundabort_on bit NULL,
	is_quoted_identifier_on bit NULL,
	is_recursive_triggers_on bit NULL,
	is_cursor_close_on_commit_on bit NULL,
	is_local_cursor_default bit NULL,
	is_fulltext_enabled bit NULL,
	is_trustworthy_on bit NULL,
	is_db_chaining_on bit NULL,
	is_parameterization_forced bit NULL,
	is_master_key_encrypted_by_server bit not null,
	is_published bit not null,
	is_subscribed bit not null,
	is_merge_published bit not null,
	is_distributor bit not null,
	is_sync_with_backup bit not null,
	service_broker_guid uniqueidentifier not null,
	is_broker_enabled bit not null,
	log_reuse_wait tinyint NULL,
	log_reuse_wait_desc nvarchar(60) NULL,
	is_date_correlation_on bit not null,
	is_cdc_enabled bit not null,
	is_encrypted bit NULL,
	is_honor_broker_priority_on bit NULL,
	replica_id uniqueidentifier NULL,
	group_database_id uniqueidentifier NULL,
	default_language_lcid smallint NULL,
	default_language_name nvarchar(128) NULL,
	default_fulltext_language_lcid int NULL,
	default_fulltext_language_name nvarchar(128) NULL,
	is_nested_triggers_on bit NULL,
	is_transform_noise_words_on bit NULL,
	two_digit_year_cutoff smallint NULL,
	containment tinyint NULL,
	containment_desc nvarchar(60) NULL,
	target_recovery_time_in_seconds int NULL,
	as_of datetime2(3) not null 
		constraint DF_databases_as_of default (getdate())
	
	constraint PK_databases primary key(systems_key),
	constraint UQ_databases unique(systems_server_name, name),
	constraint FK_databases_host_servers 
		foreign key(systems_server_name) 
			references systems.host_servers(systems_server_name)
				on delete cascade on update cascade


)
GO
create sequence systems.databases_key 
	as int start with 1 cache 100
