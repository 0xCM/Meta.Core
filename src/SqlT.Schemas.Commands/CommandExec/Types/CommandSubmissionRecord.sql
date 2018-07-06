create type [CommandExec].[CommandSubmissionRecord] as table
(	
	SubmissionId bigint not null,
	CommandName nvarchar(250) not null,
	CommandSpecName nvarchar(500) null,
	CommandJson nvarchar(max) not null,
	CorrelationToken nvarchar(50) null
	 
)
GO
