create type [WF].[SystemReaction] as table
(
	EventId uniqueidentifier null,
	SourceNodeId nvarchar(75) not null,
	SourceSystemId nvarchar(75) not null,
	EventUri nvarchar(250) not null,
	StartedTS datetime2(0) not null,
	Completed bit not null,	
	CompleteTS datetime2(0) null,
	Succeeded bit not null,
	ResultDescription nvarchar(max) null

	
)
GO
