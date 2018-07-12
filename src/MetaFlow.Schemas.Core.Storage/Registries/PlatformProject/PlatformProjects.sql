create function [PF].[PlatformProjects]() returns table as return
	select 
		SystemId,
		SolutionId,
		ProjectId,
		ProjectName,
		TargetAssembly,
		IsSqlProject,
		TargetDatabase
	from
		[PF].[PlatformProjectRegistry]
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[PlatformProject]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'PlatformProjects',
    @level2type = NULL,
    @level2name = NULL


