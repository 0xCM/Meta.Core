create table [PF].[PlatformShareDefinition]
(
	SystemKey bigint not null 
		constraint DF_PlatformShare_SystemKey default(next value for [PF].[SystemKeySequence]),
	HostId nvarchar(75) not null,
	ShareType nvarchar(75) not null,
	ShareName nvarchar(75) not null,
	HostPath nvarchar(250) not null,
	UserName nvarchar(128) null,
	UserPass nvarchar(128) null,
	CreateTS datetime2(0) not null 
		constraint DF_PlatformShare_CreateTS default(getdate()),
	UpdateTS datetime2 (0) null,
	
	constraint CK_PlatformShare_ShareType check([PF].[PlatformShareTypeExists](ShareType) = 1),
	constraint PK_PlatformShare primary key(SystemKey),
	constraint UQ_PlatformShare unique(HostId, ShareType),
	constraint FK_PlatformShare_PlatformServer foreign key(HostId)
		references [PF].[PlatformServerRegistry](NodeId)
	


)
GO


