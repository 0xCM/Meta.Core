create function [PF].[MessageAttributes]() returns table as return
	select 
		SystemId, 
		SchemaName, 
		TypeName,
		ColumnName,
		ColumnPosition,
		DataTypeName,
		IsNullable,
		[Length],
		[Precision],
		[Scale],
		[Description]
		
	from [PF].[MessageTypeAttribute]
	
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[MessageAttribute]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'MessageAttributes',
    @level2type = NULL,
    @level2name = NULL



	
