create type [SqlT].[FileTableDescription] as table
(
	ServerName nvarchar(128) not null,
	DatabaseName nvarchar(128) not null,
	TableSchema nvarchar(128) not null,
	TableName nvarchar(128) not null,
	UncParentPath nvarchar(512),
	DirectoryName nvarchar(128)
)