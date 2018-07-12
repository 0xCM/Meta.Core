create table [PF].[MonitoredTableSetting]
(
	SettingId int not null
		constraint DF_MonitoredTableSetting_SettingId
			default(next value for [PF].[PlatformSettingSequence]),	
	HostId nvarchar(75) not null,
	DatabaseName nvarchar(128) not null,
	SchemaName nvarchar(128) not null,
	TableName nvarchar(128) not null,
	MonitorFrequency int not null,
	MonitorEnabled bit not null,
	CreateTS datetime2(0) not null
		constraint DF_MonitoredTableSetting_CreateTS default(getdate()),	
	UpdateTS datetime2(0) null,
	SystemRV timestamp,
	constraint PK_MonitoredTableSetting primary key(SettingId),
	constraint UQ_MonitoredTableSetting unique(HostId,DatabaseName,SchemaName,TableName)

)
	
GO
	
create sequence [PF].[PlatformSettingSequence]
	as int start with 1 cache 10
GO

