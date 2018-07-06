create table [systems].table_indexes
(
	systems_key int not null constraint DF_indexes_key default (next value for [systems].[table_indexes_key]),
	systems_server_name sysname not null,
	systems_database_name sysname not null,
	systems_schema_name sysname not null,
	systems_parent_name sysname not null,
	systems_parent_type char(2) not null,
	[object_id] [int] NOT null,
	[name] sysname null,
	[index_id] [int] NOT null,
	[type] [tinyint] NOT null,
	[type_desc] [nvarchar](60) null,
	[is_unique] [bit] null,
	[data_space_id] [int] null,
	[ignore_dup_key] [bit] null,
	[is_primary_key] [bit] null,
	[is_unique_constraint] [bit] null,
	[fill_factor] [tinyint] NOT null,
	[is_padded] [bit] null,
	[is_disabled] [bit] null,
	[is_hypothetical] [bit] null,
	[allow_row_locks] [bit] null,
	[allow_page_locks] [bit] null,
	[has_filter] [bit] null,
	[filter_definition] [nvarchar](max) null,
	as_of datetime2(3) not null 
		constraint DF_table_indexes_as_of default (getdate()),
	
	constraint PK_table_indexes primary key(systems_key),
	
	constraint UQ_table_indexes 
		unique
		(
			systems_server_name, 
			systems_database_name, 
			systems_schema_name, 
			systems_parent_name, 
			systems_parent_type, 
			name
		),
	
	constraint FK_table_indexes_tables 
		foreign key
		(
			systems_server_name, 
			systems_database_name, 
			systems_schema_name, 
			systems_parent_name
		)
		references [systems].[tables]
		(
			systems_server_name, 
			systems_database_name, 
			systems_schema_name, 
			name
		) on delete cascade on update cascade
)

GO
create sequence [systems].[table_indexes_key] 
	as int start with 1 cache 100


