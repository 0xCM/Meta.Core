create table [SqlStore].[Database]
(
	StoreKey int not null
		constraint DF_Database_StoreKey 
			default(next value for [SqlStore].[StoreKeySequence]),
	ServerName nvarchar(128) not null,
	DatabaseName nvarchar(128) not null,
	DatabaseType nvarchar(128) not null,
	CreateTS datetime2(0) not null
		constraint DF_Database_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,

	constraint PK_Database primary key(StoreKey),
	constraint UQ_Database unique(ServerName,DatabaseName),

)
	
