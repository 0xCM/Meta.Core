create type [CommandSpec].[CommandLibraryEntry] as table
(
	CommandSpecName nvarchar(150) not null,	
	CommandName nvarchar(250) not null,
	CommandJson nvarchar(max) not null
)
GO
