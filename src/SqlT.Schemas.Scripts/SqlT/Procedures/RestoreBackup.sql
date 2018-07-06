create procedure [SqlT].[RestoreBackup](@BackupName nvarchar(128), @BackupFolder nvarchar(500), @DataFolder nvarchar(500)) as

	declare @BackupFile varchar(250) = concat(@BackupFolder, @BackupName, '.bak')
	declare @DataFile varchar(50) = concat(@DataFolder, @BackupName, '.mdf')
	declare @LogFile varchar(50) = concat(@DataFolder, @BackupName, '.ldf')
	declare @BackupDescription [SqlT].[BackupDescription]

	declare @Sql varchar(500) = 'RESTORE FILELISTONLY FROM DISK = ''' + @BackupFile + ''''
	insert into @BackupDescription
		exec(@Sql)

	declare @OldDataFile nvarchar(500) = (select LogicalName from @BackupDescription where [Type] = 'D')
	declare @OldLogFile nvarchar(500) = (select LogicalName from @BackupDescription where [Type] = 'L')

	declare @RestoreDbName sysname = @BackupName

	restore database @RestoreDbName from disk = @BackupFile
	with 
		move @OldDataFile to @DataFile, 
		move @OldLogFile to @LogFile,
		stats = 5

