create type [WF].[Task] as table
(
	TaskId bigint not null,

	CorrelationToken nvarchar(250) null	
	
)

	
