create function [SqlT].[DescribeTableColumns]() returns table as return
	select
		RowId = row_number() over(order by db_name(), s.[name], t.[name], c.column_id),
		CatalogName = db_name(),
		SchemaName = s.[name],
		TableName = t.[name],
		ColumnName = c.[name],
		[Description] = cast(xpt.[value] as nvarchar(250))
	from 
		sys.columns c   
		inner join sys.tables t on 
			t.[object_id] =c.[object_id]
		inner join sys.schemas s on
			s.[schema_id] = t.[schema_id]
		left join sys.extended_properties xpt on 
			xpt.major_id = t.[object_id]
		and xpt.minor_id = c.[column_id]
	where 
		xpt.[name] = 'MS_Description'
