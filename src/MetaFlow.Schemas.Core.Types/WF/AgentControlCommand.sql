create type [WF].[AgentControlCommand] as table
(
	CommandNode nvarchar(75) not null,
	AgentId nvarchar(75) not null
)


