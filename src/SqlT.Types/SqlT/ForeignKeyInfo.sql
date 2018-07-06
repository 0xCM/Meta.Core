create type [SqlT].[ForeignKeyInfo] as table
(
	ServerName nvarchar(128) not null,
	DatabaseName nvarchar(128) not null,
	ForeignKeySchema nvarchar(128) not null,
	ForeignKeyName nvarchar(128) not null,
	ClientTableSchema nvarchar(128) not null,
	ClientTableName nvarchar(128) not null,
	SupplierTableSchema nvarchar(128) not null,
	SupplierTableName nvarchar(128) not null,	
	KeyColumnId int not null,
	ClientColumnName nvarchar(128) not null,
	ClientColummnId int not null,
	SupplierColumnName nvarchar(128) not null,
	SupplierColumnId int not null,
	Documentation nvarchar(250) null
)
