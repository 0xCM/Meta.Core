create function [SqlT].[GenerateColumnDropSql](@ColumnName sysname) returns table as return
select 
	'alter table '  
	+ OBJECT_SCHEMA_NAME([object_id]) + '.' + OBJECT_NAME([object_id]) 
	+' drop column ' + name 
	as SqlScript
from sys.columns where name = @ColumnName