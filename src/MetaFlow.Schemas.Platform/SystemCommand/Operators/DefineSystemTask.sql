create procedure [WF].[DefineSystemTask]
(
	@SourceNodeId nvarchar(75), 
	@TargetNodeId nvarchar(75), 
	@TargetSystemId nvarchar(75), 
	@CommandUri nvarchar(75),
	@CommandBody nvarchar(max),
	@CorrelationToken nvarchar(250)
) as	
	
	declare @Definitions [WF].[SystemTaskDefinition];

	insert [WF].[SystemTaskDefinitionStore]
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
		inserted.DefinedTS,
		inserted.Enqueued,
		inserted.EnqueuedTS,
		inserted.CorrelationToken
	into @Definitions	
	(
		TaskId,
		SourceNodeId,
		TargetNodeId,
		TargetSystemId,
		CommandUri,
		CommandBody,
		DefinedTS,
		Enqueued,
		EnqueuedTS,
		CorrelationToken
	)
	select
		@SourceNodeId,
		@TargetNodeId,
		@TargetSystemId,
		@CommandUri,
		@CommandBody,
		@CorrelationToken
	
	select * from @Definitions
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[WF].[SystemTaskDefinition]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Procedure',
    @level1name = N'DefineSystemTask',
    @level2type = NULL,
    @level2name = NULL
GO
