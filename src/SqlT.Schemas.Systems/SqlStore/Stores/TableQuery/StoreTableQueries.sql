create procedure [SqlT].[StoreTableQueries]
(
	@Tables [SqlT].[TableQuery] readonly,
	@Columns [SqlT].[TableQueryColumn] readonly,
	@Comparisons [SqlT].[ColumnComparison] readonly
) as

	set nocount, xact_abort on

	begin transaction

		declare @InsertedQueries as table(QueryId int, QueryName nvarchar(250));
		
		insert [SqlStore].[TableQuery]
		(
			QueryName,
			TableCatalog,
			TableSchema,
			TableName,
			TableAlias	
		)
		output
			inserted.QueryId,
			inserted.QueryName
		into
			@InsertedQueries
		select 			
			QueryName,
			TableCatalog,
			TableSchema,
			TableName,
			TableAlias	
		 from
			@Tables;

			
		declare @InsertedColumns as table(QueryId int, ColumnId int, ColumnName sysname);

		with NewColumns as
		(
			select 
				q.QueryId,
				c.QueryName,
				c.ColumnPosition, 
				c.ColumnName, 
				c.ColumnAlias 
			from @Columns c inner join 
				@InsertedQueries q on q.QueryName = c.QueryName

		)
		insert [SqlStore].[TableQueryColumn]
		(
			QueryId,
			ColumnPosition,
			ColumnName,
			ColumnAlias 
		)
		output
			inserted.QueryId,
			inserted.StoreKey,
			inserted.ColumnName
		into
			@InsertedColumns
		select 
			n.QueryId,
			n.ColumnPosition, 
			n.ColumnName, 
			n.ColumnAlias 
		from 
			NewColumns n;

	
		with NewComparisons as
		(
			select 				
				q.QueryName,
				c.ColumnId,
				cc.ColumnName,
				cc.ComparisonPosition,
				cc.ComparisonOperator,
				cc.Junction,
				cc.OperandValue,
				cc.OperandDataType
			from 
				@Comparisons cc inner join 
					@InsertedQueries q on 
						q.QueryName = cc.QueryName

					inner join @InsertedColumns c on 
						c.ColumnName = cc.ColumnName
					and c.QueryId = q.QueryId
		)
		insert [SqlStore].[ColumnComparision]
		(
			ColumnId,
			ComparisonPosition,
			Junction,
			ComparisonOp,
			Operand
		 
		)
		select 
			n.ColumnId,
			n.ComparisonPosition, 
			n.Junction, 
			n.ComparisonOperator,
			[SqlT].[TextToVariant](n.OperandDataType, n.OperandValue)
		from 
			NewComparisons n 
	
	commit transaction

GO

