create function [WF].[PendingSystemTasks]() returns table as return
	
	select
		TaskId,
		SourceNodeId,
		TargetNodeId,
		TargetSystemId,
		CommandUri,
		CommandBody,
		CorrelationToken
	from
		[WF].[SystemTaskQueue] 
	where 
		Dispatched = 0
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[WF].[SystemTask]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Function',
    @level1name = N'PendingSystemTasks',
    @level2type = NULL,
    @level2name = NULL
