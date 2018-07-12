create type [WF].[AgentConfiguration] as table
(
	AgentId nvarchar(75) not null,
	IsEnabled bit not null,
	SpinFrequency int not null
)



