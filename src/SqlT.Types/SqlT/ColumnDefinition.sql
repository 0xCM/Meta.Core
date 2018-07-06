create type [SqlT].[ColumnDefinition] as table
(
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
	[Description] nvarchar(250) null
	
)

	
