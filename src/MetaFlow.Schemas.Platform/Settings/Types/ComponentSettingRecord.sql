CREATE TYPE [Configuration].[ComponentSettingRecord] AS TABLE
(
	EnvironmentName nvarchar(75) not null,
	ComponentName nvarchar(75) not null,
	SettingName nvarchar(75) not null,
	SettingValue nvarchar(MAX) NOT null,
	SettingDescription nvarchar(250) null
)
