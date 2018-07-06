create procedure [SqlDom].[SyncCollections](@Records [SqlDom].[Collection] readonly) as

	declare 
		@LoadTS datetime2(0) = getdate();

	merge into [SqlDom].[Collection] as Dst
		using @Records as Src on
			Src.ElementName = Dst.ElementName
		and Src.CollectionName = Dst.CollectionName
	when not matched then insert
	(
		ElementName,
		CollectionName,
		ItemType,
		IsReadOnly
	)
	values
	(
		Src.ElementName,
		Src.CollectionName,
		Src.ItemType,
		Src.IsReadOnly
	)
	when matched and not exists
	(
		select
			Src.ItemType,
			Src.IsReadOnly
		
		intersect

		select
			Dst.ItemType,
			Dst.IsReadOnly
	)
	then update set
		Dst.ItemType = Src.ItemType,
		Dst.UpdateTS = @LoadTS,
		Dst.IsReadOnly = Src.IsReadOnly
	when not matched by source then delete;