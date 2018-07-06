create function [CommandSpec].GetSpecs() returns table as return
	select 
		[CommandSpecName],
		[CommandName], 
		[CommandJson]
	from 
		[CommandSpec].CommandLibrary;
GO
EXEC sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[CommandSpec].[CommandLibraryEntry]',
    @level0type = N'SCHEMA',
    @level0name = N'CommandSpec',
    @level1type = N'Function',
    @level1name = N'GetSpecs'
GO
