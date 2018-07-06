create type [SqlT].[TableQueryColumn] as table
(
	QueryName nvarchar(250) not null,
	ColumnName sysname,
	ColumnPosition int not null,
	ColumnAlias nvarchar(128) null

)
