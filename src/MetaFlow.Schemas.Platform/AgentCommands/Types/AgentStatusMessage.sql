create type [WF].[AgentStatusMessage] as table
(
	AgentNodeId nvarchar(75) not null,
	CorrelationToken nvarchar(250) not null,
	AgentId nvarchar(75) not null,
	AgentState nvarchar(75) not null,
	StatusCode nvarchar(75) not null,
	MessageContent nvarchar(250) not null
)
