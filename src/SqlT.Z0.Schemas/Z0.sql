create schema [Z0];

GO
create type [Z0].[QueryDescriptor] AS TABLE 
(
    QueryId      INT not null,
    LastExecuted DATETIME2 (0)  not null,
    QueryText    nvarchar (MAX) not null
);
GO

create type [Z0].[CollationDescriptor] as table
(
	[CollationName] nvarchar(128) not null,
	CollationDescription nvarchar(250) not null,
	IsSqlCollation bit not null
)
GO

create type [Z0].[TableStatsRecord] AS TABLE 
(
    ServerName   nvarchar (128) not null,
    CatalogName  nvarchar (128) not null,
    SchemaName   nvarchar (128) not null,
    TableName    nvarchar (128) not null,
    RecordCount  BIGINT         not null,
    DataStorage  BIGINT         not null,
    IndexStorage BIGINT         not null,
    TotalStorage BIGINT         not null
);

GO

create type [Z0].[RefactorStepExec] AS TABLE (
    [ExecSql] nvarchar (MAX) not null);


GO

create type [Z0].[RenameIndexSelection] AS TABLE (
    [TableName]    nvarchar (256) not null,
    [OldIndexName] nvarchar (128) not null,
    [NewIndexName] nvarchar (128) not null);

GO

create function [Z0].[FormatMessage]
(
	@Id int, 
	@P1 sql_variant = null, 
	@P2 sql_variant = null, 
	@P3 sql_variant = null
) 
	returns varchar(2000) as
	begin

		declare @DatePattern varchar(50) = 'yyyy-MM-dd';
		declare @DateTimePattern varchar(50) = concat(@DatePattern, ' ', 'hh:mm:ss')

		declare 
			@P1Type sysname, 
			@P2Type sysname, 
			@P3Type sysname;

		select 
			@P1Type = isnull(cast(sql_variant_property(@P1, 'BaseType') as varchar),''), 
			@P2Type = isnull(cast(sql_variant_property(@P2, 'BaseType') as varchar),''), 
			@P3Type = isnull(cast(sql_variant_property(@P3, 'BaseType') as varchar),'')

		declare 
			@P1Format varchar(1024),
			@P2Format varchar(1024), 
			@P3Format varchar(1024);


		select 
			@P1Format = case @P1Type
				when 'date' then format(cast(@P1 as date), @DatePattern)
				when 'datetime' then format(cast(@P1 as datetime), @DateTimePattern)
				when 'datetime2' then format(cast(@P1 as datetime), @DateTimePattern)

				else cast(@P1 as varchar) end,

			@P2Format = case @P2Type
				when 'date' then format(cast(@P2 as date), @DatePattern)
				else cast(@P2 as varchar) end,
			@P3Format = case @P3Type
				when 'date' then format(cast(@P3 as date), @DatePattern)
				else cast(@P3 as varchar) end;


		declare @Msg varchar(2000) = formatmessage(@Id, @P1Format, @P2Format, @P3Format)

		return @Msg collate database_default;
	end
GO

create function [Z0].[object_id](@schema_qualified_name nvarchar(260))
	returns int as
	begin
		return object_id(@schema_qualified_name)
	end
GO

create function [Z0].[object_name](@object_id int)
	returns sysname as
	begin
		return object_name(@object_id) collate database_default;
	end
GO

create function [Z0].[schema_name](@schema_id int)
	returns sysname as
	begin
		return schema_name(@schema_id)
	end
GO


create function [Z0].[schema_id](@schema_name sysname)
	returns int as
	begin
		return schema_id(@schema_name);
	end

GO
create function [Z0].[db_name]() 
	returns sysname as
	begin
		return db_name() collate database_default;
	end

GO

create function [Z0].[db_id](@database_name sysname)
	returns int as
	begin
		return db_id(@database_name)
	end
GO


create function [Z0].[server_name]()
	returns sysname as
	begin
		return @@servername collate database_default;
	end
GO

create function [Z0].[FileTableRootPath](@TableName nvarchar(260) = null)
	returns nvarchar(4000) as
	begin
		return FileTableRootPath(@TableName) collate database_default
	end
GO


create view [Z0].[all_columns] as
    select src.* from sys.all_columns src
GO


create view [Z0].[all_objects] as
    select src.* from sys.all_objects src
GO

create view [Z0].[all_parameters] as
    select src.* from sys.all_parameters src
GO


create view [Z0].[all_sql_modules] as
    select src.* from sys.all_sql_modules src
GO


GO

create view [Z0].[all_views] as
    select src.* from sys.all_views src
GO


GO

create view [Z0].[allocation_units] as
    select src.* from sys.allocation_units src
GO


GO

create view [Z0].[assemblies] as
    select src.* from sys.assemblies src
GO



GO

create view [Z0].[assembly_files] as
    select src.* from sys.assembly_files src
GO


GO

create view [Z0].[assembly_modules] as
    select src.* from sys.assembly_modules src
GO


GO

create view [Z0].[assembly_references] as
    select src.* from sys.assembly_references src
GO


GO

create view [Z0].[assembly_types] as
    select src.* from sys.assembly_types src
GO


GO

create view [Z0].[asymmetric_keys] as
    select src.* from sys.asymmetric_keys src
GO



create view [Z0].[backup_devices] as
    select src.* from sys.backup_devices src
GO

create view [Z0].[certificates] as
    select src.* from sys.certificates src
GO


create view [Z0].[change_tracking_databases] as
    select src.* from sys.change_tracking_databases src
GO



GO

create view [Z0].[change_tracking_tables] as
    select src.* from sys.change_tracking_tables src
GO


GO

create view [Z0].[check_constraints] as
    select src.* from sys.check_constraints src
GO



create view [Z0].[column_encryption_key_values] as
    select src.* from sys.column_encryption_key_values src
GO



GO

create view [Z0].[column_encryption_keys] as
    select src.* from sys.column_encryption_keys src
GO



GO

create view [Z0].[column_master_keys] as
    select src.* from sys.column_master_keys src
GO



GO

create view [Z0].[column_store_dictionaries] as
    select src.* from sys.column_store_dictionaries src
GO



GO

create view [Z0].[column_store_row_groups] as
    select src.* from sys.column_store_row_groups src
GO



GO

create view [Z0].[column_store_segments] as
    select src.* from sys.column_store_segments src
GO

create view [Z0].[column_type_usages] as
    select src.* from sys.column_type_usages src

GO

create view [Z0].[column_xml_schema_collection_usages] as
    select src.* from sys.column_xml_schema_collection_usages src
GO

create view [Z0].[computed_columns] as
    select src.* from sys.computed_columns src

GO

create view [Z0].[configurations] as
    select src.* from sys.configurations src

GO

create view [Z0].[conversation_endpoints] as
    select src.* from sys.conversation_endpoints src
GO

create view [Z0].[conversation_groups] as
    select src.* from sys.conversation_groups src

GO

create view [Z0].[conversation_priorities] as
    select src.* from sys.conversation_priorities src
GO

create view [Z0].[credentials] as
    select src.* from sys.credentials src

GO

create view [Z0].[crypt_properties] as
    select src.* from sys.crypt_properties src
GO


create view [Z0].[cryptographic_providers] as
    select src.* from sys.cryptographic_providers src
GO


create view [Z0].[data_spaces] as
    select src.* from sys.data_spaces src


GO

create view [Z0].[database_audit_specification_details] as
    select src.* from sys.database_audit_specification_details src


GO

create view [Z0].[database_audit_specifications] as
    select src.* from sys.database_audit_specifications src
GO

create view [Z0].[database_credentials] as
    select src.* from sys.database_credentials src

GO

create view [Z0].[database_files] as
    select src.* from sys.database_files src


GO

create view [Z0].[database_filestream_options] as
    select src.* from sys.database_filestream_options src

GO

create view [Z0].[database_mirroring] as
    select src.* from sys.database_mirroring src


GO

create view [Z0].[database_mirroring_endpoints] as
    select src.* from sys.database_mirroring_endpoints src


GO

create view [Z0].[database_mirroring_witnesses] as
    select src.* from sys.database_mirroring_witnesses src


GO

create view [Z0].[database_permissions] as
    select src.* from sys.database_permissions src


GO

create view [Z0].[database_principals] as
    select src.* from sys.database_principals src

GO

create view [Z0].[database_query_store_options] as
    select src.* from sys.database_query_store_options src

GO

create view [Z0].[database_recovery_status] as
    select src.* from sys.database_recovery_status src


GO

create view [Z0].[database_role_members] as
    select src.* from sys.database_role_members src


GO

create view [Z0].[database_scoped_configurations] as
    select src.* from sys.database_scoped_configurations src


GO

create view [Z0].[database_scoped_credentials] as
    select src.* from sys.database_scoped_credentials src
GO

create view [Z0].[destination_data_spaces] as
    select src.* from sys.destination_data_spaces src

GO

create view [Z0].[dm_audit_actions] as
    select src.* from sys.dm_audit_actions src
GO

GO

create view [Z0].[dm_audit_class_type_map] as
    select src.* from sys.dm_audit_class_type_map src

GO

create view [Z0].[dm_broker_activated_tasks] as
    select src.* from sys.dm_broker_activated_tasks src


GO

create view [Z0].[dm_broker_connections] as
    select src.* from sys.dm_broker_connections src


GO

create view [Z0].[dm_broker_forwarded_messages] as
    select src.* from sys.dm_broker_forwarded_messages src

GO

create view [Z0].[dm_broker_queue_monitors] as
    select src.* from sys.dm_broker_queue_monitors src

GO

create view [Z0].[dm_cdc_errors] as
    select src.* from sys.dm_cdc_errors src

GO

create view [Z0].[dm_cdc_log_scan_sessions] as
    select src.* from sys.dm_cdc_log_scan_sessions src

GO

create view [Z0].[dm_clr_appdomains] as
    select src.* from sys.dm_clr_appdomains src

GO

create view [Z0].[dm_clr_loaded_assemblies] as
    select src.* from sys.dm_clr_loaded_assemblies src

GO

create view [Z0].[dm_clr_properties] as
    select src.* from sys.dm_clr_properties src

GO

create view [Z0].[dm_clr_tasks] as
    select src.* from sys.dm_clr_tasks src


GO

create view [Z0].[dm_column_store_object_pool] as
    select src.* from sys.dm_column_store_object_pool src
GO

create view [Z0].[dm_cryptographic_provider_properties] as
    select src.* from sys.dm_cryptographic_provider_properties src

GO

create view [Z0].[dm_database_encryption_keys] as
    select src.* from sys.dm_database_encryption_keys src
GO

create view [Z0].[dm_db_column_store_row_group_operational_stats] as
    select src.* from sys.dm_db_column_store_row_group_operational_stats src


GO

create view [Z0].[dm_db_column_store_row_group_physical_stats] as
    select src.* from sys.dm_db_column_store_row_group_physical_stats src

GO

create view [Z0].[dm_db_file_space_usage] as
    select src.* from sys.dm_db_file_space_usage src

GO

create view [Z0].[dm_db_fts_index_physical_stats] as
    select src.* from sys.dm_db_fts_index_physical_stats src

GO

create view [Z0].[dm_db_index_usage_stats] as
    select src.* from sys.dm_db_index_usage_stats src


GO

create view [Z0].[dm_db_log_space_usage] as
    select src.* from sys.dm_db_log_space_usage src


GO

create view [Z0].[dm_server_audit_status] as
    select src.* from sys.dm_server_audit_status src

GO

create view [Z0].[dm_server_registry] as
    select src.* from sys.dm_server_registry src

GO

create view [Z0].[dm_server_services] as
    select src.* from sys.dm_server_services src

GO

GO

create view [Z0].[endpoints] as
    select src.* from sys.endpoints src

GO

create view [Z0].[event_notification_event_types] as
    select src.* from sys.event_notification_event_types src
GO

create view [Z0].[event_notifications] as
    select src.* from sys.event_notifications src

GO
create view [Z0].[events] as
    select src.* from sys.events src
GO

create view [Z0].[message_type_xml_schema_collection_usages] as
    select src.* from sys.message_type_xml_schema_collection_usages src

GO

create view [Z0].[messages] as
    select src.* from sys.messages src

GO
create view [Z0].[remote_service_bindings] as
    select src.* from sys.remote_service_bindings src
GO

create view [Z0].[sysindexes] as
    select src.* from sys.sysindexes src
GO

create view [Z0].[partition_functions] as
    select src.* from sys.partition_functions src
GO

create view [Z0].[partition_parameters] as
    select src.* from sys.partition_parameters src
GO


create view [Z0].[partition_range_values] as
    select src.* from sys.partition_range_values src
GO


create view [Z0].[partition_schemes] as
    select src.* from sys.partition_schemes src
GO



create view [Z0].[partitions] as
    select src.* from sys.partitions src

GO

create view [Z0].[periods] as
    select src.* from sys.periods src
GO

create view [Z0].[plan_guides] as
    select src.* from sys.plan_guides src

GO

create view [Z0].[routes] as
    select src.* from sys.routes src

GO

create view [Z0].[securable_classes] as
    select src.* from sys.securable_classes src


GO

create view [Z0].[security_policies] as
    select src.* from sys.security_policies src

GO

create view [Z0].[security_predicates] as
    select src.* from sys.security_predicates src

GO

create view [Z0].[selective_xml_index_namespaces] as
    select src.* from sys.selective_xml_index_namespaces src

GO

create view [Z0].[selective_xml_index_paths] as
    select src.* from sys.selective_xml_index_paths src

GO

create view [Z0].[server_assembly_modules] as
    select src.* from sys.server_assembly_modules src

GO

create view [Z0].[server_audit_specification_details] as
    select src.* from sys.server_audit_specification_details src
GO

create view [Z0].[server_audit_specifications] as
    select src.* from sys.server_audit_specifications src

GO

create view [Z0].[server_audits] as
    select src.* from sys.server_audits src


GO

create view [Z0].[server_event_notifications] as
    select src.* from sys.server_event_notifications src


GO

create view [Z0].[server_event_session_actions] as
    select src.* from sys.server_event_session_actions src

GO

create view [Z0].[server_event_session_events] as
    select src.* from sys.server_event_session_events src


GO

create view [Z0].[server_event_session_fields] as
    select src.* from sys.server_event_session_fields src

GO

create view [Z0].[server_event_session_targets] as
    select src.* from sys.server_event_session_targets src

GO

create view [Z0].[server_event_sessions] as
    select src.* from sys.server_event_sessions src

GO

create view [Z0].[server_events] as
    select src.* from sys.server_events src

GO

create view [Z0].[server_file_audits] as
    select src.* from sys.server_file_audits src


GO

create view [Z0].[server_permissions] as
    select src.* from sys.server_permissions src

GO

create view [Z0].[server_principal_credentials] as
    select src.* from sys.server_principal_credentials src

GO

create view [Z0].[server_principals] as
    select src.* from sys.server_principals src

GO

create view [Z0].[server_role_members] as
    select src.* from sys.server_role_members src


GO

create view [Z0].[server_sql_modules] as
    select src.* from sys.server_sql_modules src

GO

create view [Z0].[server_trigger_events] as
    select src.* from sys.server_trigger_events src

GO

create view [Z0].[server_triggers] as
    select src.* from sys.server_triggers src

GO

create view [Z0].[servers] as
    select src.* from sys.servers src

GO

create view [Z0].[service_broker_endpoints] as
    select src.* from sys.service_broker_endpoints src


GO

create view [Z0].[service_contract_message_usages] as
    select src.* from sys.service_contract_message_usages src


GO

create view [Z0].[service_contract_usages] as
    select src.* from sys.service_contract_usages src


GO

create view [Z0].[service_contracts] as
    select src.* from sys.service_contracts src


GO

create view [Z0].[service_message_types] as
    select src.* from sys.service_message_types src


GO

create view [Z0].[service_queue_usages] as
    select src.* from sys.service_queue_usages src


GO

create view [Z0].[service_queues] as
    select src.* from sys.service_queues src


GO

create view [Z0].[services] as
    select src.* from sys.services src


GO

create view [Z0].[soap_endpoints] as
    select src.* from sys.soap_endpoints src

GO


create view [Z0].[dm_xe_map_values] as
    select src.* from sys.dm_xe_map_values src

GO

create view [Z0].[dm_xe_object_columns] as
    select src.* from sys.dm_xe_object_columns src


GO

create view [Z0].[dm_xe_objects] as
    select src.* from sys.dm_xe_objects src

GO

create view [Z0].[dm_xe_packages] as
    select src.* from sys.dm_xe_packages src


GO

create view [Z0].[dm_xe_session_event_actions] as
    select src.* from sys.dm_xe_session_event_actions src

GO

create view [Z0].[dm_xe_session_events] as
    select src.* from sys.dm_xe_session_events src

GO

create view [Z0].[dm_xe_session_object_columns] as
    select src.* from sys.dm_xe_session_object_columns src

GO

create view [Z0].[dm_xe_session_targets] as
    select src.* from sys.dm_xe_session_targets src

GO

create view [Z0].[dm_xe_sessions] as
    select src.* from sys.dm_xe_sessions src

GO

create view [Z0].[module_assembly_usages] as
    select src.* from sys.module_assembly_usages src


GO

create view [Z0].[numbered_procedure_parameters] as
    select src.* from sys.numbered_procedure_parameters src


GO

create view [Z0].[numbered_procedures] as
    select src.* from sys.numbered_procedures src
GO

create view [Z0].[objects] as
    select src.* from sys.objects src


GO

create view [Z0].[openkeys] as
    select src.* from sys.openkeys src
GO


create view [Z0].[parameter_type_usages] as
    select src.* from sys.parameter_type_usages src

GO

create view [Z0].[parameter_xml_schema_collection_usages] as
    select src.* from sys.parameter_xml_schema_collection_usages src


GO

create view [Z0].[parameters] as
    select src.* from sys.parameters src
GO



create view [Z0].[function_order_columns] as
    select src.* from sys.function_order_columns src


GO

create view [Z0].[hash_indexes] as
    select src.* from sys.hash_indexes src


GO

create view [Z0].[http_endpoints] as
    select src.* from sys.http_endpoints src


GO

create view [Z0].[identity_columns] as
    select src.* from sys.identity_columns src
GO


create view [Z0].[index_columns] as
    select src.* from sys.index_columns src

GO
create view [Z0].[schemas] as
    select src.* from sys.schemas src

GO

create view [Z0].[procedures] as
    select src.* from sys.procedures src


GO

create view [Z0].[query_context_settings] as
    select src.* from sys.query_context_settings src
GO



create view [Z0].[query_store_plan] as
    select src.* from sys.query_store_plan src
GO


GO

create view [Z0].[query_store_query] as
    select src.* from sys.query_store_query src
GO


GO

create view [Z0].[query_store_query_text] as
    select src.* from sys.query_store_query_text src
GO


GO

create view [Z0].[query_store_runtime_stats] as
    select src.* from sys.query_store_runtime_stats src
GO


GO

create view [Z0].[query_store_runtime_stats_interval] as
    select src.* from sys.query_store_runtime_stats_interval src
GO


create view [Z0].[sequences] as
    select src.* from sys.sequences src
GO

create view [Z0].[sql_dependencies] as
    select src.* from sys.sql_dependencies src
GO


create view [Z0].[sql_expression_dependencies] as
    select src.* from sys.sql_expression_dependencies src
GO


create view [Z0].[sql_logins] as
    select src.* from sys.sql_logins src
GO


create view [Z0].[sql_modules] as
    select src.* from sys.sql_modules src
GO

create view [Z0].[stats] as
    select src.* from sys.stats src
GO

create view [Z0].[stats_columns] as
    select src.* from sys.stats_columns src
GO

create view [Z0].[symmetric_keys] as
    select src.* from sys.symmetric_keys src
GO

create view [Z0].[synonyms] as
    select src.* from sys.synonyms src
GO

create view [Z0].[syscolumns] as
    select src.* from sys.syscolumns src
GO

create view [Z0].[system_columns] as
    select src.* from sys.system_columns src
GO

create view [Z0].[system_components_surface_area_configuration] as
    select src.* from sys.system_components_surface_area_configuration src
GO

create view [Z0].[system_objects] as
    select src.* from sys.system_objects src
GO

create view [Z0].[system_parameters] as
    select src.* from sys.system_parameters src
GO

create view [Z0].[system_sql_modules] as
    select src.* from sys.system_sql_modules src
GO

create view [Z0].[system_views] as
    select src.* from sys.system_views src
GO

create view [Z0].[table_types] as
    select src.* from sys.table_types src
GO

create view [Z0].[tables] as
    select src.* from sys.tables src
GO

create view [Z0].[tcp_endpoints] as
    select src.* from sys.tcp_endpoints src
GO

create view [Z0].[time_zone_info] as
    select src.* from sys.time_zone_info src
GO


create view [Z0].[trace_categories] as
    select src.* from sys.trace_categories src
GO

create view [Z0].[trace_columns] as
    select src.* from sys.trace_columns src
GO

create view [Z0].[trace_event_bindings] as
    select src.* from sys.trace_event_bindings src
GO


GO

create view [Z0].[trace_events] as
    select src.* from sys.trace_events src
GO


GO

create view [Z0].[trace_subclass_values] as
    select src.* from sys.trace_subclass_values src
GO


GO

create view [Z0].[traces] as
    select src.* from sys.traces src
GO


GO

create view [Z0].[transmission_queue] as
    select src.* from sys.transmission_queue src
GO

create view [Z0].[trigger_event_types] as
    select src.* from sys.trigger_event_types src
GO

create view [Z0].[trigger_events] as
    select src.* from sys.trigger_events src
GO


create view [Z0].[triggers] as
    select src.* from sys.triggers src
GO

create view [Z0].[type_assembly_usages] as
    select src.* from sys.type_assembly_usages src
GO

create view [Z0].[types] as
    select src.* from sys.types src
GO


create view [Z0].[user_token] as
    select src.* from sys.user_token src
GO


create view [Z0].[via_endpoints] as
    select src.* from sys.via_endpoints src
GO


create view [Z0].[views] as
    select src.* from sys.views src
GO


create view [Z0].[xml_indexes] as
    select src.* from sys.xml_indexes src
GO


create view [Z0].[xml_schema_attributes] as
    select src.* from sys.xml_schema_attributes src
GO



create view [Z0].[xml_schema_collections] as
    select src.* from sys.xml_schema_collections src
GO


create view [Z0].[xml_schema_component_placements] as
    select src.* from sys.xml_schema_component_placements src
GO


create view [Z0].[xml_schema_components] as
    select src.* from sys.xml_schema_components src
GO


create view [Z0].[xml_schema_elements] as
    select src.* from sys.xml_schema_elements src
GO

create view [Z0].[xml_schema_facets] as
    select src.* from sys.xml_schema_facets src
GO

create view [Z0].[xml_schema_model_groups] as
    select src.* from sys.xml_schema_model_groups src


GO

create view [Z0].[xml_schema_namespaces] as
    select src.* from sys.xml_schema_namespaces src
GO


create view [Z0].[xml_schema_types] as
    select src.* from sys.xml_schema_types src
GO

create view [Z0].[xml_schema_wildcard_namespaces] as
    select src.* from sys.xml_schema_wildcard_namespaces src
GO

create view [Z0].[xml_schema_wildcards] as
    select src.* from sys.xml_schema_wildcards src
GO


create view [Z0].[extended_properties] as
    select src.* from sys.extended_properties src

GO

create view [Z0].[filegroups] as
    select src.* from sys.filegroups src
GO

create view [Z0].[filetables] as
    select src.* from sys.filetables src
GO

create view [Z0].[foreign_key_columns] as
    select src.* from sys.foreign_key_columns src
GO

create view [Z0].[foreign_keys] as
    select src.* from sys.foreign_keys src
GO

create view [Z0].[columns] as
    select src.* from sys.columns src
GO

create view [Z0].[databases] as
    select src.* from sys.databases src
GO

create view [Z0].[default_constraints] as
    select src.* from sys.default_constraints src
GO


create view [Z0].[dm_db_partition_stats] as
    select src.* from sys.dm_db_partition_stats src

GO

create view [Z0].[indexes] as
    select src.* from sys.indexes src

GO

create view [Z0].[filetable_system_defined_objects] as
    select src.* from sys.filetable_system_defined_objects src

GO
create view [Z0].[key_constraints] as
    select src.* from sys.key_constraints src

GO
create view [Z0].[linked_logins] as
    select src.* from sys.linked_logins src

GO
create view [Z0].[internal_partitions] as
    select src.* from sys.internal_partitions src
GO

create type [Z0].[TriggerEventType] as table
(
	TypeNumber int not null,
	TypeName nvarchar(128) not null,
	GroupNumber int not null
)
GO	

create function [Z0].[TriggerEventTypes]() returns table as return
	select 
		TypeNumber,
		TypeName,
		GroupNumber
	from
		[Z0].[TriggerEventTypeDescription]
GO
execute sp_addextendedproperty 
	@name = N'DM_RecordType', 
	@value = N'[Z0].[TriggerEventType]', 
	@level0type = N'SCHEMA', 
	@level0name = N'Z0', 
	@level1type = N'FUNCTION', 
	@level1name = N'TriggerEventTypes';

GO


create function [Z0].[DescribeRecentQueries](@MaxCount int) returns table as return
	select top(@MaxCount)
		QueryId = q.query_id, 
		LastExecuted = cast(q.last_execution_time as datetime2(0)), 
		QueryText = t.query_sql_text
	from 
		[Z0].query_store_query q
			inner join [Z0].query_store_query_text t on 
				t.query_text_id = q.query_text_id
	order by
		LastExecuted desc

GO
create view [Z0].[ViewDescription] as
	select 
		RowId = row_number() over(order by [Z0].db_name(), s.[name], t.[name]),
		CatalogName = [Z0].db_name(),
		SchemaName = s.[name],
		TableName = t.[name],
		[Description] = cast(xpt.[value] as nvarchar(250))
	from 
		[Z0].views t  
		inner join [Z0].schemas s on
			s.[schema_id] = t.[schema_id]
		left join [Z0].extended_properties xpt on 
			xpt.major_id = t.[object_id]
		and xpt.[name] = 'MS_Description'
		and xpt.minor_id = 0
GO


GO
create view [Z0].[ViewColumnDescription] as
	select 
		RowId = row_number() over(order by [Z0].db_name(), s.[name], o.[name], c.column_id),
		CatalogName = [Z0].db_name(),
		SchemaName = s.[name],
		ObjectName = o.[name],
		ColumnName = c.[name],
		[Description] = cast(xpt.[value] as nvarchar(250))
	from 
		[Z0].columns c   
		inner join [Z0].views o on 
			o.[object_id] =c.[object_id]
		inner join [Z0].schemas s on
			s.[schema_id] = o.[schema_id]
		left join [Z0].extended_properties xpt on 
			xpt.major_id = o.[object_id]
		and xpt.minor_id = c.[column_id]
		and xpt.[name] = 'MS_Description'
GO

create view [Z0].[TableStats] as
--Parts adapted from: http://stackoverflow.com/questions/7892334/get-size-of-all-tables-in-database
	with RowCounts as
	(
		select 
			ServerName = @@servername,
			CatalogName = d.[name] ,
			SchemaName = s.[name],
			TableName = t.[name], 
			TableRowCount = i.[rows]
		from 
			[Z0].tables t 					
				inner join [Z0].databases d on
					d.[name] = [Z0].db_name()
				inner join [Z0].schemas s on
					s.[schema_id] = t.[schema_id]
				inner join  [Z0].sysindexes i on 
					t.[object_id] = i.id AND i.indid < 2 			
	),
	X as 
	(
		select
			ServerName = @@servername,
			CatalogName = d.[name],
			SchemaName = s.[name],
			TableName = t.[name],			
			used_pages_count =	sum (st.used_page_count),			
			pages =	sum (case when (i.index_id < 2) 
					then (
						in_row_data_page_count 
						+ lob_used_page_count 
						+ row_overflow_used_page_count
					)
					else 
						lob_used_page_count 
					+ row_overflow_used_page_count end
					)
					
			
		from 
			[Z0].dm_db_partition_stats st
				inner join [Z0].tables t on 
					st.[object_id] = t.[object_id]	
				inner join [Z0].databases d on
					d.[name] = [Z0].db_name()
				inner join [Z0].schemas s on 
					s.[schema_id] = t.[schema_id]
				inner join [Z0].indexes i on 
					i.[object_id] = t.[object_id] 
				and st.index_id = i.index_id
		where	
			t.[name] <> '__RefactorLog'
		group by
			d.[name],
			s.[name],
			t.[name]
	),
	Y as
	(
		select
			x.ServerName,
			x.CatalogName,
			x.SchemaName,
			x.TableName, 
			c.TableRowCount as RecordCount,
			cast((x.pages * 8.)/1024 as decimal(10,3)) as DataStorage, 
			cast(((CASE WHEN x.used_pages_count > x.pages 
						THEN x.used_pages_count - x.pages
						ELSE 0 
					END) * 8./1024) as decimal(10,3)) as IndexStorage
		from 
			X x 
				inner join RowCounts c 
					on c.SchemaName = x.SchemaName 
				and c.TableName = x.TableName
	),
	Z as
	(
		select 
			y.SchemaName,
			y.TableName,
			[Columns] = count(*)
		from
			Y y
				inner join [Z0].schemas s on 
					s.[name]= y.[SchemaName]
				inner join [Z0].tables t on 
					t.[name] = y.TableName
					and t.[schema_id] = s.[schema_id]
				inner join [Z0].columns c on 
					c.[object_id] = t.[object_id]
				
		group by
			y.SchemaName,
			y.TableName
	)
	select 
		ServerName = y.ServerName collate database_default,
		CatalogName = y.CatalogName collate database_default,
		SchemaName = y.SchemaName collate database_default,
		TableName = y.TableName collate database_default,
		y.RecordCount,
		[DataStorage (MB)] = y.DataStorage,
		[IndexStorage (MB)] = y.IndexStorage,			
		[Total Storage (MB)] =	y.DataStorage + y.IndexStorage					
	from 
		Y y 
			inner join Z z on 
				z.SchemaName = y.SchemaName 
			and z.TableName = y.TableName
GO

create view [Z0].[TableDescription] as
	select 
		RowId = row_number() over(order by [Z0].[server_name](), [Z0].db_name(), s.[name], t.[name]),
		ServerName = [Z0].[server_name](),
		CatalogName = [Z0].[db_name](),
		SchemaName = s.[name],
		TableName = t.[name],
		[Description] = cast(xpt.[value] as nvarchar(250))
	from 
		[Z0].tables t  
		inner join [Z0].schemas s on
			s.[schema_id] = t.[schema_id]
		left join [Z0].extended_properties xpt on 
			xpt.major_id = t.[object_id]
		and xpt.[name] = 'MS_Description'
		and xpt.minor_id = 0
GO

create view [Z0].[TableColumnDescription] as
	select 
		RowId = row_number() over(order by [Z0].[server_name](), [Z0].[db_name](), s.[name], t.[name], c.column_id),
		ServerName = [Z0].[server_name](),
		CatalogName = [Z0].[db_name](),
		SchemaName = s.[name],
		TableName = t.[name],
		ColumnId = c.[column_id],
		ColumnName = c.[name],
		[Description] = cast(xpt.[value] as nvarchar(250))
	from 
		[Z0].columns c   
		inner join [Z0].tables t on 
			t.[object_id] =c.[object_id]
		inner join [Z0].schemas s on
			s.[schema_id] = t.[schema_id]
		left join [Z0].extended_properties xpt on 
			xpt.major_id = t.[object_id]
		and xpt.minor_id = c.[column_id]
		and xpt.[name] = 'MS_Description'
GO

create view [Z0].[QueryStoreSummary] as
select 
	qsq.query_id,
	qsqt.query_sql_text,
	qsq.last_execution_time,
	qsq.avg_bind_cpu_time
from [Z0].query_store_query qsq 
		inner join [Z0].query_store_query_text qsqt on
			qsqt.query_text_id = qsq.query_text_id

GO

create view [Z0].[IndexDescription] as
	select 
		ServerName = [Z0].server_name(),
		CatalogName = [Z0].db_name(),
		SchemaName = s.[name],
		TableName = t.[name],
		IndexName = i.[name],
		IsClustered =
			case i.[type_desc]
				when 'CLUSTERED COLUMNSTORE' then 1
				when 'CLUSTERED' then 1
			else 0 
			end,
		IsColumnstore = 
			case i.[type_desc]
				when 'CLUSTERED COLUMNSTORE' then 1 
				else 0 
				end,
		IsEnabled = 
			case i.is_disabled 
				when 1 then 0 
				else 1 
				end,
		IsDisabled = i.is_disabled,
		IsPrimaryKey = i.is_primary_key,
		IsUnique = case 
			when i.is_unique = 1 or i.is_unique_constraint = 1 then 1
			else 0 
			end,
		IsUniqueIndex = i.is_unique,		
		IsUniqueConstraint = i.is_unique_constraint,
		IsNaturalKey = case 
			when  i.[name] like 'NKIX%' 
				and (i.is_unique = 1 or i.is_unique_constraint = 1) 
				then 1 
				else 0 
			end
	from 
		[Z0].indexes i 
			inner join [Z0].tables t on 
				t.[object_id] = i.[object_id]
			inner join [Z0].schemas s on 
				s.[schema_id] = t.[schema_id]

GO
create view [Z0].[IndexColumn] as
	select 
		ServerName = [Z0].[server_name](),
		CatalogName = [Z0].[db_name](),
		SchemaName = s.[name], 
		TableName = t.[name], 
		IndexName = ix.[name],
		IndexColumnId = ic.[index_column_id],
		ColumnId = ic.[column_id],
		ColumnName = c.[name],
		i.IsClustered, 
		i.IsColumnstore, 
		i.IsEnabled, 
		i.IsDisabled, 
		i.IsPrimaryKey, 
		i.IsUnique, 
		i.IsUniqueIndex, 
		i.IsUniqueConstraint,
		i.IsNaturalKey
	from 
		[Z0].[index_columns] ic

			inner join [Z0].[tables] t on 
				t.[object_id] = ic.[object_id]
			inner join [Z0].[columns] c on
				c.column_id = ic.column_id
			and c.[object_id] = t.[object_id]
			
			inner join [Z0].[schemas] s on
				s.[schema_id] = t.[schema_id]
			inner join [Z0].[indexes] ix on
				ix.[object_id] = ic.[object_id]
			and ix.[index_id] = ic.[index_id]			
			
			inner join [Z0].[IndexDescription] i  on 
				i.ServerName = [Z0].[server_name]()
			and i.CatalogName = [Z0].[db_name]()
			and s.[name] = i.[SchemaName]
			and t.[name] = i.[TableName]
			and ix.[name] = i.[IndexName]
	where
		ic.is_included_column = 0
			
				
			
Go
create view [Z0].[ForeignKeyDescription] as
	with FK as
	(
		select 
			fk_schema.[schema_id] as fk_schema_id,
			fk_schema.[name] as fk_schema,
			fk.[object_id] as fk_id,
			fk.[name] as fk_name,
			client_schema.[schema_id] as client_schema_id,
			client_schema.[name] as client_schema,
			client.[object_id] as client_id,
			client.[name] as client_name,
			supplier_schema.[schema_id] as supplier_schema_id,
			supplier_schema.[name] as supplier_schema,
			supplier.[object_id] as supplier_id,
			supplier.[name] as supplier_name
		from 
			[Z0].foreign_keys fk 
				inner join [Z0].schemas fk_schema on 
					fk_schema.[schema_id] = fk.[schema_id]
		
				inner join [Z0].objects client on 
					client.[object_id] = fk.parent_object_id
		
				inner join [Z0].schemas client_schema
					on client_schema.[schema_id] = client.[schema_id]

				inner join [Z0].objects supplier
					on supplier.[object_id] = fk.referenced_object_id

				inner join [Z0].schemas supplier_schema
					on supplier_schema.[schema_id] = supplier.[schema_id]
		),
		FKCOL as
		(
			select 
				FK.*,
				fkcol.constraint_column_id as fk_col_id,
				fkcol.parent_column_id as client_col_id,
				client_cols.[name] as client_col,
				fkcol.referenced_column_id as supplier_col_id,
				supplier_cols.[name] as supplier_col
		
			from 
				[Z0].foreign_key_columns fkcol 
					inner join FK on 
						FK.fk_id = fkcol.constraint_object_id
		
					inner join [Z0].columns client_cols on 
						client_cols.[object_id] = FK.client_id
					and client_cols.[column_id] = fkcol.parent_column_id

					inner join [Z0].columns supplier_cols on 
						supplier_cols.[object_id] = FK.supplier_id
					and supplier_cols.[column_id] = fkcol.referenced_column_id
		)
		select 
			RowId = row_number() over(order by x.fk_schema, x.fk_name, x.fk_col_id),
			CatalogName = [Z0].db_name(),
			ForeignKeySchema = x.fk_schema,
			ForeignKeyName = x.fk_name,
			ClientTableSchema = x.client_schema,
			ClientTableName = x.client_name,
			SupplierTableSchema = x.supplier_schema,
			SupplierTableName = x.supplier_name,
			ForeignKeyColumnId = x.fk_col_id,
			ClientColumnName = x.client_col,
			ClientColummnId = x.client_col_id,
			SupplierColumn = x.supplier_col,
			SupplierColumnId = x.supplier_col_id
		 from FKCOL x
GO



--See: https://docs.microsoft.com/en-us/sql/relational-databases/triggers/ddl-event-groups
create view [Z0].[TriggerEventTypeDescription] as
	with TriggerEventTypes AS   
	(  
		select 
			TypeName = [type_name],
			IndentedTypeName = convert(nvarchar(128), [type_name]), 
			GroupNumber = parent_type, 
			TypeNumber = [type], 
			[Level] = 1, 
			[sort] = convert(nvarchar(128),[type_name])  
		from 
			[Z0].trigger_event_types   
		where 
			parent_type is null 
    
		union ALL  
    
		select
			TypeName = e.[type_name],
			IndentedTypeName = convert(nvarchar(128), replicate ('|   ' , [Level]) + e.[type_name]),  
			GroupNumber = e.parent_type, 
			TypeNumber = e.[type], 
			[Level] = d.[Level] + 1,  
			[sort] = convert(nvarchar(128), RTRIM(sort) + '|   ' + e.[type_name])  
		from 
			[Z0].trigger_event_types  e  
				inner join TriggerEventTypes d on 
					e.parent_type = d.[TypeNumber]
	)  
	select top(1000)
		TypeNumber, 
		TypeName = TypeName collate database_default,
		GroupNumber, 
		[Level],
		IndentedTypeName = IndentedTypeName collate database_default  
	from
		TriggerEventTypes  
	order by
		sort;  


GO
create view [Z0].[SqlCollation] as
	select 
		[CollationName] = [name],
		[CollationDescription] = [description],
		IsSqlCollation = cast(case when [name] like 'SQL%' then 1 else 0 end as bit)
	from 
		sys.fn_helpcollations() 
	where
		[name] like 'SQL%'

GO


create view [Z0].[AvailableCollation] as
	select 
		[CollationName] = [name],
		[CollationDescription] = [description],
		IsSqlCollation = cast(case when [name] like 'SQL%' then 1 else 0 end as bit)

	from 
		sys.fn_helpcollations() 

GO

create view [Z0].[FileTableDescription] as
	select 	
		ServerName = [Z0].server_name(),
		DatabaseName = [Z0].db_name(),
		TableSchema =  [Z0].schema_name(T.[schema_id]),
		TableName = [Z0].object_name(T.[object_id]),
		UncPath = [Z0].FileTableRootPath
			(concat(
				'[',
				[Z0].schema_name(T.[schema_id]),
				'].[',
				[Z0].object_name(T.[object_id]),
				']'
				)
			),
		DirectoryName = F.directory_name		
	 from 
		[Z0].tables T  
			inner join [Z0].filetables F on 
				F.[object_id] = T.[object_id]
	where 
		T.is_filetable = 1
GO


create function [Z0].[GetTableStats]() returns table as return
	select 
		x.ServerName, 
		x.CatalogName, 
		x.SchemaName, 
		x.TableName, 
		RecordCount = cast(x.RecordCount as bigint),
		DataStorage = cast(x.[DataStorage (MB)] as bigint), 
		IndexStorage = cast(x.[IndexStorage (MB)] as bigint), 
		TotalStorage = cast(x.[Total Storage (MB)] as bigint) 
	from 
		[Z0].[TableStats] x

GO
execute sp_addextendedproperty 
	@name = N'DM_RecordType', 
	@value = N'[Z0].[TableStatsRecord]', 
	@level0type = N'SCHEMA', 
	@level0name = N'Z0', 
	@level1type = N'FUNCTION', 
	@level1name = N'GetTableStats';

GO
execute sp_addextendedproperty 
	@name = N'DM_RecordType', 
	@value = N'[Z0].[QueryDescriptor]', 
	@level0type = N'SCHEMA', 
	@level0name = N'Z0', 
	@level1type = N'FUNCTION', 
	@level1name = N'DescribeRecentQueries';

GO

create view [Z0].[SequenceDescription] as
	select 
		ServerName = [Z0].[server_name]() collate database_default,
		CatalogName = [Z0].[db_name]() collate database_default,
		SchemaName = s.[name] collate database_default,
		SequenceName = seq.[name] collate database_default,
		DataType = t.[name] collate database_default,
		StartValue = seq.start_value,
		CurrentValue = current_value 		
	from [Z0].[sequences] seq
		inner join [Z0].[schemas] s on
			s.[schema_id] = seq.[schema_id]
		inner join [Z0].[types] t on 
			t.system_type_id = seq.system_type_id
GO


create function [Z0].[CalcRenameIndexRefactorStep](@Selection [Z0].[RenameIndexSelection] readonly)
	returns table as return
	select StepExec = concat
	(
		'exec [Z0].[DefineRenameIndexRefactorStep]', ' ',
		'@TableName=', '''', TableName, '''',', ',
		'@OldIndexName=', '''', OldIndexName, '''',', ',
		'@NewIndexName=', '''', NewIndexName, '''', char(13), char(10)
	)  
	from 
		@Selection
GO


create procedure [Z0].[DefineRenameIndexRefactorSteps](@RenameIndexSelection [Z0].[RenameIndexSelection] readonly) as
	with Steps as
	(
		select 
			OperationName = 'Rename Refactor',
			[Key] = newid(),
			ChangeDateTime = cast(getdate() as datetime2(0)),
			ElementName = concat(TableName, '.[',OldIndexName,']'),
			ElementType = 'SqlIndex',
			ParentElementName = TableName,
			ParentElementType = 'SqlTable',
			[NewName] = NewIndexName
		from 
			@RenameIndexSelection
	)
	select 
	concat
	(
		'<Operation Name="',OperationName,'" Key="', [Key], '" ChangeDateTime="',ChangeDateTime,'">', char(13), char(10),
		'  <Property Name="ElementName" Value="', ElementName, '"/>', char(13), char(10),
		'  <Property Name="ElementType" Value="', ElementType, '"/>', char(13), char(10),
		'  <Property Name="ParentElementName" Value="', ParentElementName, '"/>', char(13), char(10),
		'  <Property Name="ParentElementType" Value="', ParentElementType, '"/>', char(13), char(10),
		'  <Property Name="NewName" Value="', [NewName], '"/>', char(13), char(10),
		'</Operation>'
	)
	 
	from Steps
GO

create procedure [Z0].[DefineSchemaRefactorOp]
(
	@OldSchema sysname,
	@NewSchema sysname,
	@Operation varchar(50),
	@ElementType varchar(50)
) as
	with Steps as
	(
		select 
			ObjectSchema = s.[name],	
			OperationName = @Operation,
			[Key] = newid(),
			ChangeDateTime = cast(getdate() as datetime2(0)),
			ElementName = concat('[', s.[name],'].[',o.[name], ']'),
			ElementType = @ElementType,
			NewSchema = @NewSchema,
			IsNewSchemaExternal = 'False'
		from 
			sys.objects o 
				inner join sys.schemas s on 
					o.[schema_id] = s.[schema_id]
		where
			s.[name] = @OldSchema
		and o.[type] = case @ElementType
						when 'SqlTable' then 'U'
						when 'SqlView' then 'V'
						when 'SqlProcedure' then 'P'
						end
	)
	select 
		concat
		(
			'<Operation Name="',OperationName,'" Key="', [Key], '" ChangeDateTime="',ChangeDateTime,'">', char(13), char(10),
			'  <Property Name="ElementName" Value="', ElementName, '"/>', char(13), char(10),
			'  <Property Name="ElementType" Value="', ElementType, '"/>', char(13), char(10),
			'  <Property Name="NewSchema" Value="', NewSchema, '"/>', char(13), char(10),
			'  <Property Name="IsNewSchemaExternal" Value="', IsNewSchemaExternal, '" />', char(13), char(10),
			'</Operation>'
		)
	 
	from Steps


GO

