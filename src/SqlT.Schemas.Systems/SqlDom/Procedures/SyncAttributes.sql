create procedure [SqlDom].[SyncAttributes](@Records [SqlDom].[ElementAttribute] readonly) as

	declare 
		@LoadTS datetime2(0) = getdate();

	merge into [SqlDom].[ElementAttribute] as Dst
		using @Records as Src on
			Src.ElementName = Dst.ElementName
		and Src.AttributeName = Dst.AttributeName
	when not matched then insert
	(
		ElementName,
		AttributeName,
		DataType,
		Infrastructure,
		IsReadOnly
	)
	values
	(
		Src.ElementName,
		Src.AttributeName,
		Src.DataType,
		Src.Infrastructure,
		Src.IsReadOnly
	)
	when matched and not exists
	(
		select
			Src.DataType,
			Src.Infrastructure,
			Src.IsReadOnly

		
		intersect

		select
			Dst.DataType,
			Dst.Infrastructure,
			Dst.IsReadOnly

	)
	then update set
		Dst.DataType = Src.DataType,
		Dst.Infrastructure = Src.Infrastructure,
		Dst.IsReadOnly = Src.IsReadOnly,

		Dst.UpdateTS = @LoadTS

	when not matched by source then delete;