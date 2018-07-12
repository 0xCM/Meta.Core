create procedure [WF].[DispatchSystemTasksByName](@CommandName nvarchar(75), @MaxCount int = 10) as

	
	set nocount on
	set xact_abort on
	
	declare 
		@LoadTS datetime2(0) = getdate(),
		@LoadCT int = 0,
		@OpName nvarchar(250) = '[WF].[DispatchPlatformTasksByName]',
		@Msg nvarchar(250);

	set @Msg = concat('Executing @OpName=', @OpName, ' @CommandName=', @CommandName,  ' @MaxCount=',  @MaxCount);	
	raiserror(@Msg, 0, 1) with nowait;

	
	declare @Commands [WF].[SystemTask];
		
	with Src as
	(
		select top(@MaxCount) 
			c.*
		from 
			[WF].[SystemTaskQueue] c 
		where 
			Dispatched = 0 	and CommandUri like @CommandName
		order by 
			TaskId
	)
	
	update Src set 
		Src.Dispatched = 1,
		Src.DispatchTS = getdate()
	output 
		inserted.TaskId,
		inserted.SourceNodeId,
		inserted.TargetNodeId,
		inserted.TargetSystemId,
		inserted.CommandUri,
		inserted.CommandBody,
		inserted.SubmittedTS,
		inserted.DispatchTS,
		inserted.CorrelationToken

	into @Commands
	(
		TaskId,
		SourceNodeId,
		TargetNodeId,
		TargetSystemId,
		CommandUri,
		CommandBody,
		SubmittedTS,
		DispatchTS,
		CorrelationToken
	);

	set @LoadCT = @@ROWCOUNT;
	set @Msg = concat('Executed @OpName=', @OpName, ' @LoadCT=', @LoadCT);	
	raiserror(@Msg, 0, 1) with nowait;
	
	select * from @Commands

	return @LoadCT;

GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[WF].[SystemTask]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Procedure',
    @level1name = N'DispatchSystemTasksByName'
GO

exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[DequeueOperator]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Procedure',
    @level1name = N'DispatchSystemTasksByName',
    @level2type = NULL,
    @level2name = NULL
