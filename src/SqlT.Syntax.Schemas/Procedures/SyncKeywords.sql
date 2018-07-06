create procedure [Syntax].[SyncKeywords](@Records [Syntax].[Keyword] readonly) as

	declare 
		@LoadTS datetime2(0) = getdate();

	merge into [Syntax].[Keyword] as Dst
		using @Records as Src on
			Src.KeywordName = Dst.KeywordName
	when not matched then insert
	(
		KeywordName,
		[Description]
	)
	values
	(
		Src.KeywordName,
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