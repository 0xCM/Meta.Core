create table [systems].[tables]
(
	systems_key int not null 
		constraint DF_tables_key 
			default (next value for [systems].[tables_key]),
	systems_server_name sysname not null,
	systems_database_name sysname not null,
	systems_schema_name sysname not null,
	[name] [sysname] not null,
	[object_id] int not null,
	principal_id int null,
	[schema_id] int not null,
	parent_object_id int not null,
	[type] char(2) null,
	[type_desc] nvarchar(60) null,
	create_date datetime not null,
	modify_date datetime not null,
	is_ms_shipped bit not null,
	is_published bit not null,
	is_schema_published bit not null,
	lob_data_space_id int not null,
	filestream_data_space_id int null,
	max_column_id_used int not null,
	lock_on_bulk_load bit not null,
	uses_ansi_nulls bit null,
	is_replicated bit null,
	has_replication_filter bit null,
	is_merge_published bit null,
	is_sync_tran_subscribed bit null,
	has_unchecked_assembly_data bit not null,
	text_in_row_limit int null,
	large_value_types_out_of_row bit null,
	is_tracked_by_cdc bit null,
	[lock_escalation] tinyint null,
	[lock_escalation_desc] [nvarchar](60) null,
	[is_filetable] bit null,
	[is_memory_optimized] bit null,
	[durability] tinyint null,
	durability_desc nvarchar(60) null,
	as_of datetime2(3) not null constraint DF_tables_as_of default (getdate()),

	constraint PK_tables primary key(systems_key),
	constraint UQ_tables 
		unique
		(
			systems_server_name, 
			systems_database_name, 
			systems_schema_name, 
			name
		),
	constraint FK_tables_schemas 
		foreign key
		(
			systems_server_name, 
			systems_database_name, 
			systems_schema_name
		) 
		references [systems].[schemas]
		(
			systems_server_name, 
			systems_database_name, 
			name
		)
		on delete cascade on update cascade

) 
GO

create sequence [systems].[tables_key] 
	as int start with 1 cache 100
GO
