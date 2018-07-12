create table [PF].[SystemComponentRegistry] 
(
	SystemKey bigint not null 
		constraint DF_SystemComponent_SystemKey 
			default(next value for [PF].[SystemKeySequence]),
	ComponentId nvarchar(75) not null,
	SystemId nvarchar(75) not null,
	ComponentType nvarchar(75) not null,
	ComponentVersion nvarchar(75) null,
	ComponentTS datetime2(0) not null,
	CreateTS datetime2(0) not null 
		constraint DF_SystemComponent_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,
	constraint PK_SystemComponent primary key(SystemKey),
	constraint UQ_SystemComponent unique(ComponentId),
	constraint FK_SystemComponent_PlatformSystem foreign key(SystemId)
		references [PF].[PlatformSystemRegistry](SystemId)
			on delete cascade
			on update cascade

)
GO
create trigger [PF].[SystemComponentUpdated] 
	on [PF].[SystemComponentRegistry] after update as
		update [PF].[SystemComponentRegistry] set 
			UpdateTS = getdate()
	from 
		[PF].[SystemComponentRegistry] x 
			inner join inserted on 
				inserted.SystemKey = x.SystemKey
GO

