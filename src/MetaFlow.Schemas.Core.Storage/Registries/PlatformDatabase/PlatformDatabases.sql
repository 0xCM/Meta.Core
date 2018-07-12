create function [PF].[PlatformDatabases](@HostId nvarchar(75)) returns table as return 
	select 
		ServerId,
		DatabaseName,
		DatabaseType,
		IsPrimary,
		IsEnabled,
		IsModel,
		IsRestore
	from 
		[PF].[PlatformDatabaseRegistry]
	
	where 
		ServerId = @HostId
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[PlatformDatabase]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'PlatformDatabases',
    @level2type = NULL,
    @level2name = NULL

