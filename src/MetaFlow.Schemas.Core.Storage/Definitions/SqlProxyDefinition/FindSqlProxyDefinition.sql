create function [PF].[FindSqlProxyDefinition](@ProfileName nvarchar(75)) returns table as return
	select 
		AssemblyDesignator,
		SystemId,
		ProfileName,
		SourceNode,
		SourceDatabase,		
		TargetAssembly,
		ProfileText
	from
		[PF].[SqlProxyDefinitions]()
	where
		ProfileName = @ProfileName

GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[SqlT].[SqlProxyDefinition]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'FindSqlProxyDefinition',
    @level2type = NULL,
    @level2name = NULL
