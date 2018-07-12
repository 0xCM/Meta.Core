create function [PF].[MessageFormats]() returns table as return
	select
		SchemaName,
		TypeName,
		FormatTemplate,
		P1, P2, P3,
		P4, P5, P6,
		P7, P8, P9
	from
		[PF].[MessageFormatDefinition]
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[MessageFormat]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'MessageFormats',
    @level2type = NULL,
    @level2name = NULL



	