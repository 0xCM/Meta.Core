create type [SqlT].[ForeignKey] as table
(
	ServerName sysname,
	DatabaseName sysname,
	ForeignKeySchema sysname,
	ForeignKeyName sysname,
	ClientTableSchema sysname,
	ClientTableName sysname,
	SupplierTableSchema sysname,
	SupplierTableName sysname,
	Documentation nvarchar(250) null
)

GO
