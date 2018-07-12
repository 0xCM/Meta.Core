CREATE VIEW [Configuration].[vComponentSetting] AS 
	SELECT 
		[c].[EnvironmentName], 
		[c].[ComponentName], 
		[c].[SettingName], 
		[c].[SettingValue],
		[c].SettingDescription
	FROM 
		[Configuration].ComponentConfiguration c
