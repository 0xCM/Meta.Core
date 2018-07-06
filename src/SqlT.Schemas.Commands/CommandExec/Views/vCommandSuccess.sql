create view [CommandExec].[vCommandSuccess] as
	select 
		c.*
	from 
		[CommandExec].[vCommandOutcome] c
	where 
		c.Succeeded = 1
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[CommandExec].[CommandOutcome]',
    @level0type = N'SCHEMA',
    @level0name = N'CommandExec',
    @level1type = N'VIEW',
    @level1name = N'vCommandSuccess',
    @level2type = NULL,
    @level2name = NULL
