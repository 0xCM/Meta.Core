create type [E0].[BackupDescriptionCaptured] as table
(
	HostId nvarchar(75) not null,
	HostBackupPath nvarchar(500) not null,
	LogicalFileName nvarchar(128) not null,
	BackupFileType char(1) not null


)
	
