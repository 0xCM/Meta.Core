create table [systems].[types]
(
	systems_key int not null constraint DF_types_key default (next value for [systems].[types_key]),
	systems_server_name sysname not null,
	systems_database_name sysname not null,
	systems_schema_name sysname not null,
	[name] sysname not null,
	system_type_id tinyint not null,
	user_type_id [int] not null,
	[schema_id] [int] not null,
	[principal_id] [int] NULL,
	[max_length] [smallint] not null,
	[precision] tinyint not null,
	scale tinyint not null,
	collation_name sysname NULL,
	is_nullable bit NULL,
	is_user_defined bit not null,
	is_assembly_type bit not null,
	default_object_id [int] not null,
	rule_object_id [int] not null,
	[is_table_type] bit not null,
	as_of datetime2(3) not null constraint DF_types_as_of default (getdate()),
	
	constraint PK_types primary key(systems_key),
	constraint UQ_types unique(systems_server_name, systems_database_name, systems_schema_name, name),
	constraint FK_types_schemas foreign key(systems_server_name, systems_database_name, systems_schema_name) 
		references systems.schemas(systems_server_name, systems_database_name, name)
			on delete cascade on update cascade
)
GO
create sequence [systems].[types_key] 
	as int start with 1 cache 100
go

