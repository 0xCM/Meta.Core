create function [PF].[MessageTypes]() returns table as return
	
	select 
		SystemId,
		SchemaName,
		TypeName,
		MessageClass,
		[Description]
	from
	
	[PF].[MessageTypeRegistry]
	where 
		SystemKey > 0
GO

exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[MessageTypeRegistration]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'MessageTypes',
    @level2type = NULL,
    @level2name = NULL



	
