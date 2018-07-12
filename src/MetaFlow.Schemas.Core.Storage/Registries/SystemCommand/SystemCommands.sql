create function [PF].[SystemCommands]() returns table as return
	select 
		SystemId,
		MessageName,
		Purpose
	from
		[PF].[SystemCommandRegistry]
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[SystemEventRegistration]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'SystemCommands',
    @level2type = NULL,
    @level2name = NULL



	
