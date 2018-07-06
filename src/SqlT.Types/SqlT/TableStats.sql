create type [SqlT].[TableStats] as table
(
	ServerName sysname,
	DatabaseName sysname,
	TableSchema sysname,
	TableName sysname,
	ColumnCount int not null,
	[RowCount] int not null,
	DataStorage decimal(19,3) not null,
	IndexStorage decimal(19,3) not null,
	TableStorage decimal(19,3) not null
)