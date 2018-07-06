create table [systems].[table_index_columns]
(
	systems_key int not null 
		constraint DF_table_index_columns_key 
			default (next value for [systems].[table_index_columns_key]),
	systems_server_name sysname not null,
	systems_database_name sysname not null,
	systems_schema_name sysname not null,
	systems_parent_name sysname not null,
	systems_parent_type char(2) not null,
	systems_column_name sysname not null,
	systems_index_name sysname not null,
	[object_id] [int] not null,
	[index_id] [int] not null,
	[index_column_id] [int] not null,
	[column_id] [int] not null,
	[key_ordinal] [tinyint] not null,
	[partition_ordinal] [tinyint] not null,
	[is_descending_key] [bit] NULL,
	[is_included_column] [bit] NULL,
	as_of datetime2(3) not null 
		constraint DF_table_index_columns_as_of default (getdate()),
	
	constraint PK_table_index_columns primary key(systems_key),
	constraint UQ_table_index_columns 
		unique
		(
			systems_server_name, 
			systems_database_name, 
			systems_schema_name, 
			systems_parent_name, 
			systems_parent_type, 
			systems_index_name, 
			systems_column_name
		),
	constraint FK_table_index_columns_table_index 
		foreign key
		(
			systems_server_name, 
			systems_database_name, 
			systems_schema_name, 
			systems_parent_name, 
			systems_parent_type, 
			systems_index_name
		)
		references [systems].[table_indexes]
		(

			systems_server_name, 
			systems_database_name, 
			systems_schema_name, 
			systems_parent_name, 
			systems_parent_type, 
			name
		)
		on delete cascade on update cascade
	
)
GO
create sequence [systems].[table_index_columns_key] 
	as int start with 1 cache 100