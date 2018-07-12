create procedure [WF].[SubmitSystemCommands](@Commands [WF].[SystemCommandSubmission] readonly) as

	set nocount on
	set xact_abort on
	
	declare 
		@LoadTS datetime2(0) = getdate(),
		@LoadCT int = 0,
		@OpName sysname = object_name(@@procid),
		@Msg nvarchar(250);

	set @Msg = concat('Executing @OpName=', @OpName);	
	raiserror(@Msg, 0, 1) with nowait;

	declare @Tasks [WF].[SystemTask];

	insert [WF].[SystemTaskQueue]
	(
		SourceNodeId,
		TargetNodeId,
		TargetSystemId,
		CommandUri,
		CommandBody,
		CorrelationToken
	)
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
	into @Tasks		
	select
		SourceNodeId,
		CommandNode,
		TargetSystemId,
		CommandUri,
		CommandBody,
		CorrelationToken
	from 
		@Commands

	set @LoadCT = @@ROWCOUNT
	set @Msg = concat('Executed @OpName=', @OpName, ' @LoadCT=', @LoadCT);	
	raiserror(@Msg, 0, 1) with nowait;

	select * From @Tasks

	return @LoadCT;

GO

exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[WF].[SystemTask]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Procedure',
    @level1name = N'SubmitSystemCommands',
    @level2type = NULL,
    @level2name = NULL

GO
