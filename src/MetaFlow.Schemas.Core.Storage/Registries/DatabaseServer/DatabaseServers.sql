create function [PF].[DatabaseServers]() returns table as return
	select 
		* 
	from 
	[PF].[PlatformDatabaseServer]

GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[DatabaseServer]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'DatabaseServers',
    @level2type = NULL,
    @level2name = NULL
