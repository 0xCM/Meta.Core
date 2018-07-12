create table [PF].[SystemProxyDefinition]
(
	SystemKey bigint not null 
		constraint DF_SystemProxyDefinition_SystemKey default(next value for [PF].[SystemKeySequence]),
	AssemblyDesignator nvarchar(75) not null,
	SystemId nvarchar(75) not null,
	ProfileName nvarchar(75) not null,
	SourceNode nvarchar(75) not null,
	SourceDatabase nvarchar(128),
	TargetAssembly nvarchar(128),
	ProfileText nvarchar(max) not null 
		constraint CK_SystemProxyDefinition_ProfileText check(isjson(ProfileText)>0),    
	CreateTS  datetime2(0) not null
		constraint DF_SystemProxyDefinition_CreateTS default (getdate()),
	UpdateTS  datetime2(0) null,


	constraint PK_SystemProxyDefinition  primary key(SystemKey),
	constraint UQ_SystemProxyDefinition unique(AssemblyDesignator,ProfileName),
	constraint FK_SystemProxyDefinition_DatabaseServer 
		foreign key(SourceNode) references [PF].[DatabaseServerRegistry](SqlNodeId),
	
	constraint FK_SystemProxyDefinigion_PlatformSystem foreign key(SystemId)
		references [PF].[PlatformSystemRegistry](SystemId)
			on delete cascade
			on update cascade
)

GO


create trigger [PF].[OnSystemProxyDefinitionUpdated] 
	on [PF].[SystemProxyDefinition] after update as
		update [PF].[SystemProxyDefinition] set 
			UpdateTS = getdate()
		from 
			[PF].[SystemProxyDefinition] x 
		inner join 
			inserted on x.SystemKey = x.SystemKey
GO

		