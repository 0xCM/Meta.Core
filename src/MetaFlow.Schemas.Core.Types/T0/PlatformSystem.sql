create type [T0].[PlatformSystem] as table
(
	TypeCode tinyint not null,
	Identifier nvarchar(75) not null,
	Label nvarchar(75) not null,
	[Description] nvarchar(250) null
)
