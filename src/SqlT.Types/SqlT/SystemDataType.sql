create type [SqlT].[SystemDataType] as table
(
	DbName sysname,
	DbVersion nvarchar(25) not null,
	TypeName sysname,
	Documentation nvarchar(250) null,
	[Length] int null,
	[MaxLength] int null,
	[Precision] tinyint null,
	[MaxPrecision] tinyint null,
	[Scale] tinyint null,
	[MaxScale] tinyint null,
	IsNullable bit not null
)
GO
