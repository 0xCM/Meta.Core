create table [systems].[table_columns]
(
	systems_key int not null 
		constraint DF_columns_key 
			default (next value for [systems].[columns_key]),
	systems_server_name sysname not null,
	systems_database_name sysname not null,
	systems_schema_name sysname not null,
	systems_parent_name sysname not null,
	systems_parent_type char(2) not null,
	[object_id] [int] not null,
	[name] [sysname] NULL,
	[column_id] [int] not null,
	[system_type_id] [tinyint] not null,
	[user_type_id] [int] not null,
	[max_length] [smallint] not null,
	[precision] [tinyint] not null,
	[scale] [tinyint] not null,
	[collation_name] [sysname] NULL,
	[is_nullable] [bit] NULL,
	[is_ansi_padded] [bit] not null,
	[is_rowguidcol] [bit] not null,
	[is_identity] [bit] not null,
	[is_computed] [bit] not null,
	[is_filestream] [bit] not null,
	[is_replicated] [bit] NULL,
	[is_non_sql_subscribed] [bit] NULL,
	[is_merge_published] [bit] NULL,
	[is_dts_replicated] [bit] NULL,
	[is_xml_document] [bit] not null,
	[xml_collection_id] [int] not null,
	[default_object_id] [int] not null,
	[rule_object_id] [int] not null,
	[is_sparse] [bit] NULL,
	[is_column_set] [bit] NULL,
	as_of datetime2(3) not null constraint DF_table_columns_as_of default (getdate()),

	constraint PK_table_columns primary key(systems_key),
	
	constraint UQ_table_columns 
		unique
		(
			systems_server_name, 
			systems_database_name, 
			systems_schema_name, 
			systems_parent_name, 
			systems_parent_type, 
			name
		),
	
	constraint FK_table_columns_tables 
		foreign key (systems_server_name, systems_database_name, systems_schema_name, systems_parent_name)
		references [systems].[tables](systems_server_name, systems_database_name, systems_schema_name, name)
			on delete cascade on update cascade		
) 
GO
create sequence [systems].[columns_key] 
	as int start with 1 cache 100
GO

