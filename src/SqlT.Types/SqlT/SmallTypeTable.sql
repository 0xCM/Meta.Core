
create type [SqlT].[SmallTypeTable] as table
(
	TypeCode smallint NOT NULL,
	Identifier nvarchar(75) not null,
	Label nvarchar(75) null,
	[Description] nvarchar(250) null
)
GO

