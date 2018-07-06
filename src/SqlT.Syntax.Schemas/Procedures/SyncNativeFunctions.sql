create procedure [Syntax].[SyncNativeFunctions](@Records [Syntax].[NativeFunction] readonly) as

	declare 
		@LoadTS datetime2(0) = getdate();

	merge into [Syntax].[NativeFunction] as Dst
		using @Records as Src on
			Src.FunctionName = Dst.FunctionName
	when not matched then insert
	(
		FunctionName,
		[Description]
	)
	values
	(
		Src.FunctionName,
		Src.[Description]
	)
	when matched and not exists
	(
		select
			Src.[Description]
		
		intersect

		select
			Dst.[Description]
	)
	then update set
		Dst.[Description] = Src.[Description]
	when not matched by source then delete;