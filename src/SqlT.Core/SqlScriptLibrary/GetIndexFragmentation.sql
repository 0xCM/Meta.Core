create function [dbo].[GetTableIndexFragmentation](@TableSchema sysname, @TableName sysname) returns table as return
--Adapted from: http://sqlhint.com/sqlserver/how-to/tsql/find-out-index-disk-size
	select
		s.name as TableSchema,
		t.name AS TableName,
		ind.name AS IndexName, 
		indexstats.index_type_desc AS IndexType,
		indexstats.avg_fragmentation_in_percent	
	from 
		sys.dm_db_index_physical_stats(DB_ID(), OBJECT_ID(@TableSchema + '.' + @TableName), NULL, NULL, NULL) indexstats
		inner join sys.tables t on t.name = @TableName
		inner join sys.schemas s on s.schema_id = t.schema_id
		inner join sys.indexes ind  on ind.object_id = indexstats.object_id and ind.index_id = indexstats.index_id
	where 
		indexstats.avg_fragmentation_in_percent >= 0		

	GO
