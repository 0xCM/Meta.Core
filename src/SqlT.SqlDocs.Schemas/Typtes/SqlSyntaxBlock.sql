create type [SqlDocs].[SqlSyntaxBlock] as table
(
	SegmentName nvarchar(75) not null,
	DocumentTitle nvarchar(250) not null,
	SyntaxPosition int not null,
	SyntaxContent nvarchar(max) not null
)
	
