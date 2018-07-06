create procedure [SqlDom].[SyncElements](@Records [SqlDom].[Element] readonly) as

	declare 
		@LoadTS datetime2(0) = getdate();

	merge into [SqlDom].[Element] as Dst
		using @Records as Src 
			on Src.ElementName = Dst.ElementName
		when not matched then insert
		(
			ElementName,
			ParentName,
			IsAbstract,
			ElementType
		)
		values
		(
			Src.ElementName,
			Src.ParentName,
			Src.IsAbstract,
			Src.ElementType
		)
		when matched and not exists
		(
			select
				isnull(Src.ParentName,''),
				Src.IsAbstract,
				Src.ElementType

			intersect

			select
				isnull(Dst.ParentName,''),
				Dst.IsAbstract,
				Dst.ElementType


		)
		then update set
			Dst.ParentName = Src.ParentName,
			Dst.IsAbstract = Src.IsAbstract,
			Dst.ElementType = Src.ElementType,
			Dst.UpdateTS = @LoadTS
		when not matched by source then delete;
	
	
	

GO

