create function [PF].[PlatformServers]() returns table as return	
	select 
		NodeId,
		NodeName,
		HostName,
		HostIP,
		NetworkName,
		WinOperatorName,
		WinOperatorPass
	from 
		[PF].[PlatformServerRegistry]
	
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[PlatformNode]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'PlatformServers',
    @level2type = NULL,
    @level2name = NULL
