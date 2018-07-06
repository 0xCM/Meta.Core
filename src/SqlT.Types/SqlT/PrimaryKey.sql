create type [SqlT].[PrimaryKey] as table
(
	DatabaseName sysname,
	DatabaseVersion nvarchar(25) not null,
	TableSchemaName sysname,
	TableName sysname,
	PrimaryKeyName sysname,
	IsClustered bit not null,
	Documentation nvarchar(250) null
)



