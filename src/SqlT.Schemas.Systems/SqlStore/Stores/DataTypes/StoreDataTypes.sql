create procedure [SqlT].[StoreDataTypeDescriptions](@Descriptions [SqlT].[DataTypeDescription] readonly) as

		merge into [SqlStore].[DataType] as Dst 
		using @Descriptions as Src		
			on Src.ServerName = Dst.ServerName
			and Src.DatabaseName = Dst.DatabaseName
			and Src.SchemaName = Dst.SchemaName
			and Src.TypeName = Dst.TypeName
		when not matched then insert
		(
			ServerName,
			DatabaseName,
			SchemaName,
			TypeName,
			IsUserDefined,
			[MaxLength],
			[Precision],
			[Scale],
			IsNullable,
			IsClrType
		)
		values
		(
			Src.ServerName,
			Src.DatabaseName,
			Src.SchemaName,
			Src.TypeName,
			Src.IsUserDefined,
			Src.[MaxLength],
			Src.[Precision],
			Src.[Scale],
			Src.IsNullable,
			Src.IsClrType
		)
		when matched and not exists
		(
			select 
				Src.IsUserDefined,
				Src.[MaxLength],
				Src.[Precision],
				Src.[Scale],
				Src.IsNullable,
				Src.IsClrType

			intersect

			select 
				Dst.IsUserDefined,
				Dst.[MaxLength],
				Dst.[Precision],
				Dst.[Scale],
				Dst.IsNullable,
				Dst.IsClrType
		)
		then update set
			Dst.IsUserDefined = Src.IsUserDefined,
			Dst.[MaxLength] = Src.[MaxLength],
			Dst.[Precision] = Src.[Precision],
			Dst.[Scale] = Src.[Scale],
			Dst.IsNullable = Dst.IsNullable,
			Dst.IsClrType = Dst.IsClrType,
			Dst.UpdateTS = getdate();


	
	
	
