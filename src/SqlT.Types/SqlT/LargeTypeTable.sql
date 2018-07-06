create type [SqlT].[LargeTypeTable] as table
(
	TypeCode int not null,
	Identifier nvarchar(75) not null,
	Label nvarchar(75) null,
	Description nvarchar(250) null
)
GO