create type [SqlT].[ColumnFacet] as table
(
	ServerName nvarchar(128) not null,
	DatabaseName nvarchar(128) not null,
	SchemaName nvarchar(128) not null,
	TableName nvarchar(128) not null,
	ColumnName nvarchar(128) not null
)
	
	
