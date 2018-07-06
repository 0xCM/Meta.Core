create procedure [SqlT].[SyncColumnRoleTypes](@Roles [SqlT].[LargeTypeTable] readonly) as
	
	merge into [SqlStore].[ColumnRoleType] as Dst
		using @Roles as Src
			on Src.TypeCode = Dst.TypeCode
		when not matched then insert
		(
			TypeCode,
			Identifier,
			Label,
			[Description]
		)
		values
		(
			Src.TypeCode,
			Src.Identifier,
			Src.Label,
			Src.[Description]

		)
		when matched and not exists
		(
			select
				Src.Identifier,
				isnull(Src.Label,''),
				isnull(Src.[Description],'')

			intersect

			select

				Dst.Identifier,
				isnull(Dst.Label, ''),
				isnull(Dst.[Description],'')

		)
		then update set
			Dst.Identifier = Src.Identifier,
			Dst.Label = Src.Label,
			Dst.[Description] = Src.[Description]
		when not matched by source then delete;

