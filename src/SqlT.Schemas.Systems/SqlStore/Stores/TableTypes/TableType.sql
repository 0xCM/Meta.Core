create table [SqlStore].[TableType]
(
	StoreKey int not null
		constraint DF_TableType_StoreKey default(next value for [SqlStore].[StoreKeySequence]),
	ServerName nvarchar(128) not null,
	DatabaseName nvarchar(128) not null,
	SchemaName nvarchar(128) not null,
	ObjectName nvarchar(128) not null,

	constraint PK_TableType primary key(StoreKey),
	
)
GO
