create procedure [Syntax].[SyncChoices](@Choices [Syntax].[Choice] readonly) as

	merge into [Syntax].[Choice] as Dst
		using @Choices as Src on
			Src.ChoiceName = Dst.ChoiceName
		and Src.ChoiceValue = Dst.ChoiceValue
	when not matched then insert
	(
		ChoiceName,
		ChoiceValue

	)
	values
	(
		Src.ChoiceName,
		Src.ChoiceValue
	)
	when not matched by source then delete;