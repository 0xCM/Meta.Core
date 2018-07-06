--Do: select * from sys.master_files to get the list of files
ALTER DATABASE [$(OldDatabaseName)] 
	SET OFFLINE WITH ROLLBACK IMMEDIATE

alter database [$(OldDatabaseName)] set online

alter database [$(OldDatabaseName)]
	modify name = [$(NewDatabaseName)]

alter database [$(NewDatabaseName)]
	modify file(name = [$(LogicalDataFileName)], filename = '$(NewDataFilePath)')

alter database [$(NewDatabaseName)]
	modify file(name = [$(LogicalLogFileName)], filename = '$(NewLogFilePath)')

ALTER DATABASE [$(NewDatabaseName)] 
	set offline with rollback immediate

--TODO: Rename phsycial files

alter database [$(NewDatabaseName)] set online

