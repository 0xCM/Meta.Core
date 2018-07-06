create function [SqlT].[GetObjectDefinitions]() returns table as return
	select 
		schema_name(o.[schema_id]) as [schema_name],
		o.name, 
		o.[type], 
		o.type_desc, 
		m.[definition]
	from 
		sys.sql_modules m inner join sys.objects o 
			on o.[object_id] = m.[object_id]
