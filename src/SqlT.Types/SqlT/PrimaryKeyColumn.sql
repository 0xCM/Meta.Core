create type [SqlT].[PrimaryKeyColumn] as table
(
	DatabaseName sysname,
	DatabaseVersion nvarchar(25) not null,
	PrimaryKeySchema sysname,
	PrimaryKeyName sysname,
	ColumnName sysname,
	KeyColumnPosition int not null

)