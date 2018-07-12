create type [T0].[SystemSetting] as table
(
	SystemId nvarchar(75) not null,
	SettingName nvarchar(75) not null,
	SettingValue nvarchar(250) not null,
	ChangeTS datetime2(0) not null
)
	
