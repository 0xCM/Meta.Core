create procedure [PF].[SyncHostDatabases](@Databases [T0].[PlatformDatabase] readonly) as
		


	merge into [PF].[HostDatabase] as Dst
		using @Databases as Src on
			Dst.ServerId = Src.ServerId
		and Dst.DatabaseName = Src.DatabaseName
	when not matched then insert
	(
		ServerId,
		DatabaseName,
		DatabaseType,
		IsPrimary,
		IsEnabled,
		IsModel, 
		IsRestore
	)
	values
	(
		Src.ServerId,
		Src.DatabaseName,
		Src.DatabaseType,
		Src.IsPrimary,
		Src.IsEnabled,
		Src.IsModel, 
		Src.IsRestore
	)
	when matched and not exists
	(
		select 
			Src.DatabaseType,
			Src.IsPrimary,
			Src.IsEnabled,
			Src.IsModel, 
			Src.IsRestore
	
		intersect

		select 
			Dst.DatabaseType,
			Dst.IsPrimary,
			Dst.IsEnabled,
			Dst.IsModel, 
			Dst.IsRestore
	)
	then update set
		Dst.DatabaseType = Src.DatabaseType,
		Dst.IsPrimary = Src.IsPrimary,
		Dst.IsEnabled = Src.IsEnabled,
		Dst.IsModel = Src.IsModel, 
		Dst.IsRestore = Src.IsRestore
	when not matched by source then delete;





	