create type [Factory].[RestoreDatabase] as table
(
	DatabaseName nvarchar(128) not null,
	SourceFilePath nvarchar(250) null,
	[NoUnload] bit null,
	[Replace] bit null,
	[Stats] int null
)

	
