create procedure [MC].[SyncCoreDataTypes](@Records [MC].[CoreDataTypeInfo] readonly) as

	merge into [MC].[CoreDataType] as Dst
		using @Records as Src on
			Src.DataTypeName = Dst.DataTypeName
	when not matched then insert
	(
		DataTypeName,
		ClrTypeName,
		IsInteger,
		IsText,
		IsBoolean,
		IsTemporal,
		CanSpecifyLength,
		CanSpecifyPrecision,
		CanSpecifyScale
	)
	values
	(
		Src.DataTypeName,
		Src.ClrTypeName,
		Src.IsInteger,
		Src.IsText,
		Src.IsBoolean,
		Src.IsTemporal,
		Src.CanSpecifyLength,
		Src.CanSpecifyPrecision,
		Src.CanSpecifyScale
	)	
	when matched and not exists
	(

	select 
		Src.ClrTypeName,
		Src.IsInteger,
		Src.IsText,
		Src.IsBoolean,
		Src.IsTemporal,
		Src.CanSpecifyLength,
		Src.CanSpecifyPrecision,
		Src.CanSpecifyScale
	intersect

	select

		Dst.ClrTypeName,
		Dst.IsInteger,
		Dst.IsText,
		Dst.IsBoolean,
		Dst.IsTemporal,
		Dst.CanSpecifyLength,
		Dst.CanSpecifyPrecision,
		Dst.CanSpecifyScale
	)
	then update set
		Dst.ClrTypeName = Src.ClrTypeName,
		Dst.IsInteger = Src.IsInteger,
		Dst.IsText = Src.IsText,
		Dst.IsBoolean = Src.IsBoolean,
		Dst.IsTemporal = Src.IsTemporal,
		Dst.CanSpecifyLength = Src.CanSpecifyLength,
		Dst.CanSpecifyPrecision = Src.CanSpecifyPrecision,
		Dst.CanSpecifyScale = Src.CanSpecifyScale
	when not matched by source then delete;
GO

