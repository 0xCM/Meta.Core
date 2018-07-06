create procedure [SqlDom].[SyncAssociations](@Records [SqlDom].[Association] readonly) as

	declare 
		@LoadTS datetime2(0) = getdate();

	merge into [SqlDom].[Association] as Dst
		using @Records as Src on
			Src.ElementName = Dst.ElementName
		and Src.AssociationName = Dst.AssociationName
	when not matched then insert
	(
		ElementName,
		AssociationName,
		AssociationType,
		IsReadOnly
	)
	values
	(
		Src.ElementName,
		Src.AssociationName,
		Src.AssociationType,
		Src.IsReadOnly
	)
	when matched and not exists
	(
		select
			Src.AssociationType,
			Src.IsReadOnly
		
		intersect

		select
			Dst.AssociationType,
			Dst.IsReadOnly
	)
	then update set
		Dst.AssociationType = Src.AssociationType,
		Dst.IsReadOnly = Src.IsReadOnly,
		Dst.UpdateTS = @LoadTS
	when not matched by source then delete;