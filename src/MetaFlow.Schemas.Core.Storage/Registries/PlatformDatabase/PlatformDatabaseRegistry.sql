--Defines node deployments
create table [PF].[PlatformDatabaseRegistry]
(
	SystemKey bigint not null 
		constraint DF_PlatformDatabase_SystemKey default(next value for [PF].[SystemKeySequence]),
	ServerId nvarchar(75) not null,
		--constraint DF_PlatformDatabase_ServerId default([PF].[PlatformServerId]()),
	DatabaseName nvarchar(128) not null,
	DatabaseType nvarchar(75) not null,
	IsPrimary bit not null
		constraint DF_PlatformDatabase_IsPrimary default(1),
	IsEnabled bit not null
		constraint DF_PlatformDatabase_IsEnabled default(1),
	IsModel bit not null 
		constraint DF_PlatformDatabase_IsModel default(0),
	IsRestore bit not null
		constraint DF_PlatformDatabase_IsRestore default(0),
	CreateTS datetime2(0) not null 
		constraint DF_PlatformDatabase_CreateTS default(getdate()),
	UpdateTS datetime2 (0) null,
	
	constraint FK_PlatformDatabase_SqlNode foreign key(ServerId)
		references [PF].[DatabaseServerRegistry](SqlNodeId)
			on delete cascade
			on update cascade,

	constraint PK_PlatformDatabase primary key(SystemKey),
	constraint UQ_PlatformDatabase unique(ServerId, DatabaseName)

)
GO
create trigger [PF].[PlatformDatabaseUpdated] 
	on [PF].[PlatformDatabaseRegistry] after update as
		update [PF].[PlatformDatabaseRegistry] set 
			UpdateTS = getdate()
	from 
		[PF].[PlatformDatabaseRegistry] x 
			inner join inserted on 
				inserted.SystemKey = x.SystemKey
GO



	