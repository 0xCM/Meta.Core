create function [WF].[SystemTaskStates]() returns table as return
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
		CorrelationToken		
	from
		[WF].[SystemTaskQueue]
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[WF].[SystemTaskState]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Function',
    @level1name = N'SystemTaskStates',
    @level2type = NULL,
    @level2name = NULL

	
