create type [SqlDocs].[MarkdownHelpKeyword] as table
(
	SegmentName nvarchar(75) not null,
	DocumentTitle nvarchar(250) not null,
	Keyword nvarchar(75) not null
)
	
