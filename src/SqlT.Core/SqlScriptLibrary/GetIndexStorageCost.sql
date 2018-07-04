create function [SqlT].[GetIndexStorageCost]() returns table as return
	select 
		IndexName = i.[name],
		IndexSizeMB =(sum(s.[used_page_count]) * 8)/1024
	from sys.dm_db_partition_stats s 
			inner join sys.indexes i on 
				s.[object_id] = i.[object_id]
			and s.[index_id] = i.[index_id]
	group by 
		i.[name]
