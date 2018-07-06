create procedure [SqlTest].[Table12Merge](@Records SqlTest.Table12Record readonly) as
	merge into [SqlTest].[Table12] with(holdlock) as Dst using @Records as Src
	on
		Dst.Col01 = Src.Col01
	and Dst.Col02 = Src.Col02
	and Dst.Col03 = src.Col03
	when not matched then 
		insert
		(
			Col01,
			Col02,
			Col03,
			Col04,
			Col05,
			Col06,
			Col07,
			Col08
		)
		values
		(
			Src.Col01,
			Src.Col02,
			Src.Col03,
			Src.Col04,
			Src.Col05,
			Src.Col06,
			Src.Col07,
			Src.Col08
		)
	when matched and not exists
	(
		select 			
			Src.Col04,
			Src.Col05,
			Src.Col06,
			Src.Col07,
			Src.Col08

		intersect

		select
			Dst.Col04,
			Dst.Col05,
			Dst.Col06,
			Dst.Col07,
			Dst.Col08
	)
	then update set
		Dst.Col04 = Src.Col04,
		Dst.Col05 = Src.Col05,
		Dst.Col06 = Src.Col06,
		Dst.Col07 = Src.Col07,
		Dst.Col08 = Src.Col08;