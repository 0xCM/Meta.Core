create function [PF].[PlatformSolutions]() returns table as return
	select 
		SystemId,
		SolutionId,
		SolutionName 
	from
		[PF].[PlatformSolutionStore]
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[PlatformSolution]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'PlatformSolutions',
    @level2type = NULL,
    @level2name = NULL


