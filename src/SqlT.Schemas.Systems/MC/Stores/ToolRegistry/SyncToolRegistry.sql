create procedure [MC].[SyncToolRegistry](@Entries [MC].[ToolRegistration] readonly) as
	merge into [MC].[ToolRegistry] as Dst 
		using @Entries as Src 
			on Src.ToolId = Dst.ToolId		
	when not matched then insert
	(
		ToolId,
		ExecutableName,
		ExecutablePath
	)
	values
	(
		Src.ToolId,
		Src.ExecutableName,
		Src.ExecutablePath
	)
	when matched and not exists 
	(
		select 
			Src.ExecutableName,
			Src.ExecutablePath


		intersect

		select 
			Dst.ExecutableName,
			Dst.ExecutablePath
	
	)
	then update set
		Dst.ExecutableName = Src.ExecutableName,
		Dst.ExecutablePath = Src.ExecutablePath
	when not matched by source then delete;




	
