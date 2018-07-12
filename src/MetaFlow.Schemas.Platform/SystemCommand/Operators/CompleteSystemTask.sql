create procedure [WF].[CompleteSystemTask]
(
	@TaskId bigint, 
	@Succeeded bit, 
	@ResultBody nvarchar(max) = null,
	@ResultDescription nvarchar(max) = null
) as

	set nocount on
	set xact_abort on
	
	declare 
		@LoadTS datetime2(0) = getdate(),
		@LoadCT int = 0,
		@OpName sysname = object_name(@@procid),
		@Msg nvarchar(250);

	set @Msg = concat('Executing @OpName=', @OpName);	
	raiserror(@Msg, 0, 1) with nowait;
		
	declare @Result [WF].[SystemTaskState];

	update [WF].[SystemTaskQueue] 	
	set
		Completed = 1,
		CompleteTS = getdate(),
		ResultBody = @ResultBody,
		ResultDescription = @ResultDescription,
		Succeeded = @Succeeded
	output 
		
		inserted.TaskId,
		inserted.SourceNodeId,
		inserted.TargetNodeId,
		inserted.TargetSystemId,
		inserted.CommandUri,
		inserted.CommandBody,
		inserted.ResultBody,
		inserted.SubmittedTS,
		inserted.Dispatched,
		inserted.DispatchTS,
		inserted.Completed,
		inserted.CompleteTS,
		inserted.Succeeded,
		inserted.ResultDescription,
		inserted.CorrelationToken
		into @Result
		(
			TaskId,
			SourceNodeId,
			TargetNodeId,
			TargetSystemId,
			CommandUri,
			CommandBody,
			ResultBody,
			SubmittedTS,
			Dispatched,
			DispatchTS,
			Completed,
			CompleteTS,
			Succeeded,
			ResultDescription,
			CorrelationToken
		)
	where
		TaskId = @TaskId;		
	
	set @LoadCT = @@ROWCOUNT;
	set @Msg = concat('Executed @OpName=', @OpName, ' @LoadCT=', @LoadCT);	
	raiserror(@Msg, 0, 1) with nowait;

	select * FROM @Result
	
	return @LoadCT;
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[CompletionOperator]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Procedure',
    @level1name = N'CompleteSystemTask',
    @level2type = NULL,
    @level2name = NULL
go
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[WF].[SystemTaskState]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Procedure',
    @level1name = N'CompleteSystemTask'
GO

