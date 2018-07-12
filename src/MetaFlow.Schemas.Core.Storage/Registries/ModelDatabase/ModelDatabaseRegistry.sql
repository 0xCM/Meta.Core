--Defines model database deployments
create table [PF].[ModelDatabaseRegistry]
(
	SystemKey bigint not null 
		constraint DF_ModelDatabaseRegistry_SystemKey default(next value for [PF].[SystemKeySequence]),
	NodeId nvarchar(75) not null,
	DatabaseName nvarchar(75) not null,
	DatabaseType nvarchar(75) not null,
	CreateTS datetime2(0) not null 
		constraint DF_ModelDatabaseRegistry_CreateTS default(getdate()),
	UpdateTS datetime2 (0) null,
	
	constraint PK_ModelDatabaseRegistry primary key(SystemKey),
	constraint UQ_ModelDatabaseRegistry unique(NodeId, DatabaseName)

)
GO
create trigger [PF].[OnModelDatabaseRegistryUpdated] 
	on [PF].[ModelDatabaseRegistry] after update as
		update [PF].[ModelDatabaseRegistry] set 
			UpdateTS = getdate()
	from 
		[PF].[ModelDatabaseRegistry] x 
			inner join inserted on 
				inserted.SystemKey = x.SystemKey
GO



	