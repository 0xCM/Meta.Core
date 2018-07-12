create table [PF].[SystemEventRegistry]
(
	SystemKey int not null 
		constraint DF_SystemEventRegistry_SystemKey 
			default(next value for [PF].[SystemKeySequence]),	
	SystemId nvarchar(75) not null,
	MessageName nvarchar(128) not null,
	Purpose nvarchar(250) null, 	
	CreateTS datetime2(0) not null 
		constraint DF_SystemEventRegistry_CreateTS default(getdate()),
	UpdateTS datetime2 (0) null,

	constraint PK_SystemEventRegistry primary key(SystemKey),
	constraint UQ_SystemEventRegistry unique(SystemId,MessageName)
)
GO


create trigger [PF].[SystemEventRegistryUpdated] 
	on [PF].[SystemEventRegistry] after update as
		update [PF].[SystemEventRegistry] set 
			UpdateTS = getdate()
	from 
		[PF].[SystemEventRegistry] x 
			inner join inserted on 
				inserted.SystemKey = x.SystemKey
GO
