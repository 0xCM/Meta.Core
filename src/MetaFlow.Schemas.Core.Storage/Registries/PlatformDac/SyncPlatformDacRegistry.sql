create procedure [PF].[SyncPlatformDacRegistry](@Entries [T0].[PlatformDacRegistration] readonly) as
	merge into [PF].[PlatformDacRegistry] as Dst 
		using @Entries as Src 
			on Src.PackageName = Dst.PackageName
	when not matched then insert
	(
		PackageName,
		SystemId,
		ComponentId,
		ComponentVersion,
		ComponentTS
	)
	values
	(
		Src.PackageName,
		Src.SystemId,
		Src.ComponentId,
		Src.ComponentVersion,
		Src.ComponentTS
	)
	when matched and not exists 
	(
		select 
			Src.SystemId,
			Src.ComponentId,
			Src.ComponentVersion,
			Src.ComponentTS

		intersect

		select 
			Dst.SystemId,
			Dst.ComponentId,
			Dst.ComponentVersion,
			Dst.ComponentTS
	
	)
	then update set
		Dst.SystemId = Src.SystemId,
		Dst.ComponentId = Src.ComponentId,
		Dst.ComponentVersion = Src.ComponentVersion,
		Dst.ComponentTS = Src.ComponentTS
	when not matched by source then delete;




	
