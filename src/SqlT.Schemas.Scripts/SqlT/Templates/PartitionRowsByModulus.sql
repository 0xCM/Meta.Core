create function [$(SchemaName)].[PartitionRowsByModulus](@Divisor bigint) returns table as return
	with R as
	(	
		select
			[$(ColumnName)],
			RowId = row_number() over(order by [$(ColumnName)])
		from [JH].[ConformedEvent]
	)
	select 
		R.* 
	from 
		R 
	where 
		[$(ColumnName)] % @Divisor = 0
