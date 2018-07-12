create procedure [PF].[StorePlatformEntities](@Entities [T0].[PlatformEntity] readonly) as

	
	merge into [PF].[PlatformEntityStore] as Dst
		using @Entities as Src
		on Src.EntityName = Dst.EntityName
	when not matched then insert
	(
		EntityName,
		TypeUri,
		Body
	)
	values
	(
		Src.EntityName,
		Src.TypeUri,
		Src.Body
	)
	when matched and not exists
	(
		select 
			Src.TypeUri,
			Src.Body

		intersect

		select
		
			Dst.TypeUri,
			Dst.Body
	)
	then update set
		Dst.TypeUri = Src.TypeUri,
		Dst.Body = Src.Body;

