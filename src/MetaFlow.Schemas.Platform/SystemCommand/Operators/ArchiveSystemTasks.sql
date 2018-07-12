create procedure [WF].[ArchiveSystemTasks](@ResetOutstanding bit, @RetryFailures bit) as

	set xact_abort on
	set nocount on

	declare 
		@ArchiveTS datetime2(0) = getdate(),
		@StepName nvarchar(250) = object_name(@@procid),
		@OpName sysname = object_name(@@procid),
		@Msg nvarchar(250),
		@LoadCT int = 0;
		
	set @Msg = concat('Executing ', @StepName, ' @OpName=',  @OpName);
	raiserror(@Msg, 0, 1) with nowait;
	
	begin transaction
	
		declare @Failures [WF].[SystemTask];

		if @RetryFailures = 1
		begin
			insert @Failures
			(
				SourceNodeId,
				TargetNodeId,
				TargetSystemId,
				CommandUri,
				CommandBody,
				CorrelationToken
			 )
			 select
				SourceNodeId,
				TargetNodeId,
				TargetSystemId,
				CommandUri,
				CommandBody,
				CorrelationToken
				CorrelationToken
			from
				[WF].[SystemTaskQueue] 
			where
				Completed = 1 and Succeeded = 0;

			set @LoadCT = @@ROWCOUNT;
			set @Msg = concat('Retrying ', @LoadCT, ' failures');
			raiserror(@Msg, 0, 1) with nowait;

		end		
		
		declare @Tasks table(TaskId bigint);

		insert [WF].[SystemTaskArchive]
		(
			TaskId, 
			SourceNodeId,
			TargetNodeId,
			TargetSystemId,
			CommandUri,
			CommandBody,
			SubmittedTS, 
			Dispatched,
			DispatchTS,
			Completed,
			CompleteTS,
			Succeeded,
			ResultDescription,
			CorrelationToken,
			ArchivedTS

		)
		output 
			inserted.TaskId into @Tasks			
		select 
			TaskId, 
			SourceNodeId,
			TargetNodeId,
			TargetSystemId,
			CommandUri,
			CommandBody,
			SubmittedTS, 
			Dispatched,
			DispatchTS,
			Completed,
			CompleteTS,
			Succeeded,
			ResultDescription,
			CorrelationToken,
			@ArchiveTS 
		from 
			[WF].[SystemTaskQueue] 
		where 
			Completed = 1;
	

		set @LoadCT = @@ROWCOUNT;
		set @Msg = concat('Archived ', @LoadCT, ' completed tasks');
		raiserror(@Msg, 0, 1) with nowait;

		delete [WF].[SystemTaskQueue] 
			where TaskId in (select TaskId from @Tasks)

		if @ResetOutstanding = 1
		begin

			update [WF].[SystemTaskQueue] 
				set Dispatched = 0, 
					DispatchTS = null 
				where Dispatched = 1;

			set @LoadCT = @@ROWCOUNT;
			set @Msg = concat('Reset ', @LoadCT, ' outstanding tasks');

			raiserror(@Msg, 0, 1) with nowait;

		end
		

		--if @RetryFailures = 1
		--	exec [PF].[SubmitSystemCommands] @Failures

	commit transaction

	set @Msg = concat('Executed ', @OpName);
	raiserror(@Msg, 0, 1) with nowait;
	
	return 0;
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[ArchiveOperator]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Procedure',
    @level1name = N'ArchiveSystemTasks',
    @level2type = NULL,
    @level2name = NULL



