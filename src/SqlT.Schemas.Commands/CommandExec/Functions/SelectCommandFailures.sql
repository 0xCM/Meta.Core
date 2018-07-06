create function [CommandExec].[SelectCommandFailures](@CommandName nvarchar(250)) returns table as return
	select 
		f.* 
	from 
		[CommandExec].vCommandFailure	f
	where 
		f.CommandName = @CommandName
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[CommandExec].[CommandOutcome]',
    @level0type = N'SCHEMA',
    @level0name = N'CommandExec',
    @level1type = N'Function',
    @level1name = N'SelectCommandFailures',
    @level2type = NULL,
    @level2name = NULL

