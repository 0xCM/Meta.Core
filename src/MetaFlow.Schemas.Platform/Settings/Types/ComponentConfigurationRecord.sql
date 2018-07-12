CREATE TYPE [Configuration].[ComponentConfigurationRecord] AS TABLE
(
	EnvironmentName nvarchar(75) not null,
	ComponentName nvarchar(75) not null,
	SettingName nvarchar(75) not null,
	SettingValue nvarchar(MAX) not null,
	SettingDescription nvarchar(250) null
)
