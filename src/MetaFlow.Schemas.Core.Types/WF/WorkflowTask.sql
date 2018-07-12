create type [WF].[WorkflowTask] as table
(
	TaskId bigint not null,
	CorrelationToken nvarchar(250) null		
)

	
