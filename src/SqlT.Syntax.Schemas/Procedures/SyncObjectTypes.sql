create procedure [Syntax].[SyncObjectTypes](@Records [Syntax].[ObjectType] readonly) as

	declare 
		@LoadTS datetime2(0) = getdate();

	merge into [Syntax].[ObjectType] as Dst
		using @Records as Src on
			Src.TypeCode = Dst.TypeCode
	when not matched then insert
	(
		TypeCode,
		TypeDescription
	)
	values
	(
		Src.TypeCode,
		Src.TypeDescription
	)
	when matched and not exists
	(
		select
			Src.TypeDescription
		
		intersect

		select
			Dst.TypeDescription
	)
	then update set
		Dst.TypeDescription = Src.TypeDescription
	when not matched by source then delete;