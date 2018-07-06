create function [Syntax].[Keywords]() returns table as return
	
	select 
		KeywordName,
		[Description]
	from
		[Syntax].[Keyword]
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[Syntax].[Keyword]',
    @level0type = N'SCHEMA',
    @level0name = N'Syntax',
    @level1type = N'FUNCTION',
    @level1name = N'Keywords',
    @level2type = NULL,
    @level2name = NULL





