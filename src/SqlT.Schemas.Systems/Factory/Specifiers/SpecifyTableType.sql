create procedure [Factory].[SpecifyTableType](@TableType [Factory].[TableType] readonly, @Columns [SqlT].[ColumnDefinition] readonly) as

	begin transaction

		declare @Identifier nvarchar(75) = (select top(1) Identifier from @TableType);
		insert [Factory].[TableType]
		(
			Identifier,
			SchemaName,
			TypeName,
			[Description]
		)
		select top(1)
			Identifier,
			SchemaName,
			TypeName,
			[Description]
		from 
			@TableType;


		insert [Factory].[TypeColumn]
		(
			 TableTypeIdentifier,
			 ColumnName,
			 ColumnPosition,
			 DataTypeName,
			 IsNullable,
			 [Length],
			 [Precision],
			 [Scale],
			 [Description]
		)
		select 
			 @Identifier,
			 ColumnName,
			 ColumnPosition,
			 DataTypeName,
			 IsNullable,
			 [Length],
			 [Precision],
			 [Scale],
			 [Description]
		from
			@Columns
	
	commit transaction
