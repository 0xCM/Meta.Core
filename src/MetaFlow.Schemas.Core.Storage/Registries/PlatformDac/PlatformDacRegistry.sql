create table [PF].[PlatformDacRegistry]
(
 	SystemKey bigint not null 
		constraint DF_PlatformDacRegistry_SystemKey 
			default(next value for [PF].[SystemKeySequence]),

	SystemId nvarchar(75) not null,
	PackageName nvarchar(75) not null,
	ComponentId nvarchar(75) not null,	
	ComponentVersion nvarchar(75) not null,
	ComponentTS datetime2(0) not null,

	CreateTS datetime2(0) not null 
		constraint DF_PlatformDacRegistry_CreateTS default(getdate()),
	UpdateTS datetime2 (0) null,

	constraint PK_PlatformDacRegistry primary key(SystemKey),
	constraint UQ_PlatformDacRegistry unique(PackageName),
	constraint FK_PlatformDacRegistry_PlatformSystem foreign key(SystemId)
		references [PF].[PlatformSystemRegistry](SystemId)
			on delete cascade
			on update cascade


)

	
