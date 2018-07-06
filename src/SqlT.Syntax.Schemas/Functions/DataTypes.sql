create function [Syntax].[DataTypes]() returns table as return
	
	select 
		TypeName,
		[Description]
	from
		[Syntax].[DataType]
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[Syntax].[DataType]',
    @level0type = N'SCHEMA',
    @level0name = N'Syntax',
    @level1type = N'FUNCTION',
    @level1name = N'DataTypes',
    @level2type = NULL,
    @level2name = NULL





