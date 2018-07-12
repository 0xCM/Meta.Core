create function [PF].[TargetedDatabaseComponents]() returns table as return	
	select 
		dacs.SystemId, 
		c.TargetDatabase,
		dacs.ComponentId, 
		dacs.ComponentVersion, 
		dacs.ComponentTS, 
		SqlPackageName = dacs.PackageName
	from 
		[PF].[PlatformDacs]() dacs 
			inner join [PF].[ProjectComponents]() c on 
				c.ComponentId = dacs.ComponentId
		where
			c.IsSqlProject = 1
		and c.TargetDatabase is not null
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[TargetedDatabaseComponent]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'TargetedDatabaseComponents',
    @level2type = NULL,
    @level2name = NULL


