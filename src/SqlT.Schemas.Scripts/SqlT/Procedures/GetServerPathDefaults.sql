create procedure [SqlT].[GetServerPathDefaults] as
	DECLARE @var_backup NVARCHAR(4000);

	EXEC master.dbo.xp_instance_regread 
			N'HKEY_LOCAL_MACHINE', 
			N'Software\Microsoft\MSSQLServer\MSSQLServer',N'BackupDirectory', 
			@var_backup OUTPUT,  
			'no_output' 
	select 
		@var_backup as DefaultBackupPath,
		SERVERPROPERTY('instancedefaultdatapath') AS DefaultDataPath, 
		SERVERPROPERTY('instancedefaultlogpath') AS DefaultLogPath
GO;

EXEC sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[SqlT].[DefaultFilePath]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlT',
    @level1type = N'PROCEDURE',
    @level1name = N'GetServerPathDefaults'
GO



