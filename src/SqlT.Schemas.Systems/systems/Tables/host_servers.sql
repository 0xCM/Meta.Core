create table [systems].[host_servers]
(
	systems_key int not null 
		constraint DF_host_servers_key 
			default (next value for [systems].[host_servers_key]),
	systems_server_name sysname not null,
	as_of datetime2(3) not null 
		constraint DF_host_servers_as_of default (getdate()),

	constraint PK_host_servers primary key(systems_key),
	constraint UQ_host_servers unique(systems_server_name)


)
GO
create sequence [systems].[host_servers_key] 
	as int start with 1 cache 100
go
