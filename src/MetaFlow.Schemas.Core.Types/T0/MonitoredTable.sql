create type [T0].[MonitoredTable] as table
(
	HostId nvarchar(75) not null,
	DatabaseName nvarchar(128) not null,
	SchemaName nvarchar(128) not null,
	TableName nvarchar(128) not null,
	MonitorEnabled bit not null,
	MonitorFrequency int not null

)