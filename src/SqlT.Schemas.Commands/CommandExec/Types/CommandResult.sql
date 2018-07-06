create type [CommandExec].CommandResult as table
(
	SubmissionId bigint  not null primary key nonclustered,
	Succeeded bit not null,
	ResultMessage nvarchar(MAX)
)
