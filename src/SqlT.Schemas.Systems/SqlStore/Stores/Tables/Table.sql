create table [SqlStore].[Table]
(
 	StoreKey int not null 
		constraint DF_Table_StoreKey 
			default(next value for [SqlStore].[StoreKeySequence]),

	ServerName nvarchar(128) null,
	DatabaseName nvarchar(128) null,
	SchemaName nvarchar(128)not null,	
	TableName nvarchar(128) not null,
	FileGroupName nvarchar(128) null,
	Documentation nvarchar(250) null,

	CreateTS datetime2(0) not null
		constraint DF_Table_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,

	constraint PK_Table primary key(StoreKey),	
	constraint UQ_Table unique(ServerName,DatabaseName, SchemaName, TableName)
)
	
