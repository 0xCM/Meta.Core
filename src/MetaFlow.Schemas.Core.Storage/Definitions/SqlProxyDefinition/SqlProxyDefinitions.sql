create function [PF].[SqlProxyDefinitions]() returns table as return
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

GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[SqlT].[SqlProxyDefinition]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'SqlProxyDefinitions',
    @level2type = NULL,
    @level2name = NULL
