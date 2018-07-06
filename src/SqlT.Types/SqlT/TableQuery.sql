create type [SqlT].[TableQuery] as table
(
	QueryName nvarchar(250) not null,
	TableCatalog sysname,
	TableSchema sysname,
	TableName sysname,
	TableAlias nvarchar(128) null
)	