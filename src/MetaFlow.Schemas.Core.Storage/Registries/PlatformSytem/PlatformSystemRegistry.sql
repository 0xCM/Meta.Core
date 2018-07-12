create table [PF].[PlatformSystemRegistry]
(
	SystemKey bigint not null 
		constraint DF_PlatformSystemRegistry_SystemKey default(next value for [PF].[SystemKeySequence]),
	
	SystemId nvarchar(75) not null,
	Label nvarchar(75) not null,
	CreateTS datetime2(0) not null 
		constraint DF_PlatformSystemRegistry_CreateTS default(getdate()),
	UpdateTS datetime2 (0) null,

	constraint PK_PlatformSystemRegistry primary key(SystemKey),
	constraint UQ_PlatformSystemRegistry unique(SystemId)
)
GO


create trigger [PF].[PlatformSystemRegistryUpdated] 
	on [PF].[PlatformSystemRegistry] after update as
		update [PF].[PlatformSystemRegistry] set 
			UpdateTS = getdate()
	from 
		[PF].[PlatformSystemRegistry] x 
			inner join inserted on 
				inserted.SystemKey = x.SystemKey
