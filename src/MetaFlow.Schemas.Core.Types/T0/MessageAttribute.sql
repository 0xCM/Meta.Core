create type [T0].[MessageAttribute] as table
(
	SystemId nvarchar(75) not null,
	SchemaName nvarchar(128) not null,
	TypeName nvarchar(128) not null,
	ColumnName nvarchar(128) not null,
	ColumnPosition int not null,
	DataTypeName nvarchar(128) not null,
	IsNullable bit not null,
	[Length] int null,
	[Precision] tinyint null,
	Scale tinyint null,
	[Description] nvarchar(250) null
)
	
GO
