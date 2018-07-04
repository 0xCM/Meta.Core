create function [SqlT].[GetRowCounts]() returns table as return
	select 
		@@servername as ServerName,
		db_name() as CatalogName,
		schema_name(t.schema_id) as SchemaName,
		t.name AS TableName, 
		i.[rows] as TableRowCount
	from 
		sys.tables t 	
		inner join  sys.sysindexes i 
			on t.[object_id] = i.id AND i.indid < 2 			

go
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Efficient function to get the row counts of all tables in a given database without doing table scans',
    @level0type = N'SCHEMA',
    @level0name = N'SqlT',
    @level1type = N'FUNCTION',
    @level1name = N'GetRowCounts',
    @level2type = NULL,
    @level2name = NULL
GO

EXEC sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[SqlT].[TableRowCount]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlT',
    @level1type = N'FUNCTION',
    @level1name = N'GetRowCounts'
GO



