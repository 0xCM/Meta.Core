create function  [PF].[DacProfiles]() returns table as return
	select
		ProfileFileName,
		SourcePackage,
		TargetServerId,
		TargetDatabase,
		ProfileXml,
		ProfilePath
	from
		[PF].[DacProfileStore]

GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[DacProfileDefinition]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'DacProfiles',
    @level2type = NULL,
    @level2name = NULL



