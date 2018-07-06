create function [SqlT].[SqlProxyDefinitions]() returns table as return
	select 
		AssemblyDesignator,
		ProfileName,
		SourceNode,
		SourceDatabase,		
		TargetAssembly,
		ProfileText
	from
		[SqlStore].[SqlProxyDefinitionStore]

GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[SqlT].[ProxyProfileDefinition]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlT',
    @level1type = N'FUNCTION',
    @level1name = N'SqlProxyDefinitions',
    @level2type = NULL,
    @level2name = NULL
