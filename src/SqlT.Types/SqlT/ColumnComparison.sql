create type [SqlT].[ColumnComparison] as table
(
	QueryName nvarchar(250) not null,
	ColumnName nvarchar(128) not null,
	ComparisonPosition int not null,
	Junction nvarchar(5),
	ComparisonOperator nvarchar(5) not null,
	OperandValue nvarchar(250) not null,
	OperandDataType sysname
)
