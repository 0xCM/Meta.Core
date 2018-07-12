create table [PF].[TableMonitorLog]
(
	EntryId bigint not null
		constraint DF_TableMonitorLog_EntryId 
			default(next value for [PF].[TableMonitorLogSequence]),
	HostId nvarchar(75) not null,
	DatabaseName nvarchar(128) not null,
	SchemaName nvarchar(128) not null,
	TableName nvarchar(128) not null,
	LastObservedVersion varbinary(8) null,
	ObservationTS datetime2(0) null,
	LastProcessedVersion varbinary(8) null,
	ProcessedTS datetime2(0) null,
	LoggedTS datetime2(0) not null
		constraint DF_TableMonitorLog_LoggedTS default(getdate()),
	SystemRV timestamp,

	constraint PK_TableMonitorLog primary key(EntryId),
	constraint UQ_TableMonitorLog unique(HostId,DatabaseName,SchemaName,TableName)

	
)
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[SqlT].[LogTable]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'Table',
    @level1name = N'TableMonitorLog',
    @level2type = NULL,
    @level2name = NULL

GO

create sequence [PF].[TableMonitorLogSequence]
	as bigint start with 1 cache 10
GO

