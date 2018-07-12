create function [PF].[ProjectComponents]() returns table as return
	select 
		p.SystemId, 
		p.ProjectName, 
		c.ComponentId,		
		p.TargetAssembly, 
		c.ComponentType, 
		p.IsSqlProject,
		p.TargetDatabase,
		c.ComponentVersion,
		c.ComponentTS
	from 
		[PF].[PlatformProjects]() p 
			inner join [PF].[SystemComponents]() c on 
				c.ComponentId = p.TargetAssembly

GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[ProjectComponent]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'ProjectComponents',
    @level2type = NULL,
    @level2name = NULL


