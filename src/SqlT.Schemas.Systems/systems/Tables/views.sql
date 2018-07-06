create table [systems].[views]
(
	[systems_key] int not null 
		constraint DF_views_key 
			default (next value for [systems].[views_key]),
	systems_server_name sysname not null,
	systems_database_name sysname not null,
	systems_schema_name sysname not null,
	[name] [sysname] not null,
	[object_id] int not null,
	principal_id int NULL,
	[schema_id] int not null,
	[parent_object_id] int not null,
	[type] [char](2) NULL,
	[type_desc] [nvarchar](60) NULL,
	create_date datetime not null,
	[modify_date] [datetime] not null,
	[is_ms_shipped] [bit] not null,
	[is_published] [bit] not null,
	[is_schema_published] [bit] not null,
	[is_replicated] [bit] NULL,
	[has_replication_filter] [bit] NULL,
	[has_opaque_metadata] [bit] not null,
	[has_unchecked_assembly_data] [bit] not null,
	[with_check_option] [bit] not null,
	[is_date_correlation_view] [bit] not null,
	[is_tracked_by_cdc] [bit] NULL,

	as_of datetime2(3) not null constraint DF_views_as_of default (getdate()),

	constraint PK_views primary key(systems_key),
	constraint UQ_views unique([systems_server_name], systems_database_name, systems_schema_name, name),
	constraint FK_views_schemas foreign key(systems_server_name, systems_database_name, systems_schema_name) 
		references systems.schemas(systems_server_name, systems_database_name, name)
			on delete cascade on update cascade

) 
GO
create sequence [systems].[views_key] 
	as int start with 1 cache 100
GO

