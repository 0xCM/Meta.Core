create type [WF].[TaskArchive] as table
(
	TaskId bigint not null,
	SubmittedTS datetime2(0) not null,
	Dispatched bit not null,
	DispatchTS datetime2(0) null,
	Completed bit not null,
	CompleteTS datetime2(0) null,
	Succeeded bit not null,
	ResultDescription nvarchar(max) null,
	CorrelationToken nvarchar(250) null	
)

	
