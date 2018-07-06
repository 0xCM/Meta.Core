create type [SqlT].[TypeTable] as table
(
	Identifier nvarchar(75) not null,
	Label nvarchar(75) null,
	[Description] nvarchar(250) null
)
GO