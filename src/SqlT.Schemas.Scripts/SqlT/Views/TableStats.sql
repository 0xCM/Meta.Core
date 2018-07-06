create view [SqlT].[TableStatsView] as
--Parts adapted from: http://stackoverflow.com/questions/7892334/get-size-of-all-tables-in-database
	with RowCounts as
	(
		select 
			coalesce(serverproperty('InstanceName'),  serverproperty('ComputerNamePhysicalNetBIOS')) as ServerName,
			db_name() as CatalogName,
			schema_name(t.schema_id) as SchemaName,
			t.name AS TableName, 
			i.[rows] as TableRowCount
		from 
			sys.tables t 	
			inner join  sys.sysindexes i 
				on t.[object_id] = i.id and i.indid < 2 			
	),
	X as 
	(
		select
			sc.name as SchemaName,
			t.name as TableName,			
			used_pages_count =	sum (s.used_page_count),			
			pages =	sum (case when (i.index_id < 2) 
					then (in_row_data_page_count + lob_used_page_count + row_overflow_used_page_count)
					else lob_used_page_count + row_overflow_used_page_count end) 
			
		from 
			sys.dm_db_partition_stats s 				
			join sys.tables t 
				on s.[object_id] = t.[object_id]	
			join sys.schemas AS sc 
				on sc.schema_id = t.schema_id				
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
			coalesce(serverproperty('InstanceName'),  serverproperty('ComputerNamePhysicalNetBIOS')) as ServerName,
			db_name() as CatalogName,
			x.SchemaName,
			x.TableName, 
			c.TableRowCount as RecordCount,
			cast((x.pages * 8.)/1024 as decimal(10,3)) as DataStorage, 
			cast(((CASE WHEN x.used_pages_count > x.pages 
						THEN x.used_pages_count - x.pages
						ELSE 0 
					END) * 8./1024) as decimal(10,3)) as IndexStorage
		from 
			X x inner join 
				RowCounts c 
					on c.SchemaName = x.SchemaName 
				and c.TableName = x.TableName
	),
	Z as
	(
		select 
			y.SchemaName,
			y.TableName,
			count(*) as [Columns]
		from
			Y y
			inner join sys.tables t on t.name = y.TableName and t.schema_id = schema_id(y.SchemaName)
			inner join sys.columns c on c.object_id = t.object_id
		group by
			y.SchemaName,
			y.TableName
	)
	select 
		y.ServerName,
		y.CatalogName,
		y.SchemaName,
		y.TableName,
		y.RecordCount,
		[DataStorage (MB)] = y.DataStorage,
		[IndexStorage (MB)] = y.IndexStorage,			
		[Total Storage (MB)] =	y.DataStorage + y.IndexStorage					
	from 
		Y y inner join Z z 
			on z.SchemaName = y.SchemaName 
		and z.TableName = y.TableName
	where 
		y.RecordCount <> 0


GO


