create table [SqlStore].[TableColumn]
(
	StoreKey int not null 
		constraint DF_TableColumn_StoreKey 
			default(next value for [SqlStore].[StoreKeySequence]),

	ServerName nvarchar(128) null,
	DatabaseName nvarchar(128) null,
	SchemaName nvarchar(128)not null,	
	TableName nvarchar(128) not null,
	ColumnName nvarchar(128) not null,
	ColumnId int not null,
	ColumnPosition int not null,
	DataTypeName nvarchar(128) not null,
	IsNullable bit not null,
	IsIdentity bit not null,
	[Length] int null,
	[Precision] tinyint null,
	Scale tinyint null,
	ComputationExpression nvarchar(250) null,
	ComputationPersisted bit null,
	ColumnRole nvarchar(75) null,
	Documentation nvarchar(250) null,
	CreateTS datetime2(0) not null
		constraint DF_TableColumn_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,


	constraint PK_TableColumn primary key(StoreKey),	
	constraint UQ_TableColumn unique(TableName, ColumnName),
	constraint FK_TableColumn_Table foreign key(ServerName, DatabaseName, SchemaName, TableName)
		references [SqlStore].[Table](ServerName, DatabaseName, SchemaName, TableName)
	
	


)

GO


