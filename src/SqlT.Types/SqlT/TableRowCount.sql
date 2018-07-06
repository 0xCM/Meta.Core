create type [SqlT].[TableRowCount] as table
(
	ServerName nvarchar(128) not null,
	DatabaseName nvarchar(128) not null,
	TableSchema nvarchar(128) not null,
	TableName nvarchar(128) not null,
	RowCountValue int not null
)
go
