create type [SqlT].[TableDescription] as table
(
	ServerName nvarchar(128) not null,
	DatabaseName nvarchar(128) not null,
	SchemaName nvarchar(128) not null,
	TableName nvarchar(128) not null,
	FileGroupName nvarchar(128) null,
	Documentation nvarchar(250) null
)
