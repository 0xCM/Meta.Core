create procedure [PF].[SyncEventRegistry](@Entries [T0].[SystemEventRegistration] readonly) as
	merge into [PF].[SystemEventRegistry] as Dst
		using @Entries as Src 
		on Src.SystemId = Dst.SystemId
		and Src.MessageName = Dst.MessageName
	when not matched then insert
	(
		SystemId,
		MessageName
	)
	values
	(
		Src.SystemId,
		Src.MessageName
	)
	when matched and not exists 
	(
		select 
			Src.Purpose

		intersect

		select 
			Dst.Purpose
			
	
	)
	then update set
		Dst.Purpose = Src.Purpose
	when not matched by source then delete;




	
