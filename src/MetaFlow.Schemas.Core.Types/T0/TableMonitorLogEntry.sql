create type [T0].[TableMonitorLogEntry] as table
(
	HostId nvarchar(75) not null,
	DatabaseName nvarchar(128) not null,
	SchemaName nvarchar(128) not null,
	TableName nvarchar(128) not null,
	LastObservedVersion varbinary(8) null,
	ObservationTS datetime2(0) null,
	LastProcessedVersion varbinary(8) null,
	ProcessedTS datetime2(0) null,
	LoggedTS datetime2(0) not null

)
