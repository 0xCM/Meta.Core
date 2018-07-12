create function [PF].[TableMonitorLogEntries]() returns table as return
	select 
		EntryId, 
		HostId, 
		DatabaseName, 
		SchemaName, 
		TableName, 
		LastObservedVersion, 
		ObservationTS, 
		LastProcessedVersion, 
		ProcessedTS, 
		LoggedTS 
	from [PF].[TableMonitorLog]

GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[TableMonitorLogEntry]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'TableMonitorLogEntries',
    @level2type = NULL,
    @level2name = NULL


