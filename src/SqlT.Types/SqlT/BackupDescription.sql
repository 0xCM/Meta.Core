--See: https://docs.microsoft.com/en-us/sql/t-sql/statements/restore-statements-filelistonly-transact-sql
create type [SqlT].[BackupDescription] as table
(
	LogicalName nvarchar(128) not null,
	PhysicalName nvarchar(260) not null,
	[Type] char not null,
	FileGroupName nvarchar(128) null,
	Size numeric(20,0) not null,
	MaxSize numeric(20,0) not null,
	FileId bigint not null,
	CreateLSN numeric(25,0) not null,
	DropLSN numeric(25,0)  null,
	UniqueId uniqueidentifier not null,
	ReadOnlyLSN numeric(25,0) null,
	ReadWriteLSN numeric(25,0) null,
	BackupSizeInBytes bigint not null,
	SourceBlockSize bigint not null,
	FileGroupId int not null,
	LogGroupGUID uniqueidentifier null,
	DifferentialBaseLSN numeric(25,0) null,
	DifferentialBaseGUID uniqueidentifier null,
	IsReadOnly bit not null,
	IsPresent bit not null,
	TDEThumbprint varbinary(32) null,
	SnapshotURL	nvarchar(360) null
)
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Specifies the shape of the result set returned when executing RESTORE with the filelistonly option',
    @level0type = N'SCHEMA',
    @level0name = N'SqlT',
    @level1type = N'Type',
    @level1name = N'BackupDescription'
GO
