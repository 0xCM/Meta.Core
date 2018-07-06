create function [SqlT].[DescribeFileTables]() returns table as return
	select 	
		ServerName = @@SERVERNAME collate database_default,
		DatabaseName = db_name() collate database_default,
		TableSchema =  schema_name(T.[schema_id]) collate database_default,
		TableName = object_name(T.[object_id]) collate database_default,
		UncParentPath = FILETABLEROOTPATH() collate database_default,
		DirectoryName = F.directory_name collate database_default
	 from 
		sys.tables T  
			inner join sys.filetables F on 
				F.[object_id] = T.[object_id]
	where 
		T.is_filetable = 1
GO
EXEC sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[SqlT].[FileTableDescription]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlT',
    @level1type = N'Function',
    @level1name = N'DescribeFileTables'
GO







