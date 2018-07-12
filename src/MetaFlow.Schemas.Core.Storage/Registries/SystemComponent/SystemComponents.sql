create function [PF].[SystemComponents]() returns table as return
	select
		ComponentId,
		SystemId,
		ComponentType,
		ComponentVersion,
		ComponentTS
	from
		[PF].[SystemComponentRegistry]
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[SystemComponent]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'SystemComponents',
    @level2type = NULL,
    @level2name = NULL



		

