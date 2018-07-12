create function [PF].[MonitoredTables]() returns table as return
	select
		HostId,
		DatabaseName,
		SchemaName,
		TableName,
		MonitorEnabled,
		MonitorFrequency
	from
		[PF].[MonitoredTableSetting]
	
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[MonitoredTable]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'MonitoredTables',
    @level2type = NULL,
    @level2name = NULL


