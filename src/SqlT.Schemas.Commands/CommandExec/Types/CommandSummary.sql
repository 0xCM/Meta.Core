create type [CommandExec].[CommandSummary] as table
(
	SubmissionId bigint  not null primary key nonclustered,
	CommandName nvarchar(250) not null,
	CommandSpecName nvarchar(500) not null,	
	CommandJson nvarchar(max) not null,
	CorrelationToken nvarchar(50) null,
    EnqueuedTime datetime2(3) not null,
	DispatchTime datetime2(3) null,
	CompleteTime datetime2(3) null,
	Succeeded bit null,
	ResultMessage varchar(MAX) null
)
GO
