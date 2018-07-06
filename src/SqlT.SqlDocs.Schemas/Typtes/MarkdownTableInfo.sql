create type [SqlDocs].[MarkdownTableInfo] as table
(
	SegmentName nvarchar(75) not null,
	DocumentTitle nvarchar(250) not null,
	TablePosition int not null,
	[RowCount] int not null,
	ColumnCount int not null
)

	
