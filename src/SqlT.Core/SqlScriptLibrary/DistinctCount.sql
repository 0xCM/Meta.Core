select 
	'$(ObjectSchema)' as ObjectSchema,
	'$(ObjectName)' as ObjectName,
	'$(ColumnName)' as ColumnName,
	count(distinct([$(ColumnName)])) as DistinctCount
from 
	[$(ObjectSchema)].[$(ObjectName)]

	