create table [PF].[PlatformAgentRegistry]
(	
	SystemKey bigint not null 
		constraint DF_PlatformAgent_SystemKey 
			default(next value for [PF].[SystemKeySequence]),
	SystemId nvarchar(75) not null,
	AgentId nvarchar(75) not null,	
	CreateTS datetime2(0) not null 
		constraint DF_PlatformAgent_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,
	
	constraint PK_PlatformAgent primary key(SystemKey),
	constraint UQ_PlatformAgent unique(AgentId),
	

)
GO
create trigger [PF].[OnPlatformAgentRegistryUpdated] 
	on [PF].[PlatformAgentRegistry] after update as
		update [PF].[PlatformAgentRegistry] set 
			UpdateTS = getdate()
	from 
		[PF].[PlatformAgentRegistry] x 
			inner join inserted on 
				inserted.SystemKey = x.SystemKey
