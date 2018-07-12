create procedure [WF].[SubmitSystemCommand]
(
	@SourceNodeId nvarchar(75), 
	@TargetNodeId nvarchar(75), 
	@TargetSystemId nvarchar(75), 
	@CommandUri nvarchar(75),
	@CommandBody nvarchar(max),
	@CorrelationToken nvarchar(250)
) as	


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
		@SourceNodeId,
		@TargetNodeId,
		@TargetSystemId,
		@CommandUri,
		@CommandBody,
		@CorrelationToken
	
	select * from @Tasks

GO

exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[WF].[SystemTask]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Procedure',
    @level1name = N'SubmitSystemCommand',
    @level2type = NULL,
    @level2name = NULL
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[EnqueueOperator]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Procedure',
    @level1name = N'SubmitSystemCommand',
    @level2type = NULL,
    @level2name = NULL
