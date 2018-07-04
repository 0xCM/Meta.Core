	with R as
	(	
		select
			[$(KeyColumn)],
			RowNumber = row_number() over(order by [$(KeyColumn)])
		from [$(TableSchema)].[$(TableName)]
	),
	P as
	(
		select 
			RowId = R.[$(KeyColumn)],
			R.RowNumber
		from 
			R 
		where 
			R.RowNumber % @RowCount = 0
	)
	select 
		RowPartition = row_number() over(order by RowId),
		RowId,
		RowNumber
	from
		P
