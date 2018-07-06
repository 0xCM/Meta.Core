create function [SqlT].[GetRowCount](@SchemaName sysname, @TableName sysname)
	returns bigint as 
	begin
		declare @Count bigint =
		(select SUM (row_count) FROM sys.dm_db_partition_stats
			where  
			object_id=OBJECT_ID('[' + @SchemaName + '].[' + @TableName + ']') 
		and (index_id=0 or index_id=1)
		)
	return @Count;
	end
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Counts the rows in a table quickly without doing a tablescan; for more info see http://blogs.msdn.com/b/martijnh/archive/2010/07/15/sql-server-how-to-quickly-retrieve-accurate-row-count-for-table.aspx ',
    @level0type = N'SCHEMA',
    @level0name = N'SqlT',
    @level1type = N'FUNCTION',
    @level1name = N'GetRowCount',
    @level2type = NULL,
    @level2name = NULL
GO

