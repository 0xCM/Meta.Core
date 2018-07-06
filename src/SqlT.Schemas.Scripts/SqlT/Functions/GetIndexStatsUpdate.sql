create function [SqlT].[GetIndexStatsUpdate]() returns table as return
	select 
		s.name as schema_name,
		t.name as table_name,
		ix.name AS index_name,   
		stats_date(ix.object_id, ix.index_id) AS stats_updated
	FROM 
		sys.indexes ix 
		inner join sys.tables t on t.object_id = ix.object_id
		inner join sys.schemas s on s.schema_id = t.schema_id

GO
