create function [Syntax].[NativeFunctions]() returns table as return
	
	select 
		FunctionName,
		[Description]
	from
		[Syntax].[NativeFunction]
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[Syntax].[NativeFunction]',
    @level0type = N'SCHEMA',
    @level0name = N'Syntax',
    @level1type = N'FUNCTION',
    @level1name = N'NativeFunctions',
    @level2type = NULL,
    @level2name = NULL





