create type [PF].[PlatformAgent] as table
(
	SystemId nvarchar(75) not null,
	AgentId nvarchar(75) not null
)
