create table [systems].[servers]
(
	systems_key int not null 
		constraint DF_servers_key default 
			(next value for systems.servers_key),
	systems_server_name sysname not null,
	server_id int not null,
	[name] sysname not null,
	product sysname not null,
	[provider] sysname not null,
	[data_source] nvarchar(4000) NULL,
	[location] nvarchar(4000) NULL,
	provider_string nvarchar(4000) NULL,
	[catalog] sysname NULL,
	connect_timeout int NULL,
	query_timeout int NULL,
	is_linked bit not null,
	is_remote_login_enabled bit not null,
	is_rpc_out_enabled bit not null,
	is_data_access_enabled bit not null,
	is_collation_compatible bit not null,
	uses_remote_collation bit not null,
	collation_name sysname NULL,
	lazy_schema_validation bit not null,
	is_system bit not null,
	is_publisher bit not null,
	is_subscriber bit NULL,
	is_distributor bit NULL,
	is_nonsql_subscriber bit NULL,
	is_remote_proc_transaction_promotion_enabled bit NULL,
	modify_date datetime not null,
	as_of datetime2(3) not null constraint DF_servers_as_of default (getdate()),

	constraint PK_servers primary key(systems_key),
	constraint UQ_servers unique(systems_server_name, server_id),
	constraint UQ_server_host_servers foreign key(systems_server_name) 
		references systems.host_servers(systems_server_name)
			on delete cascade on update cascade

)
GO
create sequence systems.servers_key 
	as int start with 1 cache 100
go

