create function [SqlT].[SqlProxyDefinitionsByDatabase](@DbName nvarchar(128)) returns table as return
	select 
		AssemblyDesignator,
		ProfileName,
		SourceNode,
		SourceDatabase,		
		TargetAssembly,
		ProfileText
	from
		[SqlStore].[SqlProxyDefinitionStore]
	where 
		SourceDatabase = @DbName

GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[SqlT].[ProxyProfileDefinition]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlT',
    @level1type = N'FUNCTION',
    @level1name = N'SqlProxyDefinitionsByDatabase',
    @level2type = NULL,
    @level2name = NULL
