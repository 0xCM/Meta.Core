create procedure [CommandExec].[SubmitCommands](@Commands [CommandExec].[CommandSubmissionRecord] readonly) as
begin

	set nocount on

	declare @Insertions table
	(
		SubmissionId bigint,
		CommandName nvarchar(250) not null,
		CommandSpecName nvarchar(500) null,
		CommandJson nvarchar(max) null,
		CorrelationToken nvarchar(50) null,
		EnqueuedTime datetime2(3) not null
	)

	insert [CommandExec].[CommandSubmission](SubmissionId, CommandName, CommandSpecName, CommandJson, CorrelationToken)
		output 
			inserted.SubmissionId,
			inserted.CommandName,
			inserted.CommandSpecName,
			inserted.CommandJson,
			inserted.CorrelationToken,
			inserted.EnqueuedTime
		into @Insertions
	select
		c.SubmissionId, 
		c.CommandName,
		c.CommandSpecName,
		c.CommandJson,
		c.CorrelationToken 
	from 
		@Commands c 

	declare @Summaries [CommandExec].[CommandSummary]
	insert into @Summaries(SubmissionId, CommandName, CommandSpecName, CommandJson, CorrelationToken, EnqueuedTime)
	select 
		r.SubmissionId,
		r.CommandName,
		r.CommandSpecName,
		r.CommandJson,
		r.CorrelationToken,
		r.EnqueuedTime
	from @Insertions r

	select * from @Summaries
end
GO

EXEC sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[CommandExec].[CommandSummary]',
    @level0type = N'SCHEMA',
    @level0name = N'CommandExec',
    @level1type = N'Procedure',
    @level1name = N'SubmitCommands'
GO
