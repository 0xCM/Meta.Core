create table [SqlStore].[ForeignKey]
(
	StoreKey int not null 
		constraint DF_ForeignKey_StoreKey 
			default(next value for [SqlStore].[StoreKeySequence]),
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
	Documentation nvarchar(250) null,
	CreateTS datetime2(0) not null 
		constraint DF_ForeignKey_CreateTS default(getdate()),
	
	constraint PK_ForeignKey primary key(StoreKey),
	constraint UQ_ForeignKey unique(ServerName, DatabaseName, ForeignKeySchema, ForeignKeyName)

)
GO
