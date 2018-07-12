CREATE PROCEDURE [Configuration].[SaveComponentSettings](@Records [Configuration].ComponentSettingRecord readonly) as
	merge into [Configuration].ComponentConfiguration as Dst using @Records as Src
	on
			Dst.EnvironmentName = Src.EnvironmentName 
		and Dst.ComponentName = Src.ComponentName
		and Dst.SettingName = Src.SettingName
	when not matched then
		insert(EnvironmentName, ComponentName, SettingName, SettingValue, SettingDescription)
		values(Src.EnvironmentName, Src.ComponentName, Src.SettingName, Src.SettingValue, Src.SettingDescription)
	when matched and not exists
		(
			select Dst.SettingValue, Dst.SettingDescription

			intersect

			select Src.SettingValue, Src.SettingDescription
		)
	then update set
		Dst.SettingValue = Src.SettingValue,
		Dst.SettingDescription = Src.SettingDescription;
