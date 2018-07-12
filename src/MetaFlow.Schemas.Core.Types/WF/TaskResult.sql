create type [WF].[TaskResult] as table
(
	TaskId bigint not null,
	Succeeded bit not null,
	ResultDescription nvarchar(max) null,	
	CorrelationToken nvarchar(250) null	
	
)

	
