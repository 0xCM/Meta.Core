create function [PF].[PlatformDacs]() returns table as return
	select	
		SystemId,
		PackageName,
		ComponentId,
		ComponentVersion,
		ComponentTS
	from
		[PF].[PlatformDacRegistry]
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[PlatformDacRegistration]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'PlatformDacs',
    @level2type = NULL,
    @level2name = NULL



