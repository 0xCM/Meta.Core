create type [SqlT].[ServerCollation] as table
(
	[CollationName] nvarchar(128) not null,
	[CodePage] int not null,
	[LCID] int not null,
	[ComparisonStyle] int not null,
	[Version]  int not null,
	[Description] nvarchar(250) not null
)