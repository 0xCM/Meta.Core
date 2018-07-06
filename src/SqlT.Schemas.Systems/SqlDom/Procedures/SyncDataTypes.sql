create procedure [SqlDom].[SyncDataTypes] as

	with Src as
	(
		select
			ElementId,
			ElementName
		from
			[SqlDom].[Element]
		where
			ElementType = 'Enum'
	)

	merge into [SqlDom].[DataType] as Dst
		using Src on
		Src.ElementName = Dst.TypeName
	and Src.ElementId = Dst.ElementId
	when not matched then insert
	(
		TypeName,
		ElementId
	)
	values
	(
		Src.ElementName,
		Src.ElementId
	)
	when not matched by source then delete;


		
	
