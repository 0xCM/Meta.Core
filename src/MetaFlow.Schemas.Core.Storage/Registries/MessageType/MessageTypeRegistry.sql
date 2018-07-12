create table [PF].[MessageTypeRegistry]
(
	SystemKey bigint not null 
		constraint DF_MessageType_SystemKey default(next value for [PF].[SystemKeySequence]),
	SystemId nvarchar(75) not null,
	SchemaName nvarchar(128) not null,
	TypeName nvarchar(128) not null,
	MessageClass nvarchar(75) not null,
	[Description] nvarchar(250) null,

 	CreateTS datetime2(0) not null 
		constraint DF_MessageType_CreateTS default(getdate()),
	UpdateTS datetime2 (0) null,
	
	constraint PK_MessageType primary key(SystemKey),
	constraint UQ_MessageType unique(SchemaName,TypeName),
	constraint UQ_MessageType_System unique(SystemId, TypeName),
	constraint FK_MessageTypeRegistry_MessageClass foreign key(MessageClass)
		references [PF].[MessageClass](Identifier),
	constraint FK_MessageTypeRegistry_System foreign key(SystemId)
		references [PF].[PlatformSystemRegistry](SystemId)
)

GO

create trigger [PF].[OnMessageTypeUpdated] 
	on [PF].[MessageTypeRegistry] after update as
		update [PF].[MessageTypeRegistry] set 
			UpdateTS = getdate()
	from 
		[PF].[MessageTypeRegistry] x 
			inner join inserted on 
				inserted.SystemKey = x.SystemKey

GO

