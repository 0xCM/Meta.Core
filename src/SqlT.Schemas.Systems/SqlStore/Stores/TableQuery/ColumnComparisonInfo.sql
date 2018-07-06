create view [SqlStore].[ColumnComparisionInfo] as
	select 
		ci.QueryId, 
		ci.QueryName,   
		ci.TableCatalog, 
		ci.TableSchema, 
		ci.TableName, 
		ci.TableAlias,
		ci.StoreKey, 
		ci.ColumnName, 
		ci.ColumnPosition, 
		ci.ColumnAlias,
		cf.ComparisonId,
		cf.Operand,
		cf.ComparisonOp
		
	from 
		[SqlStore].[ColumnComparision] cf inner join 
			[SqlStore].[TableQueryColumnInfo] ci on 
				ci.StoreKey = cf.ColumnId
