create table [PF].[SystemCommandRegistry]
(	
	SystemKey bigint not null 
		constraint DF_SystemCommandRegistry_SystemKey 
			default(next value for [PF].[SystemKeySequence]),
	SystemId nvarchar(75) not null,
	MessageName nvarchar(128) not null,
	Purpose nvarchar(250) null, 
	CreateTS datetime2(0) not null 
		constraint DF_SystemCommandRegistry_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,
	constraint PK_SystemCommandRegistry primary key(SystemKey),
	constraint UQ_SystemCommandRegistry unique(SystemId,MessageName),
	
	constraint FK_SystemCommandRegistry_PlatformSystem foreign key(SystemId)
		references [PF].[PlatformSystemRegistry](SystemId)

)
GO
create trigger [PF].[SystemCommandRegistryUpdated] 
	on [PF].[SystemCommandRegistry] after update as
		update [PF].[SystemCommandRegistry] set 
			UpdateTS = getdate()
	from 
		[PF].[SystemCommandRegistry] x 
			inner join inserted on 
				inserted.SystemKey = x.SystemKey
