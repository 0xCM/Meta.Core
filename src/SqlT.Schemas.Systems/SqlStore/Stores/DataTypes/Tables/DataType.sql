create table [SqlStore].[DataType]
(
	StoreKey int not null
		constraint DF_DataType_StoreKey 
			default(next value for [SqlStore].[StoreKeySequence]),		
	
	ServerName nvarchar(128) null,
	DatabaseName nvarchar(128) null,
	SchemaName nvarchar(128)not null,
	TypeName nvarchar(128) not null,
	IsUserDefined bit not null,
	[MaxLength] smallint not null,
	[Precision] tinyint not null,
	[Scale] tinyint not null,
	IsNullable bit NULL,
	IsClrType bit not null,
	CreateTS datetime2(0) not null
		constraint DF_DataType_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,
	constraint PK_DataType primary key(StoreKey),
	constraint UQ_DataType unique(ServerName,DatabaseName, SchemaName,TypeName)

) 
