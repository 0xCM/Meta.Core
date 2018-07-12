CREATE PROCEDURE [Configuration].[pCopyDescriptions](
	@SourceEnvironmentName nvarchar(75), 
	@SourceComponentName nvarchar(75),
	@TargetEnvironmentName nvarchar(75), 
	@TargetComponentName nvarchar(75))

as
	with Src as (
		select 
			[c].[EnvironmentName], 
			[c].[ComponentName], 
			[c].[SettingName], 
			[c].[SettingValue], 
			[c].[SettingDescription] 
		from
			Configuration.ComponentConfiguration c
		where
			c.EnvironmentName = @SourceEnvironmentName and
			c.ComponentName = @SourceComponentName and
			c.SettingDescription is not null and
			len(c.SettingDescription) <> 0
	),
	Dst as(
		select 
			[c].[EnvironmentName], 
			[c].[ComponentName], 
			[c].[SettingName], 
			[c].[SettingValue], 
			[c].[SettingDescription] 
		from
			Configuration.ComponentConfiguration c
		where
			c.EnvironmentName = @TargetEnvironmentName and
			c.ComponentName = @TargetComponentName
	)
	merge into Dst using Src
	on
		Dst.SettingName = Src.SettingName
	when matched then update set
		Dst.SettingDescription = Src.SettingDescription;
