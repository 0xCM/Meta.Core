create function [dbo].[GetTableStats]() returns table as return
--Parts adapted from: http://stackoverflow.com/questions/7892334/get-size-of-all-tables-in-database
	with RowCounts as
	(
		select 
			ServerName = @@servername,
			DatabaseName = db_name(),
			TableSchema = schema_name(t.[schema_id]),
			TableName = t.[name], 
			TableRowCount = i.[rows]
		from 
			sys.tables t 	
			inner join  sys.sysindexes i 
				on t.[object_id] = i.id AND i.indid < 2 			
	),
	X as 
	(
		select
			TableSchema = sc.[name],
			TableName = t.[name],
			used_pages_count =	sum (s.used_page_count),			
			pages =	sum (case when (i.index_id < 2) 
					then (in_row_data_page_count + lob_used_page_count + row_overflow_used_page_count)
					else lob_used_page_count + row_overflow_used_page_count end) 
			
		from 
			sys.dm_db_partition_stats s 				
			join sys.tables t 
				on s.[object_id] = t.[object_id]	
			join sys.schemas AS sc 
				on sc.[schema_id] = t.[schema_id]				
			join sys.indexes AS i 
				on i.[object_id] = t.[object_id] and s.index_id = i.index_id
		where	
			t.name <> '__RefactorLog'
		group by 
			sc.name,
			t.name
	),
	Y as
	(
		select
			@@servername as ServerName,
			db_name() as DatabaseName,
			x.TableSchema,
			x.TableName, 
			c.TableRowCount as [Rows],
			cast((x.pages * 8.)/1024 as decimal(10,3)) as DataStorage, 
			cast(((CASE WHEN x.used_pages_count > x.pages 
						THEN x.used_pages_count - x.pages
						ELSE 0 
					END) * 8./1024) as decimal(10,3)) as IndexStorage
		from 
			X x inner join 
				RowCounts c 
					on c.TableSchema = x.TableSchema 
				and c.TableName = x.TableName
	),
	Z as
	(
		select 
			y.TableSchema,
			y.TableName,
			count(*) as [Columns]
		from
			Y y
			inner join sys.tables t on 
				t.name = y.TableName 
			and t.[schema_id] = [schema_id]
			inner join sys.columns c on 
				c.object_id = t.object_id
		group by
			y.TableSchema,
			y.TableName
	)
	select 
		y.ServerName,
		y.DatabaseName,
		y.TableSchema,
		y.TableName,
		z.[Columns],
		y.[Rows],
		y.DataStorage,
		y.IndexStorage,			
		TableStorage = y.DataStorage + y.IndexStorage
				
	from 
		Y y inner join Z z on 
			z.TableSchema = y.TableSchema 
		and z.TableName = y.TableName

GO
EXEC sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[dbo].[TableStats]',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'FUNCTION',
    @level1name = N'GetTableStats'
GO



