create view [CommandExec].[vCommandOutcome] as
	select 
		[h].[SubmissionId], 
		[h].[CommandName],
		[h].[DispatchTime], 
		[h].[CompleteTime], 
		[h].[Succeeded], 
		[h].[ResultMessage] 
	from 
		[CommandExec].[CommandHistory] h 
GO

exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[CommandExec].[CommandOutcome]',
    @level0type = N'SCHEMA',
    @level0name = N'CommandExec',
    @level1type = N'VIEW',
    @level1name = N'vCommandOutcome',
    @level2type = NULL,
    @level2name = NULL
