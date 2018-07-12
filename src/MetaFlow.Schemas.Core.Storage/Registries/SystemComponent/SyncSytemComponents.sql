create procedure [PF].[SyncSystemComponents](@Components [T0].[SystemComponent] readonly) as
	merge into [PF].[SystemComponentRegistry] as Dst
		using @Components as Src 
		on Src.ComponentId = Dst.ComponentId
	when not matched then insert
	(
		ComponentId,
		SystemId,
		ComponentType,
		ComponentVersion,
		ComponentTS
	)
	values
	(
		Src.ComponentId,
		Src.SystemId,
		Src.ComponentType,
		Src.ComponentVersion,
		Src.ComponentTS
	)
	when matched and not exists
	(
		
		select
			Src.SystemId,
			Src.ComponentType,
			Src.ComponentVersion,
			Src.ComponentTS

		intersect

		select
			Dst.SystemId,
			Dst.ComponentType,
			Dst.ComponentVersion,
			Dst.ComponentTS

	)
	then update set
		Dst.SystemId = Src.SystemId,
		Dst.ComponentType = Src.ComponentType,
		Dst.ComponentVersion = Src.ComponentVersion,
		Dst.ComponentTS = Src.ComponentTS
	when not matched by source then delete;
