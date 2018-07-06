create function [CommandSpec].GetDefinitions() returns table as return
	select 
		[CommandName], 
		[CommandDescription]
	from 
		[CommandSpec].CommandDefinition;
GO
EXEC sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[CommandSpec].[CommandDefinitionRecord]',
    @level0type = N'SCHEMA',
    @level0name = N'CommandSpec',
    @level1type = N'Function',
    @level1name = N'GetDefinitions'
GO
