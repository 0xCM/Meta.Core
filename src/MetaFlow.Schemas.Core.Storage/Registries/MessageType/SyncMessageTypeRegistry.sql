create procedure [PF].[SyncMessageTypeRegistry](@Types [T0].[MessageTypeRegistration] readonly, @Attributes [T0].[MessageAttribute] readonly) as
	
	set nocount on
		
	begin transaction

	
		merge into [PF].[MessageTypeRegistry] as Dst
			using @Types as Src on 
				Src.SchemaName = Dst.SchemaName 
			and Src.TypeName = Dst.TypeName
		when not matched then insert
		(
			SystemId,
			SchemaName,
			TypeName,
			MessageClass,
			[Description]
		)
		values
		(
			Src.SystemId,
			Src.SchemaName,
			Src.TypeName,
			Src.MessageClass,
			Src.[Description]
		)
		when matched and not exists 
		(
			select 
				Src.SystemId,
				Src.MessageClass,
				Src.[Description]

			intersect

			select
				Dst.SystemId,
				Dst.MessageClass,
				Dst.[Description]
		)
		then update set
			Dst.SystemId = Src.SystemId,
			Dst.MessageClass = Src.MessageClass,
			Dst.[Description] = Src.[Description]
		when not matched by source then delete;


		merge into [PF].[MessageTypeAttribute] as Dst
			using @Attributes as Src on 
				Src.SchemaName = Dst.SchemaName 
			and Src.TypeName = Dst.TypeName
			and Src.ColumnName = Dst.ColumnName
		when not matched then insert
		(
			SystemId,
			SchemaName,
			TypeName,
			ColumnName,
			ColumnPosition,
			DataTypeName,
			IsNullable,
			[Length],
			[Precision],
			[Scale],
			[Description]
		)
		values
		(	Src.SystemId,
			Src.SchemaName,
			Src.TypeName,
			Src.ColumnName,
			Src.ColumnPosition,
			Src.DataTypeName,
			Src.IsNullable,
			Src.[Length],
			Src.[Precision],
			Src.[Scale],
			Src.[Description]
		)
		when matched and not exists 
		(
			select 
			Src.SystemId,
			Src.ColumnPosition,
			Src.DataTypeName,
			Src.IsNullable,
			Src.[Length],
			Src.[Precision],
			Src.[Scale],
			Src.[Description]

			intersect

			select
			Dst.SystemId,
			Dst.ColumnPosition,
			Dst.DataTypeName,
			Dst.IsNullable,
			Dst.[Length],
			Dst.[Precision],
			Dst.[Scale],
			Dst.[Description]
		)
		then update set
			Dst.SystemId = Src.SystemId,
			Dst.ColumnPosition = Src.ColumnPosition,
			Dst.DataTypeName = Src.DataTypeName,
			Dst.IsNullable = Src.IsNullable,
			Dst.[Length] = Src.[Length],
			Dst.[Precision] = Src.[Precision],
			Dst.[Scale] = Src.[Scale],
			Dst.[Description] = Src.[Description]
		when not matched by source then delete;

		exec [PF].[StubMessageFormats]

	commit transaction