create procedure [PF].[SyncSystemCommandRegistry](@Entries [T0].[SystemCommandRegistration] readonly) as
	merge into [PF].[SystemCommandRegistry] as Dst 
		using @Entries as Src 
			on Src.SystemId = Dst.SystemId
			and Src.MessageName = Dst.MessageName
	when not matched then insert
	(
		SystemId,
		MessageName,
		Purpose
	)
	values
	(
		Src.SystemId,
		Src.MessageName,
		Src.Purpose
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




	
