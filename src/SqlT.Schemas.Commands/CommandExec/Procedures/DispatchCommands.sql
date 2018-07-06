create procedure [CommandExec].DispatchCommands(@CommandName nvarchar(250), @MaxCount int) as
begin

	set nocount on
	set xact_abort on
	
	declare @Insertions table
	(
		SubmissionId bigint,
		CommandName nvarchar(250) not null,
		CommandSpecName nvarchar(500) null,	
		CommandJson nvarchar(max) null,
		CorrelationToken nvarchar(50) null,
		EnqueuedTime datetime2(3) not null,
		DispatchTime datetime2(3) not null
	)
	
	begin transaction


		insert [CommandExec].[CommandDispatch]
			(
				SubmissionId, 
				CommandName, 
				CommandSpecName, 
				CommandJson, 
				CorrelationToken, 
				EnqueuedTime
			)
		output 
			inserted.SubmissionId,
			inserted.CommandName,
			inserted.CommandSpecName,
			inserted.CommandJson,
			inserted.CorrelationToken,
			inserted.EnqueuedTime,
			inserted.DispatchTime
		into @Insertions	
		
		select top(@MaxCount)
			c.SubmissionId,		
			c.CommandName,
			c.CommandSpecName,
			c.CommandJson,
			c.CorrelationToken,
			c.EnqueuedTime
		from 
			[CommandExec].[CommandSubmission] c 
		where CommandName  = coalesce(@CommandName, c.CommandName)
	
		delete 
			[CommandExec].[CommandSubmission] 
		where 
			SubmissionId in (select SubmissionId from @Insertions);
	
	
		declare @Summaries [CommandExec].[CommandSummary]
		insert into @Summaries
		(
			SubmissionId, 
			CommandName, 
			CommandSpecName, 
			CommandJson, 
			CorrelationToken, 
			EnqueuedTime,
			DispatchTime
		)
		select 
			i.SubmissionId,
			i.CommandName,
			i.CommandSpecName,
			i.CommandJson,
			i.CorrelationToken,
			i.EnqueuedTime,
			i.DispatchTime
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
    @level1name = N'DispatchCommands'
GO
