create type [T0].[TinyTypeTableRow] as table
(
	TypeCode tinyint not null,
	Identifier nvarchar(75) not null,
	Label nvarchar(75) not null,
	[Description] nvarchar(250) null
)
GO
create type [T0].[MediumTypeTableRow] as table
(
	TypeCode smallint not null,
	Identifier nvarchar(75) not null,
	Label nvarchar(75) not null,
	[Description] nvarchar(250) null
)
GO
create type [T0].[LargeTypeTableRow] as table
(
	TypeCode int not null,
	Identifier nvarchar(75) not null,
	Label nvarchar(75) not null,
	[Description] nvarchar(250) null
)

