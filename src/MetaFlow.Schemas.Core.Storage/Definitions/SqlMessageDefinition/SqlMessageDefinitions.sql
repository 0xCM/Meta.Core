create function [PF].[SqlMessageDefinitions]() returns table as return
	select
		MessageNumber,
		SystemId,
		MessageName,
		Severity,
		FormatString
	from 
		[PF].[SqlMessageDefinition]
GO

exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[SqlMessageSpec]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'SqlMessageDefinitions',
    @level2type = NULL,
    @level2name = NULL
