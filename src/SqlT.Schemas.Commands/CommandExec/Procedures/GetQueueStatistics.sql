create function [CommandExec].GetQueueStatistics() returns table as return
with Incoming as(
	select 
		CommandName, 
		count(*) as CommandCount
	from 
		[CommandExec].CommandSubmission
	group by 
		CommandName
), Dispatched as(

	select 
		CommandName, 
		count(*) as CommandCount
	from 
		[CommandExec].CommandDispatch
	group by 
		CommandName
), Completed as (
	select 
		CommandName, 
		count(*) as CommandCount
	from 
		[CommandExec].CommandHistory
	group by 
		CommandName
)
select 'SubmissionQueue' as QueueName, i.* from Incoming i
union 
select 'DispatchQueue' as QueueName, i.* from Dispatched i
union
select 'HistoryQueue' as QueueName, i.* from Completed i

GO
EXEC sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[CommandExec].[QueueStatisticRecord]',
    @level0type = N'SCHEMA',
    @level0name = N'CommandExec',
    @level1type = N'Function',
    @level1name = N'GetQueueStatistics'
GO







