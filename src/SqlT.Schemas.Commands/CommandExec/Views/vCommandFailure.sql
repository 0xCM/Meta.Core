create view [CommandExec].[vCommandFailure] as
	select 
		c.*
	from 
		[CommandExec].[vCommandOutcome] c
	where 
		c.Succeeded = 0
GO

exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[CommandExec].[CommandOutcome]',
    @level0type = N'SCHEMA',
    @level0name = N'CommandExec',
    @level1type = N'VIEW',
    @level1name = N'vCommandFailure',
    @level2type = NULL,
    @level2name = NULL
