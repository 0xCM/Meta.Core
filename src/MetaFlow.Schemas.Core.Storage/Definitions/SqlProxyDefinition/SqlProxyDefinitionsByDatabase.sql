create function [PF].[SqlProxyDefinitionsByDatabase](@DbName nvarchar(128)) returns table as return
	select 
		AssemblyDesignator,
		SystemId,
		ProfileName,
		SourceNode,
		SourceDatabase,		
		TargetAssembly,
		ProfileText
	from
		[PF].[SystemProxyDefinition]
	where 
		SourceDatabase = @DbName

GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[SqlT].[SqlProxyDefinition]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'SqlProxyDefinitionsByDatabase',
    @level2type = NULL,
    @level2name = NULL
