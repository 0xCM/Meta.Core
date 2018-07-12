create type [WF].[AgentStatus] as table
(
	HostId nvarchar(75) not null,
	SystemId nvarchar(75) not null,
	AgentId nvarchar(75) not null,
	AgentState nvarchar(75) not null,
	StatusSummary nvarchar(4000) null
)
