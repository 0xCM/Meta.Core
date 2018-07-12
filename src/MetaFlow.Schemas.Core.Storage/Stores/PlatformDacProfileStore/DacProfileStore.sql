create table [PF].[DacProfileStore]
(
	SystemKey bigint not null 
		constraint DF_DacProfile_SystemKey 
			default(next value for [PF].[SystemKeySequence]),
	ProfileFileName nvarchar(250) not null,
	SourcePackage nvarchar(75) null,
	TargetServerId nvarchar(75) not null,	
	TargetDatabase nvarchar(128) not null,
	ProfileXml nvarchar(max) not null,
	ProfilePath nvarchar(250) null,	
	CreateTS datetime2(0) not null 
		constraint DF_DacProfile_CreateTS default(getdate()),
	UpdateTS datetime2 (0) null,

	constraint FK_DacProfile_PlatformNode foreign key(TargetServerId)
		references [PF].[DatabaseServerRegistry](SqlNodeId)
			on delete cascade
			on update cascade,

	
	constraint PK_DacProfile primary key(SystemKey),
	constraint UQ_DacProfile unique(ProfileFileName)


)	
GO
create trigger [PF].[DacProfileUpdated] 
	on [PF].[DacProfileStore] after update as
		update [PF].[DacProfileStore] set 
			UpdateTS = getdate()
	from 
		[PF].[DacProfileStore] x 
			inner join inserted on 
				inserted.SystemKey = x.SystemKey
GO



