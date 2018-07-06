create type [SqlT].[TinyTypeTable] as table
(
	TypeCode tinyint NOT NULL,
	Identifier nvarchar(75) not null,
	Label nvarchar(75) null,
	[Description] nvarchar(250) null
)
GO
