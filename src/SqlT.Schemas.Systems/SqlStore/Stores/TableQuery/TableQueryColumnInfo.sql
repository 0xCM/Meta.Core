create view [SqlStore].[TableQueryColumnInfo] as
	select
		q.QueryId,
		q.QueryName,
		q.TableCatalog,
		q.TableSchema,
		q.TableName,
		q.TableAlias,
		c.StoreKey,
		c.ColumnName,
		c.ColumnPosition,
		c.ColumnAlias
	from 
		[SqlStore].[TableQueryColumn] c inner join
			[SqlStore].[TableQuery] q on c.QueryId = c.QueryId

