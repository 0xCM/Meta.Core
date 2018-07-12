create type [WF].[CommandSpecifier] as table
(
	CommandName nvarchar(128) not null,
	TargetNodeId nvarchar(75) not null,
	TargetSystem nvarchar(75) not null,
	CorrelationToken nvarchar(250) null
)
