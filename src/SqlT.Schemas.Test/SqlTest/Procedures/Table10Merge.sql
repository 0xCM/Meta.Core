create procedure [SqlTest].[Table10Merge](@Records SqlTest.Table10Record readonly) as
	merge into [SqlTest].[Table10] with(holdlock) as Dst using @Records as Src
	on
		Dst.Col02 = Src.Col02
	when not matched then 
		insert
		(
			Col02,
			Col03,
			Col04
		)
		values
		(
			Src.Col02,
			Src.Col03,
			Src.Col04
		)
	when matched and not exists
	(
		select 
			Src.Col03,
			Src.Col04

		intersect

		select

			Dst.Col03,
			Dst.Col04
	)
	then update set
		Dst.Col03 = Src.Col03,
		Dst.Col04 = Src.Col04;