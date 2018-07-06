create type [CommandExec].[CommandOutcome] as table
(
	SubmissionId bigint  not null,
	CommandName nvarchar(250) not null,
	DispatchTime datetime2(3) null,
	CompleteTime datetime2(3) null,
	Succeeded bit null,
	ResultMessage varchar(MAX) null
)
GO
