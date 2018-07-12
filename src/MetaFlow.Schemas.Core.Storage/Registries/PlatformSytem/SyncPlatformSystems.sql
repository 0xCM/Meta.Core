create procedure [PF].[SyncPlatformSystems](@Systems [T0].[PlatformSystem] readonly) as
	merge into [PF].[PlatformSystemRegistry] as Dst
		using @Systems as Src 
		on Src.Identifier = Dst.SystemId
	when not matched then insert
	(
		SystemId,
		Label
	)
	values
	(
		Src.Identifier,
		Src.Label
	)
	when matched and not exists
	(
		
		select
			Src.Label

		intersect

		select
			Dst.Label

	)
	then update set
		Dst.Label = Src.Label
	when not matched by source then delete;
