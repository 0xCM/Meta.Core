create function [dbo].[DescribeSchemaIndexes](@SchemaName sysname) returns table as return
select 
	row_number() over(order by s.name, t.name, i.name) as RowId,
	s.name as SchemaName, 
	t.name as TableName,
	i.name as IndexName,
	IsEnabled = case i.is_disabled 
					when 1 then 0 else 1 end,
	i.type_desc as IndexType,
	i.is_unique as IsUnique
		from sys.indexes i 
			inner join sys.tables t 
				on t.object_id = i.object_id 
			inner join sys.schemas s 
				on s.schema_id = t.schema_id
where s.name 
	= @SchemaName
