create table [PF].[DatabaseBackup]
	as filetable with (FileTable_Directory = 'backups')
GO

create table [PF].[DatabaseBackupArchive]
	as filetable with (FileTable_Directory = 'backups.a')
