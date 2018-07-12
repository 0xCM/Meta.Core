create function [Configuration].SelectComponentSettings(@EnvironmentName varchar(75), @ComponentName varchar(75)) returns table as return
select
	[c].[EnvironmentName], 
	[c].[ComponentName], 
	[c].[SettingName], 
	[c].[SettingValue], 
	[c].[SettingDescription] 
from 
	[Configuration].vComponentSetting c 
where 
	c.EnvironmentName = @EnvironmentName and 
	c.ComponentName = @ComponentName
GO
EXEC sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[Configuration].[ComponentSettingRecord]',
    @level0type = N'SCHEMA',
    @level0name = N'Configuration',
    @level1type = N'Function',
    @level1name = N'SelectComponentSettings'
GO

