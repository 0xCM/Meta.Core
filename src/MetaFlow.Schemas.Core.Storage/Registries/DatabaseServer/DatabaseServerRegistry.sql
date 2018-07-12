create table [PF].[DatabaseServerRegistry]
(
	SystemKey bigint not null 
		constraint DF_DatabaseServerRegistry_SystemKey 
			default(next value for [PF].[SystemKeySequence]),
	HostId nvarchar(75) not null,
	SqlNodeId nvarchar(75) not null,
	SqlInstanceName nvarchar(128) not null,
	SqlInstancePort int null,
	SqlAlias nvarchar(75) not null,
	AliasProtocal nvarchar(15) null,
	AliasConnector nvarchar(250) null,
	FileStreamRoot nvarchar(250) null,
	DefaultDataDir nvarchar(250) null,
	DefaultLogDir nvarchar(250) null,
	DefaultBackupDir nvarchar(250) null,
	AdminLogDir nvarchar(250) null,
	SqlOperatorName nvarchar(128) null,
	SqlOperatorPass nvarchar(128) null,
	CreateTS  datetime2(0) not null
		constraint DF_DatabaseServerRegistry_CreateTS default (getdate()),
	UpdateTS  datetime2(0) null,	
	
	constraint PK_DatabaseServerRegistry primary key(HostId, SqlInstanceName),
	constraint UQIX_DatabaseServerRegistry_SqlNodeId unique(SqlNodeId),
	constraint UQIX_DatabaseServerRegistry_SqlAlias unique(SqlAlias),
	
	constraint FK_DatabaseServerRegistry_PlatformNode foreign key(HostId) 
		references [PF].[PlatformServerRegistry](NodeId) 
			on delete cascade
			on update cascade
)
GO

create trigger [PF].[OnDatabaseServerRegistryUpdated] 
	on [PF].[DatabaseServerRegistry] after update as
	update [PF].[DatabaseServerRegistry] set 
		UpdateTS = getdate()
	from 
		[PF].[DatabaseServerRegistry] x 
			inner join inserted on 
				inserted.SystemKey = x.SystemKey
