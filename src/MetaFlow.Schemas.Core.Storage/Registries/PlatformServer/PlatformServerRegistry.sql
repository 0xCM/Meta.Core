create table [PF].[PlatformServerRegistry]
(	
	SystemKey bigint not null 
		constraint DF_PlatformServer_SystemKey default(next value for [PF].[SystemKeySequence]),
	NodeId nvarchar(75) not null,
	NodeName nvarchar(75) not null,
	HostName nvarchar(128) not null,
	HostIP varchar(16) null,
	NetworkName varchar(128) null,
	WinOperatorName nvarchar(128) null,
	WinOperatorPass nvarchar(128) null,
	CreateTS datetime2(0) not null 
		constraint DF_PlatformServer_CreateTS default(getdate()),
	UpdateTS datetime2 (0) null,
	
	constraint PK_PlatformServer primary key(SystemKey),
	constraint UQ_PlatformServer unique(NodeId),
	constraint UQ_PlatformServer_NodeName unique(NodeName)
	
)
GO
exec sp_addextendedproperty @name = N'MS_Description',
    @value = N'Registry for Windows server hosts, each of which host an arbitrary number of SQL Server instances',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'PlatformServers',
    @level2type = NULL,
    @level2name = NULL

GO

create trigger [PF].[PlatformNodeStoreUpdated] 
	on [PF].[PlatformServerRegistry] after update as
		update [PF].[PlatformServerRegistry] set 
			UpdateTS = getdate()
	from 
		[PF].[PlatformServerRegistry] x 
			inner join inserted on 
				inserted.SystemKey = x.SystemKey
GO


