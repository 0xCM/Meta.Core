create function [PF].[Systems]() returns table as return
	select 
		SystemId,
		Label
		
	from
		[PF].[PlatformSystemRegistry]
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[PlatformSystem]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'Systems',
    @level2type = NULL,
    @level2name = NULL


