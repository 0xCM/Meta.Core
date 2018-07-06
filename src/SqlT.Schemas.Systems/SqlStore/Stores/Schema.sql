create table [SqlStore].[Schema] 
(
	StoreKey int not null 
		constraint DF_Schema_StoreKey 
			default(next value for [SqlStore].[StoreKeySequence]),
	ServerName nvarchar(128) not null,
	DatabaseName nvarchar(128) not null,
	SchemaName nvarchar(128) not null,
	Documentation nvarchar(250) null,    
	constraint PK_Schema primary key(StoreKey),
	constraint UQ_Schema unique(ServerName, DatabaseName, SchemaName)
)
GO
create sequence [SqlStore].[StoreKeySequence]
	as int start with 1 cache 10;

