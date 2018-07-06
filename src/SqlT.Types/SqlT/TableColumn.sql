create type [SqlT].[TableColumn] as table
(
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
	Documentation nvarchar(250) null


)
