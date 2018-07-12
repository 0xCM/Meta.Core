create function [PF].[PlatformAgents]() returns table as return
	select 
		SystemId,
		AgentId 
	from
		[PF].[PlatformAgentRegistry]
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[PlatformAgent]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'PlatformAgents',
    @level2type = NULL,
    @level2name = NULL


