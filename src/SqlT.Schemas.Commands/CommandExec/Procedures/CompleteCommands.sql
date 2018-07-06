CREATE PROCEDURE [CommandExec].HistorizeCommands(@Completions [CommandExec].CommandResult readonly) as
begin

	set nocount on
	set xact_abort on
	begin transaction

	declare @Insertions table
	(
		SubmissionId bigint,
		CommandName nvarchar(250) not null,
		CommandSpecName nvarchar(500) null,	
		CommandJson nvarchar(max) null,
		CorrelationToken nvarchar(50) null,
		EnqueuedTime datetime2(3) not null,
		DispatchTime datetime2(3) not null,
		CompleteTime datetime2(3) not null,
		Suceeded bit not null,
		ResultMessage nvarchar(MAX)	
	)

	insert [CommandExec].[CommandHistory](SubmissionId, CommandName, CommandSpecName, CommandJson, CorrelationToken, EnqueuedTime, DispatchTime, Succeeded, ResultMessage)
		output 
			inserted.SubmissionId,
			inserted.CommandName,
			inserted.CommandSpecName,
			inserted.CommandJson,
			inserted.CorrelationToken,
			inserted.EnqueuedTime,
			inserted.DispatchTime,
			inserted.CompleteTime,
			inserted.Succeeded,
			inserted.ResultMessage
		into @Insertions
	select
		c.SubmissionId,
		d.CommandName,
		d.CommandSpecName,
		d.CommandJson,
		d.CorrelationToken,
		d.EnqueuedTime,
		d.DispatchTime,
		c.Succeeded,
		c.ResultMessage
	from 
		@Completions c inner join  [CommandExec].[CommandDispatch] d on d.SubmissionId = c.SubmissionId

	delete [CommandExec].[CommandDispatch] where SubmissionId in (select SubmissionId from @Insertions);
	
	declare @Summaries [CommandExec].[CommandSummary]
	insert into @Summaries
	(
		SubmissionId, 
		CommandName, 
		CommandSpecName, 
		CommandJson, 
		CorrelationToken,
		EnqueuedTime,
		DispatchTime,
		CompleteTime,
		Succeeded,
		ResultMessage
	)
	select 
		i.SubmissionId,
		i.CommandName,
		i.CommandSpecName,
		i.CommandJson,
		i.CorrelationToken,
		i.EnqueuedTime,
		i.DispatchTime,
		i.CompleteTime,
		i.Suceeded,
		i.ResultMessage
	from @Insertions i 

	commit transaction

	select * from @Summaries		
end
GO

EXEC sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[CommandExec].[CommandSummary]',
    @level0type = N'SCHEMA',
    @level0name = N'CommandExec',
    @level1type = N'Procedure',
    @level1name = N'HistorizeCommands'
GO
