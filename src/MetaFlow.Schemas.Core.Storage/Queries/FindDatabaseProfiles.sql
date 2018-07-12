create function [PF].[FindDatabaseProfiles](@DatabaseName nvarchar(128)) returns table as return
	select 
		ServerId,
		DatabaseName, 
		DatabaseType,
		ProfilePath,
		ProfileXml
	from 
		[PF].[PlatformDatabaseProfiles]() 
	where 
		DatabaseName = @DatabaseName
GO

exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[PlatformDatabaseProfile]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'FindDatabaseProfiles',
    @level2type = NULL,
    @level2name = NULL


