create table [systems].[schemas]
(
	systems_key int not null 
		constraint DF_schemas_key default 
			(next value for [systems].[schemas_key]),
	systems_server_name sysname not null,
	systems_database_name sysname not null,
	[name] sysname not null,
	[schema_id] [int] NOT NULL,
	[principal_id] [int] NULL,
	as_of datetime2(3) not null constraint DF_schemas_as_of default (getdate())
	constraint PK_schemas primary key(systems_key),
	constraint UQ_schemas unique([systems_server_name], systems_database_name, name),
	constraint FK_schemas_databases foreign key(systems_server_name, systems_database_name) 
		references systems.databases(systems_server_name, name)
			on delete cascade on update cascade

) 
GO
create sequence [systems].[schemas_key] as int start with 1 cache 100
GO

