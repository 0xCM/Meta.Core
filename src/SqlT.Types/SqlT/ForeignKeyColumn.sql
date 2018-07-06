create type [SqlT].[ForeignKeyColumn] as table
(
	ServerName sysname,
	DatabaseName sysname,
	ForeignKeySchema sysname,
	ForeignKeyName sysname,
	ClientTableSchema sysname,
	ClientTableName sysname,
	SupplierTableSchema sysname,
	SupplierTableName sysname,	
	KeyColumnId int not null,
	ClientColumnName sysname,
	ClientColummnId int not null,
	SupplierColumnName sysname,
	SupplierColumnId int not null
)