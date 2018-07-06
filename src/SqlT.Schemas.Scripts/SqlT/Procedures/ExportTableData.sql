create procedure [SqlT].[ExportTableData]
(
	@TableSchema sysname,	
	@TableName sysname,
	@DstFile nvarchar(500)
)
as

	declare @Query varchar(max) = 
		'"select * from [db_name()].[' + @TableSchema + '].[' + @TableName + ']"'
	declare @var_sql varchar(8000) =
		'bcp ' + @Query + ' queryout  "' + @DstFile + '" -c -T'

	exec xp_cmdshell @var_sql

