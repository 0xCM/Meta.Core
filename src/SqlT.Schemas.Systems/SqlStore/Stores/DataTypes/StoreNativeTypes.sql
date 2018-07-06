create procedure [SqlT].[StoreNativeTypes] as
	

	with Natives as
	(
		select * from [SqlT].[DescribeDataTypes]() where IsUserDefined = 0
	)
	merge into [SqlStore].[NativeDataType] as Dst 
		using Natives as Src
			on Src.TypeName = Dst.TypeName
		when not matched then insert
		(
			TypeName,
			[MaxLength],
			[Precision],
			[Scale],
			IsNullable,
			IsClrType
		)
		values
		(
			Src.TypeName,
			Src.[MaxLength],
			Src.[Precision],
			Src.[Scale],
			Src.IsNullable,
			Src.IsClrType
		)
		when matched and not exists
		(
			select 
				Src.[MaxLength],
				Src.[Precision],
				Src.[Scale],
				Src.IsNullable,
				Src.IsClrType

			intersect

			select 
				Dst.[MaxLength],
				Dst.[Precision],
				Dst.[Scale],
				Dst.IsNullable,
				Dst.IsClrType
		)
		then update set
			Dst.[MaxLength] = Src.[MaxLength],
			Dst.[Precision] = Src.[Precision],
			Dst.[Scale] = Src.[Scale],
			Dst.IsNullable = Dst.IsNullable,
			Dst.IsClrType = Dst.IsClrType,
			Dst.UpdateTS = getdate();

	
	
