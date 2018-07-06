create type [SqlDocs].[MarkdownFileInfo] as table
(
	SegmentName nvarchar(75) not null,
	DocumentTitle nvarchar(250) not null,
	FileLocation nvarchar(500) not null,
	ModifiedDate date null,
	FileSize bigint not null
	
)
	
