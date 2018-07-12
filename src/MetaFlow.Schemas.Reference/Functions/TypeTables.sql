create function [RF].[TypeTables]() returns table as return
	with TypeTables as
	(
		select 
			TableSchema = object_schema_name(t.object_id),
			TableName = t.[name],
			TableRole = p.[value]		
		from 
			sys.tables t 
				inner join sys.extended_properties p on 
					p.major_id = t.[object_id] 
	where 
		p.[name] = 'SqlT_TableRole' 
	)
	select * from TypeTables


