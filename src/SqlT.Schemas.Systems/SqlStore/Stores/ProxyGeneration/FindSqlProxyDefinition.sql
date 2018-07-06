create function [SqlT].[FindSqlProxyDefinition](@ProfileName nvarchar(75)) returns table as return
	select 
		AssemblyDesignator,
		ProfileName,
		SourceNode,
		SourceDatabase,		
		TargetAssembly,
		ProfileText
	from
		[SqlT].[SqlProxyDefinitions]()
	where
		ProfileName = @ProfileName

GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[SqlT].[ProxyProfileDefinition]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlT',
    @level1type = N'FUNCTION',
    @level1name = N'FindSqlProxyDefinition',
    @level2type = NULL,
    @level2name = NULL
