create table [systems].[extended_properties]
(
 	systems_key int not null 
		constraint DF_extened_properties_key default 
			(next value for [systems].[extended_properties_key]),
	systems_server_name sysname not null,
	systems_database_name sysname not null,
	class tinyint not null,
	class_desc nvarchar(120) null,
	major_id int not null,
	minor_id int not null,
	[name] sysname not null,
	[value] sql_variant null,
	as_of datetime2(3) not null 
		constraint DF_extended_properties_as_of default (getdate()),
	constraint PK_extended_properties primary key(systems_key),
	constraint FK_extended_properties_host_servers 
		foreign key(systems_server_name) 
			references systems.host_servers(systems_server_name)
				on delete cascade on update cascade


)
GO
create sequence [systems].[extended_properties_key] 
	as int start with 1 cache 100
	
