create type [SqlT].[DefaultFilePath] as table
(
	DefaultBackupPath nvarchar(500) not null,
	DefaultDataPath nvarchar(500) not null,
	DefaultLogPath nvarchar(500) not null
)
go
